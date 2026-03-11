namespace EvsonHardware.Forms
{
    partial class SalesDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls declared here (NOT in the .cs file) ──────────────
        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnX;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlInfo;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.Label lblReceiptVal;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDateVal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCustomerVal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalVal;
        private Guna.UI2.WinForms.Guna2DataGridView dgvItems;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var dgvCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dgvCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnX = new Guna.UI2.WinForms.Guna2Button();
            pnlInfo = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblReceipt = new System.Windows.Forms.Label();
            lblReceiptVal = new System.Windows.Forms.Label();
            lblDate = new System.Windows.Forms.Label();
            lblDateVal = new System.Windows.Forms.Label();
            lblCustomer = new System.Windows.Forms.Label();
            lblCustomerVal = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();
            lblTotalVal = new System.Windows.Forms.Label();
            dgvItems = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();

            pnlTitleBar.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();

            // ── pnlTitleBar ───────────────────────────────────────────
            pnlTitleBar.FillColor = System.Drawing.Color.OliveDrab;
            pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTitleBar.Height = 48;
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.TabIndex = 0;
            pnlTitleBar.CustomizableEdges = customizableEdges1;
            pnlTitleBar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(btnX);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Sitka Banner", 14F,
                                     System.Drawing.FontStyle.Bold,
                                     System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🧾  Sale Details";

            // btnX
            // FIX: Was at X=738 on a 780px form — button nearly off-screen.
            //      Moved to X=734 and added Anchor so it stays right-aligned on resize.
            btnX.AutoRoundedCorners = true;
            btnX.BackColor = System.Drawing.Color.Transparent;
            btnX.BorderColor = System.Drawing.Color.Transparent;
            btnX.CustomizableEdges = customizableEdges3;
            btnX.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnX.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnX.FillColor = System.Drawing.Color.Firebrick;
            btnX.Font = new System.Drawing.Font("Segoe UI", 10F,
                                                 System.Drawing.FontStyle.Bold,
                                                 System.Drawing.GraphicsUnit.Point, 0);
            btnX.ForeColor = System.Drawing.Color.White;
            btnX.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 40, 40);
            btnX.Location = new System.Drawing.Point(734, 7);
            btnX.Anchor = System.Windows.Forms.AnchorStyles.Top
                              | System.Windows.Forms.AnchorStyles.Right;
            btnX.Name = "btnX";
            btnX.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnX.Size = new System.Drawing.Size(34, 34);
            btnX.TabIndex = 1;
            btnX.Text = "✕";
            btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            btnX.Click += btnX_Click;

            // ── pnlInfo ───────────────────────────────────────────────
            pnlInfo.BackColor = System.Drawing.Color.Transparent;
            pnlInfo.FillColor = System.Drawing.Color.PaleGoldenrod;
            pnlInfo.ShadowColor = System.Drawing.Color.FromArgb(60, 0, 0, 0);
            pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            pnlInfo.Height = 95;
            pnlInfo.Name = "pnlInfo";
            pnlInfo.TabIndex = 1;
            pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblReceipt,    lblReceiptVal,
                lblDate,       lblDateVal,
                lblCustomer,   lblCustomerVal,
                lblTotal,      lblTotalVal
            });

            // lblReceipt
            lblReceipt.AutoSize = true;
            lblReceipt.Font = new System.Drawing.Font("Segoe UI", 9F,
                                       System.Drawing.FontStyle.Bold,
                                       System.Drawing.GraphicsUnit.Point, 0);
            lblReceipt.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblReceipt.Location = new System.Drawing.Point(16, 14);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.TabIndex = 0;
            lblReceipt.Text = "Receipt #:";

            // lblReceiptVal
            lblReceiptVal.AutoSize = true;
            lblReceiptVal.Font = new System.Drawing.Font("Segoe UI", 9F,
                                          System.Drawing.FontStyle.Regular,
                                          System.Drawing.GraphicsUnit.Point, 0);
            lblReceiptVal.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblReceiptVal.Location = new System.Drawing.Point(100, 14);
            lblReceiptVal.Name = "lblReceiptVal";
            lblReceiptVal.TabIndex = 1;
            lblReceiptVal.Text = "—";

            // lblDate
            lblDate.AutoSize = true;
            lblDate.Font = new System.Drawing.Font("Segoe UI", 9F,
                                    System.Drawing.FontStyle.Bold,
                                    System.Drawing.GraphicsUnit.Point, 0);
            lblDate.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblDate.Location = new System.Drawing.Point(400, 14);
            lblDate.Name = "lblDate";
            lblDate.TabIndex = 2;
            lblDate.Text = "Date:";

            // lblDateVal
            lblDateVal.AutoSize = true;
            lblDateVal.Font = new System.Drawing.Font("Segoe UI", 9F,
                                       System.Drawing.FontStyle.Regular,
                                       System.Drawing.GraphicsUnit.Point, 0);
            lblDateVal.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblDateVal.Location = new System.Drawing.Point(445, 14);
            lblDateVal.Name = "lblDateVal";
            lblDateVal.TabIndex = 3;
            lblDateVal.Text = "—";

            // lblCustomer
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F,
                                        System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblCustomer.Location = new System.Drawing.Point(16, 54);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.TabIndex = 4;
            lblCustomer.Text = "Customer:";

            // lblCustomerVal
            lblCustomerVal.AutoSize = true;
            lblCustomerVal.Font = new System.Drawing.Font("Segoe UI", 9F,
                                           System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point, 0);
            lblCustomerVal.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lblCustomerVal.Location = new System.Drawing.Point(100, 54);
            lblCustomerVal.Name = "lblCustomerVal";
            lblCustomerVal.TabIndex = 5;
            lblCustomerVal.Text = "—";

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F,
                                     System.Drawing.FontStyle.Bold,
                                     System.Drawing.GraphicsUnit.Point, 0);
            lblTotal.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblTotal.Location = new System.Drawing.Point(400, 54);
            lblTotal.Name = "lblTotal";
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total:";

            // lblTotalVal
            lblTotalVal.AutoSize = true;
            lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 11F,
                                        System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, 0);
            lblTotalVal.ForeColor = System.Drawing.Color.DarkGreen;
            lblTotalVal.Location = new System.Drawing.Point(445, 50);
            lblTotalVal.Name = "lblTotalVal";
            lblTotalVal.TabIndex = 7;
            lblTotalVal.Text = "—";

            // ── dgvItems ──────────────────────────────────────────────
            dgvCellStyle1.BackColor = System.Drawing.Color.FromArgb(247, 250, 211);
            dgvItems.AlternatingRowsDefaultCellStyle = dgvCellStyle1;
            dgvItems.BackgroundColor = System.Drawing.Color.Ivory;

            dgvCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle2.BackColor = System.Drawing.Color.OliveDrab;
            dgvCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                                   System.Drawing.FontStyle.Bold,
                                                   System.Drawing.GraphicsUnit.Point, 0);
            dgvCellStyle2.ForeColor = System.Drawing.Color.White;
            dgvCellStyle2.SelectionBackColor = System.Drawing.Color.OliveDrab;
            dgvCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dgvCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dgvCellStyle2;
            dgvItems.ColumnHeadersHeight = 36;
            dgvItems.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvCellStyle3.BackColor = System.Drawing.Color.FromArgb(255, 252, 224);
            dgvCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                                   System.Drawing.FontStyle.Regular,
                                                   System.Drawing.GraphicsUnit.Point, 0);
            dgvCellStyle3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            dgvCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(226, 239, 169);
            dgvCellStyle3.SelectionForeColor = System.Drawing.Color.DarkOliveGreen;
            dgvCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvItems.DefaultCellStyle = dgvCellStyle3;

            dgvItems.GridColor = System.Drawing.Color.FromArgb(214, 223, 118);
            dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvItems.Name = "dgvItems";
            dgvItems.TabIndex = 2;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dgvItems.RowHeadersVisible = false;
            dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.MultiSelect = false;

            dgvItems.ThemeStyle.BackColor = System.Drawing.Color.Ivory;
            dgvItems.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(214, 223, 118);
            dgvItems.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.OliveDrab;
            dgvItems.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvItems.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvItems.ThemeStyle.HeaderStyle.Height = 36;
            dgvItems.ThemeStyle.HeaderStyle.HeaightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvItems.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 252, 224);
            dgvItems.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            dgvItems.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 239, 169);
            dgvItems.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.DarkOliveGreen;
            dgvItems.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.ThemeStyle.RowsStyle.Height = 28;
            dgvItems.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 250, 211);
            dgvItems.ThemeStyle.ReadOnly = true;

            // ── pnlBottom ─────────────────────────────────────────────
            pnlBottom.FillColor = System.Drawing.Color.OliveDrab;
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Height = 52;
            pnlBottom.Name = "pnlBottom";
            pnlBottom.TabIndex = 3;
            pnlBottom.CustomizableEdges = customizableEdges5;
            pnlBottom.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlBottom.Controls.Add(btnClose);

            // btnClose
            // FIX: Added Anchor so the button stays right-aligned if the form is resized
            btnClose.AutoRoundedCorners = true;
            btnClose.BorderRadius = 20;
            btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnClose.FillColor = System.Drawing.Color.Firebrick;
            btnClose.Font = new System.Drawing.Font("Sitka Display Semibold", 9.75F,
                                                    System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, 0);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 40, 40);
            btnClose.Location = new System.Drawing.Point(660, 10);
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top
                                  | System.Windows.Forms.AnchorStyles.Right;
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(110, 34);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.Click += btnClose_Click;

            // ── Form ──────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 230);
            ClientSize = new System.Drawing.Size(780, 540);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SalesDetailsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Sale Details";

            // Dock order: Fill first, then Bottom, then Top panels
            Controls.Add(dgvItems);
            Controls.Add(pnlBottom);
            Controls.Add(pnlInfo);
            Controls.Add(pnlTitleBar);

            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}