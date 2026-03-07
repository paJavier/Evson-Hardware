using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public class CustomMessageBox : Form
    {
        private Label lblTitle = null!;
        private Label lblMessage = null!;
        private Button btnOK = null!;
        private Button btnYes = null!;
        private Button btnNo = null!;
        private Panel headerPanel = null!;

        public CustomMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponents(buttons);

            lblTitle.Text = title;
            lblMessage.Text = message;

            RoundCorners(this, 20);
            RoundCorners(btnOK, 15);
            RoundCorners(btnYes, 15);
            RoundCorners(btnNo, 15);
        }

        private void InitializeComponents(MessageBoxButtons buttons)
        {
            this.Size = new Size(380, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Beige;

            // HEADER PANEL
            headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 40;
            headerPanel.BackColor = Color.SeaGreen;
            this.Controls.Add(headerPanel);

            // TITLE
            lblTitle = new Label();
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle.Location = new Point(12, 10);
            lblTitle.AutoSize = true;
            headerPanel.Controls.Add(lblTitle);

            // MESSAGE
            lblMessage = new Label();
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.Size = new Size(320, 60);
            lblMessage.Location = new Point(30, 60);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblMessage);

            // OK BUTTON
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Size = new Size(90, 35);
            btnOK.Location = new Point((this.Width / 2) - 45, 130);
            btnOK.BackColor = Color.SeaGreen;
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;

            btnOK.DialogResult = DialogResult.OK;
            btnOK.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnOK);

            // YES BUTTON
            btnYes = new Button();
            btnYes.Text = "Yes";
            btnYes.Size = new Size(90, 35);
            btnYes.Location = new Point((this.Width / 2) - 100, 130);
            btnYes.BackColor = Color.SeaGreen;
            btnYes.ForeColor = Color.White;
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.FlatAppearance.BorderSize = 0;
            btnYes.DialogResult = DialogResult.Yes;
            btnYes.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnYes);

            // NO BUTTON
            btnNo = new Button();
            btnNo.Text = "No";
            btnNo.Size = new Size(90, 35);
            btnNo.Location = new Point((this.Width / 2) + 10, 130);
            btnNo.BackColor = Color.DarkSeaGreen;
            btnNo.ForeColor = Color.White;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.FlatAppearance.BorderSize = 0;
            btnNo.DialogResult = DialogResult.No;
            btnNo.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnNo);

            if (buttons == MessageBoxButtons.YesNo)
            {
                btnOK.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
                this.AcceptButton = btnYes;
                this.CancelButton = btnNo;
            }
            else
            {
                btnOK.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;
                this.AcceptButton = btnOK;
            }
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

        /*  public static void Show(string message, string title = "Message")
          {
              CustomMessageBox box = new CustomMessageBox(message, title);
              box.ShowDialog();
          }*/

        public static DialogResult Show(string message)
        {
            return Show(message, "Message");
        }

        public static DialogResult Show(
            string message,
            string title,
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            if (buttons != MessageBoxButtons.OK && buttons != MessageBoxButtons.YesNo)
            {
                return MessageBox.Show(message, title, buttons, icon);
            }

            using CustomMessageBox box = new CustomMessageBox(message, title, buttons);
            return box.ShowDialog();
        }

        public static DialogResult Show(
            IWin32Window? owner,
            string message,
            string title = "Message",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            if (buttons != MessageBoxButtons.OK && buttons != MessageBoxButtons.YesNo)
            {
                return MessageBox.Show(owner, message, title, buttons, icon);
            }

            using CustomMessageBox box = new CustomMessageBox(message, title, buttons);
            box.StartPosition = owner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;
            return owner == null ? box.ShowDialog() : box.ShowDialog(owner);
        }
    }
}
