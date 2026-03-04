using EvsonHardware.Data;
using Guna.UI2.WinForms;
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
        private void SearchProduct(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return;

            productGrid.Rows.Clear();

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT product_name, price, stock
            FROM product_stock
            WHERE product_name LIKE $search
            LIMIT 10";

            cmd.Parameters.AddWithValue("$search", "%" + searchText + "%");

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                productGrid.Rows.Add(
                    reader.GetString(0),
                    reader.GetDouble(1),
                    reader.GetInt32(2)
                );
            }
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

                MessageBox.Show(
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
            productGrid.Rows.Clear();

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT 
            p.product_name,
            SUM(sd.quantity) as qty,
            SUM(sd.quantity * sd.unit_price) as total
            FROM sales_details sd
            JOIN product p ON p.product_id = sd.product_id
            JOIN sale s ON s.sale_id = sd.sale_id
            WHERE DATE(s.sale_date) = DATE('now')
            GROUP BY p.product_id
            ORDER BY total DESC
            LIMIT 10";

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                productGrid.Rows.Add(
                    reader.GetString(0),
                    reader.GetInt32(1),
                    reader.GetDouble(2)
                );
            }
        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}