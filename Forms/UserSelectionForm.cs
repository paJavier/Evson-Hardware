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

        public UserSelectionForm(Dictionary<string, int> users)
        {
            this.Size = new Size(420, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Beige;

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
            this.Controls.Add(header);

            int y = 90;

            foreach (var user in users)
            {
                Button btn = new Button();

                btn.Text = user.Key;
                btn.Tag = user.Value;

                btn.Size = new Size(300, 50);
                btn.Location = new Point(60, y);

                btn.BackColor = Color.SeaGreen;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                btn.FlatAppearance.BorderSize = 0;

                RoundCorners(btn, 15);

                btn.Click += (s, e) =>
                {
                    SelectedUserId = (int)((Button)s).Tag;

                    this.DialogResult = DialogResult.OK;
                    this.Close(); // closes immediately
                };

                this.Controls.Add(btn);

                y += 65;
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
    }
}