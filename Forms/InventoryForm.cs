using EvsonHardware.Data;
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
            LoadCategories();
            LoadInventory();
        }

        private void LoadCategories()
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT category_id, category_name FROM category ORDER BY category_name;";
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

                // product_stock view: product_id, product_name, price, category_name, stock
                // product table:      product_id, product_name, unit, price, category_id, description, brandname, reorder_level
                cmd.CommandText = @"
                    SELECT
                        ps.product_id    AS ID,
                        ps.product_name  AS Name,
                        ps.category_name AS Category,
                        p.brandname      AS Brand,
                        ps.price         AS Price,
                        p.unit           AS Unit,
                        p.reorder_level  AS Reorder,
                        ps.stock         AS Stock
                    FROM product_stock ps
                    JOIN product p ON ps.product_id = p.product_id
                    ORDER BY ps.product_name;";

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvInventory.DataSource = dt;
                dgvInventory.ClearSelection();
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
                        INSERT INTO product (product_name, unit, price, category_id, description, brandname, reorder_level)
                        VALUES (@name, @unit, @price, @catId, @desc, @brand, @reorder);";
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
                cmd.Parameters.AddWithValue("@price", numPrice.Value);
                cmd.Parameters.AddWithValue("@catId", catId);
                cmd.Parameters.AddWithValue("@desc", "");
                cmd.Parameters.AddWithValue("@brand", txtBrand.Text.Trim());
                cmd.Parameters.AddWithValue("@reorder", numReorder.Value);

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
            if (selectedProductId == 0 || numRestockQty.Value <= 0)
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
                c1.CommandText = @"
                    INSERT INTO supply (supply_date, supplier_name, employee_id, user_id, total_amount)
                    VALUES (@date, 'Quick Restock', NULL, 1, 0);";
                c1.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                c1.ExecuteNonQuery();

                var c2 = conn.CreateCommand();
                c2.Transaction = tr;
                c2.CommandText = "SELECT last_insert_rowid();";
                long supplyId = (long)c2.ExecuteScalar();

                // supply_details columns: supply_id, product_id, quantity, unit_cost, subtotal
                var c3 = conn.CreateCommand();
                c3.Transaction = tr;
                c3.CommandText = @"
                    INSERT INTO supply_details (supply_id, product_id, quantity, unit_cost, subtotal)
                    VALUES (@sid, @pid, @qty, 0, 0);";
                c3.Parameters.AddWithValue("@sid", supplyId);
                c3.Parameters.AddWithValue("@pid", selectedProductId);
                c3.Parameters.AddWithValue("@qty", (int)numRestockQty.Value);
                c3.ExecuteNonQuery();

                tr.Commit();
                MessageBox.Show($"Added {(int)numRestockQty.Value} units. Supply ID: {supplyId}",
                    "Restock Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                numRestockQty.Value = 0;
                LoadInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Restock error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

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
            numPrice.Value = 0;
            numReorder.Value = 10;
            lblSelectedStock.Text = "Selected Stock: 0";
            dgvInventory.ClearSelection();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}