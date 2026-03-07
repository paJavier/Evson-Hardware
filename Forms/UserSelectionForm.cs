using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public class UserSelectionForm : Form
    {
        public int SelectedUserId { get; private set; }
        private Button? _selectedButton;

        public UserSelectionForm(Dictionary<string, int> users)
        {
            this.Size = new Size(420, 350);
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
            title.Text = "Switch User";
            title.ForeColor = Color.White;
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(15, 15);

            header.Controls.Add(title);

            Button closeHeaderBtn = new Button();
            closeHeaderBtn.Text = "X";
            closeHeaderBtn.Size = new Size(34, 30);
            closeHeaderBtn.Location = new Point(this.Width - 52, 12);
            closeHeaderBtn.BackColor = Color.Firebrick;
            closeHeaderBtn.ForeColor = Color.White;
            closeHeaderBtn.FlatStyle = FlatStyle.Flat;
            closeHeaderBtn.FlatAppearance.BorderSize = 0;
            closeHeaderBtn.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            header.Controls.Add(closeHeaderBtn);
            this.Controls.Add(header);

            Panel listPanel = new Panel();
            listPanel.Location = new Point(40, 80);
            listPanel.Size = new Size(340, 185);
            listPanel.AutoScroll = true;
            listPanel.BackColor = Color.Transparent;
            this.Controls.Add(listPanel);

            int y = 0;

            foreach (var user in users)
            {
                Button btn = new Button();

                btn.Text = user.Key;
                btn.Tag = user.Value;

                btn.Size = new Size(300, 50);
                btn.Location = new Point(0, y);

                btn.BackColor = Color.SeaGreen;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                btn.FlatAppearance.BorderSize = 0;

                RoundCorners(btn, 15);

                btn.Click += (s, e) =>
                {
                    if (_selectedButton != null)
                        _selectedButton.BackColor = Color.SeaGreen;

                    _selectedButton = (Button)s!;
                    _selectedButton.BackColor = Color.MediumSeaGreen;
                    SelectedUserId = (int)_selectedButton.Tag!;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                listPanel.Controls.Add(btn);

                y += 65;
            }

            if (users.Count == 0)
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "No active users found.";
                emptyLabel.AutoSize = true;
                emptyLabel.Location = new Point(95, 120);
                emptyLabel.ForeColor = Color.DarkRed;
                this.Controls.Add(emptyLabel);
            }

            Button enterBtn = new Button();
            enterBtn.Text = "Enter";
            enterBtn.Size = new Size(130, 38);
            enterBtn.Location = new Point(70, 280);
            enterBtn.BackColor = Color.SeaGreen;
            enterBtn.ForeColor = Color.White;
            enterBtn.FlatStyle = FlatStyle.Flat;
            enterBtn.FlatAppearance.BorderSize = 0;
            enterBtn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            RoundCorners(enterBtn, 12);
            enterBtn.Click += (s, e) =>
            {
                if (SelectedUserId == 0)
                {
                    MessageBox.Show(this, "Select a user first.", "Switch User",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(enterBtn);

            Button closeBtn = new Button();
            closeBtn.Text = "Close (Esc)";
            closeBtn.Size = new Size(130, 38);
            closeBtn.Location = new Point(220, 280);
            closeBtn.BackColor = Color.DimGray;
            closeBtn.ForeColor = Color.White;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            RoundCorners(closeBtn, 12);
            closeBtn.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(closeBtn);

            this.AcceptButton = enterBtn;
            this.CancelButton = closeBtn;
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
