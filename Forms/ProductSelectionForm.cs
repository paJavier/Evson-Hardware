using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public class ProductSelectionForm : Form
    {
        // ── UI Controls ──────────────────────────────────────────────
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private DataGridView dgvProducts;
        private Button btnSelect;
        private Button btnCancel;
        private Label lblStock;

        // ── Selected Product Properties ──────────────────────────────
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
            this.Text = "Select Product";
            this.Size = new Size(700, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // ── Title ─────────────────────────────────────────────────
            var lblTitle = new Label()
            {
                Text = "Product Search",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                Location = new Point(20, 15),
                AutoSize = true
            };

            // ── Search Bar ────────────────────────────────────────────
            var lblSearch = new Label()
            {
                Text = "Search:",
                Location = new Point(20, 58),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(80, 80, 100)
            };

            txtSearch = new TextBox()
            {
                Location = new Point(75, 55),
                Size = new Size(300, 24),
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += (s, e) => LoadProducts(txtSearch.Text, GetSelectedCategoryId());

            // ── Category Filter ───────────────────────────────────────
            var lblCat = new Label()
            {
                Text = "Category:",
                Location = new Point(390, 58),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(80, 80, 100)
            };

            cmbCategory = new ComboBox()
            {
                Location = new Point(460, 55),
                Size = new Size(200, 24),
                Font = new Font("Segoe UI", 9.5F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.SelectedIndexChanged += (s, e) => LoadProducts(txtSearch.Text, GetSelectedCategoryId());

            // ── Product Grid ──────────────────────────────────────────
            dgvProducts = new DataGridView()
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

            // ── Stock Info Label ──────────────────────────────────────
            lblStock = new Label()
            {
                Text = "",
                Location = new Point(20, 420),
                Size = new Size(460, 22),
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(0, 128, 80)
            };

            // ── Buttons ───────────────────────────────────────────────
            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(460, 415),
                Size = new Size(90, 34),
                Font = new Font("Segoe UI", 9.5F),
                BackColor = Color.FromArgb(220, 220, 230),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(50, 50, 70),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            btnSelect = new Button()
            {
                Text = "Select Product",
                Location = new Point(562, 415),
                Size = new Size(120, 34),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 30, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, e) => SelectProduct();

            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblSearch, txtSearch, lblCat, cmbCategory,
                dgvProducts, lblStock, btnCancel, btnSelect
            });
        }

        // ── Load category dropdown ────────────────────────────────────
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

                // Add "All Categories" row at top
                var allRow = dt.NewRow();
                allRow["category_id"] = 0;
                allRow["category_name"] = "All Categories";
                dt.Rows.InsertAt(allRow, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        // ── Fix: use SelectedItem cast to DataRowView ─────────────────
        private int GetSelectedCategoryId()
        {
            if (cmbCategory.SelectedItem == null) return 0;
            var row = cmbCategory.SelectedItem as DataRowView;
            if (row == null) return 0;
            return Convert.ToInt32(row["category_id"]);
        }

        // ── Load products from inventory (stock > 0 only) ─────────────
        // Note: Return_Details and Adjustment_Details excluded until
        // those modules are built. Add them back in when ready.
        private void LoadProducts(string search, int categoryId)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT * FROM (
                        SELECT 
                            p.product_id    AS ID,
                            p.product_name  AS Product,
                            c.category_name AS Category,
                            p.brandname     AS Brand,
                            p.unit          AS Unit,
                            p.price         AS Price,
                            (
                                COALESCE((SELECT SUM(quantity) FROM Supply_Details WHERE product_id = p.product_id), 0)
                              - COALESCE((SELECT SUM(quantity) FROM Sales_Details  WHERE product_id = p.product_id), 0)
                            ) AS Stock
                        FROM Product p
                        LEFT JOIN Category c ON p.category_id = c.category_id
                        WHERE p.product_name LIKE @search
                          AND (@catId = 0 OR p.category_id = @catId)
                    ) WHERE Stock > 0
                    ORDER BY Product;";

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@catId", categoryId);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvProducts.DataSource = dt;

                // Hide the raw ID column
                if (dgvProducts.Columns["ID"] != null)
                    dgvProducts.Columns["ID"].Visible = false;

                lblStock.Text = $"{dt.Rows.Count} product(s) found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }

        // ── Update stock label on row selection ───────────────────────
        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var row = dgvProducts.SelectedRows[0];
                int stock = Convert.ToInt32(row.Cells["Stock"].Value);
                string unit = row.Cells["Unit"].Value?.ToString() ?? "pcs";
                string name = row.Cells["Product"].Value?.ToString() ?? "";

                lblStock.Text = $"✔ {name}  —  {stock} {unit} available";
                lblStock.ForeColor = stock <= 5
                    ? Color.FromArgb(200, 60, 60)
                    : Color.FromArgb(0, 128, 80);
            }
        }

        // ── Confirm selection and return to SalesForm ─────────────────
        private void SelectProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            SelectedProductId = Convert.ToInt32(row.Cells["ID"].Value);
            SelectedProductName = row.Cells["Product"].Value.ToString();
            SelectedPrice = Convert.ToDecimal(row.Cells["Price"].Value);
            AvailableStock = Convert.ToInt32(row.Cells["Stock"].Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}