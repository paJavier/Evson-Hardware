namespace EvsonHardware.Forms
{
    partial class Dashboard_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_Form));
            pnlTop = new Panel();
            searchbar = new TextBox();
            loginbtn = new Button();
            label1 = new Label();
            pnlSidebar = new Panel();
            button1 = new Button();
            button9 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            pnlMainContent = new Panel();
            pnlSearchResult = new Panel();
            lblProductName = new Label();
            lblPrice = new Label();
            lblStock = new Label();
            lblStatus = new Label();
            pnlTop.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlSearchResult.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.BorderStyle = BorderStyle.Fixed3D;
            pnlTop.Controls.Add(pnlSearchResult);
            pnlTop.Controls.Add(searchbar);
            pnlTop.Controls.Add(loginbtn);
            pnlTop.Controls.Add(label1);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(2, 2, 2, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(949, 131);
            pnlTop.TabIndex = 1;
            // 
            // searchbar
            // 
            searchbar.AcceptsTab = true;
            searchbar.BackColor = Color.Ivory;
            searchbar.BorderStyle = BorderStyle.None;
            searchbar.Font = new Font("Sitka Display", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbar.Location = new Point(241, 20);
            searchbar.Margin = new Padding(2, 2, 2, 2);
            searchbar.Multiline = true;
            searchbar.Name = "searchbar";
            searchbar.PlaceholderText = "Search Product";
            searchbar.Size = new Size(450, 28);
            searchbar.TabIndex = 7;
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.Transparent;
            loginbtn.BackgroundImageLayout = ImageLayout.None;
            loginbtn.Enabled = false;
            loginbtn.FlatAppearance.BorderColor = Color.Black;
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.Transparent;
            loginbtn.Image = (Image)resources.GetObject("loginbtn.Image");
            loginbtn.Location = new Point(769, 35);
            loginbtn.Margin = new Padding(2, 2, 2, 2);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(167, 48);
            loginbtn.TabIndex = 5;
            loginbtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(9, -67);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 175);
            label1.TabIndex = 6;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Transparent;
            pnlSidebar.BorderStyle = BorderStyle.Fixed3D;
            pnlSidebar.Controls.Add(button1);
            pnlSidebar.Controls.Add(button9);
            pnlSidebar.Controls.Add(button5);
            pnlSidebar.Controls.Add(button6);
            pnlSidebar.Controls.Add(button7);
            pnlSidebar.Controls.Add(button8);
            pnlSidebar.Controls.Add(button4);
            pnlSidebar.Controls.Add(button3);
            pnlSidebar.Controls.Add(button2);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 131);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(213, 570);
            pnlSidebar.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Enabled = false;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(15, 10);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(176, 53);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.BackgroundImageLayout = ImageLayout.None;
            button9.Enabled = false;
            button9.FlatAppearance.BorderColor = Color.Black;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.Transparent;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(2, 503);
            button9.Margin = new Padding(2);
            button9.Name = "button9";
            button9.Size = new Size(133, 64);
            button9.TabIndex = 15;
            button9.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.Enabled = false;
            button5.FlatAppearance.BorderColor = Color.Black;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.Transparent;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(9, 435);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(181, 55);
            button5.TabIndex = 14;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.Enabled = false;
            button6.FlatAppearance.BorderColor = Color.Black;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Transparent;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(9, 378);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(176, 53);
            button6.TabIndex = 13;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImageLayout = ImageLayout.None;
            button7.Enabled = false;
            button7.FlatAppearance.BorderColor = Color.Black;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.Transparent;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(10, 317);
            button7.Margin = new Padding(2);
            button7.Name = "button7";
            button7.Size = new Size(175, 57);
            button7.TabIndex = 12;
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.Enabled = false;
            button8.FlatAppearance.BorderColor = Color.Black;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.Transparent;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(15, 255);
            button8.Margin = new Padding(2);
            button8.Name = "button8";
            button8.Size = new Size(175, 58);
            button8.TabIndex = 11;
            button8.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.Enabled = false;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Transparent;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(15, 195);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(175, 56);
            button4.TabIndex = 10;
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Enabled = false;
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(15, 130);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(175, 61);
            button3.TabIndex = 9;
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.Enabled = false;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Sitka Small", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(15, 67);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(176, 59);
            button2.TabIndex = 8;
            button2.UseVisualStyleBackColor = false;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.Transparent;
            pnlMainContent.BorderStyle = BorderStyle.Fixed3D;
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(213, 131);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(736, 570);
            pnlMainContent.TabIndex = 3;
            // 
            // pnlSearchResult
            // 
            pnlSearchResult.BackColor = SystemColors.Control;
            pnlSearchResult.BorderStyle = BorderStyle.FixedSingle;
            pnlSearchResult.Controls.Add(lblStatus);
            pnlSearchResult.Controls.Add(lblStock);
            pnlSearchResult.Controls.Add(lblPrice);
            pnlSearchResult.Controls.Add(lblProductName);
            pnlSearchResult.Location = new Point(241, 53);
            pnlSearchResult.Name = "pnlSearchResult";
            pnlSearchResult.Size = new Size(450, 61);
            pnlSearchResult.TabIndex = 8;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Transparent;
            lblProductName.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.ForeColor = Color.DarkOliveGreen;
            lblProductName.Location = new Point(30, 14);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(50, 19);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Product";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.DarkOliveGreen;
            lblPrice.Location = new Point(146, 14);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 19);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Price";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.ForeColor = Color.DarkOliveGreen;
            lblStock.Location = new Point(256, 14);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(37, 19);
            lblStock.TabIndex = 2;
            lblStock.Text = "Stock";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Sitka Banner", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.DarkOliveGreen;
            lblStatus.Location = new Point(369, 14);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status";
            // 
            // Dashboard_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(949, 701);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "Dashboard_Form";
            Text = "Evson Hardware";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSearchResult.ResumeLayout(false);
            pnlSearchResult.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlTop;
        internal Label label1;
        private Button loginbtn;
        private TextBox searchbar;
        private Panel pnlSidebar;
        private Button button1;
        private Button button9;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel pnlMainContent;
        private Panel pnlSearchResult;
        private Label lblStatus;
        private Label lblStock;
        private Label lblPrice;
        private Label lblProductName;
    }
}