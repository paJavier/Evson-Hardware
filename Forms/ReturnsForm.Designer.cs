namespace EvsonHardware.Forms
{
    partial class ReturnsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.viewPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnProcess = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.txtEmployeeId = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmployee = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCustomer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblReason = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbReturnType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblReturnType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numReturnQty = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblQuantity = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSelection = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvSaleItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblSaleStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLoadSale = new Guna.UI2.WinForms.Guna2Button();
            this.txtReceiptNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblReceipt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.exitbtn = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).BeginInit();
            this.SuspendLayout();
            // 
            // viewPanel
            // 
            this.viewPanel.BackColor = System.Drawing.Color.Transparent;
            this.viewPanel.Controls.Add(this.btnProcess);
            this.viewPanel.Controls.Add(this.btnCancel);
            this.viewPanel.Controls.Add(this.txtEmployeeId);
            this.viewPanel.Controls.Add(this.lblEmployee);
            this.viewPanel.Controls.Add(this.txtCustomerName);
            this.viewPanel.Controls.Add(this.lblCustomer);
            this.viewPanel.Controls.Add(this.txtReason);
            this.viewPanel.Controls.Add(this.lblReason);
            this.viewPanel.Controls.Add(this.cmbReturnType);
            this.viewPanel.Controls.Add(this.lblReturnType);
            this.viewPanel.Controls.Add(this.numReturnQty);
            this.viewPanel.Controls.Add(this.lblQuantity);
            this.viewPanel.Controls.Add(this.lblSelection);
            this.viewPanel.Controls.Add(this.dgvSaleItems);
            this.viewPanel.Controls.Add(this.lblSaleStatus);
            this.viewPanel.Controls.Add(this.btnLoadSale);
            this.viewPanel.Controls.Add(this.txtReceiptNumber);
            this.viewPanel.Controls.Add(this.lblReceipt);
            this.viewPanel.FillColor = System.Drawing.Color.PaleGoldenrod;
            this.viewPanel.Location = new System.Drawing.Point(24, 62);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.ShadowColor = System.Drawing.Color.Black;
            this.viewPanel.Size = new System.Drawing.Size(832, 482);
            this.viewPanel.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.BorderRadius = 20;
            this.btnProcess.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProcess.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProcess.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProcess.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProcess.FillColor = System.Drawing.Color.ForestGreen;
            this.btnProcess.Font = new System.Drawing.Font("Sitka Display Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(676, 416);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(125, 48);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Process Return";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.IndianRed;
            this.btnCancel.Font = new System.Drawing.Font("Sitka Display Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(534, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 48);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.BorderColor = System.Drawing.Color.DarkGreen;
            this.txtEmployeeId.BorderRadius = 10;
            this.txtEmployeeId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeId.DefaultText = "";
            this.txtEmployeeId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeId.FillColor = System.Drawing.Color.Cornsilk;
            this.txtEmployeeId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmployeeId.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtEmployeeId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeId.Location = new System.Drawing.Point(610, 358);
            this.txtEmployeeId.MaxLength = 6;
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.PasswordChar = '\0';
            this.txtEmployeeId.PlaceholderText = "Employee ID";
            this.txtEmployeeId.SelectedText = "";
            this.txtEmployeeId.Size = new System.Drawing.Size(191, 36);
            this.txtEmployeeId.TabIndex = 9;
            // 
            // lblEmployee
            // 
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Font = new System.Drawing.Font("Sitka Display", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmployee.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEmployee.Location = new System.Drawing.Point(610, 335);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(111, 21);
            this.lblEmployee.TabIndex = 18;
            this.lblEmployee.Text = "Verified By (ID)*";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderColor = System.Drawing.Color.DarkGreen;
            this.txtCustomerName.BorderRadius = 10;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.FillColor = System.Drawing.Color.Cornsilk;
            this.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerName.Location = new System.Drawing.Point(355, 358);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.PlaceholderText = "Override customer (if needed)";
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.Size = new System.Drawing.Size(234, 36);
            this.txtCustomerName.TabIndex = 8;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Sitka Display", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCustomer.Location = new System.Drawing.Point(355, 335);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(114, 21);
            this.lblCustomer.TabIndex = 16;
            this.lblCustomer.Text = "Customer Override";
            // 
            // txtReason
            // 
            this.txtReason.BorderColor = System.Drawing.Color.DarkGreen;
            this.txtReason.BorderRadius = 10;
            this.txtReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.DefaultText = "";
            this.txtReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReason.FillColor = System.Drawing.Color.Cornsilk;
            this.txtReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReason.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReason.Location = new System.Drawing.Point(28, 358);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.PasswordChar = '\0';
            this.txtReason.PlaceholderText = "Reason for return...";
            this.txtReason.SelectedText = "";
            this.txtReason.Size = new System.Drawing.Size(308, 106);
            this.txtReason.TabIndex = 7;
            // 
            // lblReason
            // 
            this.lblReason.BackColor = System.Drawing.Color.Transparent;
            this.lblReason.Font = new System.Drawing.Font("Sitka Display", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReason.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblReason.Location = new System.Drawing.Point(28, 335);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(103, 21);
            this.lblReason.TabIndex = 14;
            this.lblReason.Text = "Reason / Notes*";
            // 
            // cmbReturnType
            // 
            this.cmbReturnType.BackColor = System.Drawing.Color.Transparent;
            this.cmbReturnType.BorderColor = System.Drawing.Color.DarkGreen;
            this.cmbReturnType.BorderRadius = 10;
            this.cmbReturnType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnType.FillColor = System.Drawing.Color.Cornsilk;
            this.cmbReturnType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReturnType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReturnType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbReturnType.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmbReturnType.ItemHeight = 30;
            this.cmbReturnType.Items.AddRange(new object[] {
            "Refund",
            "Replacement",
            "Damaged"});
            this.cmbReturnType.Location = new System.Drawing.Point(640, 284);
            this.cmbReturnType.Name = "cmbReturnType";
            this.cmbReturnType.Size = new System.Drawing.Size(161, 36);
            this.cmbReturnType.TabIndex = 6;
            // 
            // lblReturnType
            // 
            this.lblReturnType.BackColor = System.Drawing.Color.Transparent;
            this.lblReturnType.Font = new System.Drawing.Font("Sitka Display", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReturnType.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblReturnType.Location = new System.Drawing.Point(640, 261);
            this.lblReturnType.Name = "lblReturnType";
            this.lblReturnType.Size = new System.Drawing.Size(84, 21);
            this.lblReturnType.TabIndex = 12;
            this.lblReturnType.Text = "Return Type*";
            // 
            // numReturnQty
            // 
            this.numReturnQty.BackColor = System.Drawing.Color.Transparent;
            this.numReturnQty.BorderColor = System.Drawing.Color.DarkGreen;
            this.numReturnQty.BorderRadius = 10;
            this.numReturnQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numReturnQty.FillColor = System.Drawing.Color.Cornsilk;
            this.numReturnQty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numReturnQty.ForeColor = System.Drawing.Color.DarkGreen;
            this.numReturnQty.Location = new System.Drawing.Point(468, 284);
            this.numReturnQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numReturnQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReturnQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReturnQty.Name = "numReturnQty";
            this.numReturnQty.Size = new System.Drawing.Size(150, 36);
            this.numReturnQty.TabIndex = 5;
            this.numReturnQty.UpDownButtonFillColor = System.Drawing.Color.DarkOliveGreen;
            this.numReturnQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Sitka Display", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblQuantity.Location = new System.Drawing.Point(468, 261);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(96, 21);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Return Qty (pcs)";
            // 
            // lblSelection
            // 
            this.lblSelection.BackColor = System.Drawing.Color.Transparent;
            this.lblSelection.Font = new System.Drawing.Font("Sitka Display", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelection.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelection.Location = new System.Drawing.Point(28, 261);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(212, 21);
            this.lblSelection.TabIndex = 9;
            this.lblSelection.Text = "No item selected. Choose a row.";
            // 
            // dgvSaleItems
            // 
            this.dgvSaleItems.AllowUserToAddRows = false;
            this.dgvSaleItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(230)))));
            this.dgvSaleItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSaleItems.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvSaleItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSaleItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSaleItems.ColumnHeadersHeight = 34;
            this.dgvSaleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(169)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkOliveGreen;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSaleItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSaleItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(118)))));
            this.dgvSaleItems.Location = new System.Drawing.Point(28, 94);
            this.dgvSaleItems.MultiSelect = false;
            this.dgvSaleItems.Name = "dgvSaleItems";
            this.dgvSaleItems.ReadOnly = true;
            this.dgvSaleItems.RowHeadersVisible = false;
            this.dgvSaleItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleItems.Size = new System.Drawing.Size(773, 152);
            this.dgvSaleItems.TabIndex = 4;
            this.dgvSaleItems.SelectionChanged += new System.EventHandler(this.dgvSaleItems_SelectionChanged);
            this.dgvSaleItems.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSaleItems_CellMouseClick);
            // 
            // lblSaleStatus
            // 
            this.lblSaleStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblSaleStatus.Font = new System.Drawing.Font("Sitka Display", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaleStatus.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSaleStatus.Location = new System.Drawing.Point(28, 61);
            this.lblSaleStatus.Name = "lblSaleStatus";
            this.lblSaleStatus.Size = new System.Drawing.Size(177, 21);
            this.lblSaleStatus.TabIndex = 7;
            this.lblSaleStatus.Text = "No receipt loaded yet.";
            // 
            // btnLoadSale
            // 
            this.btnLoadSale.BorderRadius = 10;
            this.btnLoadSale.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadSale.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadSale.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadSale.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadSale.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.btnLoadSale.Font = new System.Drawing.Font("Sitka Display Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoadSale.ForeColor = System.Drawing.Color.White;
            this.btnLoadSale.Location = new System.Drawing.Point(640, 18);
            this.btnLoadSale.Name = "btnLoadSale";
            this.btnLoadSale.Size = new System.Drawing.Size(161, 34);
            this.btnLoadSale.TabIndex = 3;
            this.btnLoadSale.Text = "Load Receipt";
            this.btnLoadSale.Click += new System.EventHandler(this.btnLoadSale_Click);
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.BorderColor = System.Drawing.Color.DarkGreen;
            this.txtReceiptNumber.BorderRadius = 10;
            this.txtReceiptNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReceiptNumber.DefaultText = "";
            this.txtReceiptNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReceiptNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReceiptNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReceiptNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReceiptNumber.FillColor = System.Drawing.Color.Cornsilk;
            this.txtReceiptNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReceiptNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReceiptNumber.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtReceiptNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReceiptNumber.Location = new System.Drawing.Point(146, 18);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.PasswordChar = '\0';
            this.txtReceiptNumber.PlaceholderText = "Enter or scan receipt number";
            this.txtReceiptNumber.SelectedText = "";
            this.txtReceiptNumber.Size = new System.Drawing.Size(478, 34);
            this.txtReceiptNumber.TabIndex = 2;
            // 
            // lblReceipt
            // 
            this.lblReceipt.BackColor = System.Drawing.Color.Transparent;
            this.lblReceipt.Font = new System.Drawing.Font("Sitka Display", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblReceipt.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblReceipt.Location = new System.Drawing.Point(28, 24);
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Size = new System.Drawing.Size(112, 23);
            this.lblReceipt.TabIndex = 1;
            this.lblReceipt.Text = "Receipt Number";
            // 
            // exitbtn
            // 
            this.exitbtn.AutoRoundedCorners = true;
            this.exitbtn.BorderColor = System.Drawing.Color.Transparent;
            this.exitbtn.BorderRadius = 16;
            this.exitbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitbtn.FillColor = System.Drawing.Color.Transparent;
            this.exitbtn.Font = new System.Drawing.Font("Sitka Small", 10F, System.Drawing.FontStyle.Bold);
            this.exitbtn.ForeColor = System.Drawing.Color.DarkRed;
            this.exitbtn.Location = new System.Drawing.Point(844, 12);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(40, 34);
            this.exitbtn.TabIndex = 12;
            this.exitbtn.Text = "X";
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Sitka Banner", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 39);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Returns Center";
            // 
            // ReturnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.viewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReturnsForm";
            this.viewPanel.ResumeLayout(false);
            this.viewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel viewPanel;
        private Guna.UI2.WinForms.Guna2Button btnLoadSale;
        private Guna.UI2.WinForms.Guna2TextBox txtReceiptNumber;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReceipt;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSaleStatus;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSaleItems;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSelection;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuantity;
        private Guna.UI2.WinForms.Guna2NumericUpDown numReturnQty;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReturnType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbReturnType;
        private Guna.UI2.WinForms.Guna2TextBox txtReason;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblReason;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeId;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmployee;
        private Guna.UI2.WinForms.Guna2Button btnProcess;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button exitbtn;
        private System.Windows.Forms.Label lblTitle;
    }
}
