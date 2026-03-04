using EvsonHardware.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class Dashboard_Form : Form
    {
        private string _role;
        private int _userId;

        public Dashboard_Form(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            WireEvents();
            ConfigureAccess();
;        }

        public Dashboard_Form()
        {
        }

        // ================================
        // WIRE EVENTS
        // ================================
        private void WireEvents()
        {
            homebtn.Click += Homebtn_Click;
            salesbtn.Click += Salesbtn_Click;
            inventorybtn.Click += Inventorybtn_Click;
            expensesbtn.Click += Expensesbtn_Click;
            reportbtn.Click += Reportbtn_Click;
            logoutbtn.Click += Logoutbtn_Click;
            exitbtn.Click += Exitbtn_Click;
            searchbar.TextChanged += Searchbar_TextChanged;
        }

        // ================================
        // ROLE CONTROL
        // ================================
        private void ConfigureAccess()
        {
            if (_role == "Cashier")
            {
                returnbtn.Visible = false;
                expensesbtn.Visible = false;
                reportbtn.Visible = false;
            }
        }

        // ================================
        // SIDEBAR BUTTON HIGHLIGHT
        // ================================
        private void ResetSidebarButtons()
        {
            foreach (Control ctrl in guna2ShadowPanel1.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                    btn.FillColor = Color.Beige;
            }
        }

        private void ActivateButton(Guna.UI2.WinForms.Guna2Button button)
        {
            ResetSidebarButtons();
            button.FillColor = Color.LightGreen;
        }

        // ================================
        // BUTTON EVENTS
        // ================================
        private void Homebtn_Click(object sender, EventArgs e)
        {
            ActivateButton(homebtn);
            LoadDashboardStats();
        }

        private void Salesbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(salesbtn);
            var form = new SalesForm();
            form.ShowDialog();
        }

        private void Inventorybtn_Click(object sender, EventArgs e)
        {
            ActivateButton(inventorybtn);
            var form = new InventoryForm();
            form.ShowDialog();
        }

        private void Expensesbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(expensesbtn);
            MessageBox.Show("Open Expenses Module");
        }

        private void Reportbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(reportbtn);
            MessageBox.Show("Open Reports Module");
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ================================
        // GLOBAL SEARCH
        // ================================
        private void Searchbar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchbar.Text))
                return;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT product_name, price, stock
                FROM Product
                WHERE product_name LIKE $search
                LIMIT 1";

            cmd.Parameters.AddWithValue("$search", "%" + searchbar.Text + "%");

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string name = reader.GetString(0);
                double price = reader.GetDouble(1);
                int stock = reader.GetInt32(2);

                MessageBox.Show(
                    $"Product: {name}\nPrice: ₱{price:N2}\nStock: {stock}",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ================================
        // DASHBOARD CARD LOGIC
        // ================================
        private void LoadDashboardStats()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            // Example: Sales Today
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT IFNULL(SUM(total_amount),0)
                FROM Sale
                WHERE sale_date = date('now')";

            var result = cmd.ExecuteScalar();
            decimal salesToday = Convert.ToDecimal(result);

            // You can later display this inside labels inside:
            // guna2GradientPanel1, guna2GradientPanel2 etc.
            // Example:
            // lblSalesToday.Text = "₱ " + salesToday.ToString("N2");
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }       
    }
}