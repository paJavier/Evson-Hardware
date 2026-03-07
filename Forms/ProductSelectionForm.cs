using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using EvsonHardware.Data;
using EvsonHardware.Forms;

namespace EvsonHardware
{
    public class ProductSelectionForm : Form
    {
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button exitbtn;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSearch;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private System.ComponentModel.IContainer components;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvProducts;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStock;
        private Guna.UI2.WinForms.Guna2Button btnSelect;
        private Guna.UI2.WinForms.Guna2Button btnCancel;

        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public decimal SelectedPrice { get; private set; }
        public int AvailableStock { get; private set; }

        public ProductSelectionForm()
        {
            InitializeComponent();
            ApplyGridTheme();

            LoadCategories();
            LoadProducts("", "");
        }

        private void ApplyGridTheme()
        {
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.BackgroundColor = Color.Ivory;
            dgvProducts.BorderStyle = BorderStyle.FixedSingle;
            dgvProducts.GridColor = Color.FromArgb(214, 223, 118);

            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            dgvProducts.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvProducts.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvProducts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);

            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                var all = dt.NewRow();
                all["category_id"] = 0;
                all["category_name"] = "All Categories";
                dt.Rows.InsertAt(all, 0);

                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex) { CustomMessageBox.Show("LoadCategories error: " + ex.Message, "Error"); }
        }

        private string GetSelectedCategoryName()
        {
            if (cmbCategory.SelectedItem is DataRowView row)
            {
                string name = row["category_name"]?.ToString()?.Trim() ?? "";
                return string.Equals(name, "All Categories", StringComparison.OrdinalIgnoreCase) ? "" : name;
            }
            return "";
        }

        private void LoadProducts(string search, string categoryName)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    SELECT
                        ps.product_id    AS ID,
                        ps.product_name  AS Product,
                        ps.category_name AS Category,
                        p.unit           AS Unit,
                        ps.price         AS Price,
                        ps.stock         AS Stock
                    FROM product_stock ps
                    JOIN product p ON ps.product_id = p.product_id
                    WHERE ps.product_name LIKE @search
                      AND (@catName = '' OR LOWER(TRIM(ps.category_name)) = LOWER(TRIM(@catName)))
                    ORDER BY ps.product_name;";

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@catName", categoryName);

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                dgvProducts.DataSource = dt;
                if (dgvProducts.Columns["Price"] != null)
                {
                    dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2";
                    dgvProducts.Columns["Price"].DefaultCellStyle.FormatProvider = PhCulture;
                    dgvProducts.Columns["Price"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                }
                if (dgvProducts.Rows.Count > 0)
                {
                    dgvProducts.FirstDisplayedScrollingRowIndex = 0;
                }

                if (dgvProducts.Columns["ID"] != null)
                    dgvProducts.Columns["ID"].Visible = false;

                lblStock.Text = $"{dt.Rows.Count} product(s) found";
            }
            catch (Exception ex) { CustomMessageBox.Show("LoadProducts error: " + ex.Message, "Error"); }
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
                CustomMessageBox.Show("Please select a product first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            int stock = Convert.ToInt32(row.Cells["Stock"].Value);

            if (stock <= 0)
            {
                CustomMessageBox.Show("This product is out of stock. Please restock it in Inventory first.",
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


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSelectionForm));
            lblTitle = new Label();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            lblSearch = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cmbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            dgvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            lblStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            btnSelect = new Guna.UI2.WinForms.Guna2Button();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(165, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Product Search";
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BackColor = Color.Transparent;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.CustomizableEdges = customizableEdges1;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new Font("Sitka Small", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitbtn.ImageSize = new Size(260, 220);
            exitbtn.Location = new Point(651, 3);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            exitbtn.Size = new Size(32, 34);
            exitbtn.TabIndex = 20;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // txtSearch
            // 
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FillColor = Color.Cornsilk;
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.DarkGreen;
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(81, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(335, 30);
            txtSearch.TabIndex = 21;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Font = new Font("Sitka Display", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.ForeColor = Color.DarkGreen;
            lblSearch.Location = new Point(25, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(50, 23);
            lblSearch.TabIndex = 22;
            lblSearch.Text = "Search:";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(cmbCategory);
            guna2ShadowPanel1.Controls.Add(guna2HtmlLabel1);
            guna2ShadowPanel1.Controls.Add(txtSearch);
            guna2ShadowPanel1.Controls.Add(lblSearch);
            guna2ShadowPanel1.FillColor = Color.PaleGoldenrod;
            guna2ShadowPanel1.Location = new Point(-2, 65);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(688, 59);
            guna2ShadowPanel1.TabIndex = 23;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.PaleGoldenrod;
            cmbCategory.BorderColor = Color.Transparent;
            cmbCategory.BorderThickness = 0;
            cmbCategory.CustomizableEdges = customizableEdges5;
            cmbCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FillColor = Color.Cornsilk;
            cmbCategory.FocusedColor = Color.Empty;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.ForeColor = Color.DarkGreen;
            cmbCategory.ItemHeight = 30;
            cmbCategory.Location = new Point(508, 10);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbCategory.Size = new Size(140, 36);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Sitka Display", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.DarkGreen;
            guna2HtmlLabel1.Location = new Point(438, 14);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(64, 23);
            guna2HtmlLabel1.TabIndex = 23;
            guna2HtmlLabel1.Text = "Category:";
            // 
            // dgvProducts
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.BackgroundColor = Color.PaleGoldenrod;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeight = 28;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducts.GridColor = Color.Cornsilk;
            dgvProducts.Location = new Point(15, 140);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.Size = new Size(657, 245);
            dgvProducts.TabIndex = 24;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvProducts.ThemeStyle.BackColor = Color.PaleGoldenrod;
            dgvProducts.ThemeStyle.GridColor = Color.Cornsilk;
            dgvProducts.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvProducts.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProducts.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProducts.ThemeStyle.HeaderStyle.Height = 28;
            dgvProducts.ThemeStyle.ReadOnly = false;
            dgvProducts.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvProducts.ThemeStyle.RowsStyle.Height = 25;
            dgvProducts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvProducts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            dgvProducts.DoubleClick += dgvProducts_DoubleClick;
            // 
            // lblStock
            // 
            lblStock.BackColor = Color.Transparent;
            lblStock.Font = new Font("Sitka Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.ForeColor = Color.Honeydew;
            lblStock.Location = new Point(15, 419);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 25);
            lblStock.TabIndex = 25;
            lblStock.Text = "Stock";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderColor = Color.WhiteSmoke;
            btnCancel.BorderRadius = 25;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = customizableEdges7;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.IndianRed;
            btnCancel.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(420, 403);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancel.Size = new Size(123, 54);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Clcik;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.Transparent;
            btnSelect.BorderColor = Color.WhiteSmoke;
            btnSelect.BorderRadius = 25;
            btnSelect.BorderThickness = 1;
            btnSelect.CustomizableEdges = customizableEdges9;
            btnSelect.DisabledState.BorderColor = Color.DarkGray;
            btnSelect.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSelect.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSelect.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSelect.FillColor = Color.ForestGreen;
            btnSelect.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(549, 403);
            btnSelect.Name = "btnSelect";
            btnSelect.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSelect.Size = new Size(123, 54);
            btnSelect.TabIndex = 27;
            btnSelect.Text = "Select";
            btnSelect.Click += btnSelect_Click;
            // 
            // ProductSelectionForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(688, 481);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            Controls.Add(lblStock);
            Controls.Add(dgvProducts);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(exitbtn);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadProducts(txtSearch.Text, GetSelectedCategoryName());
        }

        private void btnCancel_Clcik(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private Guna.UI2.WinForms.Guna2ComboBox cmbCategory;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text, GetSelectedCategoryName());
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text, GetSelectedCategoryName());
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



