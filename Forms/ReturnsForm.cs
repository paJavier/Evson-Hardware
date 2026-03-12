using EvsonHardware.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class ReturnsForm : Form
    {
        private readonly int _userId;
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");
        private long _loadedSaleId;
        private int _selectedProductId;
        private int _selectedAvailableQty;
        private string _selectedProductName = "";

        public ReturnsForm(int userId = 1)
        {
            InitializeComponent();
            _userId = userId <= 0 ? 1 : userId;
            cmbReturnType.SelectedIndex = 0;
            ResetSelectionState();
        }

        /// <summary>
        /// Processes a product return by reversing the sale line, updating stock,
        /// and logging the transaction to the return tables.
        /// </summary>
        /// <returns>true if the operation succeeds; otherwise false.</returns>
        public bool ProcessReturn(
            string receiptNumber,
            int productId,
            int quantity,
            string returnType,
            string reason,
            int? verifyingEmployeeId = null,
            string? customerNameOverride = null)
        {
            if (string.IsNullOrWhiteSpace(receiptNumber))
            {
                MessageBox.Show("Receipt number is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (productId <= 0)
            {
                MessageBox.Show("Product must be selected before processing a return.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var tr = conn.BeginTransaction();

                string saleTable = ResolveSaleTable(conn, tr);
                string salesDetailsTable = ResolveSalesDetailsTable(conn, tr);

                var saleCmd = conn.CreateCommand();
                saleCmd.Transaction = tr;
                saleCmd.CommandText = $@"
                    SELECT rowid, COALESCE(total_amount, '0'), customer_name
                    FROM {saleTable}
                    WHERE receipt_number = @receipt
                    LIMIT 1;";
                saleCmd.Parameters.AddWithValue("@receipt", receiptNumber.Trim());

                using var saleReader = saleCmd.ExecuteReader();
                if (!saleReader.Read())
                {
                    MessageBox.Show("Receipt number was not found.", "Return Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                long saleId = saleReader.GetInt64(0);
                decimal saleTotal = ParseDecimal(saleReader.GetValue(1));
                string? saleCustomer = saleReader.IsDBNull(2) ? null : saleReader.GetString(2);

                var saleLines = LoadSaleLines(conn, tr, salesDetailsTable, saleId, productId);
                if (saleLines.Count == 0)
                {
                    MessageBox.Show("The selected product is not part of that receipt.", "Return Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int totalSold = saleLines.Sum(line => line.Quantity);
                if (quantity > totalSold)
                {
                    MessageBox.Show($"Cannot return {quantity} unit(s). Only {totalSold} were sold on that receipt.",
                        "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int qtyToReverse = quantity;
                decimal refundAmount = 0m;

                foreach (var line in saleLines)
                {
                    if (qtyToReverse <= 0) break;

                    int consume = Math.Min(qtyToReverse, line.Quantity);
                    int newQty = line.Quantity - consume;
                    refundAmount += consume * line.UnitPrice;

                    if (newQty == 0)
                    {
                        var deleteCmd = conn.CreateCommand();
                        deleteCmd.Transaction = tr;
                        deleteCmd.CommandText = $"DELETE FROM {salesDetailsTable} WHERE sales_detail_id = @id;";
                        deleteCmd.Parameters.AddWithValue("@id", line.DetailId);
                        deleteCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        var updateCmd = conn.CreateCommand();
                        updateCmd.Transaction = tr;
                        updateCmd.CommandText = $@"
                            UPDATE {salesDetailsTable}
                            SET quantity = @qty,
                                subtotal = @subtotal
                            WHERE sales_detail_id = @id;";
                        updateCmd.Parameters.AddWithValue("@qty", newQty);
                        updateCmd.Parameters.AddWithValue("@subtotal", newQty * line.UnitPrice);
                        updateCmd.Parameters.AddWithValue("@id", line.DetailId);
                        updateCmd.ExecuteNonQuery();
                    }

                    qtyToReverse -= consume;
                }

                if (qtyToReverse > 0)
                {
                    throw new InvalidOperationException("Unable to consume all quantities for the requested return.");
                }

                decimal newTotal = saleTotal - refundAmount;
                if (newTotal < 0) newTotal = 0;

                var updateSaleCmd = conn.CreateCommand();
                updateSaleCmd.Transaction = tr;
                updateSaleCmd.CommandText = $"UPDATE {saleTable} SET total_amount = @total WHERE rowid = @id;";
                updateSaleCmd.Parameters.AddWithValue("@total", newTotal);
                updateSaleCmd.Parameters.AddWithValue("@id", saleId);
                updateSaleCmd.ExecuteNonQuery();

                long returnId = GetNextNumericId(conn, "return_transaction", "return_id", tr);
                var returnCmd = conn.CreateCommand();
                returnCmd.Transaction = tr;
                returnCmd.CommandText = @"
                    INSERT INTO return_transaction
                        (return_id, return_date, return_type, reason, verified_by_employee_id, sale_id, customer_name, user_id)
                    VALUES
                        (@id, @date, @type, @reason, @employee, @sale, @customer, @user);";
                returnCmd.Parameters.AddWithValue("@id", returnId);
                returnCmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                returnCmd.Parameters.AddWithValue("@type", string.IsNullOrWhiteSpace(returnType) ? "Refund" : returnType.Trim());
                returnCmd.Parameters.AddWithValue("@reason", string.IsNullOrWhiteSpace(reason) ? "Processed via ReturnsForm" : reason.Trim());
                returnCmd.Parameters.AddWithValue("@employee", verifyingEmployeeId.HasValue ? verifyingEmployeeId.Value : (object)DBNull.Value);
                returnCmd.Parameters.AddWithValue("@sale", saleId);

                string? resolvedCustomer = string.IsNullOrWhiteSpace(customerNameOverride)
                    ? saleCustomer
                    : customerNameOverride.Trim();

                returnCmd.Parameters.AddWithValue("@customer",
                    string.IsNullOrWhiteSpace(resolvedCustomer) ? (object)DBNull.Value : resolvedCustomer);

                returnCmd.Parameters.AddWithValue("@user", _userId);
                returnCmd.ExecuteNonQuery();

                long returnDetailId = GetNextNumericId(conn, "return_details", "return_detail_id", tr);
                var returnDetailsCmd = conn.CreateCommand();
                returnDetailsCmd.Transaction = tr;
                returnDetailsCmd.CommandText = @"
                    INSERT INTO return_details (return_detail_id, return_id, product_id, quantity)
                    VALUES (@id, @returnId, @product, @qty);";
                returnDetailsCmd.Parameters.AddWithValue("@id", returnDetailId);
                returnDetailsCmd.Parameters.AddWithValue("@returnId", returnId);
                returnDetailsCmd.Parameters.AddWithValue("@product", productId);
                returnDetailsCmd.Parameters.AddWithValue("@qty", quantity);
                returnDetailsCmd.ExecuteNonQuery();

                tr.Commit();

                MessageBox.Show(
                    $"Return completed.\nRefund amount: {refundAmount.ToString("C2", PhCulture)}",
                    "Return Processed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshDashboard();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return processing error: " + ex.Message,
                    "Return Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static List<(long DetailId, int Quantity, decimal UnitPrice)> LoadSaleLines(
            SqliteConnection conn,
            SqliteTransaction tr,
            string salesDetailsTable,
            long saleId,
            int productId)
        {
            var result = new List<(long DetailId, int Quantity, decimal UnitPrice)>();

            var cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            cmd.CommandText = $@"
                SELECT sales_detail_id, COALESCE(quantity, 0), COALESCE(unit_price, 0)
                FROM {salesDetailsTable}
                WHERE sale_id = @sale AND product_id = @product
                ORDER BY sales_detail_id;";
            cmd.Parameters.AddWithValue("@sale", saleId);
            cmd.Parameters.AddWithValue("@product", productId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                long detailId = Convert.ToInt64(reader.GetValue(0));
                int qty = Convert.ToInt32(reader.GetValue(1));
                decimal unitPrice = ParseDecimal(reader.GetValue(2));
                result.Add((detailId, qty, unitPrice));
            }

            return result;
        }

        private static decimal ParseDecimal(object? dbValue)
        {
            if (dbValue == null || dbValue == DBNull.Value) return 0m;
            if (dbValue is decimal d) return d;
            if (dbValue is double dbl) return Convert.ToDecimal(dbl);
            if (dbValue is float flt) return Convert.ToDecimal(flt);
            if (dbValue is long lng) return lng;
            if (dbValue is int i) return i;

            return decimal.TryParse(
                Convert.ToString(dbValue),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal parsed)
                ? parsed
                : 0m;
        }

        private static long GetNextNumericId(SqliteConnection conn, string tableName, string columnName, SqliteTransaction? tr = null)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            cmd.CommandText = $"SELECT COALESCE(MAX(CAST({columnName} AS INTEGER)), 0) + 1 FROM {tableName};";
            object? scalar = cmd.ExecuteScalar();
            return Convert.ToInt64(scalar == null || scalar == DBNull.Value ? 1 : scalar);
        }

        private static bool TableExists(SqliteConnection conn, string tableName, SqliteTransaction? tr = null)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            cmd.CommandText = @"
                SELECT 1
                FROM sqlite_master
                WHERE type IN ('table', 'view')
                  AND LOWER(name) = LOWER(@name)
                LIMIT 1;";
            cmd.Parameters.AddWithValue("@name", tableName);
            return cmd.ExecuteScalar() != null;
        }

        private static string ResolveSaleTable(SqliteConnection conn, SqliteTransaction? tr = null)
        {
            if (TableExists(conn, "sale", tr)) return "sale";
            if (TableExists(conn, "sales", tr)) return "sales";
            throw new InvalidOperationException("No sale table found (expected sale or sales).");
        }

        private static string ResolveSalesDetailsTable(SqliteConnection conn, SqliteTransaction? tr = null)
        {
            if (TableExists(conn, "sales_details_fixed", tr)) return "sales_details_fixed";
            if (TableExists(conn, "sales_details", tr)) return "sales_details";
            throw new InvalidOperationException("No sales details table found (expected sales_details or sales_details_fixed).");
        }

        private void RefreshDashboard()
        {
            if (Application.OpenForms["Dashboard_Form"] is Dashboard_Form dashboard)
            {
                dashboard.RefreshData();
            }
        }

        private void btnLoadSale_Click(object sender, EventArgs e)
        {
            LoadSaleByReceipt(txtReceiptNumber.Text);
        }

        private void dgvSaleItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSaleItems.SelectedRows.Count == 0)
            {
                ResetSelectionState();
                return;
            }

            ApplySaleItemSelection(dgvSaleItems.SelectedRows[0]);
        }

        private void dgvSaleItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSaleItems.Rows.Count) return;
            dgvSaleItems.Rows[e.RowIndex].Selected = true;
            ApplySaleItemSelection(dgvSaleItems.Rows[e.RowIndex]);
        }

        private void ApplySaleItemSelection(DataGridViewRow? row)
        {
            if (row == null || row.Cells.Count == 0)
            {
                ResetSelectionState();
                return;
            }

            object? productIdValue = row.Cells["ProductId"]?.Value;
            if (productIdValue == null || productIdValue == DBNull.Value)
            {
                ResetSelectionState();
                return;
            }

            _selectedProductId = Convert.ToInt32(productIdValue);
            _selectedProductName = row.Cells["Product"]?.Value?.ToString() ?? "Unknown Product";
            _selectedAvailableQty = Convert.ToInt32(row.Cells["Quantity"]?.Value ?? 0);
            decimal price = ParseDecimal(row.Cells["UnitPrice"]?.Value);

            if (_selectedAvailableQty < 1)
                _selectedAvailableQty = 1;

            numReturnQty.Maximum = Math.Max(1, _selectedAvailableQty);
            if (numReturnQty.Value > _selectedAvailableQty)
                numReturnQty.Value = _selectedAvailableQty;
            if (numReturnQty.Value < 1)
                numReturnQty.Value = 1;

            lblSelection.Text =
                $"{_selectedProductName} ? Sold Qty: {_selectedAvailableQty} @ {price.ToString("C2", PhCulture)}";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string receiptNumber = txtReceiptNumber.Text.Trim();
            if (_loadedSaleId == 0 || string.IsNullOrWhiteSpace(receiptNumber))
            {
                MessageBox.Show("Load a receipt before processing a return.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedProductId == 0)
            {
                MessageBox.Show("Select a sale item to return.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a brief reason or note for this return.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEmployeeId.Text.Trim(), out int employeeId) || employeeId <= 0)
            {
                MessageBox.Show("Enter a valid employee ID for verification.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numReturnQty.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Return quantity must be at least 1.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string returnType = cmbReturnType.SelectedItem?.ToString() ?? "Refund";
            string? customCustomer = string.IsNullOrWhiteSpace(txtCustomerName.Text)
                ? null
                : txtCustomerName.Text.Trim();

            bool isProcessed = ProcessReturn(
                receiptNumber,
                _selectedProductId,
                quantity,
                returnType,
                txtReason.Text.Trim(),
                employeeId,
                customCustomer);

            if (isProcessed)
            {
                LoadSaleByReceipt(receiptNumber);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void exitbtn_Click(object sender, EventArgs e) => Close();

        private void LoadSaleByReceipt(string receiptNumber)
        {
            if (string.IsNullOrWhiteSpace(receiptNumber))
            {
                MessageBox.Show("Please enter a receipt number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string saleTable = ResolveSaleTable(conn);
                string salesDetailsTable = ResolveSalesDetailsTable(conn);

                var saleCmd = conn.CreateCommand();
                saleCmd.CommandText = $@"
                    SELECT rowid,
                           COALESCE(customer_name, ''),
                           COALESCE(total_amount, '0'),
                           COALESCE(sale_date, '')
                    FROM {saleTable}
                    WHERE receipt_number = @receipt
                    LIMIT 1;";
                saleCmd.Parameters.AddWithValue("@receipt", receiptNumber.Trim());

                using var reader = saleCmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Receipt not found. Please double-check the number.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblSaleStatus.Text = "No receipt loaded yet.";
                    dgvSaleItems.DataSource = null;
                    _loadedSaleId = 0;
                    ResetSelectionState();
                    return;
                }

                _loadedSaleId = reader.GetInt64(0);
                string customer = reader.GetString(1);
                decimal total = ParseDecimal(reader.GetValue(2));
                string saleDate = reader.GetString(3);

                string status = $"Receipt {receiptNumber}";
                if (!string.IsNullOrWhiteSpace(saleDate))
                    status += $" • {saleDate}";
                status += $" • Total {total.ToString("C2", PhCulture)}";
                if (!string.IsNullOrWhiteSpace(customer))
                    status += $" • Customer: {customer}";

                lblSaleStatus.Text = status;

                var detailsCmd = conn.CreateCommand();
                detailsCmd.CommandText = $@"
                    SELECT
                        sd.sales_detail_id AS DetailId,
                        sd.product_id      AS ProductId,
                        IFNULL(p.product_name, '') AS Product,
                        sd.unit_price      AS UnitPrice,
                        sd.quantity        AS Quantity,
                        sd.subtotal        AS Subtotal
                    FROM {salesDetailsTable} sd
                    LEFT JOIN product p ON CAST(p.product_id AS INTEGER) = CAST(sd.product_id AS INTEGER)
                    WHERE sd.sale_id = @sale
                    ORDER BY sd.sales_detail_id;";
                detailsCmd.Parameters.AddWithValue("@sale", _loadedSaleId);

                var dt = new DataTable();
                using (var detailReader = detailsCmd.ExecuteReader())
                {
                    dt.Load(detailReader);
                }

                dgvSaleItems.DataSource = dt;
                if (dgvSaleItems.Columns["DetailId"] != null)
                    dgvSaleItems.Columns["DetailId"].Visible = false;
                if (dgvSaleItems.Columns["ProductId"] != null)
                    dgvSaleItems.Columns["ProductId"].Visible = false;

                if (dgvSaleItems.Columns["UnitPrice"] != null)
                {
                    dgvSaleItems.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                    dgvSaleItems.Columns["UnitPrice"].DefaultCellStyle.FormatProvider = PhCulture;
                }
                if (dgvSaleItems.Columns["Subtotal"] != null)
                {
                    dgvSaleItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvSaleItems.Columns["Subtotal"].DefaultCellStyle.FormatProvider = PhCulture;
                }

                ResetSelectionState();
                txtReason.Clear();
                txtCustomerName.Clear();
                txtEmployeeId.Clear();
                numReturnQty.Value = 1;
                if (cmbReturnType.Items.Count > 0)
                    cmbReturnType.SelectedIndex = 0;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No sale items found for this receipt.", "Empty Receipt",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load sale error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSelectionState()
        {
            _selectedProductId = 0;
            _selectedProductName = "";
            _selectedAvailableQty = 0;
            numReturnQty.Value = 1;
            numReturnQty.Maximum = 1;
            lblSelection.Text = "No item selected. Choose a row.";
        }
    }
}
