using System.Xml.Linq;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            btnX = new Guna.UI2.WinForms.Guna2Button();
            pnlInfo = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblReceipt = new Label();
            lblReceiptVal = new Label();
            lblDate = new Label();
            lblDateVal = new Label();
            lblCustomer = new Label();
            lblCustomerVal = new Label();
            lblTotal = new Label();
            lblTotalVal = new Label();
            dgvItems = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            pnlTitleBar.SuspendLayout();
            pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.Controls.Add(exitbtn);
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(btnX);
            pnlTitleBar.CustomizableEdges = customizableEdges5;
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.FillColor = Color.OliveDrab;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Margin = new Padding(3, 2, 3, 2);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlTitleBar.Size = new Size(682, 36);
            pnlTitleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Sitka Banner", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(14, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(136, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\U0001f9fe  Sale Details";
            // 
            // btnX
            // 
            btnX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnX.AutoRoundedCorners = true;
            btnX.BackColor = Color.Transparent;
            btnX.BorderColor = Color.Transparent;
            btnX.Cursor = Cursors.Hand;
            btnX.CustomizableEdges = customizableEdges3;
            btnX.DisabledState.BorderColor = Color.DarkGray;
            btnX.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnX.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnX.FillColor = Color.Firebrick;
            btnX.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.White;
            btnX.HoverState.FillColor = Color.FromArgb(200, 40, 40);
            btnX.Location = new Point(1149, 5);
            btnX.Margin = new Padding(3, 2, 3, 2);
            btnX.Name = "btnX";
            btnX.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnX.Size = new Size(30, 26);
            btnX.TabIndex = 1;
            btnX.Text = "✕";
            btnX.Click += btnX_Click;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.Transparent;
            pnlInfo.Controls.Add(lblReceipt);
            pnlInfo.Controls.Add(lblReceiptVal);
            pnlInfo.Controls.Add(lblDate);
            pnlInfo.Controls.Add(lblDateVal);
            pnlInfo.Controls.Add(lblCustomer);
            pnlInfo.Controls.Add(lblCustomerVal);
            pnlInfo.Controls.Add(lblTotal);
            pnlInfo.Controls.Add(lblTotalVal);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.FillColor = Color.PaleGoldenrod;
            pnlInfo.Location = new Point(0, 36);
            pnlInfo.Margin = new Padding(3, 2, 3, 2);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            pnlInfo.Size = new Size(682, 71);
            pnlInfo.TabIndex = 1;
            // 
            // lblReceipt
            // 
            lblReceipt.AutoSize = true;
            lblReceipt.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReceipt.ForeColor = Color.DarkOliveGreen;
            lblReceipt.Location = new Point(14, 10);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(63, 15);
            lblReceipt.TabIndex = 0;
            lblReceipt.Text = "Receipt #:";
            // 
            // lblReceiptVal
            // 
            lblReceiptVal.AutoSize = true;
            lblReceiptVal.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReceiptVal.ForeColor = Color.FromArgb(50, 50, 50);
            lblReceiptVal.Location = new Point(88, 10);
            lblReceiptVal.Name = "lblReceiptVal";
            lblReceiptVal.Size = new Size(19, 15);
            lblReceiptVal.TabIndex = 1;
            lblReceiptVal.Text = "—";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.DarkOliveGreen;
            lblDate.Location = new Point(350, 10);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(37, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date:";
            // 
            // lblDateVal
            // 
            lblDateVal.AutoSize = true;
            lblDateVal.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateVal.ForeColor = Color.FromArgb(50, 50, 50);
            lblDateVal.Location = new Point(389, 10);
            lblDateVal.Name = "lblDateVal";
            lblDateVal.Size = new Size(19, 15);
            lblDateVal.TabIndex = 3;
            lblDateVal.Text = "—";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomer.ForeColor = Color.DarkOliveGreen;
            lblCustomer.Location = new Point(14, 40);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(64, 15);
            lblCustomer.TabIndex = 4;
            lblCustomer.Text = "Customer:";
            // 
            // lblCustomerVal
            // 
            lblCustomerVal.AutoSize = true;
            lblCustomerVal.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerVal.ForeColor = Color.FromArgb(50, 50, 50);
            lblCustomerVal.Location = new Point(88, 40);
            lblCustomerVal.Name = "lblCustomerVal";
            lblCustomerVal.Size = new Size(19, 15);
            lblCustomerVal.TabIndex = 5;
            lblCustomerVal.Text = "—";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.DarkOliveGreen;
            lblTotal.Location = new Point(350, 40);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(37, 15);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total:";
            // 
            // lblTotalVal
            // 
            lblTotalVal.AutoSize = true;
            lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVal.ForeColor = Color.DarkGreen;
            lblTotalVal.Location = new Point(389, 38);
            lblTotalVal.Name = "lblTotalVal";
            lblTotalVal.Size = new Size(24, 20);
            lblTotalVal.TabIndex = 7;
            lblTotalVal.Text = "—";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 250, 211);
            dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvItems.BackgroundColor = Color.Ivory;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.OliveDrab;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.OliveDrab;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvItems.ColumnHeadersHeight = 36;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 252, 224);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.DarkOliveGreen;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dataGridViewCellStyle3.SelectionForeColor = Color.DarkOliveGreen;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvItems.DefaultCellStyle = dataGridViewCellStyle3;
            dgvItems.Dock = DockStyle.Fill;
            dgvItems.GridColor = Color.FromArgb(214, 223, 118);
            dgvItems.Location = new Point(0, 107);
            dgvItems.Margin = new Padding(3, 2, 3, 2);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowTemplate.Height = 28;
            dgvItems.Size = new Size(682, 259);
            dgvItems.TabIndex = 2;
            dgvItems.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 250, 211);
            dgvItems.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvItems.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvItems.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvItems.ThemeStyle.BackColor = Color.Ivory;
            dgvItems.ThemeStyle.GridColor = Color.FromArgb(214, 223, 118);
            dgvItems.ThemeStyle.HeaderStyle.BackColor = Color.OliveDrab;
            dgvItems.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvItems.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvItems.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvItems.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvItems.ThemeStyle.HeaderStyle.Height = 36;
            dgvItems.ThemeStyle.ReadOnly = true;
            dgvItems.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvItems.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvItems.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvItems.ThemeStyle.RowsStyle.ForeColor = Color.DarkOliveGreen;
            dgvItems.ThemeStyle.RowsStyle.Height = 28;
            dgvItems.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvItems.ThemeStyle.RowsStyle.SelectionForeColor = Color.DarkOliveGreen;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.CustomizableEdges = customizableEdges9;
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.FillColor = Color.OliveDrab;
            pnlBottom.Location = new Point(0, 366);
            pnlBottom.Margin = new Padding(3, 2, 3, 2);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlBottom.Size = new Size(682, 39);
            pnlBottom.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.AutoRoundedCorners = true;
            btnClose.BorderRadius = 12;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges7;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Firebrick;
            btnClose.Font = new System.Drawing.Font("Sitka Display Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.HoverState.FillColor = Color.FromArgb(200, 40, 40);
            btnClose.Location = new Point(1085, 8);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClose.Size = new Size(96, 26);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.BorderRadius = 12;
            exitbtn.CustomizableEdges = customizableEdges1;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new System.Drawing.Font("Sitka Banner", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.Location = new Point(645, 4);
            exitbtn.Name = "exitbtn";
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            exitbtn.Size = new Size(29, 26);
            exitbtn.TabIndex = 13;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // SalesDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 230);
            ClientSize = new Size(682, 405);
            Controls.Add(dgvItems);
            Controls.Add(pnlBottom);
            Controls.Add(pnlInfo);
            Controls.Add(pnlTitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "SalesDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sale Details";
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Guna.UI2.WinForms.Guna2Button exitbtn;
    }
}