﻿namespace BakeryOrder
{
    partial class FormCheckout
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
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnCouponA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelCouponGot = new System.Windows.Forms.Label();
            this.textBoxCouponGot = new System.Windows.Forms.TextBox();
            this.textBoxDeduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCashGot = new System.Windows.Forms.TextBox();
            this.btnNumber100 = new System.Windows.Forms.Button();
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
            this.btnPayCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelDeduct = new System.Windows.Forms.Label();
            this.labelIncome = new System.Windows.Forms.Label();
            this.labelCashGot = new System.Windows.Forms.Label();
            this.labelChange = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btZhekou85 = new System.Windows.Forms.Button();
            this.btZhekou88 = new System.Windows.Forms.Button();
            this.btZhekou95 = new System.Windows.Forms.Button();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.labelzhekou = new System.Windows.Forms.Label();
            this.labelCouponGot2 = new System.Windows.Forms.Label();
            this.labelCouponGot1 = new System.Windows.Forms.Label();
            this.btnCouponB = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.SeaShell;
            this.btnCash.Location = new System.Drawing.Point(27, 18);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(75, 53);
            this.btnCash.TabIndex = 12;
            this.btnCash.Text = "现金";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.SeaShell;
            this.btnCard.Location = new System.Drawing.Point(108, 18);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(75, 53);
            this.btnCard.TabIndex = 13;
            this.btnCard.Text = "刷卡";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnCouponA
            // 
            this.btnCouponA.BackColor = System.Drawing.Color.SeaShell;
            this.btnCouponA.Location = new System.Drawing.Point(189, 18);
            this.btnCouponA.Name = "btnCouponA";
            this.btnCouponA.Size = new System.Drawing.Size(75, 53);
            this.btnCouponA.TabIndex = 14;
            this.btnCouponA.Text = "劵A";
            this.btnCouponA.UseVisualStyleBackColor = true;
            this.btnCouponA.Click += new System.EventHandler(this.btnCouponA_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "优惠";
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.labelCouponGot);
            this.panelLogin.Controls.Add(this.textBoxCouponGot);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.textBoxDeduct);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textBoxCashGot);
            this.panelLogin.Controls.Add(this.btnNumber100);
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
            this.panelLogin.Location = new System.Drawing.Point(367, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(327, 529);
            this.panelLogin.TabIndex = 15;
            // 
            // labelCouponGot
            // 
            this.labelCouponGot.AutoSize = true;
            this.labelCouponGot.BackColor = System.Drawing.Color.Transparent;
            this.labelCouponGot.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCouponGot.Location = new System.Drawing.Point(20, 109);
            this.labelCouponGot.Name = "labelCouponGot";
            this.labelCouponGot.Size = new System.Drawing.Size(54, 21);
            this.labelCouponGot.TabIndex = 17;
            this.labelCouponGot.Text = "收券";
            this.labelCouponGot.Visible = false;
            // 
            // textBoxCouponGot
            // 
            this.textBoxCouponGot.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxCouponGot.Location = new System.Drawing.Point(92, 101);
            this.textBoxCouponGot.MaxLength = 6;
            this.textBoxCouponGot.Name = "textBoxCouponGot";
            this.textBoxCouponGot.Size = new System.Drawing.Size(194, 35);
            this.textBoxCouponGot.TabIndex = 16;
            this.textBoxCouponGot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCouponGot.Visible = false;
            this.textBoxCouponGot.Enter += new System.EventHandler(this.textBoxCouponGot_Enter);
            // 
            // textBoxDeduct
            // 
            this.textBoxDeduct.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxDeduct.Location = new System.Drawing.Point(92, 56);
            this.textBoxDeduct.MaxLength = 6;
            this.textBoxDeduct.Name = "textBoxDeduct";
            this.textBoxDeduct.Size = new System.Drawing.Size(194, 35);
            this.textBoxDeduct.TabIndex = 1;
            this.textBoxDeduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDeduct.Enter += new System.EventHandler(this.textBoxDeduct_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "收现";
            // 
            // textBoxCashGot
            // 
            this.textBoxCashGot.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCashGot.Location = new System.Drawing.Point(92, 11);
            this.textBoxCashGot.MaxLength = 6;
            this.textBoxCashGot.Name = "textBoxCashGot";
            this.textBoxCashGot.Size = new System.Drawing.Size(194, 35);
            this.textBoxCashGot.TabIndex = 0;
            this.textBoxCashGot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCashGot.Enter += new System.EventHandler(this.textBoxCashGot_Enter);
            // 
            // btnNumber100
            // 
            this.btnNumber100.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber100.Location = new System.Drawing.Point(223, 442);
            this.btnNumber100.Name = "btnNumber100";
            this.btnNumber100.Size = new System.Drawing.Size(90, 74);
            this.btnNumber100.TabIndex = 13;
            this.btnNumber100.Text = "100";
            this.btnNumber100.UseVisualStyleBackColor = true;
            this.btnNumber100.Click += new System.EventHandler(this.btnNumber100_Click);
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
            // btnPayCheck
            // 
            this.btnPayCheck.BackColor = System.Drawing.Color.SeaShell;
            this.btnPayCheck.Location = new System.Drawing.Point(27, 449);
            this.btnPayCheck.Name = "btnPayCheck";
            this.btnPayCheck.Size = new System.Drawing.Size(174, 80);
            this.btnPayCheck.TabIndex = 16;
            this.btnPayCheck.Text = "結帳打單";
            this.btnPayCheck.UseVisualStyleBackColor = true;
            this.btnPayCheck.Click += new System.EventHandler(this.btnPayCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Azure;
            this.btnCancel.Location = new System.Drawing.Point(256, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 80);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(42, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "收现";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(42, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "小计";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(42, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "优惠";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(42, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "找零";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(42, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "应收";
            // 
            // labelTotal
            // 
            this.labelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTotal.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTotal.Location = new System.Drawing.Point(127, 151);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(104, 32);
            this.labelTotal.TabIndex = 23;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDeduct
            // 
            this.labelDeduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDeduct.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDeduct.Location = new System.Drawing.Point(127, 192);
            this.labelDeduct.Name = "labelDeduct";
            this.labelDeduct.Size = new System.Drawing.Size(104, 32);
            this.labelDeduct.TabIndex = 24;
            this.labelDeduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIncome
            // 
            this.labelIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIncome.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelIncome.Location = new System.Drawing.Point(127, 274);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(104, 32);
            this.labelIncome.TabIndex = 25;
            this.labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCashGot
            // 
            this.labelCashGot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCashGot.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCashGot.Location = new System.Drawing.Point(127, 315);
            this.labelCashGot.Name = "labelCashGot";
            this.labelCashGot.Size = new System.Drawing.Size(104, 32);
            this.labelCashGot.TabIndex = 26;
            this.labelCashGot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelChange
            // 
            this.labelChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelChange.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelChange.Location = new System.Drawing.Point(127, 356);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(104, 32);
            this.labelChange.TabIndex = 27;
            this.labelChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCalc
            // 
            this.btnCalc.BackColor = System.Drawing.Color.Azure;
            this.btnCalc.Location = new System.Drawing.Point(256, 247);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(87, 151);
            this.btnCalc.TabIndex = 28;
            this.btnCalc.Text = "<==";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btZhekou85
            // 
            this.btZhekou85.BackColor = System.Drawing.Color.SeaShell;
            this.btZhekou85.Location = new System.Drawing.Point(53, 97);
            this.btZhekou85.Name = "btZhekou85";
            this.btZhekou85.Size = new System.Drawing.Size(75, 38);
            this.btZhekou85.TabIndex = 29;
            this.btZhekou85.Text = "85折";
            this.btZhekou85.UseVisualStyleBackColor = true;
            this.btZhekou85.Click += new System.EventHandler(this.btZhekou85_Click);
            // 
            // btZhekou88
            // 
            this.btZhekou88.BackColor = System.Drawing.Color.SeaShell;
            this.btZhekou88.Location = new System.Drawing.Point(144, 97);
            this.btZhekou88.Name = "btZhekou88";
            this.btZhekou88.Size = new System.Drawing.Size(75, 38);
            this.btZhekou88.TabIndex = 30;
            this.btZhekou88.Text = "88折";
            this.btZhekou88.UseVisualStyleBackColor = true;
            this.btZhekou88.Click += new System.EventHandler(this.btZhekou88_Click);
            // 
            // btZhekou95
            // 
            this.btZhekou95.BackColor = System.Drawing.Color.SeaShell;
            this.btZhekou95.Location = new System.Drawing.Point(235, 97);
            this.btZhekou95.Name = "btZhekou95";
            this.btZhekou95.Size = new System.Drawing.Size(75, 38);
            this.btZhekou95.TabIndex = 31;
            this.btZhekou95.Text = "95折";
            this.btZhekou95.UseVisualStyleBackColor = true;
            this.btZhekou95.Click += new System.EventHandler(this.btZhekou95_Click);
            // 
            // labelDiscount
            // 
            this.labelDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDiscount.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelDiscount.Location = new System.Drawing.Point(127, 233);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(104, 32);
            this.labelDiscount.TabIndex = 33;
            this.labelDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelzhekou
            // 
            this.labelzhekou.AutoSize = true;
            this.labelzhekou.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelzhekou.Location = new System.Drawing.Point(42, 239);
            this.labelzhekou.Name = "labelzhekou";
            this.labelzhekou.Size = new System.Drawing.Size(54, 21);
            this.labelzhekou.TabIndex = 32;
            this.labelzhekou.Text = "折扣";
            // 
            // labelCouponGot2
            // 
            this.labelCouponGot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCouponGot2.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCouponGot2.Location = new System.Drawing.Point(127, 397);
            this.labelCouponGot2.Name = "labelCouponGot2";
            this.labelCouponGot2.Size = new System.Drawing.Size(104, 32);
            this.labelCouponGot2.TabIndex = 35;
            this.labelCouponGot2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCouponGot2.Visible = false;
            // 
            // labelCouponGot1
            // 
            this.labelCouponGot1.AutoSize = true;
            this.labelCouponGot1.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCouponGot1.ForeColor = System.Drawing.Color.Red;
            this.labelCouponGot1.Location = new System.Drawing.Point(42, 403);
            this.labelCouponGot1.Name = "labelCouponGot1";
            this.labelCouponGot1.Size = new System.Drawing.Size(54, 21);
            this.labelCouponGot1.TabIndex = 34;
            this.labelCouponGot1.Text = "收券";
            this.labelCouponGot1.Visible = false;
            // 
            // btnCouponB
            // 
            this.btnCouponB.BackColor = System.Drawing.Color.SeaShell;
            this.btnCouponB.Location = new System.Drawing.Point(270, 18);
            this.btnCouponB.Name = "btnCouponB";
            this.btnCouponB.Size = new System.Drawing.Size(75, 53);
            this.btnCouponB.TabIndex = 36;
            this.btnCouponB.Text = "劵B";
            this.btnCouponB.UseVisualStyleBackColor = true;
            this.btnCouponB.Click += new System.EventHandler(this.btnCouponB_Click);
            // 
            // FormCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(749, 550);
            this.Controls.Add(this.btnCouponB);
            this.Controls.Add(this.labelCouponGot2);
            this.Controls.Add(this.labelCouponGot1);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.labelzhekou);
            this.Controls.Add(this.btZhekou95);
            this.Controls.Add(this.btZhekou88);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.labelChange);
            this.Controls.Add(this.labelCashGot);
            this.Controls.Add(this.labelIncome);
            this.Controls.Add(this.btZhekou85);
            this.Controls.Add(this.labelDeduct);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPayCheck);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnCouponA);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCash);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCheckout";
            this.Text = "FormCheckout";
            this.Load += new System.EventHandler(this.FormCheckout_Load);
            this.Shown += new System.EventHandler(this.FormCheckout_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormCheckout_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormCheckout_KeyUp);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnCouponA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox textBoxDeduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCashGot;
        private System.Windows.Forms.Button btnNumber100;
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
        private System.Windows.Forms.Button btnPayCheck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelDeduct;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.Label labelCashGot;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btZhekou88;
        private System.Windows.Forms.Button btZhekou85;
        private System.Windows.Forms.Button btZhekou95;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.Label labelzhekou;
        private System.Windows.Forms.Label labelCouponGot;
        private System.Windows.Forms.TextBox textBoxCouponGot;
        private System.Windows.Forms.Label labelCouponGot2;
        private System.Windows.Forms.Label labelCouponGot1;
        private System.Windows.Forms.Button btnCouponB;
    }
}