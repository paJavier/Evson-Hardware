using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public class ProductSelectionForm : Form
    {
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private DataGridView dgvProducts;
        private Button btnSelect;
        private Button btnCancel;
        private Label lblStock;

        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public decimal SelectedPrice { get; private set; }
        public int AvailableStock { get; private set; }

        public ProductSelectionForm()
        {
            InitializeUI();
            LoadCategories();
            LoadProducts("", 0);
        }

        private void InitializeUI()
        {
            Text = "Select Product";
            Size = new Size(700, 520);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(245, 247, 250);

            var lblTitle = new Label { Text = "Product Search", Font = new Font("Segoe UI", 14F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 30, 60), Location = new Point(20, 15), AutoSize = true };
            var lblSearch = new Label { Text = "Search:", Location = new Point(20, 58), AutoSize = true, Font = new Font("Segoe UI", 9F) };

            txtSearch = new TextBox { Location = new Point(75, 55), Size = new Size(300, 24), Font = new Font("Segoe UI", 9.5F) };
            txtSearch.TextChanged += (s, e) => LoadProducts(txtSearch.Text, GetSelectedCategoryId());

            var lblCat = new Label { Text = "Category:", Location = new Point(390, 58), AutoSize = true, Font = new Font("Segoe UI", 9F) };

            cmbCategory = new ComboBox { Location = new Point(460, 55), Size = new Size(200, 24), Font = new Font("Segoe UI", 9.5F), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.SelectedIndexChanged += (s, e) => LoadProducts(txtSearch.Text, GetSelectedCategoryId());

            dgvProducts = new DataGridView
            {
                Location = new Point(20, 90),
                Size = new Size(640, 320),
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                Font = new Font("Segoe UI", 9F),
                GridColor = Color.FromArgb(220, 225, 235),
                MultiSelect = false
            };
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 60);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            dgvProducts.DoubleClick += (s, e) => SelectProduct();

            lblStock = new Label { Text = "", Location = new Point(20, 420), Size = new Size(460, 22), Font = new Font("Segoe UI", 9F, FontStyle.Italic) };

            btnCancel = new Button { Text = "Cancel", Location = new Point(460, 415), Size = new Size(90, 34), Font = new Font("Segoe UI", 9.5F), BackColor = Color.FromArgb(220, 220, 230), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            btnSelect = new Button { Text = "Select Product", Location = new Point(562, 415), Size = new Size(120, 34), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), BackColor = Color.FromArgb(30, 30, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, e) => SelectProduct();

            Controls.AddRange(new Control[] { lblTitle, lblSearch, txtSearch, lblCat, cmbCategory, dgvProducts, lblStock, btnCancel, btnSelect });
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

                var all = dt.NewRow();
                all["category_id"] = 0;
                all["category_name"] = "All Categories";
                dt.Rows.InsertAt(all, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("LoadCategories error: " + ex.Message); }
        }

        private int GetSelectedCategoryId()
        {
            if (cmbCategory.SelectedItem is DataRowView row)
                return Convert.ToInt32(row["category_id"]);
            return 0;
        }

        private void LoadProducts(string search, int categoryId)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                // product_stock view: product_id, product_name, price, category_name, stock
                // JOIN product for: unit, brandname
                cmd.CommandText = @"
                    SELECT
                        ps.product_id    AS ID,
                        ps.product_name  AS Product,
                        ps.category_name AS Category,
                        p.brandname      AS Brand,
                        p.unit           AS Unit,
                        ps.price         AS Price,
                        ps.stock         AS Stock
                    FROM product_stock ps
                    JOIN product p ON ps.product_id = p.product_id
                    WHERE ps.product_name LIKE @search
                      AND (@catId = 0 OR p.category_id = @catId)
                    ORDER BY ps.product_name;";

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@catId", categoryId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvProducts.DataSource = dt;

                if (dgvProducts.Columns["ID"] != null)
                    dgvProducts.Columns["ID"].Visible = false;

                lblStock.Text = $"{dt.Rows.Count} product(s) found";
            }
            catch (Exception ex) { MessageBox.Show("LoadProducts error: " + ex.Message); }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) return;

            var row = dgvProducts.SelectedRows[0];
            int stock = Convert.ToInt32(row.Cells["Stock"].Value);
            string unit = row.Cells["Unit"].Value?.ToString() ?? "pcs";
            string name = row.Cells["Product"].Value?.ToString() ?? "";

            if (stock <= 0)
            { lblStock.Text = $"⚠ {name} — Out of stock"; lblStock.ForeColor = Color.FromArgb(200, 60, 60); }
            else if (stock <= 5)
            { lblStock.Text = $"⚠ {name} — Low stock: {stock} {unit}"; lblStock.ForeColor = Color.FromArgb(200, 130, 0); }
            else
            { lblStock.Text = $"✔ {name} — {stock} {unit} available"; lblStock.ForeColor = Color.FromArgb(0, 128, 80); }
        }

        private void SelectProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            int stock = Convert.ToInt32(row.Cells["Stock"].Value);

            if (stock <= 0)
            {
                MessageBox.Show("This product is out of stock. Please restock it in Inventory first.",
                    "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedProductId = Convert.ToInt32(row.Cells["ID"].Value);
            SelectedProductName = row.Cells["Product"].Value.ToString();
            SelectedPrice = Convert.ToDecimal(row.Cells["Price"].Value);
            AvailableStock = stock;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}