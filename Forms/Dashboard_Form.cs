using EvsonHardware.Data;
using Guna.UI2.WinForms;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
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

        // Grid lives here
        private Guna2DataGridView productGrid;

        // Parallel list — index matches grid row index → sale_id
        private readonly List<int> _transactionSaleIds = new List<int>();

        // Tracks whether the grid shows transactions (clickable) or product search results
        private bool _isShowingTransactions = false;

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
            ConfigureAccess();
            InitializeSalesPanelDetails();
            SetDashboardDateToToday();
            InitializeTransactionGrid();   // build grid first
            WireEvents();                  // wire events after grid exists
            LoadDashboardStats();
            LoadCurrentUser();
            LoadTransactionsGrid();
        }

        public Dashboard_Form() { }

        // ================================================================
        // GRID SETUP — called once in constructor
        // ================================================================
        private void InitializeTransactionGrid()
        {
            // Use Guna2DataGridView so click events are not swallowed by the Guna2GradientPanel
            productGrid = new Guna2DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.Ivory,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9.5F),
                GridColor = Color.FromArgb(214, 223, 118),
                EnableHeadersVisualStyles = false,
                Cursor = Cursors.Hand
            };

            productGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            productGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            productGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            productGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            productGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.ColumnHeadersHeight = 34;
            productGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            productGrid.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            productGrid.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            productGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            productGrid.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            productGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);

            // Apply Guna2-specific theme so it renders correctly inside Guna2GradientPanel
            productGrid.ThemeStyle.BackColor = Color.Ivory;
            productGrid.ThemeStyle.GridColor = Color.FromArgb(214, 223, 118);
            productGrid.ThemeStyle.HeaderStyle.BackColor = Color.OliveDrab;
            productGrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            productGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            productGrid.ThemeStyle.HeaderStyle.Height = 34;
            productGrid.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 252, 224);
            productGrid.ThemeStyle.RowsStyle.ForeColor = Color.DarkOliveGreen;
            productGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            productGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.DarkOliveGreen;
            productGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            productGrid.ThemeStyle.RowsStyle.Height = 28;
            productGrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 250, 211);

            // Wire CellClick for single-click row selection → opens SalesDetailsForm
            productGrid.CellClick += ProductGrid_CellClick;

            dynamicpanel.Controls.Clear();
            dynamicpanel.Controls.Add(productGrid);
        }

        // Single-click a transaction row → open SalesDetailsForm
        private void ProductGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;                                   // header click
            if (!_isShowingTransactions) return;                          // search results mode
            if (e.RowIndex >= _transactionSaleIds.Count) return;          // safety bounds

            int saleId = _transactionSaleIds[e.RowIndex];
            if (saleId <= 0) return;

            try
            {
                var form = new SalesDetailsForm(saleId);
                form.ShowDialog(this);
                form.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SalesDetailsForm error:\n" + ex.ToString(), "Error");
            }
        }

        // No double-click handler needed — CellClick fires on the first click of a double-click too
        private void ProductGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { }

        // ================================================================
        // LOAD TRANSACTIONS INTO GRID
        // ================================================================
        private void LoadTransactionsGrid()
        {
            _transactionSaleIds.Clear();

            if (productGrid == null) return;

            productGrid.DataSource = null;
            productGrid.Rows.Clear();
            productGrid.Columns.Clear();

            productGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colReceipt",
                HeaderText = "Receipt #",
                FillWeight = 25
            });
            productGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Date / Time",
                FillWeight = 30
            });
            productGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomer",
                HeaderText = "Customer",
                FillWeight = 25
            });
            productGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total (₱)",
                FillWeight = 20,
                DefaultCellStyle =
                {
                    Alignment  = DataGridViewContentAlignment.MiddleRight,
                    Format     = "N2",
                    Font       = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor  = Color.DarkGreen
                }
            });

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string saleTable = ResolveSaleTable(conn);
                string selectedDate = salesdaterevenue.Value.Date.ToString("yyyy-MM-dd");

                var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    SELECT
                        sale_id,
                        COALESCE(receipt_number, '-')      AS receipt_number,
                        sale_date,
                        COALESCE(customer_name, 'Walk-in') AS customer_name,
                        CAST(total_amount AS REAL)          AS total_amount
                    FROM {saleTable}
                    WHERE DATE(sale_date) = @day
                    ORDER BY sale_date DESC;";
                cmd.Parameters.AddWithValue("@day", selectedDate);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // FIX: Guard every column against DBNull before converting
                    int saleId = reader["sale_id"] == DBNull.Value
                        ? 0 : Convert.ToInt32(reader["sale_id"]);
                    _transactionSaleIds.Add(saleId);

                    double total = reader["total_amount"] == DBNull.Value
                        ? 0.0 : Convert.ToDouble(reader["total_amount"]);

                    productGrid.Rows.Add(
                        reader["receipt_number"] == DBNull.Value ? "-" : reader["receipt_number"].ToString(),
                        reader["sale_date"] == DBNull.Value ? "-" : reader["sale_date"].ToString(),
                        reader["customer_name"] == DBNull.Value ? "Walk-in" : reader["customer_name"].ToString(),
                        total
                    );
                }

                if (productGrid.Rows.Count > 0)
                    productGrid.Rows[0].Selected = false;

                // Grid is now showing transactions — clicks should open SalesDetailsForm
                _isShowingTransactions = true;
                productGrid.Cursor = Cursors.Hand;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Load transactions error: " + ex.Message, "Error");
            }
        }

        // ================================================================
        // WIRE EVENTS
        // ================================================================
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

            salesdaterevenue.ValueChanged += (_, __) =>
            {
                LoadDashboardStats();
                LoadTransactionsGrid();
            };
        }

        // ================================================================
        // SIDEBAR BUTTONS
        // ================================================================
        private void ResetSidebarButtons()
        {
            foreach (Control ctrl in guna2ShadowPanel1.Controls)
                if (ctrl is Guna2Button btn)
                    btn.FillColor = Color.Beige;
        }

        private void ActivateButton(Guna2Button button)
        {
            ResetSidebarButtons();
            button.FillColor = Color.LightGreen;
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            ActivateButton(homebtn);
            LoadDashboardStats();
            LoadTransactionsGrid();
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
            Hide();
            new LoginForm().Show();
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ================================================================
        // SEARCH
        // ================================================================
        private void Searchbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchProduct(searchbar.Text);
        }

        private void SearchProduct(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadTransactionsGrid();
                return;
            }

            // Grid is now showing product search results — clicks should NOT open SalesDetailsForm
            _isShowingTransactions = false;
            productGrid.Cursor = Cursors.Default;

            _transactionSaleIds.Clear();
            productGrid.DataSource = null;
            productGrid.Rows.Clear();
            productGrid.Columns.Clear();

            productGrid.Columns.Add("colName", "Name");
            productGrid.Columns.Add("colCategory", "Category");
            productGrid.Columns.Add("colBrand", "Brand");
            productGrid.Columns.Add("colPrice", "Price");
            productGrid.Columns.Add("colStock", "Stock");

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT ps.product_name, ps.category_name,
                       IFNULL(p.brandname,'') AS brandname,
                       ROUND(ps.price,2), CAST(ps.stock AS INTEGER)
                FROM product_stock ps
                LEFT JOIN product p ON p.product_id = ps.product_id
                WHERE ps.product_name   LIKE $s
                   OR ps.category_name  LIKE $s
                   OR IFNULL(p.brandname,'') LIKE $s
                LIMIT 20;";
            cmd.Parameters.AddWithValue("$s", "%" + searchText + "%");

            using var r = cmd.ExecuteReader();
            while (r.Read())
                productGrid.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
        }

        // ================================================================
        // DASHBOARD STATS
        // ================================================================
        private void SetDashboardDateToToday()
        {
            var today = DateTime.Today;
            if (today < salesdaterevenue.MinDate) today = salesdaterevenue.MinDate;
            if (today > salesdaterevenue.MaxDate) today = salesdaterevenue.MaxDate;
            salesdaterevenue.Value = today;
        }

        private void InitializeSalesPanelDetails()
        {
            salesprogressperday.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
            salesprogressperday.Text = FormatPeso(0m);
            salesprogressperday.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            selectedRevenueDetail = CreateSalesPanelLabel(new Point(12, 192), $"Revenue: {FormatPeso(0m)}");
            selectedExpensesDetail = CreateSalesPanelLabel(new Point(12, 212), $"Expenses: {FormatPeso(0m)}");
            selectedProfitDetail = CreateSalesPanelLabel(new Point(12, 232), $"Profit: {FormatPeso(0m)}");
            selectedMarginDetail = CreateSalesPanelLabel(new Point(12, 252), "Margin: 0.00%");

            salespanel.Controls.Add(selectedRevenueDetail);
            salespanel.Controls.Add(selectedExpensesDetail);
            salespanel.Controls.Add(selectedProfitDetail);
            salespanel.Controls.Add(selectedMarginDetail);
        }

        private static Guna2HtmlLabel CreateSalesPanelLabel(Point location, string text) =>
            new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DarkGreen,
                Location = location,
                AutoSize = true,
                Text = text
            };

        private void ApplyCurrencyFonts()
        {
            var f = new Font("Segoe UI", 16F, FontStyle.Bold);
            revenueamt.Font = f;
            profitamt.Font = f;
            expensesamt.Font = f;
        }

        private void LoadDashboardStats()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string date = salesdaterevenue.Value.Date.ToString("yyyy-MM-dd");
            string saleTable = ResolveSaleTable(conn);
            string salesDetailsTable = ResolveSalesDetailsTable(conn);
            string supplyDetailsTable = ResolveSupplyDetailsTable(conn);

            // Revenue
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT COALESCE(SUM(total_amount),0) FROM {saleTable} WHERE DATE(sale_date)=@d";
            cmd.Parameters.AddWithValue("@d", date);
            decimal revenue = Convert.ToDecimal(cmd.ExecuteScalar());
            revenueamt.Text = FormatPeso(revenue);

            // Expenses
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COALESCE(SUM(amount),0) FROM expense WHERE DATE(expense_date)=@d";
            cmd.Parameters.AddWithValue("@d", date);
            decimal expenses = Convert.ToDecimal(cmd.ExecuteScalar());
            expensesamt.Text = FormatPeso(expenses);

            // COGS
            cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT COALESCE(SUM(
                    CAST(sd.quantity AS REAL) * COALESCE(
                        (SELECT CAST(sup.unit_cost AS REAL)
                         FROM {supplyDetailsTable} sup
                         WHERE CAST(sup.product_id AS INTEGER)=CAST(sd.product_id AS INTEGER)
                           AND COALESCE(CAST(sup.unit_cost AS REAL),0)>0
                         ORDER BY ROWID DESC LIMIT 1),0)),0)
                FROM {salesDetailsTable} sd
                INNER JOIN {saleTable} s ON CAST(s.sale_id AS INTEGER)=CAST(sd.sale_id AS INTEGER)
                WHERE DATE(s.sale_date)=@d";
            cmd.Parameters.AddWithValue("@d", date);
            decimal cogs = Convert.ToDecimal(cmd.ExecuteScalar());

            decimal profit = revenue - cogs - expenses;
            profitamt.Text = FormatPeso(profit);

            UpdateProfitCircle(revenue, expenses, cogs, profit);
        }

        private void UpdateProfitCircle(decimal revenue, decimal expenses, decimal cogs, decimal profit)
        {
            decimal pct = revenue <= 0 ? 0 : (profit / revenue) * 100m;
            int val = (int)Math.Max(0, Math.Min(100, Math.Round(pct)));

            salesprogressperday.Value = val;
            salesprogressperday.Text = FormatPeso(profit);
            salesprogressperday.ForeColor = profit < 0 ? Color.Firebrick : Color.DarkGreen;
            salesprogressperday.ProgressColor = profit < 0 ? Color.IndianRed : Color.Green;
            salesprogressperday.ProgressColor2 = profit < 0 ? Color.LightCoral : Color.LimeGreen;

            selectedRevenueDetail.Text = $"Revenue: {FormatPeso(revenue)}";
            selectedExpensesDetail.Text = $"Expenses: {FormatPeso(expenses)}";
            selectedProfitDetail.Text = $"Profit: {FormatPeso(profit)}";
            selectedMarginDetail.Text = $"Margin: {(revenue <= 0 ? 0 : profit / revenue * 100m):N2}%";
        }

        private static string FormatPeso(decimal amount) => amount.ToString("C2", PhCulture);

        // ================================================================
        // USER
        // ================================================================
        private void ConfigureAccess()
        {
            returnbtn.Visible = _role != "Cashier";
            expensesbtn.Visible = _role != "Cashier";
            reportbtn.Visible = _role != "Cashier";
        }

        private void LoadCurrentUser()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT COALESCE(e.employee_name, u.username)
                FROM users u
                LEFT JOIN employee e ON u.employee_id = e.employee_id
                WHERE u.user_id = $id LIMIT 1";
            cmd.Parameters.AddWithValue("$id", _userId);

            using var r = cmd.ExecuteReader();
            userlbl.Text = r.Read() && !r.IsDBNull(0) ? r.GetString(0) : "Unknown";
        }

        private void userbtn_Click(object sender, EventArgs e)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT u.user_id,
                       COALESCE(e.employee_name, u.username) AS display_name,
                       COALESCE(e.position, u.role)          AS display_role
                FROM users u
                LEFT JOIN employee e ON u.employee_id = e.employee_id
                WHERE u.is_active = 1
                ORDER BY display_name";

            using var r = cmd.ExecuteReader();
            var users = new Dictionary<string, int>();
            while (r.Read())
            {
                int uid = r.GetInt32(0);
                string name = $"{r.GetString(1)} ({(r.IsDBNull(2) ? "No Role" : r.GetString(2))})";
                if (users.ContainsKey(name)) name += $" [ID:{uid}]";
                users[name] = uid;
            }

            if (users.Count == 0) { CustomMessageBox.Show("No active users found.", "Switch User"); return; }

            var sel = new UserSelectionForm(users);
            if (sel.ShowDialog() != DialogResult.OK) return;

            int selId = sel.SelectedUserId;
            string selLabel = "";
            foreach (var kv in users) if (kv.Value == selId) { selLabel = kv.Key; break; }

            var pwdForm = new PasswordPromptForm(selLabel);
            if (pwdForm.ShowDialog() != DialogResult.OK) return;

            string hash = Models.PasswordHasher.Hash(pwdForm.EnteredPassword);

            var vCmd = conn.CreateCommand();
            vCmd.CommandText = "SELECT role FROM users WHERE user_id=$id AND password_hash=$p";
            vCmd.Parameters.AddWithValue("$id", selId);
            vCmd.Parameters.AddWithValue("$p", hash);

            var roleObj = vCmd.ExecuteScalar();
            if (roleObj != null)
            {
                _userId = selId;
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

        // ================================================================
        // REFRESH / CHILD FORM
        // ================================================================
        public void RefreshData()
        {
            LoadDashboardStats();
            LoadTransactionsGrid();
        }

        // FIX #3: Wrap OpenChildForm in try/catch so the dashboard
        //         re-appears correctly if a child form throws on load.
        private void OpenChildForm(Form childForm)
        {
            try
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
            catch (Exception ex)
            {
                Show(); // ensure dashboard is visible again on error
                Activate();
                CustomMessageBox.Show("Error opening form: " + ex.Message, "Error");
            }
        }

        // ================================================================
        // TABLE RESOLVERS
        // ================================================================
        private static bool TableExists(SqliteConnection conn, string name)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=@n LIMIT 1;";
            cmd.Parameters.AddWithValue("@n", name);
            return cmd.ExecuteScalar() != null;
        }

        private static string ResolveSaleTable(SqliteConnection conn)
        {
            if (TableExists(conn, "sale")) return "sale";
            if (TableExists(conn, "sales")) return "sales";
            throw new InvalidOperationException("No sale table found.");
        }

        private static string ResolveSalesDetailsTable(SqliteConnection conn)
        {
            if (TableExists(conn, "sales_details_fixed")) return "sales_details_fixed";
            if (TableExists(conn, "sales_details")) return "sales_details";
            throw new InvalidOperationException("No sales details table found.");
        }

        private static string ResolveSupplyDetailsTable(SqliteConnection conn)
        {
            if (TableExists(conn, "supply_details_fixed")) return "supply_details_fixed";
            if (TableExists(conn, "supply_details")) return "supply_details";
            throw new InvalidOperationException("No supply details table found.");
        }

        private void dynamicpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewSalesDetail_Click(object sender, EventArgs e)
        {
            if (productGrid != null && productGrid.SelectedRows.Count > 0)
            {
                if (productGrid.Columns.Contains("sale_id"))
                {
                    var cellValue = productGrid.SelectedRows[0].Cells["sale_id"].Value;

                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        int saleId = Convert.ToInt32(cellValue);
                        using (var detailsForm = new SalesDetailsForm(saleId))
                        {
                            detailsForm.ShowDialog(this);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a sale record from the revenue breakdown first.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the grid first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}