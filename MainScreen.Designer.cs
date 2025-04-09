namespace AssistyWin
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSentence1 = new TextBox();
            txtSentence2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnCompare = new Button();
            txtSimilarity = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnSubmit = new Button();
            txtBnkCode = new TextBox();
            label6 = new Label();
            txtAmount = new TextBox();
            label5 = new Label();
            label4 = new Label();
            dtValuedate = new DateTimePicker();
            label3 = new Label();
            cmbCurrency = new ComboBox();
            tabPage2 = new TabPage();
            btnSumit2 = new Button();
            cmbBankCode2 = new TextBox();
            label7 = new Label();
            cmbAmount2 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            cmbValuedate2 = new DateTimePicker();
            label10 = new Label();
            cmbCounterparty = new ComboBox();
            tabPage3 = new TabPage();
            btnSubmit3 = new Button();
            textBox1 = new TextBox();
            label11 = new Label();
            textBox2 = new TextBox();
            label12 = new Label();
            label13 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label14 = new Label();
            comboBox1 = new ComboBox();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            AssistyPanel = new Panel();
            txtAssisty = new RichTextBox();
            button3 = new Button();
            btnIssues = new Button();
            button4 = new Button();
            btnSubmit4 = new Button();
            textBox3 = new TextBox();
            label15 = new Label();
            textBox4 = new TextBox();
            label16 = new Label();
            label17 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label18 = new Label();
            comboBox2 = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            AssistyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtSentence1
            // 
            txtSentence1.Location = new Point(458, 536);
            txtSentence1.Name = "txtSentence1";
            txtSentence1.Size = new Size(274, 31);
            txtSentence1.TabIndex = 0;
            txtSentence1.Visible = false;
            // 
            // txtSentence2
            // 
            txtSentence2.Location = new Point(458, 609);
            txtSentence2.Name = "txtSentence2";
            txtSentence2.Size = new Size(274, 31);
            txtSentence2.TabIndex = 1;
            txtSentence2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(359, 542);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 2;
            label1.Text = "First text";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 615);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 3;
            label2.Text = "Second Text";
            label2.Visible = false;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(501, 676);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(175, 35);
            btnCompare.TabIndex = 4;
            btnCompare.Text = "Compare";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Visible = false;
            btnCompare.Click += btnSubmit_ClickAsync;
            // 
            // txtSimilarity
            // 
            txtSimilarity.AutoSize = true;
            txtSimilarity.Location = new Point(458, 734);
            txtSimilarity.Name = "txtSimilarity";
            txtSimilarity.Size = new Size(272, 25);
            txtSimilarity.TabIndex = 5;
            txtSimilarity.Text = "                                                    ";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(12, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 489);
            tabControl1.TabIndex = 6;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSubmit);
            tabPage1.Controls.Add(txtBnkCode);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtAmount);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(dtValuedate);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(cmbCurrency);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 451);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Screen 1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(322, 360);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtBnkCode
            // 
            txtBnkCode.Location = new Point(254, 280);
            txtBnkCode.Name = "txtBnkCode";
            txtBnkCode.Size = new Size(180, 31);
            txtBnkCode.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(157, 287);
            label6.Name = "label6";
            label6.Size = new Size(94, 25);
            label6.TabIndex = 6;
            label6.Text = "Bank code";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(256, 197);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(180, 31);
            txtAmount.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(159, 204);
            label5.Name = "label5";
            label5.Size = new Size(77, 25);
            label5.TabIndex = 4;
            label5.Text = "Amount";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(142, 120);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 3;
            label4.Text = "Value date";
            // 
            // dtValuedate
            // 
            dtValuedate.Format = DateTimePickerFormat.Short;
            dtValuedate.Location = new Point(256, 114);
            dtValuedate.Name = "dtValuedate";
            dtValuedate.Size = new Size(180, 31);
            dtValuedate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 45);
            label3.Name = "label3";
            label3.Size = new Size(45, 25);
            label3.TabIndex = 1;
            label3.Text = "Curr";
            // 
            // cmbCurrency
            // 
            cmbCurrency.FormattingEnabled = true;
            cmbCurrency.Items.AddRange(new object[] { "USD", "EUR", "GBP", "AUD", "JPY", "EGP" });
            cmbCurrency.Location = new Point(254, 45);
            cmbCurrency.Name = "cmbCurrency";
            cmbCurrency.Size = new Size(182, 33);
            cmbCurrency.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnSumit2);
            tabPage2.Controls.Add(cmbBankCode2);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(cmbAmount2);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(cmbValuedate2);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(cmbCounterparty);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 451);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Screen 2";
            tabPage2.Click += tabPage2_Click;
            // 
            // btnSumit2
            // 
            btnSumit2.Location = new Point(367, 348);
            btnSumit2.Name = "btnSumit2";
            btnSumit2.Size = new Size(112, 34);
            btnSumit2.TabIndex = 17;
            btnSumit2.Text = "Submit";
            btnSumit2.UseVisualStyleBackColor = true;
            btnSumit2.Click += btnSumit2_Click;
            // 
            // cmbBankCode2
            // 
            cmbBankCode2.Location = new Point(299, 270);
            cmbBankCode2.Name = "cmbBankCode2";
            cmbBankCode2.Size = new Size(180, 31);
            cmbBankCode2.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(202, 277);
            label7.Name = "label7";
            label7.Size = new Size(94, 25);
            label7.TabIndex = 15;
            label7.Text = "Bank code";
            // 
            // cmbAmount2
            // 
            cmbAmount2.Location = new Point(301, 187);
            cmbAmount2.Name = "cmbAmount2";
            cmbAmount2.Size = new Size(180, 31);
            cmbAmount2.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(204, 194);
            label8.Name = "label8";
            label8.Size = new Size(77, 25);
            label8.TabIndex = 13;
            label8.Text = "Amount";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(187, 110);
            label9.Name = "label9";
            label9.Size = new Size(94, 25);
            label9.TabIndex = 12;
            label9.Text = "Value date";
            // 
            // cmbValuedate2
            // 
            cmbValuedate2.Format = DateTimePickerFormat.Short;
            cmbValuedate2.Location = new Point(301, 104);
            cmbValuedate2.Name = "cmbValuedate2";
            cmbValuedate2.Size = new Size(180, 31);
            cmbValuedate2.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(180, 38);
            label10.Name = "label10";
            label10.Size = new Size(116, 25);
            label10.TabIndex = 10;
            label10.Text = "Counterparty";
            // 
            // cmbCounterparty
            // 
            cmbCounterparty.FormattingEnabled = true;
            cmbCounterparty.Items.AddRange(new object[] { "JP_MORGAN_LDN", "ABC" });
            cmbCounterparty.Location = new Point(299, 35);
            cmbCounterparty.Name = "cmbCounterparty";
            cmbCounterparty.Size = new Size(182, 33);
            cmbCounterparty.TabIndex = 9;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnSubmit3);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(textBox2);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(dateTimePicker1);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(comboBox1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 451);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Screen 3";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // btnSubmit3
            // 
            btnSubmit3.Location = new Point(421, 365);
            btnSubmit3.Name = "btnSubmit3";
            btnSubmit3.Size = new Size(112, 34);
            btnSubmit3.TabIndex = 26;
            btnSubmit3.Text = "Submit";
            btnSubmit3.UseVisualStyleBackColor = true;
            btnSubmit3.Click += btnSubmit3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(353, 287);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 31);
            textBox1.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(256, 294);
            label11.Name = "label11";
            label11.Size = new Size(94, 25);
            label11.TabIndex = 24;
            label11.Text = "Bank code";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(355, 204);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(180, 31);
            textBox2.TabIndex = 23;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(258, 211);
            label12.Name = "label12";
            label12.Size = new Size(77, 25);
            label12.TabIndex = 22;
            label12.Text = "Amount";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(241, 127);
            label13.Name = "label13";
            label13.Size = new Size(94, 25);
            label13.TabIndex = 21;
            label13.Text = "Value date";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(355, 121);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(180, 31);
            dateTimePicker1.TabIndex = 20;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(234, 55);
            label14.Name = "label14";
            label14.Size = new Size(116, 25);
            label14.TabIndex = 19;
            label14.Text = "Counterparty";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "JP_MORGAN_LDN", "ABC" });
            comboBox1.Location = new Point(353, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 18;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnSubmit4);
            tabPage4.Controls.Add(textBox3);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(textBox4);
            tabPage4.Controls.Add(label16);
            tabPage4.Controls.Add(label17);
            tabPage4.Controls.Add(dateTimePicker2);
            tabPage4.Controls.Add(label18);
            tabPage4.Controls.Add(comboBox2);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(768, 451);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Screen 4";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Click += tabPage4_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(AssistyPanel);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(768, 451);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Assisty";
            tabPage5.UseVisualStyleBackColor = true;
            tabPage5.Click += tabPage5_Click;
            // 
            // AssistyPanel
            // 
            AssistyPanel.AutoScroll = true;
            AssistyPanel.Controls.Add(txtAssisty);
            AssistyPanel.Dock = DockStyle.Fill;
            AssistyPanel.Location = new Point(0, 0);
            AssistyPanel.Name = "AssistyPanel";
            AssistyPanel.Size = new Size(768, 451);
            AssistyPanel.TabIndex = 1;
            // 
            // txtAssisty
            // 
            txtAssisty.Location = new Point(0, 3);
            txtAssisty.Name = "txtAssisty";
            txtAssisty.ReadOnly = true;
            txtAssisty.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtAssisty.Size = new Size(762, 360);
            txtAssisty.TabIndex = 0;
            txtAssisty.Text = "";
            // 
            // button3
            // 
            button3.Location = new Point(53, 539);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 7;
            button3.Text = "AssistyLog";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // btnIssues
            // 
            btnIssues.Location = new Point(53, 599);
            btnIssues.Name = "btnIssues";
            btnIssues.Size = new Size(112, 34);
            btnIssues.TabIndex = 8;
            btnIssues.Text = "Issues";
            btnIssues.UseVisualStyleBackColor = true;
            btnIssues.Visible = false;
            btnIssues.Click += button4_Click;
            // 
            // button4
            // 
            button4.Location = new Point(53, 676);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 9;
            button4.Text = "FIS Tickets";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click_1;
            // 
            // btnSubmit4
            // 
            btnSubmit4.Location = new Point(421, 365);
            btnSubmit4.Name = "btnSubmit4";
            btnSubmit4.Size = new Size(112, 34);
            btnSubmit4.TabIndex = 35;
            btnSubmit4.Text = "Submit";
            btnSubmit4.UseVisualStyleBackColor = true;
            btnSubmit4.Click += btnSubmit4_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(353, 287);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(180, 31);
            textBox3.TabIndex = 34;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(256, 294);
            label15.Name = "label15";
            label15.Size = new Size(94, 25);
            label15.TabIndex = 33;
            label15.Text = "Bank code";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(355, 204);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(180, 31);
            textBox4.TabIndex = 32;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(258, 211);
            label16.Name = "label16";
            label16.Size = new Size(77, 25);
            label16.TabIndex = 31;
            label16.Text = "Amount";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(241, 127);
            label17.Name = "label17";
            label17.Size = new Size(94, 25);
            label17.TabIndex = 30;
            label17.Text = "Value date";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(355, 121);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(180, 31);
            dateTimePicker2.TabIndex = 29;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(234, 55);
            label18.Name = "label18";
            label18.Size = new Size(116, 25);
            label18.TabIndex = 28;
            label18.Text = "Counterparty";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "JP_MORGAN_LDN", "ABC" });
            comboBox2.Location = new Point(353, 52);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 27;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(button4);
            Controls.Add(btnIssues);
            Controls.Add(button3);
            Controls.Add(tabControl1);
            Controls.Add(txtSimilarity);
            Controls.Add(btnCompare);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSentence2);
            Controls.Add(txtSentence1);
            Name = "MainScreen";
            Text = "Main Screen";
            Load += MainScreen_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            AssistyPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSentence1;
        private TextBox txtSentence2;
        private Label label1;
        private Label label2;
        private Button btnCompare;
        private Label txtSimilarity;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button btnIssues;
        private Button button4;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label label3;
        private ComboBox cmbCurrency;
        private DateTimePicker dtValuedate;
        private Label label4;
        private TextBox txtAmount;
        private Label label5;
        private TextBox txtBnkCode;
        private Label label6;
        private Button btnSubmit;
        private TabPage tabPage5;
        private RichTextBox txtAssisty;
        private Panel AssistyPanel;
        private Button btnSumit2;
        private TextBox cmbBankCode2;
        private Label label7;
        private TextBox cmbAmount2;
        private Label label8;
        private Label label9;
        private DateTimePicker cmbValuedate2;
        private Label label10;
        private ComboBox cmbCounterparty;
        private Button btnSubmit3;
        private TextBox textBox1;
        private Label label11;
        private TextBox textBox2;
        private Label label12;
        private Label label13;
        private DateTimePicker dateTimePicker1;
        private Label label14;
        private ComboBox comboBox1;
        private Button btnSubmit4;
        private TextBox textBox3;
        private Label label15;
        private TextBox textBox4;
        private Label label16;
        private Label label17;
        private DateTimePicker dateTimePicker2;
        private Label label18;
        private ComboBox comboBox2;
    }
}
