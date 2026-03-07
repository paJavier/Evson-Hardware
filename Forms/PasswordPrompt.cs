using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public class PasswordPromptForm : Form
    {
        public string EnteredPassword { get; private set; }

        public PasswordPromptForm(string username)
        {
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Beige;
            this.KeyPreview = true;

            RoundCorners(this, 20);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 55;
            header.BackColor = Color.SeaGreen;

            Label title = new Label();
            title.Text = "Enter Password";
            title.ForeColor = Color.White;
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(15, 15);

            header.Controls.Add(title);
            this.Controls.Add(header);

            Label userLabel = new Label();
            userLabel.Text = username;
            userLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            userLabel.Location = new Point(40, 80);
            userLabel.AutoSize = true;

            TextBox passwordBox = new TextBox();
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.Size = new Size(300, 35);
            passwordBox.Location = new Point(40, 110);
            passwordBox.Font = new Font("Segoe UI", 12);

            Button confirm = new Button();
            confirm.Text = "Login";
            confirm.Size = new Size(120, 40);
            confirm.Location = new Point(70, 170);

            confirm.BackColor = Color.SeaGreen;
            confirm.ForeColor = Color.White;
            confirm.FlatStyle = FlatStyle.Flat;
            confirm.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            confirm.FlatAppearance.BorderSize = 0;

            RoundCorners(confirm, 15);

            confirm.Click += (s, e) =>
            {
                EnteredPassword = passwordBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            Button cancel = new Button();
            cancel.Text = "Close (Esc)";
            cancel.Size = new Size(120, 40);
            cancel.Location = new Point(210, 170);
            cancel.BackColor = Color.DimGray;
            cancel.ForeColor = Color.White;
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            cancel.FlatAppearance.BorderSize = 0;
            RoundCorners(cancel, 15);
            cancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.Add(userLabel);
            this.Controls.Add(passwordBox);
            this.Controls.Add(confirm);
            this.Controls.Add(cancel);

            this.AcceptButton = confirm;
            this.CancelButton = cancel;
        }

        private void RoundCorners(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);

            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseAllFigures();

            control.Region = new Region(path);
        }
    }
}
