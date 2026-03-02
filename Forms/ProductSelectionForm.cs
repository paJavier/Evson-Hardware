using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public class ProductSelectionForm : Form
    {
        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private Button btnSelect;

        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public decimal SelectedPrice { get; private set; }

        public ProductSelectionForm()
        {
            InitializeUI();
            LoadProducts("");
        }

        private void InitializeUI()
        {
            this.Text = "Select Product";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblSearch = new Label() { Text = "Search:", Location = new Point(20, 20), AutoSize = true };
            txtSearch = new TextBox() { Location = new Point(80, 18), Size = new Size(480, 22) };
            txtSearch.TextChanged += (s, e) => LoadProducts(txtSearch.Text);

            dgvProducts = new DataGridView()
            {
                Location = new Point(20, 60),
                Size = new Size(540, 280),
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvProducts.DoubleClick += (s, e) => SelectProduct();

            btnSelect = new Button()
            {
                Text = "Select",
                Location = new Point(460, 360),
                Size = new Size(100, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };
            btnSelect.Click += (s, e) => SelectProduct();

            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            this.Controls.Add(dgvProducts);
            this.Controls.Add(btnSelect);
        }

        private void LoadProducts(string search)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT * FROM (
                        SELECT p.product_id AS ID, p.product_name AS Product, p.price AS Price,
                        (
                            COALESCE((SELECT SUM(quantity) FROM Supply_Details WHERE product_id = p.product_id), 0) -
                            COALESCE((SELECT SUM(quantity) FROM Sales_Details WHERE product_id = p.product_id), 0) +
                            COALESCE((SELECT SUM(CASE WHEN adjustment_type = 'IN' THEN quantity ELSE -quantity END) 
                                      FROM Adjustment_Details ad 
                                      JOIN Inventory_Adjustment ia ON ad.adjustment_id = ia.adjustment_id 
                                      WHERE ad.product_id = p.product_id), 0) +
                            COALESCE((SELECT SUM(quantity) FROM Return_Details WHERE product_id = p.product_id), 0)
                        ) as Stock
                        FROM Product p
                        WHERE p.product_name LIKE @search
                    ) WHERE Stock > 0;";
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SelectProduct()
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var row = dgvProducts.SelectedRows[0];
                SelectedProductId = Convert.ToInt32(row.Cells["ID"].Value);
                SelectedProductName = row.Cells["Product"].Value.ToString();
                SelectedPrice = Convert.ToDecimal(row.Cells["Price"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}