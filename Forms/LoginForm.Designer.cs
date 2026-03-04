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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            forgotpass = new LinkLabel();
            loginbtn = new Guna.UI2.WinForms.Guna2Button();
            usertxt = new Guna.UI2.WinForms.Guna2TextBox();
            passwordtxt = new Guna.UI2.WinForms.Guna2TextBox();
            exitbtn = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // forgotpass
            // 
            forgotpass.ActiveLinkColor = Color.Blue;
            forgotpass.AutoSize = true;
            forgotpass.BackColor = Color.Transparent;
            forgotpass.Location = new Point(226, 317);
            forgotpass.Name = "forgotpass";
            forgotpass.Size = new Size(151, 29);
            forgotpass.TabIndex = 8;
            forgotpass.TabStop = true;
            forgotpass.Text = "Forgot Password?";
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.Transparent;
            loginbtn.BorderColor = Color.LemonChiffon;
            loginbtn.BorderRadius = 30;
            loginbtn.BorderThickness = 2;
            loginbtn.CustomizableEdges = customizableEdges1;
            loginbtn.DisabledState.BorderColor = Color.DarkGray;
            loginbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            loginbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            loginbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            loginbtn.FillColor = Color.DarkGreen;
            loginbtn.FocusedColor = Color.PaleGreen;
            loginbtn.Font = new Font("Sitka Display", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(134, 403);
            loginbtn.Name = "loginbtn";
            loginbtn.PressedColor = Color.Green;
            loginbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            loginbtn.Size = new Size(214, 67);
            loginbtn.TabIndex = 13;
            loginbtn.Text = "Login";
            loginbtn.Click += loginbtn_Click;
            // 
            // usertxt
            // 
            usertxt.BackColor = Color.Transparent;
            usertxt.BorderColor = Color.OliveDrab;
            usertxt.BorderRadius = 10;
            usertxt.BorderThickness = 3;
            usertxt.CustomizableEdges = customizableEdges3;
            usertxt.DefaultText = "";
            usertxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            usertxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            usertxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            usertxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            usertxt.FillColor = Color.LemonChiffon;
            usertxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            usertxt.Font = new Font("Segoe UI", 9F);
            usertxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            usertxt.Location = new Point(94, 166);
            usertxt.Margin = new Padding(4, 5, 4, 5);
            usertxt.Name = "usertxt";
            usertxt.PlaceholderForeColor = Color.DarkSeaGreen;
            usertxt.PlaceholderText = "User ID";
            usertxt.SelectedText = "";
            usertxt.ShadowDecoration.CustomizableEdges = customizableEdges4;
            usertxt.Size = new Size(283, 52);
            usertxt.TabIndex = 14;
            // 
            // passwordtxt
            // 
            passwordtxt.BackColor = Color.Transparent;
            passwordtxt.BorderColor = Color.OliveDrab;
            passwordtxt.BorderRadius = 10;
            passwordtxt.BorderThickness = 3;
            passwordtxt.CustomizableEdges = customizableEdges5;
            passwordtxt.DefaultText = "";
            passwordtxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            passwordtxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            passwordtxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            passwordtxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            passwordtxt.FillColor = Color.LemonChiffon;
            passwordtxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordtxt.Font = new Font("Segoe UI", 9F);
            passwordtxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            passwordtxt.Location = new Point(94, 251);
            passwordtxt.Margin = new Padding(4, 5, 4, 5);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PasswordChar = '*';
            passwordtxt.PlaceholderForeColor = Color.DarkSeaGreen;
            passwordtxt.PlaceholderText = "Password";
            passwordtxt.SelectedText = "";
            passwordtxt.ShadowDecoration.CustomizableEdges = customizableEdges6;
            passwordtxt.Size = new Size(283, 51);
            passwordtxt.TabIndex = 15;
            // 
            // exitbtn
            // 
            exitbtn.AutoRoundedCorners = true;
            exitbtn.BackColor = Color.Transparent;
            exitbtn.BorderColor = Color.Transparent;
            exitbtn.CustomizableEdges = customizableEdges7;
            exitbtn.DisabledState.BorderColor = Color.DarkGray;
            exitbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            exitbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            exitbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            exitbtn.FillColor = Color.Transparent;
            exitbtn.Font = new Font("Sitka Small", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.DarkRed;
            exitbtn.HoverState.FillColor = Color.FromArgb(128, 255, 128);
            exitbtn.ImageSize = new Size(260, 220);
            exitbtn.Location = new Point(420, 12);
            exitbtn.Name = "exitbtn";
            exitbtn.PressedColor = Color.DarkGreen;
            exitbtn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            exitbtn.Size = new Size(41, 48);
            exitbtn.TabIndex = 19;
            exitbtn.Text = "X";
            exitbtn.Click += exitbtn_Click_1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(473, 529);
            Controls.Add(exitbtn);
            Controls.Add(passwordtxt);
            Controls.Add(usertxt);
            Controls.Add(loginbtn);
            Controls.Add(forgotpass);
            DoubleBuffered = true;
            Font = new Font("Sitka Banner", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ForeColor = Color.YellowGreen;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Evson Hardware";
            TransparencyKey = Color.White;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel forgotpass;
        private Guna.UI2.WinForms.Guna2Button loginbtn;
        private Guna.UI2.WinForms.Guna2TextBox usertxt;
        private Guna.UI2.WinForms.Guna2TextBox passwordtxt;
        private Guna.UI2.WinForms.Guna2Button exitbtn;
    }
}