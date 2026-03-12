namespace EvsonHardware.Forms
{
    partial class ExpenseForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseForm));
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Label();
            cmbType = new Guna.UI2.WinForms.Guna2ComboBox();
            lblType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            addPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            txtdescription = new Guna.UI2.WinForms.Guna2TextBox();
            txtamt = new Guna.UI2.WinForms.Guna2TextBox();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            viewPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            expensesdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            expensesgdv = new Guna.UI2.WinForms.Guna2DataGridView();
            addPanel.SuspendLayout();
            viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expensesgdv).BeginInit();
            SuspendLayout();
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
            exitbtn.Location = new Point(561, 1);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            exitbtn.Size = new Size(32, 34);
            exitbtn.TabIndex = 22;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Sitka Banner", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(107, 35);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "Expenses";
            // 
            // cmbType
            // 
            cmbType.BackColor = Color.PaleGoldenrod;
            cmbType.BorderColor = Color.DarkGreen;
            cmbType.BorderRadius = 10;
            cmbType.CustomizableEdges = customizableEdges3;
            cmbType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FillColor = Color.Cornsilk;
            cmbType.FocusedColor = Color.Empty;
            cmbType.Font = new Font("Segoe UI", 10F);
            cmbType.ForeColor = Color.DarkGreen;
            cmbType.ItemHeight = 30;
            cmbType.Location = new Point(395, 29);
            cmbType.Name = "cmbType";
            cmbType.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbType.Size = new Size(140, 36);
            cmbType.TabIndex = 0;
            // 
            // lblType
            // 
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Sitka Display", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.DarkGreen;
            lblType.Location = new Point(325, 37);
            lblType.Name = "lblType";
            lblType.Size = new Size(55, 21);
            lblType.TabIndex = 23;
            lblType.Text = "Category:";
            // 
            // lblAmount
            // 
            lblAmount.BackColor = Color.Transparent;
            lblAmount.Font = new Font("Sitka Display", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.DarkGreen;
            lblAmount.Location = new Point(31, 37);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(47, 21);
            lblAmount.TabIndex = 22;
            lblAmount.Text = "Amount";
            // 
            // addPanel
            // 
            addPanel.BackColor = Color.Transparent;
            addPanel.Controls.Add(txtdescription);
            addPanel.Controls.Add(txtamt);
            addPanel.Controls.Add(lblAmount);
            addPanel.Controls.Add(lblType);
            addPanel.Controls.Add(cmbType);
            addPanel.FillColor = Color.PaleGoldenrod;
            addPanel.Location = new Point(12, 290);
            addPanel.Name = "addPanel";
            addPanel.ShadowColor = Color.Black;
            addPanel.Size = new Size(563, 169);
            addPanel.TabIndex = 25;
            // 
            // txtdescription
            // 
            txtdescription.BorderColor = Color.DarkGreen;
            txtdescription.BorderRadius = 10;
            txtdescription.CustomizableEdges = customizableEdges5;
            txtdescription.DefaultText = "";
            txtdescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtdescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtdescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtdescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtdescription.FillColor = Color.Cornsilk;
            txtdescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtdescription.Font = new Font("Sitka Display", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtdescription.ForeColor = Color.DarkGreen;
            txtdescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtdescription.Location = new Point(31, 81);
            txtdescription.Margin = new Padding(3, 4, 3, 4);
            txtdescription.Multiline = true;
            txtdescription.Name = "txtdescription";
            txtdescription.PlaceholderForeColor = Color.DarkGreen;
            txtdescription.PlaceholderText = "Description...";
            txtdescription.SelectedText = "";
            txtdescription.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtdescription.Size = new Size(504, 63);
            txtdescription.TabIndex = 25;
            // 
            // txtamt
            // 
            txtamt.BorderColor = Color.DarkGreen;
            txtamt.BorderRadius = 10;
            txtamt.CustomizableEdges = customizableEdges7;
            txtamt.DefaultText = "";
            txtamt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtamt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtamt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtamt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtamt.FillColor = Color.Cornsilk;
            txtamt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtamt.Font = new Font("Segoe UI", 9F);
            txtamt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtamt.Location = new Point(96, 29);
            txtamt.Name = "txtamt";
            txtamt.PlaceholderForeColor = Color.DarkGreen;
            txtamt.PlaceholderText = "";
            txtamt.SelectedText = "";
            txtamt.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtamt.Size = new Size(191, 36);
            txtamt.TabIndex = 24;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.BorderColor = Color.WhiteSmoke;
            btnAdd.BorderRadius = 15;
            btnAdd.BorderThickness = 1;
            btnAdd.CustomizableEdges = customizableEdges9;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.ForestGreen;
            btnAdd.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(478, 476);
            btnAdd.Name = "btnAdd";
            btnAdd.PressedColor = Color.YellowGreen;
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAdd.Size = new Size(97, 40);
            btnAdd.TabIndex = 29;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Select;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderColor = Color.WhiteSmoke;
            btnCancel.BorderRadius = 15;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = customizableEdges11;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.IndianRed;
            btnCancel.Font = new Font("Sitka Display Semibold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(359, 476);
            btnCancel.Name = "btnCancel";
            btnCancel.PressedColor = Color.Brown;
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnCancel.Size = new Size(97, 40);
            btnCancel.TabIndex = 28;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // viewPanel
            // 
            viewPanel.BackColor = Color.Transparent;
            viewPanel.Controls.Add(expensesdate);
            viewPanel.Controls.Add(expensesgdv);
            viewPanel.FillColor = Color.PaleGoldenrod;
            viewPanel.Location = new Point(12, 47);
            viewPanel.Name = "viewPanel";
            viewPanel.ShadowColor = Color.Black;
            viewPanel.Size = new Size(563, 223);
            viewPanel.TabIndex = 30;
            // 
            // expensesdate
            // 
            expensesdate.BorderColor = Color.LimeGreen;
            expensesdate.BorderRadius = 10;
            expensesdate.BorderThickness = 1;
            expensesdate.Checked = true;
            expensesdate.CustomizableEdges = customizableEdges13;
            expensesdate.FillColor = Color.DarkSeaGreen;
            expensesdate.Font = new Font("Segoe UI", 9F);
            expensesdate.Format = DateTimePickerFormat.Long;
            expensesdate.Location = new Point(18, 15);
            expensesdate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            expensesdate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            expensesdate.Name = "expensesdate";
            expensesdate.ShadowDecoration.CustomizableEdges = customizableEdges14;
            expensesdate.Size = new Size(186, 26);
            expensesdate.TabIndex = 1;
            expensesdate.Value = new DateTime(2026, 3, 8, 3, 14, 41, 583);
            // 
            // expensesgdv
            // 
            expensesgdv.AllowUserToAddRows = false;
            expensesgdv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            expensesgdv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            expensesgdv.BackgroundColor = Color.Cornsilk;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            expensesgdv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            expensesgdv.ColumnHeadersHeight = 4;
            expensesgdv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            expensesgdv.DefaultCellStyle = dataGridViewCellStyle3;
            expensesgdv.GridColor = Color.DarkSeaGreen;
            expensesgdv.Location = new Point(18, 52);
            expensesgdv.Name = "expensesgdv";
            expensesgdv.ReadOnly = true;
            expensesgdv.RowHeadersVisible = false;
            expensesgdv.Size = new Size(528, 151);
            expensesgdv.TabIndex = 0;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.Font = null;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            expensesgdv.ThemeStyle.BackColor = Color.Cornsilk;
            expensesgdv.ThemeStyle.GridColor = Color.DarkSeaGreen;
            expensesgdv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            expensesgdv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            expensesgdv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            expensesgdv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            expensesgdv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            expensesgdv.ThemeStyle.HeaderStyle.Height = 4;
            expensesgdv.ThemeStyle.ReadOnly = true;
            expensesgdv.ThemeStyle.RowsStyle.BackColor = Color.White;
            expensesgdv.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            expensesgdv.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            expensesgdv.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            expensesgdv.ThemeStyle.RowsStyle.Height = 25;
            expensesgdv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            expensesgdv.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // ExpenseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(593, 529);
            Controls.Add(viewPanel);
            Controls.Add(btnAdd);
            Controls.Add(btnCancel);
            Controls.Add(addPanel);
            Controls.Add(exitbtn);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ExpenseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExpenseForm";
            addPanel.ResumeLayout(false);
            addPanel.PerformLayout();
            viewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)expensesgdv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button exitbtn;
        private Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAmount;
        private Guna.UI2.WinForms.Guna2ShadowPanel addPanel;
        private Guna.UI2.WinForms.Guna2TextBox txtamt;
        private Guna.UI2.WinForms.Guna2TextBox txtdescription;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2ShadowPanel viewPanel;
        private Guna.UI2.WinForms.Guna2DataGridView expensesgdv;
        private Guna.UI2.WinForms.Guna2DateTimePicker expensesdate;
    }
}