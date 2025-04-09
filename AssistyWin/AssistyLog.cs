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
    public partial class AssistyLog : Form
    {
        public AssistyLog()
        {
            InitializeComponent();
        }

        private void AssistyLog_Load(object sender, EventArgs e)
        {  
            dgAssistylog.DataSource = AssistyLogDLA.GetAll();

            var dt = DatabaseHelper.ExecuteQuery("SELECT name FROM sqlite_master WHERE type='table' AND name='AssistyLog'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("AssistyLog table is missing in the database.");
            }

            var trxList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT [trx] FROM AssistyLog WHERE [trx] IS NOT NULL AND [trx] != ''");

            cmbTrxList.Items.Clear();
            foreach (DataRow row in trxList.Rows)
            {
                cmbTrxList.Items.Add(row["trx"].ToString());
            }

            var userList = DatabaseHelper.ExecuteQuery("SELECT DISTINCT [User] FROM AssistyLog WHERE [User] IS NOT NULL AND [User] != ''");

            cmbUsers.Items.Clear();
            foreach (DataRow row in userList.Rows)
            {
                cmbUsers.Items.Add(row["User"].ToString());
            }


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string user = cmbUsers.SelectedItem?.ToString() ?? "";
            string trx = cmbTrxList.SelectedItem?.ToString() ?? "";

            dgAssistylog.DataSource = GetFilteredLogs(user, trx);
        }
        public static DataTable GetFilteredLogs(string user, string transaction)
        {
            string query = "SELECT * FROM AssistyLog WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(user))
                query += $" AND User LIKE '%{user}%'";

            if (!string.IsNullOrWhiteSpace(transaction))
                query += $" AND trx = '{transaction}'";

            return DatabaseHelper.ExecuteQuery(query);
        }

    }
}
