namespace EvsonHardware
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSelectedProduct;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            pnlHeader = new Panel();
            pnlActions = new Panel();
            btnBrowse = new Button();
            lblSelectedProduct = new Label();
            lblQty = new Label();
            numQty = new NumericUpDown();
            btnAdd = new Button();
            btnRemove = new Button();
            dgvCart = new DataGridView();
            lblTotal = new Label();
            btnCheckout = new Button();
            txtCustomer = new TextBox();
            lblCustomer = new Label();
            txtReceipt = new TextBox();
            lblReceipt = new Label();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(258, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Point of Sale (POS)";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 60);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(760, 55);
            pnlHeader.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(240, 243, 248);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.Controls.Add(btnBrowse);
            pnlActions.Controls.Add(lblSelectedProduct);
            pnlActions.Controls.Add(lblQty);
            pnlActions.Controls.Add(numQty);
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Location = new Point(20, 108);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(720, 50);
            pnlActions.TabIndex = 5;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(30, 30, 60);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(8, 10);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(140, 28);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "🔍 Search Product";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSelectedProduct.ForeColor = Color.FromArgb(30, 90, 160);
            lblSelectedProduct.Location = new Point(162, 15);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(102, 20);
            lblSelectedProduct.TabIndex = 1;
            lblSelectedProduct.Text = "Selected: None";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 9F);
            lblQty.ForeColor = Color.FromArgb(80, 80, 100);
            lblQty.Location = new Point(483, 15);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(35, 20);
            lblQty.TabIndex = 2;
            lblQty.Text = "Qty:";
            // 
            // numQty
            // 
            numQty.Font = new Font("Segoe UI", 9.5F);
            numQty.Location = new Point(524, 11);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(65, 29);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(34, 139, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(600, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 28);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "＋ Add to Cart";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(200, 60, 60);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9F);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(20, 408);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(130, 32);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "✖ Remove Item";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(30, 30, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.Font = new Font("Segoe UI", 9.5F);
            dgvCart.GridColor = Color.FromArgb(220, 225, 235);
            dgvCart.Location = new Point(20, 168);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(720, 230);
            dgvCart.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(30, 30, 60);
            lblTotal.Location = new Point(490, 412);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(152, 35);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(34, 139, 80);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(555, 455);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(185, 48);
            btnCheckout.TabIndex = 9;
            btnCheckout.Text = "✔  Process Sale";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // txtCustomer
            // 
            txtCustomer.Font = new Font("Segoe UI", 9.5F);
            txtCustomer.Location = new Point(460, 71);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(270, 29);
            txtCustomer.TabIndex = 4;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F);
            lblCustomer.ForeColor = Color.FromArgb(80, 80, 100);
            lblCustomer.Location = new Point(336, 75);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(119, 20);
            lblCustomer.TabIndex = 3;
            lblCustomer.Text = "Customer Name:";
            // 
            // txtReceipt
            // 
            txtReceipt.Font = new Font("Segoe UI", 9.5F);
            txtReceipt.Location = new Point(155, 71);
            txtReceipt.Name = "txtReceipt";
            txtReceipt.Size = new Size(175, 29);
            txtReceipt.TabIndex = 2;
            // 
            // lblReceipt
            // 
            lblReceipt.AutoSize = true;
            lblReceipt.Font = new Font("Segoe UI", 9F);
            lblReceipt.ForeColor = Color.FromArgb(80, 80, 100);
            lblReceipt.Location = new Point(20, 74);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(147, 20);
            lblReceipt.TabIndex = 1;
            lblReceipt.Text = "Receipt # (Optional):";
            // 
            // SalesForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(760, 520);
            Controls.Add(pnlHeader);
            Controls.Add(lblReceipt);
            Controls.Add(txtReceipt);
            Controls.Add(lblCustomer);
            Controls.Add(txtCustomer);
            Controls.Add(pnlActions);
            Controls.Add(dgvCart);
            Controls.Add(btnRemove);
            Controls.Add(lblTotal);
            Controls.Add(btnCheckout);
            Name = "SalesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware — Sales";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}