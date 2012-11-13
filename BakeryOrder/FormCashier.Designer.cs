﻿namespace BakeryOrder
{
    partial class FormCashier
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lvItems = new System.Windows.Forms.ListView();
            this.columnHeader代碼 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader品名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader量 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader金額 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnStatics = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTestLeave = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDiscount = new System.Windows.Forms.CheckBox();
            this.pictureBoxOrdered = new System.Windows.Forms.PictureBox();
            this.btnCashDrawer = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCashierID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNumber9 = new System.Windows.Forms.Button();
            this.btnNumber8 = new System.Windows.Forms.Button();
            this.btnNumber7 = new System.Windows.Forms.Button();
            this.btnNumber6 = new System.Windows.Forms.Button();
            this.btnNumber5 = new System.Windows.Forms.Button();
            this.btnNumber4 = new System.Windows.Forms.Button();
            this.btnNumber3 = new System.Windows.Forms.Button();
            this.btnNumber2 = new System.Windows.Forms.Button();
            this.btnNumber1 = new System.Windows.Forms.Button();
            this.btnNumber0 = new System.Windows.Forms.Button();
            this.productTableAdapter = new BakeryOrder.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.bakeryOrderSet = new BakeryOrder.BakeryOrderSet();
            this.cashierTableAdapter = new BakeryOrder.BakeryOrderSetTableAdapters.CashierTableAdapter();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdered)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            this.SuspendLayout();
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
            this.lvItems.Location = new System.Drawing.Point(1, 0);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(226, 426);
            this.lvItems.TabIndex = 0;
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
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(132, 717);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 51);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnStatics
            // 
            this.btnStatics.Location = new System.Drawing.Point(1, 717);
            this.btnStatics.Name = "btnStatics";
            this.btnStatics.Size = new System.Drawing.Size(75, 51);
            this.btnStatics.TabIndex = 2;
            this.btnStatics.Text = "统计";
            this.btnStatics.UseVisualStyleBackColor = true;
            this.btnStatics.Click += new System.EventHandler(this.btnStatics_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 32);
            this.tabControl1.Location = new System.Drawing.Point(233, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(791, 768);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Azure;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 728);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "饮料西点";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Azure;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 728);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "面包";
            // 
            // btnTestLeave
            // 
            this.btnTestLeave.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTestLeave.Location = new System.Drawing.Point(1, 706);
            this.btnTestLeave.Name = "btnTestLeave";
            this.btnTestLeave.Size = new System.Drawing.Size(106, 62);
            this.btnTestLeave.TabIndex = 0;
            this.btnTestLeave.Text = "測試用 離開程式";
            this.btnTestLeave.UseVisualStyleBackColor = true;
            this.btnTestLeave.Visible = false;
            this.btnTestLeave.Click += new System.EventHandler(this.btnTestLeave_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new System.Drawing.Point(152, 434);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(55, 20);
            this.labelTotal.TabIndex = 4;
            this.labelTotal.Text = "0";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "總計";
            // 
            // checkBoxDiscount
            // 
            this.checkBoxDiscount.AutoSize = true;
            this.checkBoxDiscount.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBoxDiscount.Location = new System.Drawing.Point(22, 486);
            this.checkBoxDiscount.Name = "checkBoxDiscount";
            this.checkBoxDiscount.Size = new System.Drawing.Size(71, 25);
            this.checkBoxDiscount.TabIndex = 6;
            this.checkBoxDiscount.Text = "九折";
            this.checkBoxDiscount.UseVisualStyleBackColor = true;
            this.checkBoxDiscount.Visible = false;
            this.checkBoxDiscount.CheckedChanged += new System.EventHandler(this.checkBoxDiscount_CheckedChanged);
            // 
            // pictureBoxOrdered
            // 
            this.pictureBoxOrdered.Location = new System.Drawing.Point(1, 465);
            this.pictureBoxOrdered.Name = "pictureBoxOrdered";
            this.pictureBoxOrdered.Size = new System.Drawing.Size(226, 169);
            this.pictureBoxOrdered.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxOrdered.TabIndex = 7;
            this.pictureBoxOrdered.TabStop = false;
            // 
            // btnCashDrawer
            // 
            this.btnCashDrawer.Location = new System.Drawing.Point(132, 649);
            this.btnCashDrawer.Name = "btnCashDrawer";
            this.btnCashDrawer.Size = new System.Drawing.Size(75, 51);
            this.btnCashDrawer.TabIndex = 8;
            this.btnCashDrawer.Text = "钱箱";
            this.btnCashDrawer.UseVisualStyleBackColor = true;
            this.btnCashDrawer.Click += new System.EventHandler(this.btnCashDrawer_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(1, 649);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(75, 51);
            this.btnNewOrder.TabIndex = 9;
            this.btnNewOrder.Text = "新單";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // checkBoxTest
            // 
            this.checkBoxTest.AutoSize = true;
            this.checkBoxTest.Checked = true;
            this.checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTest.Location = new System.Drawing.Point(17, 434);
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.Size = new System.Drawing.Size(59, 20);
            this.checkBoxTest.TabIndex = 10;
            this.checkBoxTest.Text = "不印";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.SeaShell;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textBoxCashierID);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.btnClear);
            this.panelLogin.Controls.Add(this.btnNumber9);
            this.panelLogin.Controls.Add(this.btnNumber8);
            this.panelLogin.Controls.Add(this.btnNumber7);
            this.panelLogin.Controls.Add(this.btnNumber6);
            this.panelLogin.Controls.Add(this.btnNumber5);
            this.panelLogin.Controls.Add(this.btnNumber4);
            this.panelLogin.Controls.Add(this.btnNumber3);
            this.panelLogin.Controls.Add(this.btnNumber2);
            this.panelLogin.Controls.Add(this.btnNumber1);
            this.panelLogin.Controls.Add(this.btnNumber0);
            this.panelLogin.Location = new System.Drawing.Point(432, 22);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(327, 529);
            this.panelLogin.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(32, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "密碼";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxPassword.Location = new System.Drawing.Point(117, 90);
            this.textBoxPassword.MaxLength = 6;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(135, 35);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(32, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "收銀員";
            // 
            // textBoxCashierID
            // 
            this.textBoxCashierID.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCashierID.Location = new System.Drawing.Point(117, 25);
            this.textBoxCashierID.MaxLength = 6;
            this.textBoxCashierID.Name = "textBoxCashierID";
            this.textBoxCashierID.Size = new System.Drawing.Size(135, 35);
            this.textBoxCashierID.TabIndex = 0;
            this.textBoxCashierID.Enter += new System.EventHandler(this.textBoxCashierID_Enter);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLogin.Location = new System.Drawing.Point(223, 442);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 74);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(117, 442);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 74);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNumber9
            // 
            this.btnNumber9.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber9.Location = new System.Drawing.Point(223, 352);
            this.btnNumber9.Name = "btnNumber9";
            this.btnNumber9.Size = new System.Drawing.Size(90, 74);
            this.btnNumber9.TabIndex = 10;
            this.btnNumber9.Text = "9";
            this.btnNumber9.UseVisualStyleBackColor = true;
            // 
            // btnNumber8
            // 
            this.btnNumber8.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber8.Location = new System.Drawing.Point(117, 352);
            this.btnNumber8.Name = "btnNumber8";
            this.btnNumber8.Size = new System.Drawing.Size(90, 74);
            this.btnNumber8.TabIndex = 9;
            this.btnNumber8.Text = "8";
            this.btnNumber8.UseVisualStyleBackColor = true;
            // 
            // btnNumber7
            // 
            this.btnNumber7.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber7.Location = new System.Drawing.Point(11, 352);
            this.btnNumber7.Name = "btnNumber7";
            this.btnNumber7.Size = new System.Drawing.Size(90, 74);
            this.btnNumber7.TabIndex = 8;
            this.btnNumber7.Text = "7";
            this.btnNumber7.UseVisualStyleBackColor = true;
            // 
            // btnNumber6
            // 
            this.btnNumber6.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber6.Location = new System.Drawing.Point(223, 262);
            this.btnNumber6.Name = "btnNumber6";
            this.btnNumber6.Size = new System.Drawing.Size(90, 74);
            this.btnNumber6.TabIndex = 7;
            this.btnNumber6.Text = "6";
            this.btnNumber6.UseVisualStyleBackColor = true;
            // 
            // btnNumber5
            // 
            this.btnNumber5.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber5.Location = new System.Drawing.Point(117, 262);
            this.btnNumber5.Name = "btnNumber5";
            this.btnNumber5.Size = new System.Drawing.Size(90, 74);
            this.btnNumber5.TabIndex = 6;
            this.btnNumber5.Text = "5";
            this.btnNumber5.UseVisualStyleBackColor = true;
            // 
            // btnNumber4
            // 
            this.btnNumber4.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber4.Location = new System.Drawing.Point(11, 262);
            this.btnNumber4.Name = "btnNumber4";
            this.btnNumber4.Size = new System.Drawing.Size(90, 74);
            this.btnNumber4.TabIndex = 5;
            this.btnNumber4.Text = "4";
            this.btnNumber4.UseVisualStyleBackColor = true;
            // 
            // btnNumber3
            // 
            this.btnNumber3.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber3.Location = new System.Drawing.Point(223, 172);
            this.btnNumber3.Name = "btnNumber3";
            this.btnNumber3.Size = new System.Drawing.Size(90, 74);
            this.btnNumber3.TabIndex = 4;
            this.btnNumber3.Text = "3";
            this.btnNumber3.UseVisualStyleBackColor = true;
            // 
            // btnNumber2
            // 
            this.btnNumber2.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber2.Location = new System.Drawing.Point(117, 172);
            this.btnNumber2.Name = "btnNumber2";
            this.btnNumber2.Size = new System.Drawing.Size(90, 74);
            this.btnNumber2.TabIndex = 3;
            this.btnNumber2.Text = "2";
            this.btnNumber2.UseVisualStyleBackColor = true;
            // 
            // btnNumber1
            // 
            this.btnNumber1.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber1.Location = new System.Drawing.Point(11, 172);
            this.btnNumber1.Name = "btnNumber1";
            this.btnNumber1.Size = new System.Drawing.Size(90, 74);
            this.btnNumber1.TabIndex = 2;
            this.btnNumber1.Text = "1";
            this.btnNumber1.UseVisualStyleBackColor = true;
            // 
            // btnNumber0
            // 
            this.btnNumber0.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber0.Location = new System.Drawing.Point(11, 442);
            this.btnNumber0.Name = "btnNumber0";
            this.btnNumber0.Size = new System.Drawing.Size(90, 74);
            this.btnNumber0.TabIndex = 11;
            this.btnNumber0.Text = "0";
            this.btnNumber0.UseVisualStyleBackColor = true;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cashierTableAdapter
            // 
            this.cashierTableAdapter.ClearBeforeFill = true;
            // 
            // FormCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.checkBoxTest);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnCashDrawer);
            this.Controls.Add(this.checkBoxDiscount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnStatics);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.pictureBoxOrdered);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnTestLeave);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCashier";
            this.Text = "烘焙收銀";
            this.Load += new System.EventHandler(this.FormCashier_Load);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrdered)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader columnHeader品名;
        private System.Windows.Forms.ColumnHeader columnHeader量;
        private System.Windows.Forms.ColumnHeader columnHeader金額;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnStatics;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader代碼;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDiscount;
        private System.Windows.Forms.PictureBox pictureBoxOrdered;
        private System.Windows.Forms.Button btnCashDrawer;
        private System.Windows.Forms.Button btnNewOrder;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.CheckBox checkBoxTest;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNumber9;
        private System.Windows.Forms.Button btnNumber8;
        private System.Windows.Forms.Button btnNumber7;
        private System.Windows.Forms.Button btnNumber6;
        private System.Windows.Forms.Button btnNumber5;
        private System.Windows.Forms.Button btnNumber4;
        private System.Windows.Forms.Button btnNumber3;
        private System.Windows.Forms.Button btnNumber2;
        private System.Windows.Forms.Button btnNumber1;
        private System.Windows.Forms.Button btnNumber0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCashierID;
        private BakeryOrderSetTableAdapters.CashierTableAdapter cashierTableAdapter;
        private System.Windows.Forms.Button btnTestLeave;
    }
}

