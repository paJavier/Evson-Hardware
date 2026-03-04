using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public class CustomMessageBox : Form
    {
        private Label lblTitle;
        private Label lblMessage;
        private Button btnOK;
        private Panel headerPanel;

        public CustomMessageBox(string message, string title)
        {
            InitializeComponents();

            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        private void InitializeComponents()
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
            btnOK.Click += (s, e) => { this.Close(); };

            this.Controls.Add(btnOK);
        }

        public static void Show(string message, string title = "Message")
        {
            CustomMessageBox box = new CustomMessageBox(message, title);
            box.ShowDialog();
        }
    }
}