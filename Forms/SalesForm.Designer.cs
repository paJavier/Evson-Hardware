namespace EvsonHardware
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectedProduct;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblTotal;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesForm));
            lblTitle = new Label();
            lblSelectedProduct = new Label();
            lblQty = new Label();
            numQty = new NumericUpDown();
            dgvCart = new DataGridView();
            lblTotal = new Label();
            txtCustomer = new TextBox();
            lblCustomer = new Label();
            txtReceipt = new TextBox();
            lblReceipt = new Label();
            btnRemove = new Guna.UI2.WinForms.Guna2Button();
            pnlActions = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            pnlHeader = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            exitBtn = new Guna.UI2.WinForms.Guna2Button();
            btnSale = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlActions.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Sitka Heading", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(19, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Point of Sale (POS)";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblSelectedProduct
            // 
            lblSelectedProduct.AutoSize = true;
            lblSelectedProduct.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSelectedProduct.ForeColor = Color.White;
            lblSelectedProduct.Location = new Point(166, 25);
            lblSelectedProduct.Name = "lblSelectedProduct";
            lblSelectedProduct.Size = new Size(79, 19);
            lblSelectedProduct.TabIndex = 1;
            lblSelectedProduct.Text = "Selected: None";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 9F);
            lblQty.ForeColor = Color.FromArgb(80, 80, 100);
            lblQty.Location = new Point(567, 28);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(29, 15);
            lblQty.TabIndex = 2;
            lblQty.Text = "Qty:";
            // 
            // numQty
            // 
            numQty.Font = new Font("Segoe UI", 9.5F);
            numQty.Location = new Point(608, 24);
            numQty.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(65, 24);
            numQty.TabIndex = 3;
            numQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.PaleGoldenrod;
            dgvCart.BorderStyle = BorderStyle.Fixed3D;
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
            dgvCart.GridColor = Color.LemonChiffon;
            dgvCart.Location = new Point(20, 188);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(854, 288);
            dgvCart.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Sitka Banner", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(702, 499);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(118, 29);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "Total: ₱0.00";
            // 
            // txtCustomer
            // 
            txtCustomer.BackColor = Color.FloralWhite;
            txtCustomer.Font = new Font("Segoe UI", 9.5F);
            txtCustomer.ForeColor = Color.DarkGreen;
            txtCustomer.Location = new Point(570, 72);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(287, 24);
            txtCustomer.TabIndex = 4;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.BackColor = Color.Transparent;
            lblCustomer.Font = new Font("Sitka Display", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = Color.Black;
            lblCustomer.Location = new Point(468, 74);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(96, 19);
            lblCustomer.TabIndex = 3;
            lblCustomer.Text = "Customer Name:";
            // 
            // txtReceipt
            // 
            txtReceipt.BackColor = Color.FloralWhite;
            txtReceipt.Font = new Font("Segoe UI", 9.5F);
            txtReceipt.ForeColor = Color.DarkGreen;
            txtReceipt.Location = new Point(175, 72);
            txtReceipt.Name = "txtReceipt";
            txtReceipt.Size = new Size(175, 24);
            txtReceipt.TabIndex = 2;
            // 
            // lblReceipt
            // 
            lblReceipt.AutoSize = true;
            lblReceipt.BackColor = Color.Transparent;
            lblReceipt.Font = new Font("Sitka Display", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReceipt.ForeColor = Color.Black;
            lblReceipt.Location = new Point(33, 74);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(120, 19);
            lblReceipt.TabIndex = 1;
            lblReceipt.Text = "Receipt # (Optional):";
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Transparent;
            btnRemove.BorderColor = Color.LemonChiffon;
            btnRemove.BorderRadius = 25;
            btnRemove.BorderThickness = 1;
            btnRemove.CustomizableEdges = customizableEdges1;
            btnRemove.DisabledState.BorderColor = Color.DarkGray;
            btnRemove.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRemove.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRemove.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRemove.FillColor = Color.IndianRed;
            btnRemove.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(20, 499);
            btnRemove.Name = "btnRemove";
            btnRemove.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRemove.Size = new Size(167, 47);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "✖ Remove Item";
            btnRemove.Click += btnRemove_Click;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.Transparent;
            pnlActions.Controls.Add(btnAdd);
            pnlActions.Controls.Add(btnBrowse);
            pnlActions.Controls.Add(numQty);
            pnlActions.Controls.Add(lblQty);
            pnlActions.Controls.Add(lblSelectedProduct);
            pnlActions.FillColor = Color.DarkKhaki;
            pnlActions.Location = new Point(20, 110);
            pnlActions.Name = "pnlActions";
            pnlActions.ShadowColor = Color.Black;
            pnlActions.Size = new Size(854, 72);
            pnlActions.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.BorderColor = Color.Transparent;
            btnAdd.BorderRadius = 15;
            btnAdd.CustomizableEdges = customizableEdges3;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.LemonChiffon;
            btnAdd.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.ForestGreen;
            btnAdd.Location = new Point(703, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.PressedColor = Color.DarkKhaki;
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAdd.Size = new Size(126, 27);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "＋ Add to Cart";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.Transparent;
            btnBrowse.BorderColor = Color.Transparent;
            btnBrowse.BorderRadius = 15;
            btnBrowse.CustomizableEdges = customizableEdges5;
            btnBrowse.DisabledState.BorderColor = Color.DarkGray;
            btnBrowse.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBrowse.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBrowse.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBrowse.FillColor = Color.LemonChiffon;
            btnBrowse.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = Color.ForestGreen;
            btnBrowse.Location = new Point(22, 22);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.PressedColor = Color.DarkKhaki;
            btnBrowse.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBrowse.Size = new Size(126, 27);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "🔍 Search Product";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(exitBtn);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomBorderColor = Color.Transparent;
            pnlHeader.CustomizableEdges = customizableEdges9;
            pnlHeader.FillColor = Color.DarkKhaki;
            pnlHeader.FillColor2 = Color.Khaki;
            pnlHeader.FillColor3 = Color.PaleGoldenrod;
            pnlHeader.FillColor4 = Color.LemonChiffon;
            pnlHeader.ForeColor = SystemColors.ControlText;
            pnlHeader.Location = new Point(1, -1);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlHeader.Size = new Size(902, 60);
            pnlHeader.TabIndex = 13;
            // 
            // exitBtn
            // 
            exitBtn.AutoRoundedCorners = true;
            exitBtn.BackColor = Color.Transparent;
            exitBtn.BorderColor = Color.Transparent;
            exitBtn.CustomizableEdges = customizableEdges7;
            exitBtn.DisabledState.BorderColor = Color.DarkGray;
            exitBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitBtn.FillColor = Color.Transparent;
            exitBtn.Font = new Font("Sitka Small", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBtn.ForeColor = Color.DarkRed;
            exitBtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitBtn.ImageSize = new Size(260, 220);
            exitBtn.Location = new Point(861, 3);
            exitBtn.Name = "exitBtn";
            exitBtn.PressedColor = Color.DarkGreen;
            exitBtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            exitBtn.Size = new Size(41, 48);
            exitBtn.TabIndex = 20;
            exitBtn.Text = "X";
            exitBtn.Click += exitbtn_Click;
            // 
            // btnSale
            // 
            btnSale.BackColor = Color.Transparent;
            btnSale.BorderColor = Color.LemonChiffon;
            btnSale.BorderRadius = 25;
            btnSale.BorderThickness = 1;
            btnSale.CustomizableEdges = customizableEdges11;
            btnSale.DisabledState.BorderColor = Color.DarkGray;
            btnSale.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSale.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSale.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSale.FillColor = Color.DarkGreen;
            btnSale.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSale.ForeColor = Color.White;
            btnSale.Location = new Point(707, 537);
            btnSale.Name = "btnSale";
            btnSale.PressedColor = Color.PaleGreen;
            btnSale.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSale.Size = new Size(167, 47);
            btnSale.TabIndex = 14;
            btnSale.Text = "✔ Process Sale";
            btnSale.Click += btnSale_Click;
            // 
            // SalesForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(904, 620);
            Controls.Add(btnSale);
            Controls.Add(pnlHeader);
            Controls.Add(pnlActions);
            Controls.Add(btnRemove);
            Controls.Add(lblReceipt);
            Controls.Add(txtReceipt);
            Controls.Add(lblCustomer);
            Controls.Add(txtCustomer);
            Controls.Add(dgvCart);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware — Sales";
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlActions;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button exitBtn;
        private Guna.UI2.WinForms.Guna2Button btnSale;
    }
}