using EvsonHardware.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EvsonHardware.Forms
{
    public partial class SalesDetailsForm : Form
    {
        private static readonly CultureInfo PhCulture = CultureInfo.GetCultureInfo("en-PH");

        public SalesDetailsForm(int saleKey)
        {
            InitializeComponent();
            ApplyGridTheme();
            LoadSaleDetails(saleKey);
        }

        // Extra grid styling on top of Designer defaults
        private void ApplyGridTheme()
        {
            dgvItems.EnableHeadersVisualStyles = false;
        }

        // Load sale header + itemized products
        private void LoadSaleDetails(int saleKey)
        {
            try
            {
                using var conn = Database.GetConnection();
                conn.Open();

                // FIX #5: Use the resolver instead of hardcoding 'sale'
                //         so it works whether the table is 'sale' or 'sales'
                string saleTable = ResolveSaleTable(conn);

                // Header
                var hCmd = conn.CreateCommand();
                hCmd.CommandText = $@"
                    SELECT receipt_number,
                           sale_date,
                           COALESCE(customer_name, 'Walk-in') AS customer_name,
                           total_amount
                    FROM {saleTable}
                    WHERE COALESCE(
                              NULLIF(CAST(sale_id AS INTEGER), 0),
                              CAST(rowid AS INTEGER)
                          ) = @key
                    LIMIT 1;";
                hCmd.Parameters.AddWithValue("@key", saleKey);

                bool headerFound = false;
                using (var r = hCmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        headerFound = true;
                        lblReceiptVal.Text = r["receipt_number"] == DBNull.Value ? "—" : r["receipt_number"].ToString();
                        lblDateVal.Text = r["sale_date"] == DBNull.Value ? "—" : r["sale_date"].ToString();
                        lblCustomerVal.Text = r["customer_name"] == DBNull.Value ? "Walk-in" : r["customer_name"].ToString();
                        lblTotalVal.Text = r["total_amount"] == DBNull.Value ? "—"
                                                 : Convert.ToDecimal(r["total_amount"]).ToString("C2", PhCulture);
                    }
                }
                if (!headerFound)
                {
                    MessageBox.Show("Sale record not found for the selected row.",
                        "Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvItems.DataSource = null;
                    return;
                }

                // Products the customer bought
                string detailsTable = ResolveSalesDetailsTable(conn);
                var dCmd = conn.CreateCommand();
                dCmd.CommandText = $@"
                    SELECT
                        COALESCE(p.product_name,
                            'Product #' || CAST(sd.product_id AS TEXT)) AS Product,
                        CAST(sd.quantity AS INTEGER)                     AS Qty,
                        sd.unit_price                                    AS [Unit Price],
                        sd.subtotal                                      AS Subtotal
                    FROM {detailsTable} sd
                    LEFT JOIN product p
                           ON CAST(p.product_id AS INTEGER) = CAST(sd.product_id AS INTEGER)
                    WHERE CAST(sd.sale_id AS INTEGER) = @key
                    ORDER BY sd.rowid;";
                dCmd.Parameters.AddWithValue("@key", saleKey);

                var dt = new DataTable();
                dt.Load(dCmd.ExecuteReader());
                dgvItems.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No line items recorded for this sale.",
                        "Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Format columns after DataSource is set
                if (dgvItems.Columns["Unit Price"] != null)
                {
                    dgvItems.Columns["Unit Price"].DefaultCellStyle.Format = "C2";
                    dgvItems.Columns["Unit Price"].DefaultCellStyle.FormatProvider = PhCulture;
                    dgvItems.Columns["Unit Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvItems.Columns["Subtotal"] != null)
                {
                    dgvItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    dgvItems.Columns["Subtotal"].DefaultCellStyle.FormatProvider = PhCulture;
                    dgvItems.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvItems.Columns["Subtotal"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                if (dgvItems.Columns["Qty"] != null)
                    dgvItems.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sale details:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click handlers (referenced by Designer)
        private void btnClose_Click(object sender, EventArgs e) => Close();
        private void btnX_Click(object sender, EventArgs e) => Close();

        // ── Table resolvers ───────────────────────────────────────────
        private static bool TableExists(SqliteConnection conn, string name)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText =
                "SELECT 1 FROM sqlite_master WHERE type='table' AND name=@n LIMIT 1;";
            cmd.Parameters.AddWithValue("@n", name);
            return cmd.ExecuteScalar() != null;
        }

        // FIX #5: Added ResolveSaleTable — was missing, causing hardcoded 'sale' risk
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

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
