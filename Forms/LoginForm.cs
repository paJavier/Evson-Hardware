using EvsonHardware.Data;
using EvsonHardware.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EvsonHardware.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = loginbtn;
            passwordtxt.UseSystemPasswordChar = true;
        }

        private void loginbtn_Click(object sender, EventArgs e)

        {
            string username = usertxt.Text.Trim();
            string rawPassword = passwordtxt.Text.Trim();

            if (username == "" || rawPassword == "")
            {
                CustomMessageBox.Show("Please enter username and password.");
                return;
            }

            string password = PasswordHasher.Hash(rawPassword);

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT user_id, role
            FROM users
            WHERE username = $username
            AND password_hash = $password
            AND is_active = 1
            LIMIT 1";

            cmd.Parameters.AddWithValue("$username", username);
            cmd.Parameters.AddWithValue("$password", password);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int userId = reader.GetInt32(0);
                string role = reader.GetString(1);

                Dashboard_Form dashboard = new Dashboard_Form(role, userId);
                dashboard.Show();

                this.Hide();
            }
            else
            {
                CustomMessageBox.Show("Invalid username or password");
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forgotpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var form = new ForgotPasswordForm();
            form.ShowDialog(this);
        }



        private bool _showPass = false;
        private void lblShowPass_Click(object sender, EventArgs e)
        {
            _showPass = !_showPass;
            passwordtxt.UseSystemPasswordChar = !_showPass;
            lblShowPass.Text = _showPass ? "🙈" : "👁";
        }
    }
}
