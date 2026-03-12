using EvsonHardware.Data;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EvsonHardware
{
    public partial class InventoryForm : Form
    {
        private int selectedProductId = 0;
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");

        public InventoryForm()
        {
            InitializeComponent();
            ApplyGridTheme();
            LoadCategories();
            LoadInventory();
        }

        private void ApplyGridTheme()
        {
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.BackgroundColor = Color.Ivory;
            dgvInventory.BorderStyle = BorderStyle.FixedSingle;
            dgvInventory.GridColor = Color.FromArgb(214, 223, 118);

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            dgvInventory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInventory.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvInventory.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvInventory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventory.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);

            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventory.ThemeStyle.BackColor = Color.Ivory;
            dgvInventory.ThemeStyle.GridColor = Color.FromArgb(214, 223, 118);
            dgvInventory.ThemeStyle.HeaderStyle.BackColor = Color.OliveDrab;
            dgvInventory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvInventory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInventory.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvInventory.ThemeStyle.RowsStyle.ForeColor = Color.DarkOliveGreen;
            dgvInventory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvInventory.ThemeStyle.RowsStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 250, 211);
        }

        private void LoadCategories()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT
                        COALESCE(
                            MIN(CASE
                                WHEN TRIM(IFNULL(category_id, '')) GLOB '[0-9]*'
                                     AND TRIM(IFNULL(category_id, '')) <> ''
                                THEN CAST(category_id AS INTEGER)
                            END),
                            MIN(rowid)
                        ) AS category_id,
                        TRIM(category_name) AS category_name
                    FROM category
                    WHERE TRIM(IFNULL(category_name, '')) <> ''
                    GROUP BY LOWER(TRIM(category_name))
                    ORDER BY TRIM(category_name);";
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadCategories error: " + ex.Message);
            }
        }

        private void LoadInventory()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                string supplyDetailsTable = ResolveSupplyDetailsTable(conn);
                string salesDetailsTable = ResolveSalesDetailsTable(conn);

                cmd.CommandText = $@"
                    SELECT
                        p.product_id     AS ID,
                        p.product_name   AS Name,
                        COALESCE(c.category_name, '') AS Category,
                        COALESCE(p.brandname, '')     AS Brand,
                        COALESCE(p.price, 0)          AS Price,
                        COALESCE(p.unit, 'pcs')       AS Unit,
                        COALESCE(p.reorder_level, 10) AS Reorder,
                            (
                                COALESCE(
                                    (SELECT SUM(quantity) FROM {supplyDetailsTable}
                                     WHERE CAST(product_id AS INTEGER) = p.product_id), 0
                                )
                                -
                                COALESCE(
                                    (SELECT SUM(quantity) FROM {salesDetailsTable}
                                     WHERE CAST(product_id AS INTEGER) = p.product_id), 0
                                )
                                +
                                COALESCE(
                                    (SELECT SUM(quantity) FROM adjustment_details
                                     WHERE CAST(product_id AS INTEGER) = p.product_id), 0
                                )
                            ) AS Stock                    
                    FROM product p
                    LEFT JOIN category c ON c.category_id = p.category_id
                    ORDER BY p.product_name;";

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvInventory.DataSource = dt;
                if (dgvInventory.Columns["Price"] != null)
                {
                    dgvInventory.Columns["Price"].DefaultCellStyle.Format = "C2";
                    dgvInventory.Columns["Price"].DefaultCellStyle.FormatProvider = PhCulture;
                    dgvInventory.Columns["Price"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                }
                dgvInventory.ClearSelection();
                if (dgvInventory.Rows.Count > 0)
                {
                    dgvInventory.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadInventory error: " + ex.Message);
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvInventory.Rows[e.RowIndex];
            selectedProductId = GetCellInt(row, "ID", 0);

            txtName.Text = GetCellString(row, "Name", "");
            txtBrand.Text = GetCellString(row, "Brand", "");
            txtUnit.Text = GetCellString(row, "Unit", "pcs");
            numPrice1.Value = GetCellDecimal(row, "Price", 0m);
            numReorder1.Value = GetCellDecimal(row, "Reorder", 10m);
            cmbCategory.Text = GetCellString(row, "Category", "");

            decimal stock = GetCellDecimal(row, "Stock", 0m);
            lblSelectedStock.Text = $"Selected Stock: {stock} {txtUnit.Text}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int catId = GetSelectedCategoryId();
            if (catId == 0)
            {
                MessageBox.Show("Please select a category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                if (selectedProductId == 0)
                {
                    // product columns: product_name, unit, price, category_id, description, brandname, reorder_level
                    cmd.CommandText = @"
                        INSERT INTO product (product_id, product_name, unit, price, category_id, description, brandname, reorder_level)
                        VALUES (
                            (SELECT COALESCE(MAX(CAST(product_id AS INTEGER)), 0) + 1 FROM product),
                            @name, @unit, @price, @catId, @desc, @brand, @reorder
                        );";
                }
                else
                {
                    cmd.CommandText = @"
                        UPDATE product SET
                            product_name  = @name,
                            unit          = @unit,
                            price         = @price,
                            category_id   = @catId,
                            description   = @desc,
                            brandname     = @brand,
                            reorder_level = @reorder
                        WHERE product_id  = @id;";
                    cmd.Parameters.AddWithValue("@id", selectedProductId);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@price", numPrice1.Value);
                cmd.Parameters.AddWithValue("@catId", catId);
                cmd.Parameters.AddWithValue("@desc", "");
                cmd.Parameters.AddWithValue("@brand", txtBrand.Text.Trim());
                cmd.Parameters.AddWithValue("@reorder", numReorder1.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message);
            }
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0 || numRestockQty1.Value <= 0)
            {
                MessageBox.Show("Select a product and enter quantity > 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var tr = conn.BeginTransaction();

                // supply columns: supply_date, supplier_name, employee_id, user_id, total_amount
                var c1 = conn.CreateCommand();
                c1.Transaction = tr;
                long supplyId = GetNextNumericId(conn, "supply", "supply_id", tr);
                c1.CommandText = @"
                    INSERT INTO supply (supply_id, supply_date, supplier_name, employee_id, user_id, total_amount)
                    VALUES (@sid, @date, 'Quick Restock', NULL, 1, 0);";
                c1.Parameters.AddWithValue("@sid", supplyId);
                c1.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                c1.ExecuteNonQuery();

                // supply_details columns: supply_id, product_id, quantity, unit_cost, subtotal
                string supplyDetailsTable = ResolveSupplyDetailsTable(conn, tr);
                var c3 = conn.CreateCommand();
                c3.Transaction = tr;
                c3.CommandText = $@"
                    INSERT INTO {supplyDetailsTable} (supply_id, product_id, quantity, unit_cost, subtotal)
                    VALUES (@sid, @pid, @qty, 0, 0);";
                c3.Parameters.AddWithValue("@sid", supplyId);
                c3.Parameters.AddWithValue("@pid", selectedProductId);
                c3.Parameters.AddWithValue("@qty", (int)numRestockQty1.Value);
                c3.ExecuteNonQuery();

                tr.Commit();
                MessageBox.Show($"Added {(int)numRestockQty1.Value} units. Supply ID: {supplyId}",
                    "Restock Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                numRestockQty1.Value = numRestockQty1.Minimum;
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restock error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private static bool TableExists(Microsoft.Data.Sqlite.SqliteConnection conn, string tableName, Microsoft.Data.Sqlite.SqliteTransaction? tr = null)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type = 'table' AND name = @name LIMIT 1;";
            cmd.Parameters.AddWithValue("@name", tableName);
            return cmd.ExecuteScalar() != null;
        }

        private static string ResolveSupplyDetailsTable(Microsoft.Data.Sqlite.SqliteConnection conn, Microsoft.Data.Sqlite.SqliteTransaction? tr = null)
        {
            if (TableExists(conn, "supply_details_fixed", tr)) return "supply_details_fixed";
            if (TableExists(conn, "supply_details", tr)) return "supply_details";
            throw new InvalidOperationException("No supply details table found (expected supply_details or supply_details_fixed).");
        }

        private static string ResolveSalesDetailsTable(Microsoft.Data.Sqlite.SqliteConnection conn, Microsoft.Data.Sqlite.SqliteTransaction? tr = null)
        {
            if (TableExists(conn, "sales_details_fixed", tr)) return "sales_details_fixed";
            if (TableExists(conn, "sales_details", tr)) return "sales_details";
            throw new InvalidOperationException("No sales details table found (expected sales_details or sales_details_fixed).");
        }

        private static long GetNextNumericId(
            Microsoft.Data.Sqlite.SqliteConnection conn,
            string tableName,
            string idColumn,
            Microsoft.Data.Sqlite.SqliteTransaction? tr = null)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            cmd.CommandText = $"SELECT COALESCE(MAX(CAST({idColumn} AS INTEGER)), 0) + 1 FROM {tableName};";
            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        private static string GetCellString(DataGridViewRow row, string columnName, string fallback)
        {
            object? value = row.Cells[columnName].Value;
            return value == null || value == DBNull.Value ? fallback : value.ToString() ?? fallback;
        }

        private static int GetCellInt(DataGridViewRow row, string columnName, int fallback)
        {
            object? value = row.Cells[columnName].Value;
            if (value == null || value == DBNull.Value) return fallback;
            return int.TryParse(value.ToString(), out int parsed) ? parsed : fallback;
        }

        private static decimal GetCellDecimal(DataGridViewRow row, string columnName, decimal fallback)
        {
            object? value = row.Cells[columnName].Value;
            if (value == null || value == DBNull.Value) return fallback;
            return decimal.TryParse(value.ToString(), out decimal parsed) ? parsed : fallback;
        }

        private int GetSelectedCategoryId()
        {
            if (cmbCategory.SelectedItem is DataRowView row)
                return Convert.ToInt32(row["category_id"]);
            return 0;
        }

        private void ClearForm()
        {
            selectedProductId = 0;
            txtName.Clear();
            txtBrand.Clear();
            txtUnit.Text = "pcs";
            numPrice1.Value = 0;
            numReorder1.Value = 0;
            lblSelectedStock.Text = "Selected Stock: 0";
            dgvInventory.ClearSelection();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Select a product first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)numRestockQty1.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Enter quantity to remove.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var tr = conn.BeginTransaction();

                // create adjustment record
                long adjustmentId = GetNextNumericId(conn, "inventory_adjustment", "adjustment_id", tr);

                var cmd1 = conn.CreateCommand();
                cmd1.Transaction = tr;
                cmd1.CommandText = @"
            INSERT INTO inventory_adjustment
            (adjustment_id, adjustment_date, reason, user_id)
            VALUES (@id, @date, 'Manual stock removal', 1);";

                cmd1.Parameters.AddWithValue("@id", adjustmentId);
                cmd1.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd1.ExecuteNonQuery();

                // subtract quantity
                long detailId = GetNextNumericId(conn, "adjustment_details", "adjustment_detail_id", tr);

                var cmd2 = conn.CreateCommand();
                cmd2.Transaction = tr;
                cmd2.CommandText = @"
            INSERT INTO adjustment_details
            (adjustment_detail_id, adjustment_id, product_id, quantity)
            VALUES (@did, @aid, @pid, @qty);";

                cmd2.Parameters.AddWithValue("@did", detailId);
                cmd2.Parameters.AddWithValue("@aid", adjustmentId);
                cmd2.Parameters.AddWithValue("@pid", selectedProductId);

                // negative quantity removes stock
                cmd2.Parameters.AddWithValue("@qty", -qty);

                cmd2.ExecuteNonQuery();

                tr.Commit();

                MessageBox.Show($"Removed {qty} units from stock.",
                    "Stock Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                numRestockQty1.Value = numRestockQty1.Minimum;
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stock removal error: " + ex.Message);
            }
        }
    }
}
