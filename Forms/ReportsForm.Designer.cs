namespace EvsonHardware.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            dgvReports = new Guna.UI2.WinForms.Guna2DataGridView();
            TopPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnPrintReport = new Guna.UI2.WinForms.Guna2Button();
            salesdaterevenue = new Guna.UI2.WinForms.Guna2DateTimePicker();
            logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(92, 35);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Reports";
            // 
            // dgvReports
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvReports.BackgroundColor = Color.PaleGoldenrod;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReports.ColumnHeadersHeight = 28;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvReports.DefaultCellStyle = dataGridViewCellStyle3;
            dgvReports.GridColor = Color.Cornsilk;
            dgvReports.Location = new Point(22, 151);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersVisible = false;
            dgvReports.Size = new Size(666, 319);
            dgvReports.TabIndex = 25;
            dgvReports.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvReports.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvReports.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvReports.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvReports.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvReports.ThemeStyle.BackColor = Color.PaleGoldenrod;
            dgvReports.ThemeStyle.GridColor = Color.Cornsilk;
            dgvReports.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvReports.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReports.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvReports.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvReports.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvReports.ThemeStyle.HeaderStyle.Height = 28;
            dgvReports.ThemeStyle.ReadOnly = false;
            dgvReports.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvReports.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReports.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvReports.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvReports.ThemeStyle.RowsStyle.Height = 25;
            dgvReports.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvReports.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // TopPanel
            // 
            TopPanel.BackColor = Color.Transparent;
            TopPanel.Controls.Add(btnPrintReport);
            TopPanel.Controls.Add(salesdaterevenue);
            TopPanel.Controls.Add(logo);
            TopPanel.Controls.Add(guna2HtmlLabel1);
            TopPanel.FillColor = Color.LightGoldenrodYellow;
            TopPanel.Location = new Point(22, 57);
            TopPanel.Margin = new Padding(2);
            TopPanel.Name = "TopPanel";
            TopPanel.Radius = 10;
            TopPanel.ShadowColor = Color.Goldenrod;
            TopPanel.Size = new Size(666, 64);
            TopPanel.TabIndex = 26;
            // 
            // btnPrintReport
            // 
            btnPrintReport.BackgroundImageLayout = ImageLayout.None;
            btnPrintReport.BorderRadius = 10;
            btnPrintReport.CustomizableEdges = customizableEdges1;
            btnPrintReport.DisabledState.BorderColor = Color.DarkGray;
            btnPrintReport.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrintReport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrintReport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrintReport.FillColor = Color.ForestGreen;
            btnPrintReport.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrintReport.ForeColor = Color.White;
            btnPrintReport.Location = new Point(539, 19);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrintReport.Size = new Size(97, 23);
            btnPrintReport.TabIndex = 28;
            btnPrintReport.Text = "Print";
            // 
            // salesdaterevenue
            // 
            salesdaterevenue.Checked = true;
            salesdaterevenue.CustomizableEdges = customizableEdges3;
            salesdaterevenue.FillColor = Color.FromArgb(255, 255, 192);
            salesdaterevenue.FocusedColor = Color.FromArgb(255, 255, 128);
            salesdaterevenue.Font = new Font("Sitka Display", 11.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salesdaterevenue.ForeColor = Color.DarkGreen;
            salesdaterevenue.Format = DateTimePickerFormat.Short;
            salesdaterevenue.Location = new Point(396, 19);
            salesdaterevenue.Margin = new Padding(2);
            salesdaterevenue.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            salesdaterevenue.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            salesdaterevenue.Name = "salesdaterevenue";
            salesdaterevenue.ShadowDecoration.CustomizableEdges = customizableEdges4;
            salesdaterevenue.Size = new Size(128, 23);
            salesdaterevenue.TabIndex = 27;
            salesdaterevenue.Value = new DateTime(2026, 3, 4, 18, 34, 2, 233);
            // 
            // logo
            // 
            logo.BackColor = Color.Transparent;
            logo.BackgroundImageLayout = ImageLayout.Zoom;
            logo.FillColor = Color.Transparent;
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.ImageRotate = 0F;
            logo.Location = new Point(13, 0);
            logo.Margin = new Padding(2);
            logo.Name = "logo";
            logo.ShadowDecoration.CustomizableEdges = customizableEdges5;
            logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            logo.Size = new Size(70, 62);
            logo.SizeMode = PictureBoxSizeMode.CenterImage;
            logo.TabIndex = 18;
            logo.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.BackgroundImage = (Image)resources.GetObject("guna2HtmlLabel1.BackgroundImage");
            guna2HtmlLabel1.BackgroundImageLayout = ImageLayout.Zoom;
            guna2HtmlLabel1.Font = new Font("Sitka Banner Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.DarkGreen;
            guna2HtmlLabel1.Location = new Point(87, 21);
            guna2HtmlLabel1.Margin = new Padding(2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(90, 21);
            guna2HtmlLabel1.TabIndex = 16;
            guna2HtmlLabel1.Text = "Evson Hardware";
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BackColor = Color.Transparent;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.CustomizableEdges = customizableEdges6;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new Font("Sitka Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitbtn.ImageSize = new Size(260, 220);
            exitbtn.Location = new Point(671, 6);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges7;
            exitbtn.Size = new Size(30, 38);
            exitbtn.TabIndex = 27;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(708, 524);
            Controls.Add(exitbtn);
            Controls.Add(TopPanel);
            Controls.Add(dgvReports);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReports;
        private Guna.UI2.WinForms.Guna2ShadowPanel TopPanel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox logo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker salesdaterevenue;
        private Guna.UI2.WinForms.Guna2Button btnPrintReport;
        private Guna.UI2.WinForms.Guna2Button exitbtn;
    }
}