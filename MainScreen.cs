using System.Text.Json;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Windows.Forms;
using System;
using System.Net.Mail;
using System.Net; 
using System.Drawing.Imaging;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml;
using Control = System.Windows.Forms.Control;


namespace AssistyWin
{
    public partial class MainScreen : Form
    {
        private int lineDelay = 100;   // Delay between lines
        private int typingSpeed = 0;// Milliseconds per character


        public MainScreen()
        {
            InitializeComponent();
        }

        private async void btnSubmit_ClickAsync(object sender, EventArgs e)
        {
            string sentence1 = txtSentence1.Text;
            string sentence2 = txtSentence2.Text;

            var json = JsonSerializer.Serialize(new
            {
                sentence1 = sentence1,
                sentence2 = sentence2
            });

            using var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:5000/compare", content);
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<JsonElement>(resultJson);

                txtSimilarity.Text = "Similarity score" + result.GetProperty("similarity").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AssistyLog().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Issuesfrm().Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new FISTicket().Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            // 3. Log to AssistyLog
            AssistyLogDLA.Add(
                user: Environment.UserName,
                transaction: "Main screen",
                actionType: "View",
                description: $"User login to main screen.",
                timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            );

            // 3. Log to AssistyLog
            AssistyLogDLA.Add(
                user: Environment.UserName,
                transaction: "Scree 1",
                actionType: "View",
                description: $"User login to  screen 1",
                timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            );
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text; // Gets tab title
            string user = Environment.UserName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "View",
                description: $"User view: {selectedTab}",
                timestamp: timestamp
            );
            if (this.tabControl1.SelectedIndex != 4)
            {
                this.tabControl1.TabPages[4].Hide();
                this.txtAssisty.Text = "";
            }
            else
            {
                //Assisty logic
                this.tabControl1.SelectedTab.Show();
                ShowAssistySuggestionPanel();
            }

        }
        private async void ShowAssistySuggestionPanel()
        {


            DataTable logs = AssistyLogDLA.GetAll();
            var latestLogs = logs.AsEnumerable().TakeLast(5);
            var message = string.Join(Environment.NewLine,
                latestLogs.Select(row => $"{row["Timestamp"]} - {row["ActionType"]}: {row["Description"]}"));

            foreach (char c in message)
            {
                this.txtAssisty.Text = this.txtAssisty.Text.TrimEnd('|') + c + "|"; // Add character before cursor
                this.txtAssisty.SelectionStart = txtAssisty.Text.Length; // Keep caret at end
                this.txtAssisty.ScrollToCaret();
                await Task.Delay(typingSpeed); // Wait before adding next character
            }
            txtAssisty.Text = txtAssisty.Text.TrimEnd('|') + Environment.NewLine + "|"; // Move to new line
            await Task.Delay(lineDelay);

            // 4. Extract the last sentence that contains the word "Error"
            string lastErrorSentence = latestLogs
                .Select(row => row["Description"].ToString())
                .SelectMany(desc => desc.Split(new[] { '.', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(sentence => sentence.Contains("Error", StringComparison.OrdinalIgnoreCase))
                .LastOrDefault();

            // (Optional) Display it for now
            if (!string.IsNullOrEmpty(lastErrorSentence))
            {
                AppendBoldText($"\r\n\r\n🔍 Assisty detected this error:\r\n\"{lastErrorSentence.Trim()}");

                //call python to get most similarties issue, get its resolution, actions
                List<ActionInfo> actions = new List<ActionInfo>();


                var result = FindMostSimilarIssue(lastErrorSentence);


                if (result != null)
                {
                    //print recommendation
                    AppendBoldText($"\r\n\r\n🔍 Assisty recommend: \r\n\"{result.recommended_fix.Trim()}\"\r\n\r\n");

                    //loop for every actions
                    int yOffset = this.txtAssisty.Bottom + 20;
                    while (AssistyPanel.Controls.Count > 1)
                        AssistyPanel.Controls.RemoveAt(1);


                    for (int i = 0; i < result.actions.Count; i++)
                    {
                        AppendBoldText($"Suggested Action No: {i + 1} - {result.ActionNames[i].ToString()} : {result.actions[i].ToString()} \r\n");
                        actions.Add(new ActionInfo
                        {
                            ActionName = result.ActionNames[i].ToString(),
                            ActionDetail = result.actions[i].ToString()
                        });


                    }

                    Button btn = new Button
                    {
                        Text = result.recommended_fix,
                        Width = 250,
                        Height = 30,
                        Left = 10,
                        Top = yOffset,
                        Font = new System.Drawing. Font("Segoe UI", 9, FontStyle.Regular),
                        Tag = actions

                    };
                    btn.BringToFront();
                    this.txtAssisty.SendToBack();
                    this.AssistyPanel.Controls.Add(btn);
                    AssistyPanel.Refresh();
                    yOffset += 45;
                    btn.Click += AssistyActionButton_Click;
                }
                else
                {
                    AppendBoldText("No matching issue found.\r\n");
                }


            }
            else
            {
                AppendBoldText("\r\n\r\nNo specific error found in recent logs.\r\n");
                return;
            }


        }
        private void AssistyActionButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is List<ActionInfo> actionList)
            {
                foreach (var action in actionList)
                {
                    string actionName = action.ActionName;
                    string detail = action.ActionDetail;

                    if (actionName.Equals("Config", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            string[] parts = detail.Split(',');

                            if (parts.Length == 3)
                            {
                                string table = parts[0].Trim();
                                string keyName = parts[1].Trim();
                                string keyValue = parts[2].Trim();

                                string query = $"UPDATE {table} SET Value = '{keyValue}' WHERE Key = '{keyName}'";

                                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query);

                                MessageBox.Show($"✅ Config updated:\n{keyName} = {keyValue}\nRows affected: {rowsAffected}",
                                                "Config Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                // ✅ Log each action
                                AssistyLogDLA.Add(
                                    user: Environment.UserName,
                                    transaction: "N/A",
                                    actionType: "AIRecommendedAction",
                                    description: $"User applied: {actionName} - {detail}",
                                    timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                );
                            }
                            else
                            {
                                MessageBox.Show("⚠️ Invalid Config format.", "Assisty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Error applying config: {ex.Message}", "Assisty Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Handle communicate action
                        if (actionName.Equals("Communicate", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                string[] parts = detail.Split(',');

                                if (parts.Length != 2)
                                {
                                    MessageBox.Show("⚠️ Invalid Communicate format. Expected: RoleName,Message", "Assisty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }


                                string ruleName = parts[0].Trim();
                                string messageToSend = parts[1].Trim();

                                // Get role email from Roles table
                                DataTable dt = DatabaseHelper.ExecuteQuery($"SELECT RoleEmail FROM Roles WHERE RoleName = '{ruleName}'");

                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show($"⚠️ No role found with name: {ruleName}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string email = dt.Rows[0]["RoleEmail"].ToString();

                                string subject = $"[Assisty Notification]: {ruleName}";
                                string body = $"Assisty has triggered a communication based on rule: {ruleName}.\n\n Assisty do the following:\n\n" + messageToSend;

                                // Send the email (see step 3 below)
                                bool sent = SendEmail(email, subject, body,"");

                                if (sent)
                                    MessageBox.Show($"📧 Email sent to {email}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("❌ Failed to send email.", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"❌ Error during communication: {ex.Message}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (actionName.Equals("ConfigCounterparty", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                string[] parts = detail.Split(',');

                                if (parts.Length == 3)
                                {
                                    string table = parts[0].Trim();
                                    string keyName = parts[1].Trim();
                                    string keyValue = parts[2].Trim();

                                    string query = $"UPDATE {table} SET IsConfigured = '{keyValue}' WHERE CounterpartyCode = '{keyName}'";

                                    int rowsAffected = DatabaseHelper.ExecuteNonQuery(query);

                                    MessageBox.Show($"✅ Counterparty Config updated:\n{keyName} = {keyValue}\nRows affected: {rowsAffected}",
                                                    "Counterparty Config Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    // ✅ Log each action
                                    AssistyLogDLA.Add(
                                        user: Environment.UserName,
                                        transaction: "Assity",
                                        actionType: "AIRecommendedAction",
                                        description: $"User applied: {actionName} - {detail}",
                                        timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                    );
                                }
                                else
                                {
                                    MessageBox.Show("⚠️ Invalid Counterparty Config format.", "Assisty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"❌ Error applying Counterparty config: {ex.Message}", "Assisty Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (actionName.Equals("RaiseFISTicket", StringComparison.OrdinalIgnoreCase))
                        {
                            // Pass the current screen or panel as the control to capture
                            string docpath = GenerateAssistyReportWithScreenshot(this); // or your specific control like pnlTransaction

                            //send an email 
                            try
                            {
                                string[] parts = detail.Split(',');

                                if (parts.Length != 2)
                                {
                                    MessageBox.Show("⚠️ Invalid Communicate format. Expected: RoleName,Message", "Assisty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }


                                string ruleName = parts[0].Trim();
                                string messageToSend = parts[1].Trim();

                                // Get role email from Roles table
                                DataTable dt = DatabaseHelper.ExecuteQuery($"SELECT RoleEmail FROM Roles WHERE RoleName = '{ruleName}'");

                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show($"⚠️ No role found with name: {ruleName}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string email = dt.Rows[0]["RoleEmail"].ToString();

                                string subject = $"[Assisty Notification]: {ruleName}";
                                string body = $"Assisty has triggered a communication based on rule: {ruleName}.\n\n Assisty do the following:\n\n" + messageToSend;

                                // Send the email (see step 3 below)
                                bool sent = SendEmail(email, subject, body, docpath);

                                if (sent)
                                    MessageBox.Show($"📧 Email sent to {email}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("❌ Failed to send email.", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"❌ Error during communication: {ex.Message}", "Assisty Communicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show($"✅ Assity Action",
                                                   "Assity: RaiseFISTicket", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            // ✅ Log each action
                            AssistyLogDLA.Add(
                                user: Environment.UserName,
                                transaction: "Assity",
                                actionType: "AIRecommendedAction",
                                description: $"Assity apply {actionName} - {detail}",
                                timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }




                        MessageBox.Show($"Assisty is applying:\n\n{action.ActionName}\n\n{action.ActionDetail}",
                                            "Assisty Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                MessageBox.Show("All Action are applied, please try to submit transaction again", "Assisty");
            }
        }

        private bool SendEmail(string to, string subject, string body , string? attachement)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hany_3210@yahoo.com");  // change as needed vbbpfriioqrbsouw
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                if (!string.IsNullOrEmpty(attachement) && File.Exists(attachement))
                {
                    mail.Attachments.Add(new Attachment(attachement));
                }


                SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtp.Credentials = new NetworkCredential("hany_3210", "vbbpfriioqrbsouw");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email send failed:\n{ex.Message}", "Assisty Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        public class ActionInfo
        {
            public string ActionName { get; set; }
            public string ActionDetail { get; set; }
        }

        public class MatchedIssue
        {
            public int issue_id { get; set; }
            public string recommended_fix { get; set; }
            public List<string> ActionNames { get; set; }
            public List<string> actions { get; set; }
        }

        public static MatchedIssue FindMostSimilarIssue(string errorText)
        {
            DataTable issuesTable = DatabaseHelper.ExecuteQuery("SELECT * FROM Issues");

            double highestScore = 0;
            int matchedIssueId = -1;

            foreach (DataRow row in issuesTable.Rows)
            {
                string issueText = row["description"].ToString();
                double score = GetSimilarityScore(errorText, issueText);

                if (score > highestScore)
                {
                    highestScore = score;
                    matchedIssueId = Convert.ToInt32(row["issue_id"]);
                }
            }

            if (matchedIssueId == -1) return null;

            // Get resolution
            DataTable resolutionTable = DatabaseHelper.ExecuteQuery($"SELECT * FROM Resolutions WHERE issue_id = {matchedIssueId} LIMIT 1");
            string fix = resolutionTable.Rows.Count > 0 ? resolutionTable.Rows[0]["recommended_fix"].ToString() : "No fix found.";

            // Get actions
            DataTable actionTable = DatabaseHelper.ExecuteQuery($"SELECT a.ActionName , a.ActionDetail FROM ResolutionActions ra JOIN Actions a ON ra.ActionId = a.ActionId WHERE ra.IssueId = {matchedIssueId}");
            var ActionNames = actionTable.AsEnumerable().Select(row => row["ActionName"].ToString()).ToList();
            var actions = actionTable.AsEnumerable().Select(row => row["ActionDetail"].ToString()).ToList();

            return new MatchedIssue
            {
                issue_id = matchedIssueId,
                recommended_fix = fix,
                ActionNames = ActionNames,
                actions = actions
            };
        }


        public static double GetSimilarityScore(string errorText, string issueText)
        {

            var json = JsonSerializer.Serialize(new
            {
                sentence1 = errorText,
                sentence2 = issueText
            });

            using var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = client.PostAsync("http://127.0.0.1:5000/compare", content).Result;
                var resultJson = response.Content.ReadAsStringAsync().Result;
                var result = JsonSerializer.Deserialize<JsonElement>(resultJson);

                return double.Parse(result.GetProperty("similarity").ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return 0;
        }



        private void AppendBoldText(string text)
        {
            txtAssisty.SelectionStart = txtAssisty.TextLength;
            txtAssisty.SelectionFont =   new System.Drawing.Font(txtAssisty.Font, FontStyle.Bold);
            txtAssisty.AppendText(text);
            txtAssisty.SelectionFont =   new System.Drawing.Font(txtAssisty.Font, FontStyle.Regular); // reset to normal
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text; // Gets tab title
            string user = Environment.UserName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string valueDate = dtValuedate.Text;

            AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}",
                timestamp: timestamp
            );


            // 2. Check ALLOW_BACKDATE from SystemConfig
            bool allowBackdate = false;
            DataTable config = SystemConfig.GetAll();

            foreach (DataRow row in config.Rows)
            {
                if (row["Key"].ToString() == "ALLOW_BACKDATE" && row["Value"].ToString().ToUpper() == "TRUE")
                {
                    allowBackdate = true;
                    break;
                }
            }

            if (!allowBackdate)
            {
                AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}" + " Error: Back dated transaction not allowed",
                timestamp: timestamp);

                string msg = $"Backdated value date is not allowed.\nSystemConfig.ALLOW_BACKDATE = FALSE\n\nWould you like Assisty to help you resolve this issue?";
                var result = MessageBox.Show(msg, "Assisty Detected an Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Log user's interest in Assisty
                    AssistyLogDLA.Add(
                        user: Environment.UserName,
                        transaction: "Assisty",
                        actionType: "View",
                        description: $"User requested help after backdated validation failed (ValueDate: {valueDate:yyyy-MM-dd}).",
                        timestamp: DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                    this.tabControl1.SelectedIndex = 4;
                }
            }
            else
            {
                MessageBox.Show("Transaction Submitted succesfully", "Status");
                AssistyLogDLA.Add(
               user: user,
               transaction: selectedTab,
               actionType: "Submit",
               description: $"User trying to Submit : {selectedTab}" + " Transaction Submitted succesfully",
               timestamp: timestamp);
            }


        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void txtAssisty_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSumit2_Click(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text; // Gets tab title
            string user = Environment.UserName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string valueDate = dtValuedate.Text;
            string counterparty = cmbCounterparty.SelectedItem.ToString();

            //1. log user action
            AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}",
                timestamp: timestamp
            );


            //2.check if counterparty configured
            // 1. Check if counterparty exists and is configured
            DataTable dt = DatabaseHelper.ExecuteQuery($"SELECT * FROM Counterparties WHERE CounterpartyCode = '{counterparty}'");

            bool isConfigured = dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["IsConfigured"]) == 1;
            if (!isConfigured)
            {
                AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}" + " Error: Counterparty not configured",
                timestamp: timestamp);

                DialogResult result = MessageBox.Show(
                    $"Counterparty '{counterparty}' is not configured.\nWould you like Assisty to help?",
                    "Assisty Detected an Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 2. // Log user's interest in Assisty
                    AssistyLogDLA.Add(
                        user: user,
                        transaction: "Assisty",
                        actionType: "CounterpartyIssue",
                        description: $"Unconfigured counterparty submitted: {counterparty}",
                        timestamp: timestamp
                    );
                    this.tabControl1.SelectedIndex = 4;
                    // 3. Trigger Assisty Panel

                }
            }
            else
            {
                MessageBox.Show("Transaction Submitted succesfully", "Status");
                AssistyLogDLA.Add(
               user: user,
               transaction: selectedTab,
               actionType: "Submit",
               description: $"User trying to Submit : {selectedTab}" + " Transaction Submitted succesfully",
               timestamp: timestamp);
            }


        }

        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text; // Gets tab title
            string user = Environment.UserName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string valueDate = dtValuedate.Text;

            //1. log user action
            AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}",
                timestamp: timestamp
            );


            //2.check if screen configured
            // 1. Check if counterparty exists and is configured
            DataTable dt = DatabaseHelper.ExecuteQuery($"SELECT * FROM Screens WHERE ScreenName = '{selectedTab}'");

            bool isConfigured = dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["Enabled"]) == 1;
            if (!isConfigured)
            {
                AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}" + " Error: User not authorized to submit",
                timestamp: timestamp);

                DialogResult result = MessageBox.Show(
                    $"Screen Permission '{selectedTab}' is not Enabled.\nWould you like Assisty to help?",
                    "Assisty Detected an Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 2. // Log user's interest in Assisty
                    AssistyLogDLA.Add(
                        user: user,
                        transaction: "Assisty",
                        actionType: "Screen permission Issue",
                        description: $"Unconfigured screen submitted: {selectedTab}",
                        timestamp: timestamp
                    );
                    this.tabControl1.SelectedIndex = 4;
                    // 3. Trigger Assisty Panel

                }
            }
            else
            {
                MessageBox.Show("Transaction Submitted succesfully", "Status");
                AssistyLogDLA.Add(
               user: user,
               transaction: selectedTab,
               actionType: "Submit",
               description: $"User trying to Submit : {selectedTab}" + " Transaction Submitted succesfully",
               timestamp: timestamp);
            }

        }

        private void btnSubmit4_Click(object sender, EventArgs e)
        {
            string selectedTab = tabControl1.SelectedTab.Text; // Gets tab title
            string user = Environment.UserName;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string valueDate = dtValuedate.Text;

            //1. log user action
            AssistyLogDLA.Add(
                user: user,
                transaction: selectedTab,
                actionType: "Submit",
                description: $"User trying to Submit : {selectedTab}",
                timestamp: timestamp
            );


            //2.will force db error 
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery($"SELECT * FROM Screens111 WHERE ScreenName = '{selectedTab}'");

            }
            catch (Exception ex)
            {
                AssistyLogDLA.Add(
               user: user,
               transaction: selectedTab,
               actionType: "Submit",
               description: $"User trying to Submit : {selectedTab}" + " DB Error",
               timestamp: timestamp);



                DialogResult result = MessageBox.Show(
                    $"Would you like Assisty to help?",
                    "Assisty Detected an Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 2. // Log user's interest in Assisty
                    AssistyLogDLA.Add(
                        user: user,
                        transaction: "Assisty",
                        actionType: "DB Error",
                        description: $"DB Error screen submitted: {selectedTab}",
                        timestamp: timestamp
                    );
                    this.tabControl1.SelectedIndex = 4;
                    // 3. Trigger Assisty Panel

                }


            }


        }



        //Generate Assisty Support Report  
        public string GenerateAssistyReportWithScreenshot(  System.Windows.Forms. Control screenControl)
        {
            string docPath = Path.Combine(Path.GetTempPath(), $"Assisty_Report_{DateTime.Now:yyyyMMdd_HHmmss}.docx");
            string screenImgPath = Path.Combine(Path.GetTempPath(), $"screen_{Guid.NewGuid()}.jpg");
            string desktopImgPath = Path.Combine(Path.GetTempPath(), $"desktop_{Guid.NewGuid()}.jpg");

            // 1. Capture images
            CaptureControlScreenshot(screenControl).Save(screenImgPath, ImageFormat.Jpeg);
            CaptureFullDesktop().Save(desktopImgPath, ImageFormat.Jpeg);

            // 2. Get last 5 logs
            DataTable allLogs = AssistyLogDLA.GetAll();
            var latestLogs = allLogs.AsEnumerable().Reverse().Take(5).Reverse().ToList();

            // 3. Create .docx
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(docPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());
                Body body = mainPart.Document.Body;

                body.Append(new Paragraph(new Run(new Text("Assisty Auto-Generated FIS Support Ticket"))));
                body.Append(new Paragraph(new Run(new Text("Date & Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))));

                body.Append(new Paragraph(new Run(new Text("Recent Activity Log (Last 5 Entries):"))));
                foreach (var row in latestLogs)
                {
                    string line = $"• {row["Timestamp"]} - {row["ActionType"]}: {row["Description"]}";
                    body.Append(new Paragraph(new Run(new Text(line))));
                }

                // Add screenshots
                body.Append(new Paragraph(new Run(new Text("Application Screen Capture:"))));
                InsertImage(mainPart, screenImgPath, body);

                body.Append(new Paragraph(new Run(new Text("Full Desktop Screenshot:"))));
                InsertImage(mainPart, desktopImgPath, body);
            }

            // 4. Clean up
            File.Delete(screenImgPath);
            File.Delete(desktopImgPath);

            MessageBox.Show($"✅ Assisty Report generated:\n{docPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return docPath;
        }

        public void InsertImage(MainDocumentPart mainPart, string imagePath, Body body)
        {
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            string relationshipId = mainPart.GetIdOfPart(imagePart);

            var element =
                new Drawing(
                    new DW.Inline(
                        new DW.Extent() { Cx = 5000000L, Cy = 2800000L },
                        new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                        new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Image" },
                        new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
                        new A.Graphic(
                            new A.GraphicData(
                                new PIC.Picture(
                                    new PIC.NonVisualPictureProperties(
                                        new PIC.NonVisualDrawingProperties() { Id = 0U, Name = Path.GetFileName(imagePath) },
                                        new PIC.NonVisualPictureDrawingProperties()),
                                    new PIC.BlipFill(
                                        new A.Blip() { Embed = relationshipId },
                                        new A.Stretch(new A.FillRectangle())),
                                    new PIC.ShapeProperties(
                                        new A.Transform2D(
                                            new A.Offset() { X = 0L, Y = 0L },
                                            new A.Extents() { Cx = 5000000L, Cy = 2800000L }),
                                        new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })
                                )
                            )
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                    )
                );

            body.Append(new Paragraph(new Run(element)));
        }

        public static Bitmap CaptureControlScreenshot(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(Point.Empty, control.Size));
            return bmp;
        }

        public static Bitmap CaptureFullDesktop()
        {
            Rectangle bounds = SystemInformation.VirtualScreen;
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size);
            }
            return bmp;
        }


    }
}
