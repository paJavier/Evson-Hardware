namespace EvsonHardware.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            forgotpass = new LinkLabel();
            panel1 = new Panel();
            passwordtxt = new TextBox();
            usertxt = new TextBox();
            label1 = new Label();
            loginbtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // forgotpass
            // 
            forgotpass.ActiveLinkColor = Color.Blue;
            forgotpass.AutoSize = true;
            forgotpass.BackColor = Color.Transparent;
            forgotpass.Location = new Point(223, 342);
            forgotpass.Name = "forgotpass";
            forgotpass.Size = new Size(151, 29);
            forgotpass.TabIndex = 3;
            forgotpass.TabStop = true;
            forgotpass.Text = "Forgot Password?";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(passwordtxt);
            panel1.Controls.Add(usertxt);
            panel1.Controls.Add(loginbtn);
            panel1.Controls.Add(forgotpass);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(488, 563);
            panel1.TabIndex = 5;
            // 
            // passwordtxt
            // 
            passwordtxt.BackColor = SystemColors.Window;
            passwordtxt.Font = new Font("Sitka Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordtxt.ForeColor = Color.YellowGreen;
            passwordtxt.Location = new Point(106, 284);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PlaceholderText = "Password";
            passwordtxt.Size = new Size(271, 35);
            passwordtxt.TabIndex = 7;
            // 
            // usertxt
            // 
            usertxt.BackColor = SystemColors.Window;
            usertxt.Font = new Font("Sitka Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usertxt.ForeColor = Color.YellowGreen;
            usertxt.Location = new Point(106, 213);
            usertxt.Name = "usertxt";
            usertxt.PlaceholderText = "User ID";
            usertxt.Size = new Size(271, 35);
            usertxt.TabIndex = 6;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(92, 59);
            label1.Name = "label1";
            label1.Size = new Size(303, 195);
            label1.TabIndex = 5;
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
            loginbtn.Location = new Point(106, 406);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(231, 68);
            loginbtn.TabIndex = 4;
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(486, 559);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Font = new Font("Sitka Banner", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.YellowGreen;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware";
            TransparencyKey = Color.White;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel forgotpass;
        private Panel panel1;
        internal Label label1;
        private TextBox passwordtxt;
        private TextBox usertxt;
        private Button loginbtn;
    }
}