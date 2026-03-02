using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public partial class SalesForm : Form
    {
        private decimal currentTotal = 0m;
        private int stagedProductId = 0;
        private string stagedProductName = "";
        private decimal stagedPrice = 0m;

        public SalesForm()
        {
            InitializeComponent();
            SetupCartGrid();
        }

        private void SetupCartGrid()
        {
            dgvCart.ColumnCount = 5;
            dgvCart.Columns[0].Name = "ID";
            dgvCart.Columns[1].Name = "Product";
            dgvCart.Columns[2].Name = "Price";
            dgvCart.Columns[3].Name = "Qty";
            dgvCart.Columns[4].Name = "Subtotal";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var popup = new ProductSelectionForm())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    stagedProductId = popup.SelectedProductId;
                    stagedProductName = popup.SelectedProductName;
                    stagedPrice = popup.SelectedPrice;
                    lblSelectedProduct.Text = $"Selected: {stagedProductName} (₱{stagedPrice:F2})";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (stagedProductId == 0)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            int qty = (int)numQty.Value;
            decimal subtotal = stagedPrice * qty;

            dgvCart.Rows.Add(stagedProductId, stagedProductName, stagedPrice, qty, subtotal);

            currentTotal += subtotal;
            lblTotal.Text = $"Total: ₱{currentTotal:F2}";

            // Reset staging
            numQty.Value = 1;
            stagedProductId = 0;
            lblSelectedProduct.Text = "Selected: None";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0) return;

            string receiptNum = string.IsNullOrWhiteSpace(txtReceipt.Text)
                ? "REC-" + DateTime.Now.ToString("yyyyMMddHHmmss")
                : txtReceipt.Text;

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                var cmdSale = conn.CreateCommand();
                cmdSale.Transaction = transaction;
                cmdSale.CommandText = @"
                    INSERT INTO Sale (receipt_number, sale_date, customer_name, total_amount, user_id) 
                    VALUES (@receipt, @date, @customer, @total, 1);
                    SELECT last_insert_rowid();";
                cmdSale.Parameters.AddWithValue("@receipt", receiptNum);
                cmdSale.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmdSale.Parameters.AddWithValue("@customer", string.IsNullOrWhiteSpace(txtCustomer.Text) ? (object)DBNull.Value : txtCustomer.Text);
                cmdSale.Parameters.AddWithValue("@total", currentTotal);

                long saleId = (long)cmdSale.ExecuteScalar();

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
                MessageBox.Show($"Sale complete! Receipt: {receiptNum}");

                dgvCart.Rows.Clear();
                currentTotal = 0m;
                lblTotal.Text = "Total: ₱0.00";
                txtCustomer.Clear();
                txtReceipt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}