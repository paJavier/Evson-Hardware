namespace EvsonHardware
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblReorder;
        private System.Windows.Forms.NumericUpDown numReorder;

        private System.Windows.Forms.GroupBox grpRestock;
        private System.Windows.Forms.Label lblSelectedStock;
        private System.Windows.Forms.Label lblRestockQty;
        private System.Windows.Forms.NumericUpDown numRestockQty;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            lblTitle = new Label();
            grpDetails = new GroupBox();
            btnClear = new Guna.UI2.WinForms.Guna2Button();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            lblName = new Label();
            txtName = new TextBox();
            lblBrand = new Label();
            txtBrand = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblReorder = new Label();
            numReorder = new NumericUpDown();
            grpRestock = new GroupBox();
            btnRestock = new Guna.UI2.WinForms.Guna2Button();
            lblSelectedStock = new Label();
            lblRestockQty = new Label();
            numRestockQty = new NumericUpDown();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            dgvInventory = new Guna.UI2.WinForms.Guna2DataGridView();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).BeginInit();
            grpRestock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(26, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inventory Manager";
            // 
            // grpDetails
            // 
            grpDetails.BackColor = Color.Ivory;
            grpDetails.Controls.Add(btnClear);
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(lblName);
            grpDetails.Controls.Add(txtName);
            grpDetails.Controls.Add(lblBrand);
            grpDetails.Controls.Add(txtBrand);
            grpDetails.Controls.Add(lblCategory);
            grpDetails.Controls.Add(cmbCategory);
            grpDetails.Controls.Add(lblUnit);
            grpDetails.Controls.Add(txtUnit);
            grpDetails.Controls.Add(lblPrice);
            grpDetails.Controls.Add(numPrice);
            grpDetails.Controls.Add(lblReorder);
            grpDetails.Controls.Add(numReorder);
            grpDetails.Location = new Point(26, 390);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(542, 200);
            grpDetails.TabIndex = 2;
            grpDetails.TabStop = false;
            grpDetails.Text = "Product Information (Add/Edit)";
            // 
            // btnClear
            // 
            btnClear.BorderRadius = 15;
            btnClear.BorderThickness = 1;
            btnClear.CustomizableEdges = customizableEdges1;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.FillColor = Color.Honeydew;
            btnClear.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.DarkGreen;
            btnClear.Location = new Point(284, 153);
            btnClear.Name = "btnClear";
            btnClear.PressedColor = Color.Green;
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnClear.Size = new Size(108, 29);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderColor = Color.DarkOliveGreen;
            btnSave.BorderRadius = 15;
            btnSave.BorderThickness = 1;
            btnSave.CustomizableEdges = customizableEdges3;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.LimeGreen;
            btnSave.FocusedColor = Color.LightGreen;
            btnSave.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(133, 153);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.SeaGreen;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSave.Size = new Size(108, 29);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save Product";
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(94, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(137, 23);
            txtName.TabIndex = 1;
            // 
            // lblBrand
            // 
            lblBrand.Location = new Point(284, 35);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(50, 28);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "Brand:";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(364, 32);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(135, 23);
            txtBrand.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(20, 75);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 23);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(120, 72);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(137, 23);
            cmbCategory.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(284, 77);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(50, 18);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "Unit:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(364, 72);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(135, 23);
            txtUnit.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(20, 115);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(79, 23);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Retail Price ₱:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(120, 112);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(137, 23);
            numPrice.TabIndex = 9;
            // 
            // lblReorder
            // 
            lblReorder.Location = new Point(284, 115);
            lblReorder.Name = "lblReorder";
            lblReorder.Size = new Size(50, 23);
            lblReorder.TabIndex = 10;
            lblReorder.Text = "Reorder:";
            // 
            // numReorder
            // 
            numReorder.Location = new Point(364, 112);
            numReorder.Name = "numReorder";
            numReorder.Size = new Size(135, 23);
            numReorder.TabIndex = 11;
            // 
            // grpRestock
            // 
            grpRestock.BackColor = Color.Ivory;
            grpRestock.Controls.Add(btnRestock);
            grpRestock.Controls.Add(lblSelectedStock);
            grpRestock.Controls.Add(lblRestockQty);
            grpRestock.Controls.Add(numRestockQty);
            grpRestock.Location = new Point(574, 390);
            grpRestock.Name = "grpRestock";
            grpRestock.Size = new Size(299, 200);
            grpRestock.TabIndex = 3;
            grpRestock.TabStop = false;
            grpRestock.Text = "Quick Restock (Incoming Delivery)";
            // 
            // btnRestock
            // 
            btnRestock.BorderRadius = 15;
            btnRestock.BorderThickness = 1;
            btnRestock.CustomizableEdges = customizableEdges5;
            btnRestock.DisabledState.BorderColor = Color.DarkGray;
            btnRestock.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRestock.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRestock.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRestock.FillColor = Color.SeaGreen;
            btnRestock.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestock.ForeColor = Color.White;
            btnRestock.Location = new Point(102, 153);
            btnRestock.Name = "btnRestock";
            btnRestock.PressedColor = Color.LightGreen;
            btnRestock.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnRestock.Size = new Size(112, 29);
            btnRestock.TabIndex = 16;
            btnRestock.Text = "Add Stock";
            btnRestock.Click += btnRestock_Click;
            // 
            // lblSelectedStock
            // 
            lblSelectedStock.AutoSize = true;
            lblSelectedStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedStock.ForeColor = Color.DarkGreen;
            lblSelectedStock.Location = new Point(20, 40);
            lblSelectedStock.Name = "lblSelectedStock";
            lblSelectedStock.Size = new Size(124, 19);
            lblSelectedStock.TabIndex = 0;
            lblSelectedStock.Text = "Selected Stock: 0";
            // 
            // lblRestockQty
            // 
            lblRestockQty.Location = new Point(20, 90);
            lblRestockQty.Name = "lblRestockQty";
            lblRestockQty.Size = new Size(100, 23);
            lblRestockQty.TabIndex = 1;
            lblRestockQty.Text = "Quantity Delivered:";
            // 
            // numRestockQty
            // 
            numRestockQty.Location = new Point(150, 88);
            numRestockQty.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numRestockQty.Name = "numRestockQty";
            numRestockQty.Size = new Size(100, 23);
            numRestockQty.TabIndex = 2;
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BackColor = Color.Transparent;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.CustomizableEdges = customizableEdges7;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitbtn.ImageSize = new Size(260, 220);
            exitbtn.Location = new Point(868, 5);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            exitbtn.Size = new Size(30, 38);
            exitbtn.TabIndex = 19;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // dgvInventory
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventory.BackgroundColor = Color.Ivory;
            dgvInventory.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventory.ColumnHeadersHeight = 28;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvInventory.DefaultCellStyle = dataGridViewCellStyle3;
            dgvInventory.GridColor = Color.LemonChiffon;
            dgvInventory.Location = new Point(30, 66);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.Size = new Size(840, 302);
            dgvInventory.TabIndex = 20;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvInventory.ThemeStyle.BackColor = Color.Ivory;
            dgvInventory.ThemeStyle.GridColor = Color.LemonChiffon;
            dgvInventory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvInventory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvInventory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvInventory.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvInventory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvInventory.ThemeStyle.HeaderStyle.Height = 28;
            dgvInventory.ThemeStyle.ReadOnly = false;
            dgvInventory.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvInventory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvInventory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvInventory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvInventory.ThemeStyle.RowsStyle.Height = 25;
            dgvInventory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvInventory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvInventory.CellClick += dgvInventory_CellClick;
            // 
            // InventoryForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(904, 620);
            Controls.Add(dgvInventory);
            Controls.Add(exitbtn);
            Controls.Add(lblTitle);
            Controls.Add(grpDetails);
            Controls.Add(grpRestock);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware - Inventory";
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).EndInit();
            grpRestock.ResumeLayout(false);
            grpRestock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna.UI2.WinForms.Guna2Button exitbtn;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInventory;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnRestock;
    }
}
