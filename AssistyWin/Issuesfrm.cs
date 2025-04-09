using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistyWin
{
    public partial class Issuesfrm : Form
    {
        public Issuesfrm()
        {
            InitializeComponent();
        }

        private void Issuesfrm_Load(object sender, EventArgs e)
        {
            // Load all issues
            dgIssues.DataSource = Issue.GetAll();

            // Populate cmbTrx
            var trxList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT trx FROM Issues WHERE trx IS NOT NULL");
            cmbTrx.Items.Clear();
            foreach (DataRow row in trxList.Rows)
                cmbTrx.Items.Add(row["trx"].ToString());

            // Populate cmbIssueStatus
            var statusList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT status FROM Issues WHERE status IS NOT NULL");
            cmbIssueStatus.Items.Clear();
            foreach (DataRow row in statusList.Rows)
                cmbIssueStatus.Items.Add(row["status"].ToString());

            cmbTrx.SelectedIndex = -1;
            cmbIssueStatus.SelectedIndex = -1; 

        } 

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string trx = cmbTrx.SelectedItem?.ToString();
            string status = cmbIssueStatus.SelectedItem?.ToString();

            dgIssues.DataSource = Issue.GetFiltered(trx, status);

        }
        public static DataTable GetFiltered(string transaction, string status)
        {
            string query = "SELECT * FROM Issues WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(transaction))
                query += $" AND trx = '{transaction}'";

            if (!string.IsNullOrWhiteSpace(status))
                query += $" AND status = '{status}'";

            return DatabaseHelper.ExecuteQuery(query);
        }


    }
}
