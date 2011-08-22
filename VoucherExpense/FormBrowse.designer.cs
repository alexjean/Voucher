namespace VoucherExpense
{
    partial class FormBrowse
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewBrowse = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalOrdeNo = new System.Windows.Forms.Label();
            this.labelPepoleNo = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.labelReceived = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.labelPayed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCreditCard = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMidnight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelNormal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.basicDataSet1 = new VoucherExpense.BasicDataSet();
            this.headerTableAdapter1 = new VoucherExpense.BasicDataSetTableAdapters.HeaderTableAdapter();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.checkBoxUse12 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewBrowse
            // 
            this.listViewBrowse.AllowColumnReorder = true;
            this.listViewBrowse.CheckBoxes = true;
            this.listViewBrowse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewBrowse.FullRowSelect = true;
            this.listViewBrowse.HideSelection = false;
            this.listViewBrowse.Location = new System.Drawing.Point(12, 13);
            this.listViewBrowse.MultiSelect = false;
            this.listViewBrowse.Name = "listViewBrowse";
            this.listViewBrowse.Size = new System.Drawing.Size(553, 629);
            this.listViewBrowse.TabIndex = 0;
            this.listViewBrowse.UseCompatibleStateImageBehavior = false;
            this.listViewBrowse.View = System.Windows.Forms.View.Details;
            this.listViewBrowse.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewBrowse_ColumnClick);
            this.listViewBrowse.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewBrowse_ItemChecked);
            this.listViewBrowse.DoubleClick += new System.EventHandler(this.listViewBrowse_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序號";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "桌次";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 46;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "時間";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 84;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "人數";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "金額";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "菜單号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "收款号";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 64;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "刷卡號";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 72;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(621, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "有收款單號不列";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "單數";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "人數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "小計";
            // 
            // labelTotalOrdeNo
            // 
            this.labelTotalOrdeNo.Location = new System.Drawing.Point(611, 186);
            this.labelTotalOrdeNo.Name = "labelTotalOrdeNo";
            this.labelTotalOrdeNo.Size = new System.Drawing.Size(51, 13);
            this.labelTotalOrdeNo.TabIndex = 8;
            this.labelTotalOrdeNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPepoleNo
            // 
            this.labelPepoleNo.Location = new System.Drawing.Point(738, 186);
            this.labelPepoleNo.Name = "labelPepoleNo";
            this.labelPepoleNo.Size = new System.Drawing.Size(51, 13);
            this.labelPepoleNo.TabIndex = 9;
            this.labelPepoleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSum
            // 
            this.labelSum.Location = new System.Drawing.Point(611, 240);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(51, 13);
            this.labelSum.TabIndex = 10;
            this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(621, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "打過單不列";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(621, 87);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "打勾的不列";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // labelReceived
            // 
            this.labelReceived.Location = new System.Drawing.Point(611, 212);
            this.labelReceived.Name = "labelReceived";
            this.labelReceived.Size = new System.Drawing.Size(51, 13);
            this.labelReceived.TabIndex = 17;
            this.labelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "現金";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckFileExists = true;
            this.saveFileDialog1.DefaultExt = "mdb";
            this.saveFileDialog1.Filter = "資料|*.gz";
            this.saveFileDialog1.InitialDirectory = "Closed";
            this.saveFileDialog1.OverwritePrompt = false;
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "請選擇要看的資料檔";
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(587, 444);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(176, 28);
            this.labelMessage.TabIndex = 23;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(580, 398);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "日報列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_BeginPrint);
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // labelPayed
            // 
            this.labelPayed.Location = new System.Drawing.Point(738, 240);
            this.labelPayed.Name = "labelPayed";
            this.labelPayed.Size = new System.Drawing.Size(51, 13);
            this.labelPayed.TabIndex = 27;
            this.labelPayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(705, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "己收";
            // 
            // labelCreditCard
            // 
            this.labelCreditCard.Location = new System.Drawing.Point(738, 212);
            this.labelCreditCard.Name = "labelCreditCard";
            this.labelCreditCard.Size = new System.Drawing.Size(51, 13);
            this.labelCreditCard.TabIndex = 29;
            this.labelCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(705, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "刷卡";
            // 
            // labelMidnight
            // 
            this.labelMidnight.Location = new System.Drawing.Point(738, 268);
            this.labelMidnight.Name = "labelMidnight";
            this.labelMidnight.Size = new System.Drawing.Size(51, 13);
            this.labelMidnight.TabIndex = 33;
            this.labelMidnight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(705, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "午夜";
            // 
            // labelNormal
            // 
            this.labelNormal.Location = new System.Drawing.Point(611, 268);
            this.labelNormal.Name = "labelNormal";
            this.labelNormal.Size = new System.Drawing.Size(51, 13);
            this.labelNormal.TabIndex = 31;
            this.labelNormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(581, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "平時";
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(706, 343);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(58, 21);
            this.comboBoxDay.TabIndex = 34;
            this.comboBoxDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDay_SelectedIndexChanged);
            // 
            // basicDataSet1
            // 
            this.basicDataSet1.DataSetName = "BasicDataSet";
            this.basicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // headerTableAdapter1
            // 
            this.headerTableAdapter1.ClearBeforeFill = true;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(580, 343);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(58, 21);
            this.comboBoxMonth.TabIndex = 35;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // checkBoxUse12
            // 
            this.checkBoxUse12.AutoSize = true;
            this.checkBoxUse12.Location = new System.Drawing.Point(708, 402);
            this.checkBoxUse12.Name = "checkBoxUse12";
            this.checkBoxUse12.Size = new System.Drawing.Size(63, 17);
            this.checkBoxUse12.TabIndex = 37;
            this.checkBoxUse12.Text = "0_24時";
            this.checkBoxUse12.UseVisualStyleBackColor = true;
            this.checkBoxUse12.CheckedChanged += new System.EventHandler(this.checkBoxUse12_CheckedChanged);
            // 
            // FormBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(859, 654);
            this.Controls.Add(this.checkBoxUse12);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.labelMidnight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelNormal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelCreditCard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelPayed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelReceived);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelPepoleNo);
            this.Controls.Add(this.labelTotalOrdeNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listViewBrowse);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "FormBrowse";
            this.Text = "今日";
            this.Load += new System.EventHandler(this.FormBrowse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBrowse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalOrdeNo;
        private System.Windows.Forms.Label labelPepoleNo;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label labelReceived;
        private System.Windows.Forms.Label label5;
        private BasicDataSet basicDataSet1;
        private BasicDataSetTableAdapters.HeaderTableAdapter headerTableAdapter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Label labelPayed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCreditCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label labelMidnight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelNormal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.CheckBox checkBoxUse12;
    }
}