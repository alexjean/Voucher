namespace BakeryOrder
{
    partial class FormStatics
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader代碼 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader品名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader量 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader金額 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnDrawerOpenedList = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.labelDeduct = new System.Windows.Forms.Label();
            this.labelIncome = new System.Windows.Forms.Label();
            this.btnSystemSetup = new System.Windows.Forms.Button();
            this.btnClass = new System.Windows.Forms.Button();
            this.labelStatics = new System.Windows.Forms.Label();
            this.labelStatics2 = new System.Windows.Forms.Label();
            this.labelStatics1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.labelAlipayNo = new System.Windows.Forms.Label();
            this.labelMemberID = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(2, 712);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(88, 56);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "结帐画面";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lvItems
            // 
            this.lvItems.BackColor = System.Drawing.Color.SeaShell;
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader代碼,
            this.columnHeader品名,
            this.columnHeader量,
            this.columnHeader金額});
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(2, 0);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(226, 311);
            this.lvItems.TabIndex = 2;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader代碼
            // 
            this.columnHeader代碼.Width = 2;
            // 
            // columnHeader品名
            // 
            this.columnHeader品名.Text = "品名";
            this.columnHeader品名.Width = 124;
            // 
            // columnHeader量
            // 
            this.columnHeader量.Text = "量";
            this.columnHeader量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader量.Width = 30;
            // 
            // columnHeader金額
            // 
            this.columnHeader金額.Text = "金額";
            this.columnHeader金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader金額.Width = 52;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Location = new System.Drawing.Point(2, 643);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(88, 56);
            this.btnOrderList.TabIndex = 4;
            this.btnOrderList.Text = "收入明細";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnDrawerOpenedList
            // 
            this.btnDrawerOpenedList.Location = new System.Drawing.Point(121, 643);
            this.btnDrawerOpenedList.Name = "btnDrawerOpenedList";
            this.btnDrawerOpenedList.Size = new System.Drawing.Size(88, 56);
            this.btnDrawerOpenedList.TabIndex = 5;
            this.btnDrawerOpenedList.Text = "錢箱記錄";
            this.btnDrawerOpenedList.UseVisualStyleBackColor = true;
            this.btnDrawerOpenedList.Click += new System.EventHandler(this.btnDrawerOpenedList_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 728);
            this.tabPage1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.ItemSize = new System.Drawing.Size(48, 32);
            this.tabControl1.Location = new System.Drawing.Point(234, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 768);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // labelDeduct
            // 
            this.labelDeduct.Location = new System.Drawing.Point(83, 356);
            this.labelDeduct.Name = "labelDeduct";
            this.labelDeduct.Size = new System.Drawing.Size(124, 25);
            this.labelDeduct.TabIndex = 6;
            this.labelDeduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIncome
            // 
            this.labelIncome.Location = new System.Drawing.Point(85, 322);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(124, 25);
            this.labelIncome.TabIndex = 7;
            this.labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSystemSetup
            // 
            this.btnSystemSetup.Location = new System.Drawing.Point(121, 712);
            this.btnSystemSetup.Name = "btnSystemSetup";
            this.btnSystemSetup.Size = new System.Drawing.Size(88, 56);
            this.btnSystemSetup.TabIndex = 11;
            this.btnSystemSetup.Text = "系統設定";
            this.btnSystemSetup.UseVisualStyleBackColor = true;
            this.btnSystemSetup.Click += new System.EventHandler(this.btnSystemSetup_Click);
            // 
            // btnClass
            // 
            this.btnClass.BackColor = System.Drawing.Color.SeaShell;
            this.btnClass.Enabled = false;
            this.btnClass.Location = new System.Drawing.Point(2, 308);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(75, 53);
            this.btnClass.TabIndex = 12;
            this.btnClass.Text = "现金";
            this.btnClass.UseVisualStyleBackColor = false;
            // 
            // labelStatics
            // 
            this.labelStatics.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelStatics.Location = new System.Drawing.Point(78, 13);
            this.labelStatics.Name = "labelStatics";
            this.labelStatics.Size = new System.Drawing.Size(36, 25);
            this.labelStatics.TabIndex = 13;
            this.labelStatics.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStatics2
            // 
            this.labelStatics2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelStatics2.ForeColor = System.Drawing.Color.LawnGreen;
            this.labelStatics2.Location = new System.Drawing.Point(78, 47);
            this.labelStatics2.Name = "labelStatics2";
            this.labelStatics2.Size = new System.Drawing.Size(36, 25);
            this.labelStatics2.TabIndex = 14;
            this.labelStatics2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStatics1
            // 
            this.labelStatics1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelStatics1.ForeColor = System.Drawing.Color.Crimson;
            this.labelStatics1.Location = new System.Drawing.Point(78, 84);
            this.labelStatics1.Name = "labelStatics1";
            this.labelStatics1.Size = new System.Drawing.Size(36, 25);
            this.labelStatics1.TabIndex = 15;
            this.labelStatics1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(112, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 18;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label2.Location = new System.Drawing.Point(112, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 17;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(112, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 16;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 9F);
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(192, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 25);
            this.label4.TabIndex = 21;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 9F);
            this.label5.ForeColor = System.Drawing.Color.LawnGreen;
            this.label5.Location = new System.Drawing.Point(192, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 25);
            this.label5.TabIndex = 20;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 9F);
            this.label6.Location = new System.Drawing.Point(192, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 25);
            this.label6.TabIndex = 19;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(161, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 25);
            this.label7.TabIndex = 24;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.LawnGreen;
            this.label8.Location = new System.Drawing.Point(161, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 25);
            this.label8.TabIndex = 23;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(161, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 25);
            this.label9.TabIndex = 22;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(32, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 25);
            this.label10.TabIndex = 27;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.LawnGreen;
            this.label11.Location = new System.Drawing.Point(32, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 25);
            this.label11.TabIndex = 26;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(32, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 25);
            this.label12.TabIndex = 25;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.labelStatics);
            this.panel1.Controls.Add(this.labelStatics2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.labelStatics1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 146);
            this.panel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(85, 502);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 25);
            this.label13.TabIndex = 13;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAlipayNo
            // 
            this.labelAlipayNo.Location = new System.Drawing.Point(4, 424);
            this.labelAlipayNo.Name = "labelAlipayNo";
            this.labelAlipayNo.Size = new System.Drawing.Size(228, 55);
            this.labelAlipayNo.TabIndex = 14;
            this.labelAlipayNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemberID
            // 
            this.labelMemberID.Location = new System.Drawing.Point(4, 390);
            this.labelMemberID.Name = "labelMemberID";
            this.labelMemberID.Size = new System.Drawing.Size(228, 24);
            this.labelMemberID.TabIndex = 15;
            this.labelMemberID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.labelMemberID);
            this.Controls.Add(this.labelAlipayNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.btnClass);
            this.Controls.Add(this.btnSystemSetup);
            this.Controls.Add(this.labelIncome);
            this.Controls.Add(this.labelDeduct);
            this.Controls.Add(this.btnDrawerOpenedList);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnReturn);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormStatics";
            this.Load += new System.EventHandler(this.FormStatics_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader columnHeader代碼;
        private System.Windows.Forms.ColumnHeader columnHeader品名;
        private System.Windows.Forms.ColumnHeader columnHeader量;
        private System.Windows.Forms.ColumnHeader columnHeader金額;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnDrawerOpenedList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelDeduct;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.Button btnSystemSetup;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Label labelStatics;
        private System.Windows.Forms.Label labelStatics2;
        private System.Windows.Forms.Label labelStatics1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelAlipayNo;
        private System.Windows.Forms.Label labelMemberID;
    }
}