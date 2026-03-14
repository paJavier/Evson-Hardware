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
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblReorder;

        private System.Windows.Forms.GroupBox grpRestock;
        private System.Windows.Forms.Label lblSelectedStock;
        private System.Windows.Forms.Label lblRestockQty;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            lblTitle = new Label();
            grpDetails = new GroupBox();
            numPrice1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            numReorder1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
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
            lblReorder = new Label();
            grpRestock = new GroupBox();
            numRestockQty1 = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnRestock = new Guna.UI2.WinForms.Guna2Button();
            lblSelectedStock = new Label();
            lblRestockQty = new Label();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            dgvInventory = new Guna.UI2.WinForms.Guna2DataGridView();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorder1).BeginInit();
            grpRestock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Banner", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(270, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inventory Manager";
            // 
            // grpDetails
            // 
            grpDetails.BackColor = Color.Ivory;
            grpDetails.Controls.Add(numPrice1);
            grpDetails.Controls.Add(numReorder1);
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
            grpDetails.Controls.Add(lblReorder);
            grpDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.Location = new Point(20, 300);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(520, 226);
            grpDetails.TabIndex = 2;
            grpDetails.TabStop = false;
            grpDetails.Text = "Product Information (Add/Edit)";
            // 
            // numPrice1
            // 
            numPrice1.BackColor = Color.Transparent;
            numPrice1.BorderColor = Color.DarkGreen;
            numPrice1.BorderRadius = 5;
            numPrice1.Cursor = Cursors.IBeam;
            numPrice1.CustomizableEdges = customizableEdges1;
            numPrice1.DecimalPlaces = 2;
            numPrice1.Font = new Font("Segoe UI", 9F);
            numPrice1.ForeColor = Color.DarkGreen;
            numPrice1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numPrice1.Location = new Point(140, 126);
            numPrice1.Margin = new Padding(4, 3, 4, 3);
            numPrice1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice1.Name = "numPrice1";
            numPrice1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            numPrice1.Size = new Size(140, 32);
            numPrice1.TabIndex = 18;
            numPrice1.UpDownButtonFillColor = Color.DarkOliveGreen;
            // 
            // numReorder1
            // 
            numReorder1.BackColor = Color.Transparent;
            numReorder1.BorderColor = Color.DarkGreen;
            numReorder1.BorderRadius = 5;
            numReorder1.Cursor = Cursors.IBeam;
            numReorder1.CustomizableEdges = customizableEdges3;
            numReorder1.Font = new Font("Segoe UI", 9F);
            numReorder1.ForeColor = Color.DarkGreen;
            numReorder1.Location = new Point(360, 126);
            numReorder1.Margin = new Padding(4, 3, 4, 3);
            numReorder1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numReorder1.Name = "numReorder1";
            numReorder1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numReorder1.Size = new Size(125, 32);
            numReorder1.TabIndex = 17;
            numReorder1.UpDownButtonFillColor = Color.DarkOliveGreen;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BorderRadius = 10;
            btnDelete.BorderThickness = 1;
            btnDelete.CustomizableEdges = customizableEdges9;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.Firebrick;
            btnDelete.FocusedColor = Color.LightGreen;
            btnDelete.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(20, 154);
            btnDelete.Name = "btnDelete";
            btnDelete.PressedColor = Color.SeaGreen;
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnDelete.Size = new Size(110, 40);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete Product";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BorderRadius = 10;
            btnClear.BorderThickness = 1;
            btnClear.CustomizableEdges = customizableEdges5;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.FillColor = Color.Honeydew;
            btnClear.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.DarkGreen;
            btnClear.Location = new Point(274, 175);
            btnClear.Name = "btnClear";
            btnClear.PressedColor = Color.Green;
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnClear.Size = new Size(105, 34);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BorderRadius = 10;
            btnSave.BorderThickness = 1;
            btnSave.CustomizableEdges = customizableEdges7;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.DarkOliveGreen;
            btnSave.FocusedColor = Color.LightGreen;
            btnSave.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(140, 175);
            btnSave.Name = "btnSave";
            btnSave.PressedColor = Color.SeaGreen;
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnSave.Size = new Size(110, 34);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save Product";
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(25, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(160, 31);
            txtName.TabIndex = 1;
            // 
            // lblBrand
            // 
            lblBrand.Location = new Point(305, 40);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(60, 23);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "Brand:";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(360, 37);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(135, 31);
            txtBrand.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(25, 85);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 23);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(140, 82);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(160, 33);
            cmbCategory.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(305, 85);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(50, 18);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "Unit:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(360, 82);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(135, 31);
            txtUnit.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(25, 130);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(79, 23);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Retail Price ?:";
            // 
            // lblReorder
            // 
            lblReorder.Location = new Point(305, 130);
            lblReorder.Name = "lblReorder";
            lblReorder.Size = new Size(50, 23);
            lblReorder.TabIndex = 10;
            lblReorder.Text = "Reorder:";
            // 
            // grpRestock
            // 
            grpRestock.BackColor = Color.Ivory;
            grpRestock.Controls.Add(numRestockQty1);
            grpRestock.Controls.Add(btnRestock);
            grpRestock.Controls.Add(btnDelete);
            grpRestock.Controls.Add(lblSelectedStock);
            grpRestock.Controls.Add(lblRestockQty);
            grpRestock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRestock.Location = new Point(560, 300);
            grpRestock.Name = "grpRestock";
            grpRestock.Size = new Size(300, 226);
            grpRestock.TabIndex = 3;
            grpRestock.TabStop = false;
            grpRestock.Text = "Quick Restock (Incoming Delivery) & Delete Stock";
            // 
            // numRestockQty1
            // 
            numRestockQty1.BackColor = Color.Transparent;
            numRestockQty1.BorderColor = Color.DarkGreen;
            numRestockQty1.BorderRadius = 5;
            numRestockQty1.Cursor = Cursors.IBeam;
            numRestockQty1.CustomizableEdges = customizableEdges11;
            numRestockQty1.Font = new Font("Segoe UI", 9F);
            numRestockQty1.ForeColor = Color.DarkGreen;
            numRestockQty1.Location = new Point(170, 100);
            numRestockQty1.Margin = new Padding(4, 3, 4, 3);
            numRestockQty1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numRestockQty1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRestockQty1.Name = "numRestockQty1";
            numRestockQty1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            numRestockQty1.Size = new Size(90, 30);
            numRestockQty1.TabIndex = 19;
            numRestockQty1.UpDownButtonFillColor = Color.DarkOliveGreen;
            numRestockQty1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnRestock
            // 
            btnRestock.BorderRadius = 10;
            btnRestock.BorderThickness = 1;
            btnRestock.CustomizableEdges = customizableEdges13;
            btnRestock.DisabledState.BorderColor = Color.DarkGray;
            btnRestock.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRestock.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRestock.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRestock.FillColor = Color.DarkGreen;
            btnRestock.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestock.ForeColor = Color.White;
            btnRestock.Location = new Point(160, 154);
            btnRestock.Name = "btnRestock";
            btnRestock.PressedColor = Color.LightGreen;
            btnRestock.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnRestock.Size = new Size(110, 40);
            btnRestock.TabIndex = 16;
            btnRestock.Text = "Add Stock";
            btnRestock.Click += btnRestock_Click;
            // 
            // lblSelectedStock
            // 
            lblSelectedStock.AutoSize = true;
            lblSelectedStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedStock.ForeColor = Color.DarkGreen;
            lblSelectedStock.Location = new Point(20, 53);
            lblSelectedStock.Name = "lblSelectedStock";
            lblSelectedStock.Size = new Size(157, 25);
            lblSelectedStock.TabIndex = 0;
            lblSelectedStock.Text = "Selected Stock: 0";
            // 
            // lblRestockQty
            // 
            lblRestockQty.Location = new Point(20, 100);
            lblRestockQty.Name = "lblRestockQty";
            lblRestockQty.Size = new Size(100, 23);
            lblRestockQty.TabIndex = 1;
            lblRestockQty.Text = "Quantity Delivered:";
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BackColor = Color.Transparent;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.CustomizableEdges = customizableEdges15;
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
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges16;
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
            dgvInventory.Location = new Point(20, 60);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.RowTemplate.Height = 25;
            dgvInventory.Size = new Size(860, 210);
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
            ClientSize = new Size(904, 556);
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
            ((System.ComponentModel.ISupportInitialize)numPrice1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorder1).EndInit();
            grpRestock.ResumeLayout(false);
            grpRestock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna.UI2.WinForms.Guna2Button exitbtn;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInventory;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnRestock;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2NumericUpDown numReorder1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPrice1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numRestockQty1;
    }
}


