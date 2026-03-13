using EvsonHardware.Data;
using EvsonHardware.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private int _step = 1;
        private int _userId = -1;
        private string _username = "";
        private bool _showPass = false;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            ShowStep(1);
        }

        private void ShowStep(int step)
        {
            _step = step;
            lblUsername.Visible = false;
            txtUsername.Visible = false;
            lblFullName.Visible = false;
            txtFullName.Visible = false;
            lblNewPass.Visible = false;
            txtNewPass.Visible = false;
            lblConfirm.Visible = false;
            txtConfirm.Visible = false;
            lblShowPass.Visible = false;

            btnBack.Visible = step > 1;

            switch (step)
            {
                case 1:
                    lblStep.Text = "Step 1 of 3 — Identify Account";
                    lblInstruction.Text = "Enter your username to begin the password reset process.";
                    lblUsername.Visible = true;
                    txtUsername.Visible = true;
                    txtUsername.Clear();
                    txtUsername.Focus();
                    btnNext.Text = "Next →";
                    btnNext.BackColor = Color.OliveDrab;
                    break;

                case 2:
                    lblStep.Text = "Step 2 of 3 — Verify Identity";
                    lblInstruction.Text = "Enter the full name associated with your account to verify your identity.";
                    lblFullName.Visible = true;
                    txtFullName.Visible = true;
                    txtFullName.Clear();
                    txtFullName.Focus();
                    btnNext.Text = "Next →";
                    btnNext.BackColor = Color.OliveDrab;
                    break;

                case 3:
                    lblStep.Text = "Step 3 of 3 — Reset Password";
                    lblInstruction.Text = "Enter and confirm your new password.";
                    lblNewPass.Visible = true;
                    txtNewPass.Visible = true;
                    lblConfirm.Visible = true;
                    txtConfirm.Visible = true;
                    lblShowPass.Visible = true;
                    txtNewPass.Clear();
                    txtConfirm.Clear();
                    _showPass = false;
                    txtNewPass.UseSystemPasswordChar = true;
                    txtConfirm.UseSystemPasswordChar = true;
                    lblShowPass.Text = "👁  Show password";
                    txtNewPass.Focus();
                    btnNext.Text = "Reset Password";
                    btnNext.BackColor = Color.SeaGreen;
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (_step)
            {
                case 1: HandleStep1(); break;
                case 2: HandleStep2(); break;
                case 3: HandleStep3(); break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_step > 1) ShowStep(_step - 1);
        }

        private void btnX_Click(object sender, EventArgs e) => Close();
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void lblShowPass_Click(object sender, EventArgs e)
        {
            _showPass = !_showPass;
            txtNewPass.UseSystemPasswordChar = !_showPass;
            txtConfirm.UseSystemPasswordChar = !_showPass;
            lblShowPass.Text = _showPass ? "🙈  Hide password" : "👁  Show password";
        }

        private void HandleStep1()
        {
            _username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(_username))
            {
                Shake(txtUsername);
                CustomMessageBox.Show("Please enter your username.", "Forgot Password");
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT user_id FROM users
                    WHERE username = @u AND is_active = 1
                    LIMIT 1;";
                cmd.Parameters.AddWithValue("@u", _username);

                var result = cmd.ExecuteScalar();
                if (result == null)
                {
                    Shake(txtUsername);
                    CustomMessageBox.Show("Username not found or account is inactive.", "Forgot Password");
                    return;
                }

                _userId = Convert.ToInt32(result);
                ShowStep(2);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void HandleStep2()
        {
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Shake(txtFullName);
                CustomMessageBox.Show("Please enter your full name.", "Forgot Password");
                return;
            }

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                object result = null;

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 1 FROM users u
                    LEFT JOIN employee e ON u.employee_id = e.employee_id
                    WHERE u.user_id = @id
                      AND LOWER(TRIM(e.employee_name)) = LOWER(TRIM(@name))
                    LIMIT 1;";
                cmd.Parameters.AddWithValue("@id", _userId);
                cmd.Parameters.AddWithValue("@name", fullName);
                result = cmd.ExecuteScalar();

                if (result == null)
                {
                    var cmd2 = conn.CreateCommand();
                    cmd2.CommandText = @"
                        SELECT 1 FROM employee
                        WHERE LOWER(TRIM(employee_name)) = LOWER(TRIM(@name))
                        LIMIT 1;";
                    cmd2.Parameters.AddWithValue("@name", fullName);
                    result = cmd2.ExecuteScalar();
                }

                if (result == null)
                {
                    var cmd3 = conn.CreateCommand();
                    cmd3.CommandText = @"
                        SELECT 1 FROM users
                        WHERE user_id = @id
                          AND LOWER(TRIM(username)) = LOWER(TRIM(@name))
                        LIMIT 1;";
                    cmd3.Parameters.AddWithValue("@id", _userId);
                    cmd3.Parameters.AddWithValue("@name", fullName);
                    result = cmd3.ExecuteScalar();
                }

                if (result == null)
                {
                    Shake(txtFullName);
                    CustomMessageBox.Show(
                        "Name does not match our records.\nPlease check and try again.",
                        "Verification Failed");
                    return;
                }

                ShowStep(3);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void HandleStep3()
        {
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirm.Text;

            if (newPass.Length < 6)
            {
                Shake(txtNewPass);
                CustomMessageBox.Show("Password must be at least 6 characters.", "Forgot Password");
                return;
            }
            if (newPass != confirmPass)
            {
                Shake(txtConfirm);
                CustomMessageBox.Show("Passwords do not match.", "Forgot Password");
                return;
            }

            try
            {
                string hash = PasswordHasher.Hash(newPass);

                using var conn = Database.GetConnection();
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE users SET password_hash = @hash
                    WHERE user_id = @id;";
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.Parameters.AddWithValue("@id", _userId);
                cmd.ExecuteNonQuery();

                CustomMessageBox.Show(
                    $"Password for '{_username}' has been reset successfully!\nYou can now log in with your new password.",
                    "Success");

                Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error resetting password: " + ex.Message, "Error");
            }
        }

        private async void Shake(Control ctrl)
        {
            var orig = ctrl.Location;
            int[] steps = { -6, 6, -4, 4, -2, 2, 0 };
            foreach (int dx in steps)
            {
                ctrl.Location = new Point(orig.X + dx, orig.Y);
                await System.Threading.Tasks.Task.Delay(30);
            }
            ctrl.Location = orig;
        }
    }
}