using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistyWin
{
    public partial class FISTicket : Form
    {
        public FISTicket()
        {
            InitializeComponent();
        }

        private void FISTicket_Load(object sender, EventArgs e)
        {
            dgFISTickets.DataSource = FISTicket.GetAll();

            // Populate Applications
            var appList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT application_name FROM FISTickets WHERE application_name IS NOT NULL");
            cmbApps.Items.Clear();
            foreach (DataRow row in appList.Rows)
                cmbApps.Items.Add(row["application_name"].ToString());

            // Populate Transactions
            var trxList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT trx FROM FISTickets WHERE trx IS NOT NULL");
            cmbTrxList.Items.Clear();
            foreach (DataRow row in trxList.Rows)
                cmbTrxList.Items.Add(row["trx"].ToString());

            cmbApps.SelectedIndex = -1;
            cmbTrxList.SelectedIndex = -1;


        }


        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string user = cmbApps.SelectedItem?.ToString() ?? "";
            string trx = cmbTrxList.SelectedItem?.ToString() ?? "";

            dgFISTickets.DataSource = GetFiltered(user, trx);
        }

        public static DataTable GetAll()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM FISTickets");
        }

        public static DataTable GetFiltered(string appName, string transaction)
        {
            string query = "SELECT * FROM FISTickets WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(appName))
                query += $" AND application_name = '{appName}'";

            if (!string.IsNullOrWhiteSpace(transaction))
                query += $" AND trx = '{transaction}'";

            return DatabaseHelper.ExecuteQuery(query);
        }

    }
}
