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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblReorder = new System.Windows.Forms.Label();
            this.numReorder = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.grpRestock = new System.Windows.Forms.GroupBox();
            this.lblSelectedStock = new System.Windows.Forms.Label();
            this.lblRestockQty = new System.Windows.Forms.Label();
            this.numRestockQty = new System.Windows.Forms.NumericUpDown();
            this.btnRestock = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockQty)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.grpRestock.SuspendLayout();
            this.SuspendLayout();

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Inventory Manager";

            // DataGridView
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.Location = new System.Drawing.Point(26, 70);
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(930, 300);
            this.dgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellClick);

            // GroupBox - Details
            this.grpDetails.Location = new System.Drawing.Point(26, 390);
            this.grpDetails.Size = new System.Drawing.Size(580, 200);
            this.grpDetails.Text = "Product Information (Add/Edit)";

            this.lblName.Location = new System.Drawing.Point(20, 35);
            this.lblName.Text = "Product Name:";
            this.txtName.Location = new System.Drawing.Point(120, 32);
            this.txtName.Size = new System.Drawing.Size(150, 22);

            this.lblBrand.Location = new System.Drawing.Point(300, 35);
            this.lblBrand.Text = "Brand:";
            this.txtBrand.Location = new System.Drawing.Point(380, 32);
            this.txtBrand.Size = new System.Drawing.Size(150, 22);

            this.lblCategory.Location = new System.Drawing.Point(20, 75);
            this.lblCategory.Text = "Category:";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(120, 72);
            this.cmbCategory.Size = new System.Drawing.Size(150, 24);

            this.lblUnit.Location = new System.Drawing.Point(300, 75);
            this.lblUnit.Text = "Unit (e.g. pcs):";
            this.txtUnit.Location = new System.Drawing.Point(380, 72);
            this.txtUnit.Size = new System.Drawing.Size(150, 22);
            this.txtUnit.Text = "pcs";

            this.lblPrice.Location = new System.Drawing.Point(20, 115);
            this.lblPrice.Text = "Retail Price ₱:";
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPrice.Location = new System.Drawing.Point(120, 112);
            this.numPrice.Size = new System.Drawing.Size(150, 22);

            this.lblReorder.Location = new System.Drawing.Point(300, 115);
            this.lblReorder.Text = "Reorder Alert At:";
            this.numReorder.Location = new System.Drawing.Point(380, 112);
            this.numReorder.Size = new System.Drawing.Size(150, 22);
            this.numReorder.Value = new decimal(new int[] { 10, 0, 0, 0 });

            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 150);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Save Product";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClear.Location = new System.Drawing.Point(230, 150);
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.Text = "Clear Fields";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.lblBrand);
            this.grpDetails.Controls.Add(this.txtBrand);
            this.grpDetails.Controls.Add(this.lblCategory);
            this.grpDetails.Controls.Add(this.cmbCategory);
            this.grpDetails.Controls.Add(this.lblUnit);
            this.grpDetails.Controls.Add(this.txtUnit);
            this.grpDetails.Controls.Add(this.lblPrice);
            this.grpDetails.Controls.Add(this.numPrice);
            this.grpDetails.Controls.Add(this.lblReorder);
            this.grpDetails.Controls.Add(this.numReorder);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.btnClear);

            // GroupBox - Quick Restock
            this.grpRestock.Location = new System.Drawing.Point(630, 390);
            this.grpRestock.Size = new System.Drawing.Size(326, 200);
            this.grpRestock.Text = "Quick Restock (Incoming Delivery)";

            this.lblSelectedStock.AutoSize = true;
            this.lblSelectedStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedStock.Location = new System.Drawing.Point(20, 40);
            this.lblSelectedStock.Text = "Selected Stock: 0";
            this.lblSelectedStock.ForeColor = System.Drawing.Color.DarkGreen;

            this.lblRestockQty.Location = new System.Drawing.Point(20, 90);
            this.lblRestockQty.Text = "Quantity Delivered:";

            this.numRestockQty.Location = new System.Drawing.Point(150, 88);
            this.numRestockQty.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numRestockQty.Size = new System.Drawing.Size(100, 22);

            this.btnRestock.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRestock.ForeColor = System.Drawing.Color.White;
            this.btnRestock.Location = new System.Drawing.Point(150, 130);
            this.btnRestock.Size = new System.Drawing.Size(100, 40);
            this.btnRestock.Text = "Add Stock";
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);

            this.grpRestock.Controls.Add(this.lblSelectedStock);
            this.grpRestock.Controls.Add(this.lblRestockQty);
            this.grpRestock.Controls.Add(this.numRestockQty);
            this.grpRestock.Controls.Add(this.btnRestock);

            // Form
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpRestock);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evson Hardware - Inventory";

            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestockQty)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpRestock.ResumeLayout(false);
            this.grpRestock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}