namespace EvsonHardware
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSelectedProduct;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label lblReceipt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.lblReceipt = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Point of Sale (POS)";

            this.lblReceipt.AutoSize = true;
            this.lblReceipt.Location = new System.Drawing.Point(23, 75);
            this.lblReceipt.Text = "Receipt # (Optional):";

            this.txtReceipt.Location = new System.Drawing.Point(150, 72);
            this.txtReceipt.Size = new System.Drawing.Size(190, 22);

            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(360, 75);
            this.lblCustomer.Text = "Customer Name:";

            this.txtCustomer.Location = new System.Drawing.Point(470, 72);
            this.txtCustomer.Size = new System.Drawing.Size(206, 22);

            this.btnBrowse.Location = new System.Drawing.Point(26, 110);
            this.btnBrowse.Size = new System.Drawing.Size(150, 28);
            this.btnBrowse.Text = "Search Product";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            this.lblSelectedProduct.AutoSize = true;
            this.lblSelectedProduct.Location = new System.Drawing.Point(190, 116);
            this.lblSelectedProduct.Text = "Selected: None";
            this.lblSelectedProduct.ForeColor = System.Drawing.Color.MediumBlue;

            this.numQty.Location = new System.Drawing.Point(450, 113);
            this.numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQty.Size = new System.Drawing.Size(80, 22);
            this.numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            this.btnAdd.Location = new System.Drawing.Point(540, 110);
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.Text = "Add to Cart";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Location = new System.Drawing.Point(26, 150);
            this.dgvCart.Size = new System.Drawing.Size(650, 200);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(450, 370);
            this.lblTotal.Text = "Total: ₱0.00";

            this.btnCheckout.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(526, 420);
            this.btnCheckout.Size = new System.Drawing.Size(150, 45);
            this.btnCheckout.Text = "Process Sale";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            this.ClientSize = new System.Drawing.Size(700, 490);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblReceipt);
            this.Controls.Add(this.txtReceipt);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblSelectedProduct);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCheckout);
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evson Hardware - Sales";

            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}