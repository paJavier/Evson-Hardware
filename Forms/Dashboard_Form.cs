using EvsonHardware.Data;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class Dashboard_Form : Form
    {
        private string _role;
        private int _userId;
        private DataGridView productGrid;
        private Guna2HtmlLabel selectedRevenueDetail;
        private Guna2HtmlLabel selectedExpensesDetail;
        private Guna2HtmlLabel selectedProfitDetail;
        private Guna2HtmlLabel selectedMarginDetail;
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");

        public Dashboard_Form(string role, int userId)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            ApplyCurrencyFonts();
            WireEvents();
            ConfigureAccess();
            InitializeSalesPanelDetails();
            SetDashboardDateToToday();

            InitializeSearchGrid();
            LoadDashboardStats(loadGrid: false);
            LoadCurrentUser();
            ClearDashboardGrid();
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
            returnbtn.Click += Returnbtn_Click;
            reportbtn.Click += Reportbtn_Click;
            logoutbtn.Click += Logoutbtn_Click;
            exitbtn.Click += Exitbtn_Click;
            searchbar.KeyDown += Searchbar_KeyDown;
            salesdaterevenue.ValueChanged += (_, __) => LoadDashboardStats(loadGrid: false);
            Shown += (_, __) => ClearDashboardGrid();
        }

        private void ClearDashboardGrid()
        {
            if (productGrid == null) return;
            productGrid.DataSource = null;
            productGrid.Rows.Clear();
        }

        private void SetDashboardDateToToday()
        {
            DateTime today = DateTime.Today;
            if (today < salesdaterevenue.MinDate) today = salesdaterevenue.MinDate;
            if (today > salesdaterevenue.MaxDate) today = salesdaterevenue.MaxDate;
            salesdaterevenue.Value = today;
        }

        private void InitializeSalesPanelDetails()
        {
            salesprogressperday.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
            salesprogressperday.Text = FormatPeso(0m);
            salesprogressperday.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);

            selectedRevenueDetail = CreateSalesPanelLabel(new Point(12, 192), $"Revenue: {FormatPeso(0m)}");
            selectedExpensesDetail = CreateSalesPanelLabel(new Point(12, 212), $"Expenses: {FormatPeso(0m)}");
            selectedProfitDetail = CreateSalesPanelLabel(new Point(12, 232), $"Profit: {FormatPeso(0m)}");
            selectedMarginDetail = CreateSalesPanelLabel(new Point(12, 252), "Margin: 0.00%");

            salespanel.Controls.Add(selectedRevenueDetail);
            salespanel.Controls.Add(selectedExpensesDetail);
            salespanel.Controls.Add(selectedProfitDetail);
            salespanel.Controls.Add(selectedMarginDetail);
        }

        private static Guna2HtmlLabel CreateSalesPanelLabel(Point location, string text)
        {
            return new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.DarkGreen,
                Location = location,
                AutoSize = true,
                Text = text
            };
        }

        private void ApplyCurrencyFonts()
        {
            var pesoFont = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            revenueamt.Font = pesoFont;
            profitamt.Font = pesoFont;
            expensesamt.Font = pesoFont;
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
            LoadDashboardStats(loadGrid: false);
            ClearDashboardGrid();
        }

        private void Salesbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(salesbtn);
            OpenChildForm(new SalesForm());
        }

        private void Inventorybtn_Click(object sender, EventArgs e)
        {
            ActivateButton(inventorybtn);
            OpenChildForm(new InventoryForm());
        }

        private void Expensesbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(expensesbtn);
            OpenChildForm(new ExpenseForm());
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(returnbtn);
            OpenChildForm(new ReturnsForm());
        }

        private void Reportbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(reportbtn);
            OpenChildForm(new ReportsForm());
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
            {
                ClearDashboardGrid();
                return;
            }

            productGrid.DataSource = null;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT
                    ps.product_name  AS Name,
                    ps.category_name AS Category,
                    IFNULL(p.brandname, '') AS Brand,
                    ROUND(ps.price, 2) AS Price,
                    CAST(ps.stock AS INTEGER) AS Stock
                FROM product_stock ps
                LEFT JOIN product p ON p.product_id = ps.product_id
                WHERE ps.product_name LIKE $search
                   OR ps.category_name LIKE $search
                   OR IFNULL(p.brandname, '') LIKE $search
                   OR CAST(ps.product_id AS TEXT) LIKE $search
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

            productGrid.Columns.Clear();

            var nameCol = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name"
            };

            var categoryCol = new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category"
            };

            var priceCol = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var brandCol = new DataGridViewTextBoxColumn
            {
                Name = "Brand",
                HeaderText = "Brand",
                DataPropertyName = "Brand"
            };

            var stockCol = new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                DataPropertyName = "Stock",
                DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            productGrid.Columns.Add(nameCol);
            productGrid.Columns.Add(categoryCol);
            productGrid.Columns.Add(brandCol);
            productGrid.Columns.Add(priceCol);
            productGrid.Columns.Add(stockCol);

            productGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productGrid.ReadOnly = true;
            productGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.EnableHeadersVisualStyles = false;
            productGrid.BackgroundColor = Color.Ivory;
            productGrid.BorderStyle = BorderStyle.None;
            productGrid.GridColor = Color.FromArgb(214, 223, 118);
            productGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            productGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            productGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            productGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            productGrid.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            productGrid.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            productGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            productGrid.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            productGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);

            dynamicpanel.Controls.Add(productGrid);
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
            lblPrice.Text = "Price: " + FormatPeso(Convert.ToDecimal(price));
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
        private void LoadDashboardStats(bool loadGrid = false)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string selectedDate = salesdaterevenue.Value.Date.ToString("yyyy-MM-dd");
            string saleTable = ResolveSaleTable(conn);
            string salesDetailsTable = ResolveSalesDetailsTable(conn);
            string supplyDetailsTable = ResolveSupplyDetailsTable(conn);

            // DAILY REVENUE (from actual sales records)
            var revenueCmd = conn.CreateCommand();
            revenueCmd.CommandText = $@"
            SELECT COALESCE(SUM(total_amount), 0)
            FROM {saleTable}
            WHERE DATE(sale_date) = @day";
            revenueCmd.Parameters.AddWithValue("@day", selectedDate);

            var revenue = revenueCmd.ExecuteScalar();
            decimal dailyRevenue = revenue == null ? 0 : Convert.ToDecimal(revenue);

            revenueamt.Text = FormatPeso(dailyRevenue);

            // DAILY EXPENSES
            var expenseCmd = conn.CreateCommand();
            expenseCmd.CommandText = @"
            SELECT COALESCE(SUM(amount), 0)
            FROM expense
            WHERE DATE(expense_date) = @day";
            expenseCmd.Parameters.AddWithValue("@day", selectedDate);

            var expense = expenseCmd.ExecuteScalar();
            decimal dailyExpenses = Convert.ToDecimal(expense);

            expensesamt.Text = FormatPeso(dailyExpenses);

            // DAILY COST OF GOODS SOLD (latest known unit cost per product)
            var cogsCmd = conn.CreateCommand();
            cogsCmd.CommandText = $@"
            SELECT COALESCE(SUM(
                CAST(sd.quantity AS REAL) * COALESCE(
                    (
                        SELECT CAST(sup.unit_cost AS REAL)
                        FROM {supplyDetailsTable} sup
                        WHERE CAST(sup.product_id AS INTEGER) = CAST(sd.product_id AS INTEGER)
                          AND COALESCE(CAST(sup.unit_cost AS REAL), 0) > 0
                        ORDER BY ROWID DESC
                        LIMIT 1
                    ), 0
                )
            ), 0)
            FROM {salesDetailsTable} sd
            INNER JOIN {saleTable} s ON CAST(s.sale_id AS INTEGER) = CAST(sd.sale_id AS INTEGER)
            WHERE DATE(s.sale_date) = @day";
            cogsCmd.Parameters.AddWithValue("@day", selectedDate);
            var cogsObj = cogsCmd.ExecuteScalar();
            decimal dailyCogs = cogsObj == null ? 0 : Convert.ToDecimal(cogsObj);

            // DAILY PROFIT = Revenue - COGS - Expenses
            decimal profit = dailyRevenue - dailyCogs - dailyExpenses;

            profitamt.Text = FormatPeso(profit);

            UpdateProfitCircleAndDetails(dailyRevenue, dailyExpenses, dailyCogs, profit);

            if (loadGrid)
                LoadRevenueBreakdown();
        }

        private void UpdateProfitCircleAndDetails(decimal dailyRevenue, decimal dailyExpenses, decimal dailyCogs, decimal profit)
        {
            decimal baseAmount = dailyRevenue <= 0 ? 1 : dailyRevenue;
            int percent = ClampToPercent((profit / baseAmount) * 100m);

            salesprogressperday.Value = percent;
            salesprogressperday.ForeColor = profit < 0 ? Color.Firebrick : Color.DarkGreen;
            salesprogressperday.ProgressColor = profit < 0 ? Color.IndianRed : Color.Green;
            salesprogressperday.ProgressColor2 = profit < 0 ? Color.LightCoral : Color.LimeGreen;
            salesprogressperday.Text = FormatPeso(profit);

            decimal marginPercent = dailyRevenue <= 0 ? 0 : (profit / dailyRevenue) * 100m;
            selectedRevenueDetail.Text = $"Revenue: {FormatPeso(dailyRevenue)}";
            selectedExpensesDetail.Text = $"Expenses: {FormatPeso(dailyExpenses)}";
            selectedProfitDetail.Text = $"Profit: {FormatPeso(profit)}";
            selectedMarginDetail.Text = $"Margin: {marginPercent:N2}%";
        }

        private static string FormatPeso(decimal amount) => amount.ToString("C2", PhCulture);

        private static int ClampToPercent(decimal value)
        {
            if (value < 0) return 0;
            if (value > 100) return 100;
            return (int)Math.Round(value);
        }

        private void LoadRevenueBreakdown()
        {
            productGrid.DataSource = null;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT 
                ps.product_name  AS Name,
                ps.category_name AS Category,
                ROUND(ps.price, 2) AS Price,
                CAST(ps.stock AS INTEGER) AS Stock
                FROM product_stock ps
                ORDER BY ps.product_name
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
            LoadDashboardStats(loadGrid: false);
            ClearDashboardGrid();
        }

        private void OpenChildForm(Form childForm)
        {
            using (childForm)
            {
                Hide();
                childForm.ShowDialog(this);
                Show();
                Activate();
                RefreshData();
            }
        }

        private void LoadStockGrid()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT
                    ps.product_name  AS Name,
                    ps.category_name AS Category,
                    ROUND(ps.price, 2) AS Price,
                    CAST(ps.stock AS INTEGER) AS Stock
                FROM product_stock ps
                ORDER BY ps.product_name";

            var dt = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            productGrid.DataSource = dt; 
        }

        private static bool TableExists(SqliteConnection conn, string tableName)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=@name LIMIT 1;";
            cmd.Parameters.AddWithValue("@name", tableName);
            return cmd.ExecuteScalar() != null;
        }

        private static string ResolveSaleTable(SqliteConnection conn)
        {
            if (TableExists(conn, "sale")) return "sale";
            if (TableExists(conn, "sales")) return "sales";
            throw new InvalidOperationException("No sales table found (expected sale or sales).");
        }

        private static string ResolveSalesDetailsTable(SqliteConnection conn)
        {
            if (TableExists(conn, "sales_details_fixed")) return "sales_details_fixed";
            if (TableExists(conn, "sales_details")) return "sales_details";
            throw new InvalidOperationException("No sales details table found (expected sales_details or sales_details_fixed).");
        }

        private static string ResolveSupplyDetailsTable(SqliteConnection conn)
        {
            if (TableExists(conn, "supply_details_fixed")) return "supply_details_fixed";
            if (TableExists(conn, "supply_details")) return "supply_details";
            throw new InvalidOperationException("No supply details table found (expected supply_details or supply_details_fixed).");
        }
    }
}
