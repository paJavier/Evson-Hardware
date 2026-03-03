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
            passwordtxt = new TextBox();
            usertxt = new TextBox();
            forgotpass = new LinkLabel();
            button1 = new Button();
            SuspendLayout();
            // 
            // passwordtxt
            // 
            passwordtxt.BackColor = Color.White;
            passwordtxt.Cursor = Cursors.IBeam;
            passwordtxt.Font = new Font("Sitka Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordtxt.ForeColor = Color.YellowGreen;
            passwordtxt.Location = new Point(77, 249);
            passwordtxt.Multiline = true;
            passwordtxt.Name = "passwordtxt";
            passwordtxt.PlaceholderText = "Password";
            passwordtxt.Size = new Size(271, 35);
            passwordtxt.TabIndex = 12;
            // 
            // usertxt
            // 
            usertxt.BackColor = Color.White;
            usertxt.Cursor = Cursors.IBeam;
            usertxt.Font = new Font("Sitka Display", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usertxt.ForeColor = Color.YellowGreen;
            usertxt.Location = new Point(77, 160);
            usertxt.Multiline = true;
            usertxt.Name = "usertxt";
            usertxt.PlaceholderText = "User ID";
            usertxt.Size = new Size(271, 35);
            usertxt.TabIndex = 11;
            // 
            // forgotpass
            // 
            forgotpass.ActiveLinkColor = Color.Blue;
            forgotpass.AutoSize = true;
            forgotpass.BackColor = Color.Transparent;
            forgotpass.Location = new Point(197, 307);
            forgotpass.Name = "forgotpass";
            forgotpass.Size = new Size(151, 29);
            forgotpass.TabIndex = 8;
            forgotpass.TabStop = true;
            forgotpass.Text = "Forgot Password?";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGreen;
            button1.Font = new Font("Sitka Text", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(124, 349);
            button1.Name = "button1";
            button1.Size = new Size(169, 52);
            button1.TabIndex = 17;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(415, 456);
            Controls.Add(button1);
            Controls.Add(passwordtxt);
            Controls.Add(usertxt);
            Controls.Add(forgotpass);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordtxt;
        private TextBox usertxt;
        private LinkLabel forgotpass;
        private Button button1;
    }
}