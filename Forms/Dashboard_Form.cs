using EvsonHardware.Data;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class Dashboard_Form : Form
    {
        private string _role;
        private int _userId;
        private DataGridView productGrid;

        public Dashboard_Form(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            WireEvents();
            ConfigureAccess();

            InitializeSearchGrid();
            LoadDashboardStats();
            LoadCurrentUser();
        }

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
            searchbar.KeyDown += Searchbar_KeyDown;
            userbtn.Click += userbtn_Click;
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

            RefreshData();
        }

        private void Inventorybtn_Click(object sender, EventArgs e)
        {
            ActivateButton(inventorybtn);
            var form = new InventoryForm();
            form.ShowDialog();

            RefreshData();
        }

        private void Expensesbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(expensesbtn);
            CustomMessageBox.Show("Open Expenses Module");

            RefreshData();
        }

        private void Reportbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(reportbtn);
            CustomMessageBox.Show("Open Reports Module");

            RefreshData();
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
        private void SearchProduct(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return;

            productGrid.DataSource = null;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT product_name, price, stock
                FROM product_stock
                WHERE product_name LIKE $search
                LIMIT 10";

            cmd.Parameters.AddWithValue("$search", "%" + searchText + "%");

            var dt = new DataTable();

            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            productGrid.DataSource = dt;
        }

        private void Searchbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProduct(searchbar.Text);
            }
        }

        private void InitializeSearchGrid()
        {
            productGrid = new DataGridView();
            productGrid.Dock = DockStyle.Fill;

            productGrid.CellClick += ProductGrid_CellClick;

            productGrid.ColumnCount = 3;
            productGrid.Columns[0].Name = "Product";
            productGrid.Columns[1].Name = "Price";
            productGrid.Columns[2].Name = "Stock";

            productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productGrid.ReadOnly = true;
            productGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dynamicpanel.Controls.Add(productGrid);
        }

        private void ProductGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = productGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                string price = productGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                string stock = productGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                CustomMessageBox.Show(
                    $"Product: {name}\nPrice: ₱{price}\nStock: {stock}",
                    "Product Info"
                );
            }
        }
        private void ShowProductResult(string name, double price, int stock)
        {
            dynamicpanel.Controls.Clear();

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblName.Location = new Point(30, 30);
            lblName.AutoSize = true;

            Label lblPrice = new Label();
            lblPrice.Text = "Price: ₱" + price.ToString("N2");
            lblPrice.Font = new Font("Segoe UI", 12);
            lblPrice.Location = new Point(30, 80);
            lblPrice.AutoSize = true;

            Label lblStock = new Label();
            lblStock.Text = "Stock: " + stock;
            lblStock.Font = new Font("Segoe UI", 12);
            lblStock.Location = new Point(30, 120);
            lblStock.AutoSize = true;

            dynamicpanel.Controls.Add(lblName);
            dynamicpanel.Controls.Add(lblPrice);
            dynamicpanel.Controls.Add(lblStock);
        }

        // ================================
        // DASHBOARD CARD LOGIC
        // ================================
        private void LoadDashboardStats()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            // DAILY REVENUE
            var revenueCmd = conn.CreateCommand();
            revenueCmd.CommandText = @"
            SELECT IFNULL(total_sales,0)
            FROM daily_revenue
            WHERE revenue_date = DATE('now')";

            var revenue = revenueCmd.ExecuteScalar();
            decimal dailyRevenue = revenue == null ? 0 : Convert.ToDecimal(revenue);

            revenueamt.Text = "₱ " + dailyRevenue.ToString("N2");

            // DAILY EXPENSES
            var expenseCmd = conn.CreateCommand();
            expenseCmd.CommandText = @"
            SELECT IFNULL(SUM(amount),0)
            FROM expense
            WHERE DATE(expense_date) = DATE('now')";

            var expense = expenseCmd.ExecuteScalar();
            decimal dailyExpenses = Convert.ToDecimal(expense);

            expensesamt.Text = "₱ " + dailyExpenses.ToString("N2");

            // DAILY PROFIT
            decimal profit = dailyRevenue - dailyExpenses;

            profitamt.Text = "₱ " + profit.ToString("N2");

            LoadRevenueBreakdown();
        }

        private void LoadRevenueBreakdown()
        {
            productGrid.DataSource = null;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT 
                p.product_name,
                SUM(sd.quantity) as qty,
                SUM(sd.quantity * sd.unit_price) as total
                FROM sales_details_fixed sd
                JOIN product p ON p.product_id = sd.product_id
                JOIN sale s ON s.sale_id = sd.sale_id
                WHERE DATE(s.sale_date) = DATE('now')
                GROUP BY p.product_id
                ORDER BY total DESC
                LIMIT 10";

            var dt = new DataTable();

            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            productGrid.DataSource = dt;
        }        

        private void LoadCurrentUser()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT e.employee_name
            FROM users u
            JOIN employee e ON u.employee_id = e.employee_id
            WHERE u.user_id = $id
            LIMIT 1
        ";

            cmd.Parameters.AddWithValue("$id", _userId);

            var result = cmd.ExecuteScalar();

            if (result != null)
                userlbl.Text = result.ToString();
            else
                userlbl.Text = "Unknown User";
        }

        private void userbtn_Click(object sender, EventArgs e)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT u.user_id, e.employee_name
            FROM users u
            JOIN employee e ON u.employee_id = e.employee_id
            WHERE u.is_active = 1";

            using var reader = cmd.ExecuteReader();

            Dictionary<string, int> users = new();

            while (reader.Read())
            {
                users.Add(reader.GetString(1), reader.GetInt32(0));
            }

            var selectionForm = new UserSelectionForm(users);

            if (selectionForm.ShowDialog() != DialogResult.OK)
                return;

            int selectedUserId = selectionForm.SelectedUserId;

            string username = users.First(x => x.Value == selectedUserId).Key;

            var passwordForm = new PasswordPromptForm(username);

            if (passwordForm.ShowDialog() != DialogResult.OK)
                return;

            string passwordHash = Models.PasswordHasher.Hash(passwordForm.EnteredPassword);

            var verifyCmd = conn.CreateCommand();
            verifyCmd.CommandText = @"
            SELECT role
            FROM users
            WHERE user_id = $id
            AND password_hash = $pass";

            verifyCmd.Parameters.AddWithValue("$id", selectedUserId);
            verifyCmd.Parameters.AddWithValue("$pass", passwordHash);

            var role = verifyCmd.ExecuteScalar();

            if (role != null)
            {
                this.Hide();
                new Dashboard_Form(role.ToString(), selectedUserId).Show();
            }
            else
            {
                CustomMessageBox.Show("Incorrect password.", "Access Denied");
            }
        }

        public void RefreshData()
        {
            LoadStockGrid();
            LoadDashboardStats();
        }

        private void LoadStockGrid()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT product_name, price, stock FROM product_stock";

            var dt = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            productGrid.DataSource = dt; 
        }
    }
}