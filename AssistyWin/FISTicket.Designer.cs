namespace AssistyWin
{
    partial class FISTicket
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
            dgFISTickets = new DataGridView();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            cmbApps = new ComboBox();
            cmbTrxList = new ComboBox();
            btnApplyFilter = new Button();
            ((System.ComponentModel.ISupportInitialize)dgFISTickets).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgFISTickets
            // 
            dgFISTickets.AllowUserToAddRows = false;
            dgFISTickets.AllowUserToDeleteRows = false;
            dgFISTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFISTickets.Location = new Point(-5, 173);
            dgFISTickets.Name = "dgFISTickets";
            dgFISTickets.ReadOnly = true;
            dgFISTickets.RowHeadersWidth = 62;
            dgFISTickets.Size = new Size(929, 323);
            dgFISTickets.TabIndex = 0; 
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbApps);
            groupBox1.Controls.Add(cmbTrxList);
            groupBox1.Controls.Add(btnApplyFilter);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(912, 104);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 49);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 4;
            label1.Text = "Apps";
            // 
            // cmbApps
            // 
            cmbApps.FormattingEnabled = true;
            cmbApps.Location = new Point(74, 49);
            cmbApps.Name = "cmbApps";
            cmbApps.Size = new Size(182, 33);
            cmbApps.TabIndex = 3;
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
            // FISTicket
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 517);
            Controls.Add(groupBox1);
            Controls.Add(dgFISTickets);
            Name = "FISTicket";
            Text = "FISTicket";
            Load += FISTicket_Load;
            ((System.ComponentModel.ISupportInitialize)dgFISTickets).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgFISTickets;
        private GroupBox groupBox1;
        private ComboBox cmbTrxList;
        private Button btnApplyFilter;
        private ComboBox cmbApps;
        private Label label2;
        private Label label1;
    }
}