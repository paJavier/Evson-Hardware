using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvsonHardware.Data;
using Microsoft.Data.Sqlite;

namespace EvsonHardware.Forms
{
    public partial class ReportsForm : Form
    {
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");
        private const string SaleKeyColumn = "__SaleKey";
        private readonly List<string> printLines = new();
        private int printLineIndex = 0;
        private bool reportColumnsConfigured;

        public ReportsForm()
        {
            InitializeComponent();
            ApplyGridTheme();
            ConfigureReportColumns();
            InitializeActions();
            InitializeReportState();
        }

        private void ApplyGridTheme()
        {
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.BackgroundColor = Color.Ivory;
            dgvReports.BorderStyle = BorderStyle.FixedSingle;
            dgvReports.GridColor = Color.FromArgb(214, 223, 118);

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.OliveDrab;
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.OliveDrab;
            dgvReports.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvReports.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvReports.DefaultCellStyle.ForeColor = Color.DarkOliveGreen;
            dgvReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvReports.DefaultCellStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvReports.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReports.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);

            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 211);
            dgvReports.RowHeadersVisible = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.ThemeStyle.BackColor = Color.Ivory;
            dgvReports.ThemeStyle.BackColor = Color.Ivory;
            dgvReports.ThemeStyle.GridColor = Color.FromArgb(214, 223, 118);
            dgvReports.ThemeStyle.HeaderStyle.BackColor = Color.OliveDrab;
            dgvReports.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvReports.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReports.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 252, 224);
            dgvReports.ThemeStyle.RowsStyle.ForeColor = Color.DarkOliveGreen;
            dgvReports.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(226, 239, 169);
            dgvReports.ThemeStyle.RowsStyle.SelectionForeColor = Color.DarkOliveGreen;
            dgvReports.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 250, 211);
        }

        private void ConfigureReportColumns()
        {
            if (reportColumnsConfigured)
            {
                return;
            }

            reportColumnsConfigured = true;
            dgvReports.AutoGenerateColumns = false;
            dgvReports.Columns.Clear();

            var saleKeyColumn = new DataGridViewTextBoxColumn
            {
                Name = SaleKeyColumn,
                HeaderText = SaleKeyColumn,
                DataPropertyName = SaleKeyColumn,
                Visible = false,
                ReadOnly = true
            };

            var receiptColumn = CreateTextColumn("Receipt #", 18f);
            var dateColumn = CreateTextColumn("Date/Time", 25f);
            var customerColumn = CreateTextColumn("Customer", 37f);
            var totalColumn = CreateTextColumn("Total", 20f);
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReports.Columns.AddRange(new DataGridViewColumn[]
            {
                saleKeyColumn,
                receiptColumn,
                dateColumn,
                customerColumn,
                totalColumn
            });
        }

        private static DataGridViewTextBoxColumn CreateTextColumn(string columnKey, float fillWeight)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = columnKey,
                HeaderText = columnKey,
                DataPropertyName = columnKey,
                FillWeight = fillWeight,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };
        }

        private void InitializeReportState()
        {
            DateTime today = DateTime.Today;
            if (today < salesdaterevenue.MinDate) today = salesdaterevenue.MinDate;
            if (today > salesdaterevenue.MaxDate) today = salesdaterevenue.MaxDate;
            endDatePicker.MinDate = salesdaterevenue.MinDate;
            endDatePicker.MaxDate = salesdaterevenue.MaxDate;
            endDatePicker.FillColor = salesdaterevenue.FillColor;
            endDatePicker.FocusedColor = salesdaterevenue.FocusedColor;
            endDatePicker.Font = salesdaterevenue.Font;
            endDatePicker.ForeColor = salesdaterevenue.ForeColor;
            endDatePicker.Format = salesdaterevenue.Format;

            salesdaterevenue.Value = today;
            endDatePicker.Value = today;

            salesdaterevenue.ValueChanged += (_, __) => LoadSalesReportByDateRange();
            endDatePicker.ValueChanged += (_, __) => LoadSalesReportByDateRange();
            LoadSalesReportByDateRange();
        }

        private void InitializeActions()
        {
            dgvReports.CellMouseClick += DgvReports_CellMouseClick;
            dgvReports.CellMouseDoubleClick += DgvReports_CellMouseDoubleClick;
            dgvReports.DataError += DgvReports_DataError;
            btnPrintReport.Click += BtnPrintReport_Click;
        }

        private void LoadSalesReportByDateRange()
        {
            DateTime fromDate = salesdaterevenue.Value.Date;
            DateTime toDate = endDatePicker.Value.Date;
            if (fromDate > toDate)
            {
                (fromDate, toDate) = (toDate, fromDate);
            }

            _ = Task.Run(() =>
            {
                DataTable? dt = null;
                string? error = null;
                try
                {
                    using var conn = Database.GetConnection();
                    conn.Open();

                    string saleTable = ResolveSaleTable(conn);
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = $@"
                        SELECT
                            COALESCE(
                                NULLIF(CAST(sale_id AS INTEGER), 0),
                                CAST(ROWID AS INTEGER)
                            ) AS [{SaleKeyColumn}],
                            COALESCE(receipt_number, '-')         AS [Receipt #],
                            sale_date                              AS [Date/Time],
                            COALESCE(customer_name, 'Walk-in')     AS [Customer],
                            COALESCE(total_amount, 0)              AS [Total]
                        FROM {saleTable}
                        WHERE DATE(sale_date) BETWEEN @fromDay AND @toDay
                        ORDER BY sale_date DESC;";
                    cmd.Parameters.AddWithValue("@fromDay", fromDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@toDay", toDate.ToString("yyyy-MM-dd"));

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
                        CustomMessageBox.Show("Load reports error: " + error, "Error");
                        dgvReports.ClearSelection();
                        return;
                    }

                    ConfigureReportColumns();
                    dgvReports.DataSource = dt;
                    dgvReports.ReadOnly = true;
                    dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvReports.AllowUserToAddRows = false;
                    dgvReports.AllowUserToDeleteRows = false;
                    dgvReports.MultiSelect = false;

                    if (dgvReports.Columns[SaleKeyColumn] != null)
                    {
                        dgvReports.Columns[SaleKeyColumn].Visible = false;
                    }

                    if (dgvReports.Columns["Total"] != null)
                    {
                        dgvReports.Columns["Total"].DefaultCellStyle.Format = "C2";
                        dgvReports.Columns["Total"].DefaultCellStyle.FormatProvider = PhCulture;
                        dgvReports.Columns["Total"].DefaultCellStyle.Font =
                            new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
                    }

                    if (dgvReports.Columns["Date/Time"] != null)
                    {
                        dgvReports.Columns["Date/Time"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    }

                    dgvReports.ClearSelection();
                }

                if (InvokeRequired) BeginInvoke((Action)Apply); else Apply();
            });
        }

        private void DgvReports_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void DgvReports_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            HandleReportRowRequest(e.RowIndex);
        }

        private void DgvReports_CellMouseDoubleClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            HandleReportRowRequest(e.RowIndex);
        }

        private void HandleReportRowRequest(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvReports.Rows.Count) return;
            var row = dgvReports.Rows[rowIndex];
            if (row.Cells[SaleKeyColumn]?.Value == null) return;
            int saleKey = Convert.ToInt32(row.Cells[SaleKeyColumn].Value);
            ShowSaleDetails(saleKey);
            dgvReports.ClearSelection();
        }

        private void ShowSaleDetails(int saleKey)
        {
            try
            {
                using var detailsForm = new SalesDetailsForm(saleKey);
                detailsForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Load sale details error: " + ex.Message, "Error");
            }
        }

        private void BtnPrintReport_Click(object? sender, EventArgs e)
        {
            if (dgvReports.DataSource is not DataTable dt || dt.Rows.Count == 0)
            {
                CustomMessageBox.Show("No report rows to print for the selected date range.", "Print Report");
                return;
            }

            BuildPrintLines(dt);

            using var printDocument = new PrintDocument();
            DateTime fromDate = salesdaterevenue.Value.Date;
            DateTime toDate = endDatePicker.Value.Date;
            if (fromDate > toDate)
            {
                (fromDate, toDate) = (toDate, fromDate);
            }
            printDocument.DocumentName = fromDate == toDate
                ? $"Sales Report {fromDate:yyyy-MM-dd}"
                : $"Sales Report {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}";
            printDocument.PrintPage += PrintDocument_PrintPage;

            using var printDialog = new PrintDialog
            {
                Document = printDocument,
                UseEXDialog = true
            };

            if (printDialog.ShowDialog(this) == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void BuildPrintLines(DataTable dt)
        {
            printLines.Clear();
            printLineIndex = 0;

            DateTime fromDate = salesdaterevenue.Value.Date;
            DateTime toDate = endDatePicker.Value.Date;
            if (fromDate > toDate)
            {
                (fromDate, toDate) = (toDate, fromDate);
            }
            string reportDate = fromDate == toDate
                ? fromDate.ToString("yyyy-MM-dd")
                : $"{fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}";
            printLines.Add("EVSON HARDWARE - SALES REPORT");
            printLines.Add($"Date Filter: {reportDate}");
            printLines.Add($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            printLines.Add(new string('-', 95));
            printLines.Add(string.Format("{0,-15} {1,-20} {2,-35} {3,18}", "Receipt #", "Date/Time", "Customer", "Total"));
            printLines.Add(new string('-', 95));

            decimal grandTotal = 0m;
            foreach (DataRow row in dt.Rows)
            {
                string receipt = row["Receipt #"]?.ToString() ?? "-";
                string dateTime = row["Date/Time"]?.ToString() ?? "-";
                string customer = row["Customer"]?.ToString() ?? "Walk-in";
                decimal total = Convert.ToDecimal(row["Total"]);
                grandTotal += total;

                if (customer.Length > 35) customer = customer[..35];
                printLines.Add(string.Format(
                    "{0,-15} {1,-20} {2,-35} {3,18}",
                    receipt,
                    dateTime,
                    customer,
                    total.ToString("C2", PhCulture)));
            }

            printLines.Add(new string('-', 95));
            printLines.Add($"Transactions: {dt.Rows.Count}");
            printLines.Add($"Grand Total: {grandTotal.ToString("C2", PhCulture)}");
        }

        private void PrintDocument_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null)
            {
                e.HasMorePages = false;
                return;
            }

            using var font = new Font("Consolas", 10F, FontStyle.Regular);
            float lineHeight = font.GetHeight() + 2;
            float y = e.MarginBounds.Top;

            while (printLineIndex < printLines.Count && y + lineHeight <= e.MarginBounds.Bottom)
            {
                e.Graphics.DrawString(printLines[printLineIndex], font, Brushes.Black, e.MarginBounds.Left, y);
                printLineIndex++;
                y += lineHeight;
            }

            e.HasMorePages = printLineIndex < printLines.Count;
            if (!e.HasMorePages)
            {
                printLineIndex = 0;
            }
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

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
