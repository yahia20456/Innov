namespace AssistyWin
{
    partial class AssistyLog
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
            dgAssistylog = new DataGridView();
            groupBox1 = new GroupBox();
            cmbUsers = new ComboBox();
            cmbTrxList = new ComboBox();
            btnApplyFilter = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgAssistylog).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgAssistylog
            // 
            dgAssistylog.AllowUserToAddRows = false;
            dgAssistylog.AllowUserToDeleteRows = false;
            dgAssistylog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAssistylog.Location = new Point(-5, 173);
            dgAssistylog.Name = "dgAssistylog";
            dgAssistylog.ReadOnly = true;
            dgAssistylog.RowHeadersWidth = 62;
            dgAssistylog.Size = new Size(929, 323);
            dgAssistylog.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbUsers);
            groupBox1.Controls.Add(cmbTrxList);
            groupBox1.Controls.Add(btnApplyFilter);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(912, 104);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // cmbUsers
            // 
            cmbUsers.FormattingEnabled = true;
            cmbUsers.Location = new Point(74, 49);
            cmbUsers.Name = "cmbUsers";
            cmbUsers.Size = new Size(182, 33);
            cmbUsers.TabIndex = 3;
            // 
            // cmbTrxList
            // 
            cmbTrxList.FormattingEnabled = true;
            cmbTrxList.Location = new Point(372, 49);
            cmbTrxList.Name = "cmbTrxList";
            cmbTrxList.Size = new Size(182, 33);
            cmbTrxList.TabIndex = 2;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 49);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 4;
            label1.Text = "Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 56);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 5;
            label2.Text = "Trx";
            // 
            // AssistyLog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 517);
            Controls.Add(groupBox1);
            Controls.Add(dgAssistylog);
            Name = "AssistyLog";
            Text = "AssistyLog";
            Load += AssistyLog_Load;
            ((System.ComponentModel.ISupportInitialize)dgAssistylog).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgAssistylog;
        private GroupBox groupBox1;
        private ComboBox cmbTrxList;
        private Button btnApplyFilter;
        private ComboBox cmbUsers;
        private Label label2;
        private Label label1;
    }
}