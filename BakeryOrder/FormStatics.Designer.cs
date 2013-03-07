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
            this.tabControl1.SuspendLayout();
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
            this.lvItems.Size = new System.Drawing.Size(226, 399);
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
            this.btnDrawerOpenedList.Location = new System.Drawing.Point(108, 643);
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
            this.labelDeduct.Location = new System.Drawing.Point(83, 465);
            this.labelDeduct.Name = "labelDeduct";
            this.labelDeduct.Size = new System.Drawing.Size(124, 25);
            this.labelDeduct.TabIndex = 6;
            this.labelDeduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIncome
            // 
            this.labelIncome.Location = new System.Drawing.Point(83, 408);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(124, 25);
            this.labelIncome.TabIndex = 7;
            this.labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSystemSetup
            // 
            this.btnSystemSetup.Location = new System.Drawing.Point(108, 712);
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
            this.btnClass.Location = new System.Drawing.Point(2, 394);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(75, 53);
            this.btnClass.TabIndex = 12;
            this.btnClass.Text = "现金";
            this.btnClass.UseVisualStyleBackColor = false;
            // 
            // labelStatics
            // 
            this.labelStatics.Location = new System.Drawing.Point(12, 508);
            this.labelStatics.Name = "labelStatics";
            this.labelStatics.Size = new System.Drawing.Size(195, 25);
            this.labelStatics.TabIndex = 13;
            this.labelStatics.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.labelStatics);
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
            this.Text = "FormStatics";
            this.Load += new System.EventHandler(this.FormStatics_Load);
            this.tabControl1.ResumeLayout(false);
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
    }
}