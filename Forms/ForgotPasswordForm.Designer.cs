namespace EvsonHardware.Forms
{
    partial class ForgotPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnX;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private System.Windows.Forms.Label lblNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirm;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirm;
        private System.Windows.Forms.Label lblShowPass;
        private System.Windows.Forms.Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnNext;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var ce1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var ce14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnX = new Guna.UI2.WinForms.Guna2Button();
            lblStep = new System.Windows.Forms.Label();
            pnlCard = new System.Windows.Forms.Panel();
            lblInstruction = new System.Windows.Forms.Label();
            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblFullName = new System.Windows.Forms.Label();
            txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            lblNewPass = new System.Windows.Forms.Label();
            txtNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            lblConfirm = new System.Windows.Forms.Label();
            txtConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            lblShowPass = new System.Windows.Forms.Label();
            pnlBottom = new System.Windows.Forms.Panel();
            btnBack = new Guna.UI2.WinForms.Guna2Button();
            btnNext = new Guna.UI2.WinForms.Guna2Button();

            pnlTitleBar.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            pnlTitleBar.FillColor = System.Drawing.Color.OliveDrab;
            pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTitleBar.Height = 52;
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.TabIndex = 0;
            pnlTitleBar.CustomizableEdges = ce1;
            pnlTitleBar.ShadowDecoration.CustomizableEdges = ce2;
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(btnX);

            lblTitle.AutoSize = true;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F,
                                     System.Drawing.FontStyle.Bold,
                                     System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(16, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Forgot Password";

            btnX.AutoRoundedCorners = true;
            btnX.BackColor = System.Drawing.Color.Transparent;
            btnX.BorderColor = System.Drawing.Color.Transparent;
            btnX.CustomizableEdges = ce3;
            btnX.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnX.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnX.FillColor = System.Drawing.Color.Firebrick;
            btnX.Font = new System.Drawing.Font("Segoe UI", 10F,
                                                    System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, 0);
            btnX.ForeColor = System.Drawing.Color.White;
            btnX.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 40, 40);
            btnX.Location = new System.Drawing.Point(438, 9);
            btnX.Name = "btnX";
            btnX.ShadowDecoration.CustomizableEdges = ce4;
            btnX.Size = new System.Drawing.Size(34, 34);
            btnX.TabIndex = 1;
            btnX.Text = "✕";
            btnX.Cursor = System.Windows.Forms.Cursors.Hand;
            btnX.Click += btnX_Click;

            lblStep.Dock = System.Windows.Forms.DockStyle.Top;
            lblStep.Height = 28;
            lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStep.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                    System.Drawing.FontStyle.Bold,
                                    System.Drawing.GraphicsUnit.Point, 0);
            lblStep.ForeColor = System.Drawing.Color.OliveDrab;
            lblStep.BackColor = System.Drawing.Color.FromArgb(235, 240, 210);
            lblStep.Name = "lblStep";
            lblStep.TabIndex = 1;
            lblStep.Text = "Step 1 of 3";

            pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard.BackColor = System.Drawing.Color.FromArgb(245, 247, 230);
            pnlCard.Padding = new System.Windows.Forms.Padding(40, 20, 40, 10);
            pnlCard.Name = "pnlCard";
            pnlCard.TabIndex = 2;
            pnlCard.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblInstruction,
                lblUsername,  txtUsername,
                lblFullName,  txtFullName,
                lblNewPass,   txtNewPass,
                lblConfirm,   txtConfirm,
                lblShowPass
            });

            lblInstruction.AutoSize = false;
            lblInstruction.Size = new System.Drawing.Size(400, 38);
            lblInstruction.Location = new System.Drawing.Point(40, 20);
            lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                           System.Drawing.FontStyle.Regular,
                                           System.Drawing.GraphicsUnit.Point, 0);
            lblInstruction.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblInstruction.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            lblInstruction.Name = "lblInstruction";
            lblInstruction.TabIndex = 0;
            lblInstruction.Text = "";

            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F,
                                        System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, 0);
            lblUsername.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblUsername.Location = new System.Drawing.Point(40, 72);
            lblUsername.Name = "lblUsername";
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            lblUsername.Visible = false;

            txtUsername.BorderRadius = 8;
            txtUsername.BorderColor = System.Drawing.Color.FromArgb(186, 201, 100);
            txtUsername.FillColor = System.Drawing.Color.White;
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F,
                                             System.Drawing.FontStyle.Regular,
                                             System.Drawing.GraphicsUnit.Point, 0);
            txtUsername.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            txtUsername.Location = new System.Drawing.Point(40, 96);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(400, 38);
            txtUsername.TabIndex = 2;
            txtUsername.Visible = false;
            txtUsername.CustomizableEdges = ce5;
            txtUsername.ShadowDecoration.CustomizableEdges = ce6;

            lblFullName.AutoSize = true;
            lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F,
                                        System.Drawing.FontStyle.Bold,
                                        System.Drawing.GraphicsUnit.Point, 0);
            lblFullName.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblFullName.Location = new System.Drawing.Point(40, 72);
            lblFullName.Name = "lblFullName";
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Full Name (as registered):";
            lblFullName.Visible = false;

            txtFullName.BorderRadius = 8;
            txtFullName.BorderColor = System.Drawing.Color.FromArgb(186, 201, 100);
            txtFullName.FillColor = System.Drawing.Color.White;
            txtFullName.Font = new System.Drawing.Font("Segoe UI", 10.5F,
                                             System.Drawing.FontStyle.Regular,
                                             System.Drawing.GraphicsUnit.Point, 0);
            txtFullName.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            txtFullName.Location = new System.Drawing.Point(40, 96);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new System.Drawing.Size(400, 38);
            txtFullName.TabIndex = 4;
            txtFullName.Visible = false;
            txtFullName.CustomizableEdges = ce7;
            txtFullName.ShadowDecoration.CustomizableEdges = ce8;

            lblNewPass.AutoSize = true;
            lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9F,
                                       System.Drawing.FontStyle.Bold,
                                       System.Drawing.GraphicsUnit.Point, 0);
            lblNewPass.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblNewPass.Location = new System.Drawing.Point(40, 72);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.TabIndex = 5;
            lblNewPass.Text = "New Password:";
            lblNewPass.Visible = false;

            txtNewPass.BorderRadius = 8;
            txtNewPass.BorderColor = System.Drawing.Color.FromArgb(186, 201, 100);
            txtNewPass.FillColor = System.Drawing.Color.White;
            txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10.5F,
                                                     System.Drawing.FontStyle.Regular,
                                                     System.Drawing.GraphicsUnit.Point, 0);
            txtNewPass.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            txtNewPass.Location = new System.Drawing.Point(40, 96);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new System.Drawing.Size(400, 38);
            txtNewPass.TabIndex = 6;
            txtNewPass.UseSystemPasswordChar = true;
            txtNewPass.Visible = false;
            txtNewPass.CustomizableEdges = ce9;
            txtNewPass.ShadowDecoration.CustomizableEdges = ce10;

            lblConfirm.AutoSize = true;
            lblConfirm.Font = new System.Drawing.Font("Segoe UI", 9F,
                                       System.Drawing.FontStyle.Bold,
                                       System.Drawing.GraphicsUnit.Point, 0);
            lblConfirm.ForeColor = System.Drawing.Color.DarkOliveGreen;
            lblConfirm.Location = new System.Drawing.Point(40, 148);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.TabIndex = 7;
            lblConfirm.Text = "Confirm Password:";
            lblConfirm.Visible = false;

            txtConfirm.BorderRadius = 8;
            txtConfirm.BorderColor = System.Drawing.Color.FromArgb(186, 201, 100);
            txtConfirm.FillColor = System.Drawing.Color.White;
            txtConfirm.Font = new System.Drawing.Font("Segoe UI", 10.5F,
                                                   System.Drawing.FontStyle.Regular,
                                                   System.Drawing.GraphicsUnit.Point, 0);
            txtConfirm.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            txtConfirm.Location = new System.Drawing.Point(40, 172);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new System.Drawing.Size(400, 38);
            txtConfirm.TabIndex = 8;
            txtConfirm.UseSystemPasswordChar = true;
            txtConfirm.Visible = false;
            txtConfirm.CustomizableEdges = ce11;
            txtConfirm.ShadowDecoration.CustomizableEdges = ce12;

            lblShowPass.AutoSize = true;
            lblShowPass.Font = new System.Drawing.Font("Segoe UI", 8.5F,
                                        System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, 0);
            lblShowPass.ForeColor = System.Drawing.Color.OliveDrab;
            lblShowPass.Location = new System.Drawing.Point(40, 218);
            lblShowPass.Name = "lblShowPass";
            lblShowPass.TabIndex = 9;
            lblShowPass.Text = "👁  Show password";
            lblShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            lblShowPass.Visible = false;
            lblShowPass.Click += lblShowPass_Click;

            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Height = 60;
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(235, 240, 210);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.TabIndex = 3;
            pnlBottom.Controls.Add(btnBack);
            pnlBottom.Controls.Add(btnNext);

            btnBack.AutoRoundedCorners = true;
            btnBack.BorderRadius = 20;
            btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnBack.FillColor = System.Drawing.Color.FromArgb(160, 160, 160);
            btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                                    System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, 0);
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.HoverState.FillColor = System.Drawing.Color.FromArgb(130, 130, 130);
            btnBack.Location = new System.Drawing.Point(20, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(110, 36);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Visible = false;
            btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBack.CustomizableEdges = ce13;
            btnBack.ShadowDecoration.CustomizableEdges = ce14;
            btnBack.Click += btnBack_Click;

            btnNext.AutoRoundedCorners = true;
            btnNext.BorderRadius = 20;
            btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnNext.FillColor = System.Drawing.Color.OliveDrab;
            btnNext.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                                                    System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, 0);
            btnNext.ForeColor = System.Drawing.Color.White;
            btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(80, 120, 20);
            btnNext.Location = new System.Drawing.Point(350, 12);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(120, 36);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next →";
            btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNext.Click += btnNext_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 230);
            ClientSize = new System.Drawing.Size(480, 400);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ForgotPasswordForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Forgot Password";

            Controls.Add(pnlCard);
            Controls.Add(pnlBottom);
            Controls.Add(lblStep);
            Controls.Add(pnlTitleBar);

            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}