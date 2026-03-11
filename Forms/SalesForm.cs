using EvsonHardware.Data;
using EvsonHardware.Forms;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EvsonHardware
{
    public partial class SalesForm : Form
    {
        private decimal currentTotal = 0m;
        private int stagedProductId = 0;
        private string stagedProductName = "";
        private decimal stagedPrice = 0m;
        private int stagedAvailableStock = 0;
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");

        public SalesForm()
        {
            InitializeComponent();
            ApplyCurrencyFonts();
            SetupCartGrid();
        }

        private void ApplyCurrencyFonts()
        {
            var pesoFont = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Font = pesoFont;
            lblSelectedProduct.Font = pesoFont;
        }

        private void SetupCartGrid()
        {
            dgvCart.ColumnCount = 5;
            dgvCart.Columns[0].Name = "ID";
            dgvCart.Columns[1].Name = "Product";
            dgvCart.Columns[2].Name = "Price";
            dgvCart.Columns[3].Name = "Qty";
            dgvCart.Columns[4].Name = "Subtotal";
            dgvCart.Columns[0].Visible = false;
            dgvCart.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.BackgroundColor = Color.Ivory;
            dgvCart.BorderStyle = BorderStyle.FixedSingle;
            dgvCart.GridColor = Color.FromArgb(214, 223, 118);

            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCart.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvCart.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvCart.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvCart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);
            dgvCart.RowHeadersVisible = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var popup = new ProductSelectionForm();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                stagedProductId = popup.SelectedProductId;
                stagedProductName = popup.SelectedProductName;
                stagedPrice = popup.SelectedPrice;
                stagedAvailableStock = popup.AvailableStock;

                lblSelectedProduct.Text = $"Selected: {stagedProductName} — {FormatPeso(stagedPrice)}  (Stock: {stagedAvailableStock})";
                numQty.Maximum = stagedAvailableStock;
                numQty.Value = 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (stagedProductId == 0)
            {
                CustomMessageBox.Show("Please select a product first.", "No Product");
                return;
            }

            int qtyToAdd = (int)numQty.Value;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells["ID"].Value) == stagedProductId)
                {
                    int existingQty = Convert.ToInt32(row.Cells["Qty"].Value);
                    int newQty = existingQty + qtyToAdd;
                    if (newQty > stagedAvailableStock)
                    {
                        CustomMessageBox.Show($"Only {stagedAvailableStock - existingQty} more unit(s) available.",
                            "Insufficient Stock");

                        return;
                    }
                    decimal newSub = stagedPrice * newQty;
                    currentTotal -= Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    row.Cells["Qty"].Value = newQty;
                    row.Cells["Subtotal"].Value = newSub;
                    currentTotal += newSub;
                    UpdateTotal();
                    ResetStaging();
                    return;
                }
            }

            decimal subtotal = stagedPrice * qtyToAdd;
            dgvCart.Rows.Add(stagedProductId, stagedProductName, stagedPrice, qtyToAdd, subtotal);
            currentTotal += subtotal;
            UpdateTotal();
            ResetStaging();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0) return;
            var row = dgvCart.SelectedRows[0];
            if (row.IsNewRow) return;
            currentTotal -= Convert.ToDecimal(row.Cells["Subtotal"].Value);
            dgvCart.Rows.Remove(row);
            UpdateTotal();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {

            if (dgvCart.Rows.Count == 0)
            {
                CustomMessageBox.Show("Cart is empty.", "Nothing to Checkout");
                return;
            }

            if (CustomMessageBox.Show(
                $"Process sale for {FormatPeso(currentTotal)}?",
                "Confirm Sale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            string receiptNum = string.IsNullOrWhiteSpace(txtReceipt.Text)
                ? "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss")
                : txtReceipt.Text.Trim();

            try
            {
                // Check stock via product_stock view before committing
                using var conn = Database.GetConnection();
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "PRAGMA busy_timeout = 5000;";
                cmd.ExecuteNonQuery();

                // Check stock using the same connection
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;

                    int pid = Convert.ToInt32(row.Cells["ID"].Value);
                    int reqQty = Convert.ToInt32(row.Cells["Qty"].Value);
                    string pname = row.Cells["Product"].Value.ToString();

                    int inStock = GetStock(pid, conn);

                    if (inStock < reqQty)
                    {
                        CustomMessageBox.Show($"Not enough stock for '{pname}'.\nNeeded: {reqQty}, Available: {inStock}",
                            "Stock Error");
                        return;
                    }
                }


                using var tr = conn.BeginTransaction();

                // sale columns: receipt_number, sale_date, customer_name, total_amount, user_id
                var c1 = conn.CreateCommand();
                c1.Transaction = tr;
                c1.CommandText = @"
                    INSERT INTO sale (receipt_number, sale_date, customer_name, total_amount, user_id)
                    VALUES (@r, @d, @c, @t, 1);
                    SELECT last_insert_rowid();";
                c1.Parameters.AddWithValue("@r", receiptNum);
                c1.Parameters.AddWithValue("@d", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                c1.Parameters.AddWithValue("@c", string.IsNullOrWhiteSpace(txtCustomer.Text)
                    ? (object)DBNull.Value : txtCustomer.Text.Trim());
                c1.Parameters.AddWithValue("@t", currentTotal);
                long saleId = Convert.ToInt64(c1.ExecuteScalar());

                // sales_details columns: sale_id, product_id, quantity, unit_price, subtotal
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.IsNewRow) continue;
                    var c2 = conn.CreateCommand();
                    c2.Transaction = tr;
                    c2.CommandText = @"
                        INSERT INTO sales_details_fixed (sale_id, product_id, quantity, unit_price, subtotal)
                        VALUES (@sid, @pid, @qty, @price, @sub);";
                    c2.Parameters.AddWithValue("@sid", saleId);
                    c2.Parameters.AddWithValue("@pid", Convert.ToInt32(row.Cells["ID"].Value));
                    c2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["Qty"].Value));
                    c2.Parameters.AddWithValue("@price", Convert.ToDecimal(row.Cells["Price"].Value));
                    c2.Parameters.AddWithValue("@sub", Convert.ToDecimal(row.Cells["Subtotal"].Value));
                    c2.ExecuteNonQuery();
                }

                tr.Commit();
                CustomMessageBox.Show($"✔ Sale complete!\nReceipt: {receiptNum}\nTotal: {FormatPeso(currentTotal)}",
                "Sale Processed");
                ClearCart();
                RefreshDashboard();

                stagedAvailableStock = 0;
                lblSelectedProduct.Text = "Selected: None";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(this, "Sale error: " + ex.Message);
            }
        }

        // Reads stock from product_stock view — no calculation in code
        private int GetStock(int productId, SqliteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT CAST(stock AS INTEGER) FROM product_stock WHERE CAST(product_id AS INTEGER) = @id LIMIT 1;";
            cmd.Parameters.AddWithValue("@id", productId);

            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);

            return 0;
        }

        private void UpdateTotal() => lblTotal.Text = $"Total: {FormatPeso(currentTotal)}";

        private static string FormatPeso(decimal amount) => amount.ToString("C2", PhCulture);

        private void ResetStaging()
        {
            stagedProductId = 0; stagedProductName = "";
            stagedPrice = 0m; stagedAvailableStock = 0;
            numQty.Value = 1; numQty.Maximum = 9999;
            lblSelectedProduct.Text = "Selected: None";
        }

        private void ClearCart()
        {
            dgvCart.Rows.Clear();

            currentTotal = 0m;
            UpdateTotal();

            txtCustomer.Clear();
            txtReceipt.Clear();
            ResetStaging();
        }

        private void RefreshDashboard()
        {
            if (Application.OpenForms["Dashboard_Form"] is Dashboard_Form dashboard)
            {
                dashboard.RefreshData();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

    }
}
