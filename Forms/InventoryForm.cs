using EvsonHardware.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace EvsonHardware
{
    public partial class InventoryForm : Form
    {
        private int selectedProductId = 0;

        public InventoryForm()
        {
            InitializeComponent();
            EnsureDefaultCategory();
            LoadCategories();
            LoadInventory();
        }

        // Failsafe: Ensures at least one category exists
        private void EnsureDefaultCategory()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Category (category_name) SELECT 'General Hardware' WHERE NOT EXISTS (SELECT 1 FROM Category LIMIT 1);";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring default category: " + ex.Message);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT category_id, category_name FROM Category ORDER BY category_name;";
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadInventory()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                // Simplified stock: Supply - Sales only.
                // Add Adjustment_Details and Return_Details back when those modules are built.
                cmd.CommandText = @"
                    SELECT 
                        p.product_id    AS ID,
                        p.product_name  AS Name,
                        c.category_name AS Category,
                        p.brandname     AS Brand,
                        p.price         AS Price,
                        p.unit          AS Unit,
                        p.reorder_level AS Reorder,
                        (
                            COALESCE((SELECT SUM(quantity) FROM Supply_Details WHERE product_id = p.product_id), 0)
                          - COALESCE((SELECT SUM(quantity) FROM Sales_Details  WHERE product_id = p.product_id), 0)
                        ) AS Stock
                    FROM Product p
                    LEFT JOIN Category c ON p.category_id = c.category_id
                    ORDER BY p.product_name;";

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvInventory.DataSource = dt;
                dgvInventory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
            selectedProductId = Convert.ToInt32(row.Cells["ID"].Value);

            txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txtBrand.Text = row.Cells["Brand"].Value?.ToString() ?? "";
            txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "pcs";
            numPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
            numReorder.Value = Convert.ToDecimal(row.Cells["Reorder"].Value);
            cmbCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";

            lblSelectedStock.Text = $"Selected Stock: {row.Cells["Stock"].Value} {row.Cells["Unit"].Value}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Name and Category are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                if (selectedProductId == 0) // ADD NEW
                {
                    cmd.CommandText = @"
                        INSERT INTO Product (product_name, brandname, unit, price, reorder_level, category_id) 
                        VALUES (@name, @brand, @unit, @price, @reorder, @catId);";
                }
                else // UPDATE EXISTING
                {
                    cmd.CommandText = @"
                        UPDATE Product SET 
                            product_name  = @name,
                            brandname     = @brand,
                            unit          = @unit,
                            price         = @price,
                            reorder_level = @reorder,
                            category_id   = @catId
                        WHERE product_id  = @id;";
                    cmd.Parameters.AddWithValue("@id", selectedProductId);
                }

                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@brand", txtBrand.Text.Trim());
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text.Trim());
                cmd.Parameters.AddWithValue("@price", numPrice.Value);
                cmd.Parameters.AddWithValue("@reorder", numReorder.Value);
                cmd.Parameters.AddWithValue("@catId", GetSelectedCategoryId());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Product saved successfully!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Adds stock by inserting into Supply tables
        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0 || numRestockQty.Value <= 0)
            {
                MessageBox.Show("Select a product and enter a quantity greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                // 1. Create Supply header
                var cmdSupply = conn.CreateCommand();
                cmdSupply.Transaction = transaction;
                cmdSupply.CommandText = @"
                    INSERT INTO Supply (supply_date, supplier_name, user_id, total_amount) 
                    VALUES (@date, 'Quick Restock', 1, 0);
                    SELECT last_insert_rowid();";
                cmdSupply.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                long supplyId = (long)cmdSupply.ExecuteScalar();

                // 2. Create Supply detail
                // Note: Supply_Details has no subtotal column — only supply_id, product_id, quantity, unit_cost
                var cmdDetail = conn.CreateCommand();
                cmdDetail.Transaction = transaction;
                cmdDetail.CommandText = @"
                    INSERT INTO Supply_Details (supply_id, product_id, quantity, unit_cost) 
                    VALUES (@supplyId, @prodId, @qty, 0);";
                cmdDetail.Parameters.AddWithValue("@supplyId", supplyId);
                cmdDetail.Parameters.AddWithValue("@prodId", selectedProductId);
                cmdDetail.Parameters.AddWithValue("@qty", (int)numRestockQty.Value);
                cmdDetail.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show($"Successfully added {(int)numRestockQty.Value} units to stock!", "Restock Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                numRestockQty.Value = 0;
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restock failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ── Helpers ───────────────────────────────────────────────────

        /// <summary>
        /// Safely reads the selected category ID from the ComboBox.
        /// </summary>
        private int GetSelectedCategoryId()
        {
            if (cmbCategory.SelectedItem == null) return 0;
            var row = cmbCategory.SelectedItem as DataRowView;
            if (row == null) return 0;
            return Convert.ToInt32(row["category_id"]);
        }

        private void ClearForm()
        {
            selectedProductId = 0;
            txtName.Clear();
            txtBrand.Clear();
            txtUnit.Text = "pcs";
            numPrice.Value = 0;
            numReorder.Value = 10;
            lblSelectedStock.Text = "Selected Stock: 0";
            dgvInventory.ClearSelection();
        }
    }
}