using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EvsonHardware.Data;

namespace EvsonHardware
{
    public class ProductSelectionForm : Form
    {
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

            LoadCategories();
            LoadProducts("", 0);
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
                      AND (@catId = 0 OR p.category_id = @catId)
                    ORDER BY ps.product_name;";

                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                cmd.Parameters.AddWithValue("@catId", categoryId);

                var dt = new DataTable();
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            lblTitle.Location = new Point(240, 11);
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
            exitbtn.CustomizableEdges = customizableEdges11;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new Font("Sitka Small", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitbtn.ImageSize = new Size(260, 220);
            exitbtn.Location = new Point(641, -2);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            exitbtn.Size = new Size(41, 48);
            exitbtn.TabIndex = 20;
            exitbtn.Text = "X";
            // 
            // txtSearch
            // 
            txtSearch.CustomizableEdges = customizableEdges13;
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
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges14;
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
            cmbCategory.CustomizableEdges = customizableEdges15;
            cmbCategory.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FillColor = Color.Cornsilk;
            cmbCategory.FocusedColor = Color.Empty;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.ForeColor = Color.DarkGreen;
            cmbCategory.ItemHeight = 30;
            cmbCategory.Location = new Point(508, 10);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.ShadowDecoration.CustomizableEdges = customizableEdges16;
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
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvProducts.BackgroundColor = Color.PaleGoldenrod;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvProducts.ColumnHeadersHeight = 4;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvProducts.DefaultCellStyle = dataGridViewCellStyle6;
            dgvProducts.GridColor = Color.Cornsilk;
            dgvProducts.Location = new Point(15, 140);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.Size = new Size(645, 244);
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
            dgvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvProducts.ThemeStyle.HeaderStyle.Height = 4;
            dgvProducts.ThemeStyle.ReadOnly = false;
            dgvProducts.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvProducts.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvProducts.ThemeStyle.RowsStyle.Height = 25;
            dgvProducts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvProducts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvProducts.DoubleClick += dgvProducts_DoubleClick;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
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
            btnCancel.BorderRadius = 25;
            btnCancel.CustomizableEdges = customizableEdges17;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.IndianRed;
            btnCancel.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(408, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnCancel.Size = new Size(123, 54);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Clcik;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.Transparent;
            btnSelect.BorderRadius = 25;
            btnSelect.CustomizableEdges = customizableEdges19;
            btnSelect.DisabledState.BorderColor = Color.DarkGray;
            btnSelect.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSelect.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSelect.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSelect.FillColor = Color.ForestGreen;
            btnSelect.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(537, 400);
            btnSelect.Name = "btnSelect";
            btnSelect.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSelect.Size = new Size(123, 54);
            btnSelect.TabIndex = 27;
            btnSelect.Text = "Select";
            btnSelect.Click += btnSelect_Click;
            // 
            // ProductSelectionForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(684, 481);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            Controls.Add(lblStock);
            Controls.Add(dgvProducts);
            Controls.Add(guna2ShadowPanel1);
            Controls.Add(exitbtn);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductSelectionForm";
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadProducts(txtSearch.Text, GetSelectedCategoryId());
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
            LoadProducts(txtSearch.Text, GetSelectedCategoryId());
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text, GetSelectedCategoryId());
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            SelectProduct();
        }
    }
}