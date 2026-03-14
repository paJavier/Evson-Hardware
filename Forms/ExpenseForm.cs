using System;
using System.Data;
using EvsonHardware.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class ExpenseForm : Form
    {
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");
        private CheckBox chkAllDates = new();
        private string expenseTableName = "expense";
        private string amountColumn = "amount";
        private string dateColumn = "expense_date";
        private string typeColumn = "expense_type";
        private string descriptionColumn = "description";

        public ExpenseForm()
        {
            InitializeComponent();
            InitializeFormState();
        }

        private void InitializeFormState()
        {
            ApplyGridTheme();

            cmbType.Items.Clear();
            cmbType.Items.AddRange(new object[]
            {
                "Utilities",
                "Supplies",
                "Maintenance",
                "Salary",
                "Miscellaneous"
            });
            cmbType.SelectedIndex = 0;

            txtamt.PlaceholderText = "0.00";
            txtamt.Text = "";

            AcceptButton = btnAdd;
            CancelButton = btnCancel;

            expensesdate.Value = DateTime.Today;
            expensesdate.ValueChanged += (_, __) => LoadExpenseHistory();
            InitializeAllDatesToggle();

            LoadExpenseHistory();
        }

        private void ApplyGridTheme()
        {
            expensesgdv.EnableHeadersVisualStyles = false;
            expensesgdv.BackgroundColor = System.Drawing.Color.Ivory;
            expensesgdv.BorderStyle = BorderStyle.FixedSingle;
            expensesgdv.GridColor = System.Drawing.Color.FromArgb(214, 223, 118);

            expensesgdv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.OliveDrab;
            expensesgdv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            expensesgdv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.OliveDrab;
            expensesgdv.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            expensesgdv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            expensesgdv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 252, 224);
            expensesgdv.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            expensesgdv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 239, 169);
            expensesgdv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkOliveGreen;
            expensesgdv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            expensesgdv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);

            expensesgdv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 250, 211);
            expensesgdv.RowHeadersVisible = false;
            expensesgdv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            expensesgdv.ThemeStyle.BackColor = System.Drawing.Color.Ivory;
            expensesgdv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(214, 223, 118);
            expensesgdv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.OliveDrab;
            expensesgdv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            expensesgdv.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            expensesgdv.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            expensesgdv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(255, 252, 224);
            expensesgdv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.DarkOliveGreen;
            expensesgdv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(226, 239, 169);
            expensesgdv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.DarkOliveGreen;
            expensesgdv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 250, 211);
        }

        private void InitializeAllDatesToggle()
        {
            chkAllDates = new CheckBox
            {
                Text = "All dates",
                AutoSize = true,
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.DarkGreen,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0),
                Location = new System.Drawing.Point(460, 20)
            };

            chkAllDates.CheckedChanged += (_, __) =>
            {
                expensesdate.Enabled = !chkAllDates.Checked;
                LoadExpenseHistory();
            };

            viewPanel.Controls.Add(chkAllDates);
            chkAllDates.BringToFront();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAdd_Select(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtamt.Text.Trim(), NumberStyles.Number, PhCulture, out decimal amount) &&
                !decimal.TryParse(txtamt.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            {
                CustomMessageBox.Show("Enter a valid amount.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtamt.Focus();
                return;
            }

            if (amount <= 0)
            {
                CustomMessageBox.Show("Amount must be greater than zero.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtamt.Focus();
                return;
            }

            string selectedType = cmbType.Text?.Trim() ?? "Miscellaneous";
            string description = txtdescription.Text?.Trim() ?? "";

            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                string expenseTable = ResolveExpenseTable(conn);
                var columns = GetTableColumns(conn, expenseTable);

                var cmd = conn.CreateCommand();
                var insertCols = new System.Collections.Generic.List<string>();
                var insertVals = new System.Collections.Generic.List<string>();

                AddMappedColumn(insertCols, insertVals, cmd, columns, "amount", "@amount", amount);
                AddMappedColumn(insertCols, insertVals, cmd, columns, "expense_date", "@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                AddMappedColumn(insertCols, insertVals, cmd, columns, "description", "@desc", description);
                AddMappedColumn(insertCols, insertVals, cmd, columns, "expense_type", "@type", selectedType);
                AddMappedColumn(insertCols, insertVals, cmd, columns, "user_id", "@user", 1);

                if (!insertCols.Contains("amount"))
                {
                    throw new InvalidOperationException("Expense table is missing required 'amount' column.");
                }

                cmd.CommandText = $"INSERT INTO {expenseTable} ({string.Join(", ", insertCols)}) VALUES ({string.Join(", ", insertVals)});";
                cmd.ExecuteNonQuery();

                CustomMessageBox.Show($"Expense added: {amount.ToString("C2", PhCulture)}", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtamt.Clear();
                txtdescription.Clear();
                cmbType.SelectedIndex = 0;
                expensesdate.Value = DateTime.Today;
                LoadExpenseHistory();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Save error: " + ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadExpenseHistory()
        {
            _ = Task.Run(() =>
            {
                DataTable? dt = null;
                string? error = null;
                try
                {
                    using var conn = Database.GetConnection();
                    conn.Open();

                    expenseTableName = ResolveExpenseTable(conn);
                    var columns = GetTableColumns(conn, expenseTableName);
                    amountColumn = ResolveColumn(columns, "amount") ?? "amount";
                    dateColumn = ResolveColumn(columns, "expense_date") ?? "expense_date";
                    typeColumn = ResolveColumn(columns, "expense_type") ?? "expense_type";
                    descriptionColumn = ResolveColumn(columns, "description") ?? "description";

                    var cmd = conn.CreateCommand();
                    if (chkAllDates.Checked)
                    {
                        cmd.CommandText = $@"
                        SELECT
                            {dateColumn}        AS Date,
                            {typeColumn}        AS Category,
                            {descriptionColumn} AS Description,
                            {amountColumn}      AS Amount
                        FROM {expenseTableName}
                        ORDER BY ROWID DESC
                        LIMIT 200;";
                    }
                    else
                    {
                        cmd.CommandText = $@"
                        SELECT
                            {dateColumn}        AS Date,
                            {typeColumn}        AS Category,
                            {descriptionColumn} AS Description,
                            {amountColumn}      AS Amount
                        FROM {expenseTableName}
                        WHERE DATE({dateColumn}) = @day
                        ORDER BY ROWID DESC
                        LIMIT 200;";
                        cmd.Parameters.AddWithValue("@day", expensesdate.Value.Date.ToString("yyyy-MM-dd"));
                    }

                    dt = new DataTable();
                    using var reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

                void Apply()
                {
                    if (error != null)
                    {
                        CustomMessageBox.Show("Load expenses error: " + error, "Error");
                        return;
                    }

                    expensesgdv.DataSource = dt;
                    if (expensesgdv.Columns["Amount"] != null)
                    {
                        expensesgdv.Columns["Amount"].DefaultCellStyle.Format = "C2";
                        expensesgdv.Columns["Amount"].DefaultCellStyle.FormatProvider = PhCulture;
                    }
                }

                if (InvokeRequired) BeginInvoke((Action)Apply); else Apply();
            });
        }

        private static string ResolveExpenseTable(Microsoft.Data.Sqlite.SqliteConnection conn)
        {
            if (TableExists(conn, "expense")) return "expense";
            if (TableExists(conn, "expenses")) return "expenses";
            throw new InvalidOperationException("No expense table found (expected expense or expenses).");
        }

        private static bool TableExists(Microsoft.Data.Sqlite.SqliteConnection conn, string tableName)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1 FROM sqlite_master WHERE type='table' AND name=@name LIMIT 1;";
            cmd.Parameters.AddWithValue("@name", tableName);
            return cmd.ExecuteScalar() != null;
        }

        private static System.Collections.Generic.HashSet<string> GetTableColumns(Microsoft.Data.Sqlite.SqliteConnection conn, string tableName)
        {
            var set = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"PRAGMA table_info({tableName});";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                set.Add(reader["name"]?.ToString() ?? "");
            }
            return set;
        }

        private static void AddMappedColumn(
            System.Collections.Generic.List<string> insertCols,
            System.Collections.Generic.List<string> insertVals,
            Microsoft.Data.Sqlite.SqliteCommand cmd,
            System.Collections.Generic.HashSet<string> columns,
            string logicalName,
            string parameter,
            object value)
        {
            string? actual = ResolveColumn(columns, logicalName);
            if (string.IsNullOrWhiteSpace(actual)) return;

            insertCols.Add(actual);
            insertVals.Add(parameter);
            cmd.Parameters.AddWithValue(parameter, value ?? DBNull.Value);
        }

        private static string? ResolveColumn(System.Collections.Generic.HashSet<string> columns, string logicalName)
        {
            if (logicalName == "amount")
            {
                if (columns.Contains("amount")) return "amount";
            }

            if (logicalName == "expense_date")
            {
                if (columns.Contains("expense_date")) return "expense_date";
                if (columns.Contains("date")) return "date";
                if (columns.Contains("created_at")) return "created_at";
            }

            if (logicalName == "description")
            {
                if (columns.Contains("description")) return "description";
                if (columns.Contains("details")) return "details";
                if (columns.Contains("note")) return "note";
            }

            if (logicalName == "expense_type")
            {
                if (columns.Contains("expense_type")) return "expense_type";
                if (columns.Contains("category")) return "category";
                if (columns.Contains("type")) return "type";
            }

            if (logicalName == "user_id")
            {
                if (columns.Contains("user_id")) return "user_id";
            }

            return null;
        }
    }
}
