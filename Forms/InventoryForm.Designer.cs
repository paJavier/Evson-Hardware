namespace EvsonHardware
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvInventory;
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.GroupBox grpRestock;
        private System.Windows.Forms.Label lblSelectedStock;
        private System.Windows.Forms.Label lblRestockQty;
        private System.Windows.Forms.NumericUpDown numRestockQty;
        private System.Windows.Forms.Button btnRestock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryForm));
            lblTitle = new Label();
            dgvInventory = new DataGridView();
            grpDetails = new GroupBox();
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
            btnSave = new Button();
            btnClear = new Button();
            grpRestock = new GroupBox();
            lblSelectedStock = new Label();
            lblRestockQty = new Label();
            numRestockQty = new NumericUpDown();
            btnRestock = new Button();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).BeginInit();
            grpRestock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inventory Manager";
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = Color.Beige;
            dgvInventory.ColumnHeadersHeight = 34;
            dgvInventory.Location = new Point(26, 70);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(930, 300);
            dgvInventory.TabIndex = 1;
            dgvInventory.CellClick += dgvInventory_CellClick;
            // 
            // grpDetails
            // 
            grpDetails.BackColor = Color.Ivory;
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
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(btnClear);
            grpDetails.Location = new Point(26, 390);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(580, 200);
            grpDetails.TabIndex = 2;
            grpDetails.TabStop = false;
            grpDetails.Text = "Product Information (Add/Edit)";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Product Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 1;
            // 
            // lblBrand
            // 
            lblBrand.Location = new Point(300, 35);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(74, 28);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "Brand:";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(380, 32);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(150, 23);
            txtBrand.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(20, 75);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 4;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(120, 72);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 5;
            // 
            // lblUnit
            // 
            lblUnit.Location = new Point(300, 77);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(61, 28);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "Unit:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(380, 72);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(150, 23);
            txtUnit.TabIndex = 7;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(20, 115);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Retail Price ₱:";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(120, 112);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 23);
            numPrice.TabIndex = 9;
            // 
            // lblReorder
            // 
            lblReorder.Location = new Point(300, 115);
            lblReorder.Name = "lblReorder";
            lblReorder.Size = new Size(74, 32);
            lblReorder.TabIndex = 10;
            lblReorder.Text = "Reorder:";
            // 
            // numReorder
            // 
            numReorder.Location = new Point(380, 112);
            numReorder.Name = "numReorder";
            numReorder.Size = new Size(150, 23);
            numReorder.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(120, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save Product";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(230, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear Fields";
            btnClear.Click += btnClear_Click;
            // 
            // grpRestock
            // 
            grpRestock.BackColor = Color.Ivory;
            grpRestock.Controls.Add(lblSelectedStock);
            grpRestock.Controls.Add(lblRestockQty);
            grpRestock.Controls.Add(numRestockQty);
            grpRestock.Controls.Add(btnRestock);
            grpRestock.Location = new Point(630, 390);
            grpRestock.Name = "grpRestock";
            grpRestock.Size = new Size(326, 200);
            grpRestock.TabIndex = 3;
            grpRestock.TabStop = false;
            grpRestock.Text = "Quick Restock (Incoming Delivery)";
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
            // btnRestock
            // 
            btnRestock.BackColor = Color.YellowGreen;
            btnRestock.ForeColor = Color.White;
            btnRestock.Location = new Point(150, 130);
            btnRestock.Name = "btnRestock";
            btnRestock.Size = new Size(100, 40);
            btnRestock.TabIndex = 3;
            btnRestock.Text = "Add Stock";
            btnRestock.UseVisualStyleBackColor = false;
            btnRestock.Click += btnRestock_Click;
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
            exitbtn.Location = new Point(927, 3);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            exitbtn.Size = new Size(41, 48);
            exitbtn.TabIndex = 19;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // InventoryForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(980, 620);
            Controls.Add(exitbtn);
            Controls.Add(lblTitle);
            Controls.Add(dgvInventory);
            Controls.Add(grpDetails);
            Controls.Add(grpRestock);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware - Inventory";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).EndInit();
            grpRestock.ResumeLayout(false);
            grpRestock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRestockQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna.UI2.WinForms.Guna2Button exitbtn;
    }
}