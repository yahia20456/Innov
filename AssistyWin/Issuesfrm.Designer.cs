namespace AssistyWin
{
    partial class Issuesfrm

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgIssues = new DataGridView();
            groupBox1 = new GroupBox();
            cmbTrx = new ComboBox();
            cmbIssueStatus = new ComboBox();
            btnApplyFilter = new Button();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgIssues).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgIssues
            // 
            dgIssues.AllowUserToAddRows = false;
            dgIssues.AllowUserToDeleteRows = false;
            dgIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgIssues.Location = new Point(-5, 173);
            dgIssues.Name = "dgIssues";
            dgIssues.ReadOnly = true;
            dgIssues.RowHeadersWidth = 62;
            dgIssues.Size = new Size(929, 323);
            dgIssues.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbTrx);
            groupBox1.Controls.Add(cmbIssueStatus);
            groupBox1.Controls.Add(btnApplyFilter);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(912, 104);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // cmbTrx
            // 
            cmbTrx.FormattingEnabled = true;
            cmbTrx.Location = new Point(74, 49);
            cmbTrx.Name = "cmbTrx";
            cmbTrx.Size = new Size(182, 33);
            cmbTrx.TabIndex = 3;
            // 
            // cmbIssueStatus
            // 
            cmbIssueStatus.FormattingEnabled = true;
            cmbIssueStatus.Location = new Point(321, 49);
            cmbIssueStatus.Name = "cmbIssueStatus";
            cmbIssueStatus.Size = new Size(182, 33);
            cmbIssueStatus.TabIndex = 2;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(595, 47);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(112, 34);
            btnApplyFilter.TabIndex = 1;
            btnApplyFilter.Text = "Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 52);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 6;
            label2.Text = "Trx";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 56);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 7;
            label1.Text = "Status";
            // 
            // Issuesfrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 517);
            Controls.Add(groupBox1);
            Controls.Add(dgIssues);
            Name = "Issuesfrm";
            Text = "Issuesfrm";
            Load += Issuesfrm_Load;
            ((System.ComponentModel.ISupportInitialize)dgIssues).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgIssues;
        private GroupBox groupBox1;
        private ComboBox cmbIssueStatus;
        private Button btnApplyFilter;
        private ComboBox cmbTrx;
        private Label label2;
        private Label label1;
    }
}