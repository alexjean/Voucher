namespace VoucherExpense
{
    partial class FormBillPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBillPrint));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pD = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txbListNum = new System.Windows.Forms.TextBox();
            this.txbHandoverPeople = new System.Windows.Forms.TextBox();
            this.txbPaymentMethods = new System.Windows.Forms.TextBox();
            this.txbMoneyAa = new System.Windows.Forms.TextBox();
            this.txbMoneyA = new System.Windows.Forms.TextBox();
            this.txbAccount = new System.Windows.Forms.TextBox();
            this.txbBankOfDeposit = new System.Windows.Forms.TextBox();
            this.txbUintName = new System.Windows.Forms.TextBox();
            this.txbRequestsUse = new System.Windows.Forms.TextBox();
            this.txbApplicant = new System.Windows.Forms.TextBox();
            this.txbDepartment = new System.Windows.Forms.TextBox();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.requestsTableAdapter = new VoucherExpense.VEDataSetTableAdapters.RequestsTableAdapter();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(795, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrint.Image")));
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonPrint.Text = "打印";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "退出";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pD
            // 
            this.pD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::VoucherExpense.Properties.Resources.Requests;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.txbListNum);
            this.panel1.Controls.Add(this.txbHandoverPeople);
            this.panel1.Controls.Add(this.txbPaymentMethods);
            this.panel1.Controls.Add(this.txbMoneyAa);
            this.panel1.Controls.Add(this.txbMoneyA);
            this.panel1.Controls.Add(this.txbAccount);
            this.panel1.Controls.Add(this.txbBankOfDeposit);
            this.panel1.Controls.Add(this.txbUintName);
            this.panel1.Controls.Add(this.txbRequestsUse);
            this.panel1.Controls.Add(this.txbApplicant);
            this.panel1.Controls.Add(this.txbDepartment);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 425);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(596, 210);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 27);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(644, 107);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(109, 27);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // txbListNum
            // 
            this.txbListNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbListNum.Location = new System.Drawing.Point(644, 80);
            this.txbListNum.Margin = new System.Windows.Forms.Padding(4);
            this.txbListNum.Name = "txbListNum";
            this.txbListNum.Size = new System.Drawing.Size(49, 20);
            this.txbListNum.TabIndex = 12;
            this.txbListNum.Text = "000000";
            // 
            // txbHandoverPeople
            // 
            this.txbHandoverPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbHandoverPeople.Location = new System.Drawing.Point(552, 380);
            this.txbHandoverPeople.Margin = new System.Windows.Forms.Padding(4);
            this.txbHandoverPeople.Name = "txbHandoverPeople";
            this.txbHandoverPeople.Size = new System.Drawing.Size(177, 20);
            this.txbHandoverPeople.TabIndex = 11;
            // 
            // txbPaymentMethods
            // 
            this.txbPaymentMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPaymentMethods.Location = new System.Drawing.Point(643, 271);
            this.txbPaymentMethods.Margin = new System.Windows.Forms.Padding(4);
            this.txbPaymentMethods.Name = "txbPaymentMethods";
            this.txbPaymentMethods.Size = new System.Drawing.Size(110, 20);
            this.txbPaymentMethods.TabIndex = 10;
            // 
            // txbMoneyAa
            // 
            this.txbMoneyAa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMoneyAa.Location = new System.Drawing.Point(474, 271);
            this.txbMoneyAa.Margin = new System.Windows.Forms.Padding(4);
            this.txbMoneyAa.Name = "txbMoneyAa";
            this.txbMoneyAa.Size = new System.Drawing.Size(92, 20);
            this.txbMoneyAa.TabIndex = 9;
            this.txbMoneyAa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbMoneyA
            // 
            this.txbMoneyA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMoneyA.Location = new System.Drawing.Point(140, 271);
            this.txbMoneyA.Margin = new System.Windows.Forms.Padding(4);
            this.txbMoneyA.Name = "txbMoneyA";
            this.txbMoneyA.Size = new System.Drawing.Size(288, 20);
            this.txbMoneyA.TabIndex = 8;
            this.txbMoneyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbAccount
            // 
            this.txbAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbAccount.Location = new System.Drawing.Point(464, 243);
            this.txbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txbAccount.Name = "txbAccount";
            this.txbAccount.Size = new System.Drawing.Size(289, 20);
            this.txbAccount.TabIndex = 7;
            // 
            // txbBankOfDeposit
            // 
            this.txbBankOfDeposit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbBankOfDeposit.Location = new System.Drawing.Point(140, 243);
            this.txbBankOfDeposit.Margin = new System.Windows.Forms.Padding(4);
            this.txbBankOfDeposit.Name = "txbBankOfDeposit";
            this.txbBankOfDeposit.Size = new System.Drawing.Size(288, 20);
            this.txbBankOfDeposit.TabIndex = 6;
            // 
            // txbUintName
            // 
            this.txbUintName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUintName.Location = new System.Drawing.Point(140, 215);
            this.txbUintName.Margin = new System.Windows.Forms.Padding(4);
            this.txbUintName.Name = "txbUintName";
            this.txbUintName.Size = new System.Drawing.Size(356, 20);
            this.txbUintName.TabIndex = 4;
            // 
            // txbRequestsUse
            // 
            this.txbRequestsUse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbRequestsUse.Location = new System.Drawing.Point(45, 153);
            this.txbRequestsUse.Margin = new System.Windows.Forms.Padding(4);
            this.txbRequestsUse.Multiline = true;
            this.txbRequestsUse.Name = "txbRequestsUse";
            this.txbRequestsUse.Size = new System.Drawing.Size(701, 54);
            this.txbRequestsUse.TabIndex = 3;
            // 
            // txbApplicant
            // 
            this.txbApplicant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbApplicant.Location = new System.Drawing.Point(340, 111);
            this.txbApplicant.Margin = new System.Windows.Forms.Padding(4);
            this.txbApplicant.Name = "txbApplicant";
            this.txbApplicant.Size = new System.Drawing.Size(226, 20);
            this.txbApplicant.TabIndex = 1;
            // 
            // txbDepartment
            // 
            this.txbDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDepartment.Location = new System.Drawing.Point(82, 111);
            this.txbDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.txbDepartment.Name = "txbDepartment";
            this.txbDepartment.Size = new System.Drawing.Size(184, 20);
            this.txbDepartment.TabIndex = 0;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // FormBillPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBillPrint";
            this.Text = "FormBillPrint";
            this.Load += new System.EventHandler(this.FormBillPrint_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbDepartment;
        private System.Windows.Forms.TextBox txbListNum;
        private System.Windows.Forms.TextBox txbHandoverPeople;
        private System.Windows.Forms.TextBox txbPaymentMethods;
        private System.Windows.Forms.TextBox txbMoneyAa;
        private System.Windows.Forms.TextBox txbMoneyA;
        private System.Windows.Forms.TextBox txbAccount;
        private System.Windows.Forms.TextBox txbBankOfDeposit;
        private System.Windows.Forms.TextBox txbUintName;
        private System.Windows.Forms.TextBox txbRequestsUse;
        private System.Windows.Forms.TextBox txbApplicant;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Drawing.Printing.PrintDocument pD;
        private VEDataSet vEDataSet;
        private VEDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}