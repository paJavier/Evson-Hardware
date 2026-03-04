using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public partial class SalesForm : Form
    {
        // ── State ─────────────────────────────────────────────────────
        private decimal currentTotal = 0m;
        private int stagedProductId = 0;
        private string stagedProductName = "";
        private decimal stagedPrice = 0m;
        private int stagedAvailableStock = 0;

        public SalesForm()
        {
            InitializeComponent();
            SetupCartGrid();
        }

        // ── Cart Grid Setup ───────────────────────────────────────────
        private void SetupCartGrid()
        {
            dgvCart.ColumnCount = 5;
            dgvCart.Columns[0].Name = "ID";
            dgvCart.Columns[1].Name = "Product";
            dgvCart.Columns[2].Name = "Price";
            dgvCart.Columns[3].Name = "Qty";
            dgvCart.Columns[4].Name = "Subtotal";

            // Hide ID column — needed for DB ops, not shown to user
            dgvCart.Columns[0].Visible = false;

            dgvCart.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        }

        // ── Browse / Search Products ──────────────────────────────────
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var popup = new ProductSelectionForm();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                stagedProductId = popup.SelectedProductId;
                stagedProductName = popup.SelectedProductName;
                stagedPrice = popup.SelectedPrice;
                stagedAvailableStock = popup.AvailableStock;

                lblSelectedProduct.Text = $"Selected: {stagedProductName} — ₱{stagedPrice:F2}  (Stock: {stagedAvailableStock})";

                // Cap max quantity to available stock
                numQty.Maximum = stagedAvailableStock;
                numQty.Value = 1;
            }
        }

        // ── Add to Cart ───────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (stagedProductId == 0)
            {
                MessageBox.Show("Please select a product first.", "No Product",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qtyToAdd = (int)numQty.Value;

            // ── Merge if product already exists in cart ───────────────
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells["ID"].Value) == stagedProductId)
                {
                    int existingQty = Convert.ToInt32(row.Cells["Qty"].Value);
                    int newQty = existingQty + qtyToAdd;

                    if (newQty > stagedAvailableStock)
                    {
                        MessageBox.Show(
                            $"Cannot add {qtyToAdd} more. Only {stagedAvailableStock - existingQty} unit(s) remaining.",
                            "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    decimal newSubtotal = stagedPrice * newQty;
                    currentTotal -= Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    row.Cells["Qty"].Value = newQty;
                    row.Cells["Subtotal"].Value = newSubtotal;
                    currentTotal += newSubtotal;

                    UpdateTotalLabel();
                    ResetStaging();
                    return;
                }
            }

            // ── Add as new row ────────────────────────────────────────
            decimal subtotal = stagedPrice * qtyToAdd;
            dgvCart.Rows.Add(stagedProductId, stagedProductName, stagedPrice, qtyToAdd, subtotal);
            currentTotal += subtotal;

            UpdateTotalLabel();
            ResetStaging();
        }

        // ── Remove Selected Cart Row ──────────────────────────────────
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a cart item to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCart.SelectedRows[0];
            if (row.IsNewRow) return;

            currentTotal -= Convert.ToDecimal(row.Cells["Subtotal"].Value);
            dgvCart.Rows.Remove(row);
            UpdateTotalLabel();
        }

        // ── Process Sale / Checkout ───────────────────────────────────
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.", "Nothing to Checkout",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Process sale for ₱{currentTotal:F2}?",
                "Confirm Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string receiptNum = string.IsNullOrWhiteSpace(txtReceipt.Text)
                ? "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss")
                : txtReceipt.Text.Trim();

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                // ── 1. Validate stock for every cart item ─────────────
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;
                    int prodId = Convert.ToInt32(row.Cells["ID"].Value);
                    int qtyRequested = Convert.ToInt32(row.Cells["Qty"].Value);
                    string prodName = row.Cells["Product"].Value.ToString();

                    int currentStock = GetCurrentStock(conn, transaction, prodId);
                    if (currentStock < qtyRequested)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            $"Insufficient stock for '{prodName}'.\nRequested: {qtyRequested}, Available: {currentStock}",
                            "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // ── 2. Insert Sale header ─────────────────────────────
                var cmdSale = conn.CreateCommand();
                cmdSale.Transaction = transaction;
                cmdSale.CommandText = @"
                    INSERT INTO Sale (receipt_number, sale_date, customer_name, total_amount, user_id)
                    VALUES (@receipt, @date, @customer, @total, 1);
                    SELECT last_insert_rowid();";
                cmdSale.Parameters.AddWithValue("@receipt", receiptNum);
                cmdSale.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmdSale.Parameters.AddWithValue("@customer",
                    string.IsNullOrWhiteSpace(txtCustomer.Text)
                        ? (object)DBNull.Value
                        : txtCustomer.Text.Trim());
                cmdSale.Parameters.AddWithValue("@total", currentTotal);

                long saleId = (long)cmdSale.ExecuteScalar();

                // ── 3. Insert Sale details ────────────────────────────
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cmdDetail = conn.CreateCommand();
                    cmdDetail.Transaction = transaction;
                    cmdDetail.CommandText = @"
                        INSERT INTO Sales_Details (sale_id, product_id, quantity, unit_price, subtotal)
                        VALUES (@saleId, @prodId, @qty, @price, @subtotal);";
                    cmdDetail.Parameters.AddWithValue("@saleId", saleId);
                    cmdDetail.Parameters.AddWithValue("@prodId", Convert.ToInt32(row.Cells["ID"].Value));
                    cmdDetail.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["Qty"].Value));
                    cmdDetail.Parameters.AddWithValue("@price", Convert.ToDecimal(row.Cells["Price"].Value));
                    cmdDetail.Parameters.AddWithValue("@subtotal", Convert.ToDecimal(row.Cells["Subtotal"].Value));
                    cmdDetail.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show(
                    $"✔ Sale complete!\nReceipt: {receiptNum}\nTotal: ₱{currentTotal:F2}",
                    "Sale Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing sale: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Helpers ───────────────────────────────────────────────────

        /// <summary>
        /// Real-time derived stock using only Supply and Sales tables.
        /// Add Return_Details and Adjustment_Details back when those modules are ready.
        /// </summary>
        private int GetCurrentStock(SqliteConnection conn, SqliteTransaction transaction, int productId)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = @"
                SELECT
                    COALESCE((SELECT SUM(quantity) FROM Supply_Details WHERE product_id = @id), 0)
                  - COALESCE((SELECT SUM(quantity) FROM Sales_Details  WHERE product_id = @id), 0)
                AS Stock;";
            cmd.Parameters.AddWithValue("@id", productId);
            var result = cmd.ExecuteScalar();
            return result == DBNull.Value || result == null ? 0 : Convert.ToInt32(result);
        }

        private void UpdateTotalLabel()
        {
            lblTotal.Text = $"Total: ₱{currentTotal:F2}";
        }

        private void ResetStaging()
        {
            stagedProductId = 0;
            stagedProductName = "";
            stagedPrice = 0m;
            stagedAvailableStock = 0;
            numQty.Value = 1;
            numQty.Maximum = 9999;
            lblSelectedProduct.Text = "Selected: None";
        }

        private void ClearCart()
        {
            dgvCart.Rows.Clear();
            currentTotal = 0m;
            UpdateTotalLabel();
            txtCustomer.Clear();
            txtReceipt.Clear();
            ResetStaging();
        }
    }
}