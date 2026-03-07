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
        }

        // ================================
        // ROLE CONTROL
        // ================================
        private void ConfigureAccess()
        {
            returnbtn.Visible = true;
            expensesbtn.Visible = true;
            reportbtn.Visible = true;

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
                SELECT
                    ROUND(price, 2) AS Price,
                    CAST(stock AS INTEGER) AS Stock
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
            productGrid.AutoGenerateColumns = false;
            productGrid.AllowUserToAddRows = false;
            productGrid.AllowUserToDeleteRows = false;

            productGrid.CellClick += ProductGrid_CellClick;

            productGrid.Columns.Clear();

            var priceCol = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var stockCol = new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                DataPropertyName = "Stock",
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            productGrid.Columns.Add(priceCol);
            productGrid.Columns.Add(stockCol);

            productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productGrid.ReadOnly = true;
            productGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dynamicpanel.Controls.Add(productGrid);
        }

        private void ProductGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string price = productGrid.Rows[e.RowIndex].Cells["Price"].Value?.ToString() ?? "0";
                string stock = productGrid.Rows[e.RowIndex].Cells["Stock"].Value?.ToString() ?? "0";

                CustomMessageBox.Show(
                    $"Price: ₱{price}\nStock: {stock}",
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
                ROUND(sd.unit_price, 2) AS Price,
                SUM(sd.quantity) AS Stock
                FROM sales_details_fixed sd
                JOIN sale s ON s.sale_id = sd.sale_id
                WHERE DATE(s.sale_date) = DATE('now')
                GROUP BY ROUND(sd.unit_price, 2)
                ORDER BY Price ASC
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
            SELECT
                COALESCE(
                    e.employee_name,
                    (
                        SELECT e2.employee_name
                        FROM employee e2
                        WHERE LOWER(TRIM(e2.position)) = LOWER(TRIM(u.role))
                        ORDER BY e2.employee_id
                        LIMIT 1
                    ),
                    u.username
                ) AS display_name
            FROM users u
            LEFT JOIN employee e ON u.employee_id = e.employee_id
            WHERE u.user_id = $id
            LIMIT 1
        ";

            cmd.Parameters.AddWithValue("$id", _userId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string displayName = reader.IsDBNull(0) ? "Unknown User" : reader.GetString(0);
                userlbl.Text = displayName;
            }
            else
            {
                userlbl.Text = "Unknown User";
            }
        }

        private void userbtn_Click(object sender, EventArgs e)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT
                u.user_id,
                COALESCE(
                    e.employee_name,
                    (
                        SELECT e2.employee_name
                        FROM employee e2
                        WHERE LOWER(TRIM(e2.position)) = LOWER(TRIM(u.role))
                        ORDER BY e2.employee_id
                        LIMIT 1
                    ),
                    u.username
                ) AS employee_name,
                COALESCE(
                    e.position,
                    (
                        SELECT e2.position
                        FROM employee e2
                        WHERE LOWER(TRIM(e2.position)) = LOWER(TRIM(u.role))
                        ORDER BY e2.employee_id
                        LIMIT 1
                    ),
                    u.role
                ) AS employee_role
            FROM users u
            LEFT JOIN employee e ON u.employee_id = e.employee_id
            WHERE u.is_active = 1
            ORDER BY employee_name";

            using var reader = cmd.ExecuteReader();

            Dictionary<string, int> users = new();

            while (reader.Read())
            {
                int uid = reader.GetInt32(0);
                string employeeName = reader.GetString(1);
                string employeeRole = reader.IsDBNull(2) ? "No Role" : reader.GetString(2);
                string displayName = $"{employeeName} ({employeeRole})";

                if (users.ContainsKey(displayName))
                    displayName = $"{displayName} [ID:{uid}]";

                users[displayName] = uid;
            }

            if (users.Count == 0)
            {
                CustomMessageBox.Show("No active users found.", "Switch User");
                return;
            }

            var selectionForm = new UserSelectionForm(users);

            if (selectionForm.ShowDialog() != DialogResult.OK)
                return;

            int selectedUserId = selectionForm.SelectedUserId;

            string selectedUserLabel = users.First(x => x.Value == selectedUserId).Key;

            var passwordForm = new PasswordPromptForm(selectedUserLabel);

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

            var roleObj = verifyCmd.ExecuteScalar();

            if (roleObj != null)
            {
                _userId = selectedUserId;
                _role = roleObj.ToString() ?? _role;
                ConfigureAccess();
                LoadCurrentUser();
                CustomMessageBox.Show("User switched successfully.", "Switch User");
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
            cmd.CommandText = @"
                SELECT
                    ROUND(price, 2) AS Price,
                    CAST(stock AS INTEGER) AS Stock
                FROM product_stock";

            var dt = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            productGrid.DataSource = dt; 
        }
    }
}
