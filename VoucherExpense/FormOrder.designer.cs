namespace VoucherExpense
{
    partial class FormOrder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSaveTime = new System.Windows.Forms.Label();
            this.labelPrintTime = new System.Windows.Forms.Label();
            this.comboBoxGuoDi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxFood = new System.Windows.Forms.GroupBox();
            this.btnCodeEntry = new System.Windows.Forms.Button();
            this.textBoxVolume = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.btnSaveBack = new System.Windows.Forms.Button();
            this.lvNoDiscount = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.comboBoxPeopleNo = new System.Windows.Forms.ComboBox();
            this.btnSelectMenu = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintDiscountPart = new System.Windows.Forms.Button();
            this.btnPrintUndiscountPart = new System.Windows.Forms.Button();
            this.checkDiscount = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtbOrderNo = new System.Windows.Forms.MaskedTextBox();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.mtbDeduct = new System.Windows.Forms.MaskedTextBox();
            this.mtbInvoiceID = new System.Windows.Forms.MaskedTextBox();
            this.mtbServant = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvCanDiscount = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.checkOneDollor = new System.Windows.Forms.CheckBox();
            this.mtbCreditID = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.basicDataSet = new VoucherExpense.BasicDataSet();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderTableAdapter = new VoucherExpense.BasicDataSetTableAdapters.OrderTableAdapter();
            this.groupBoxFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "桌号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(145, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "人數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(274, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "工号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(378, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "菜單號";
            // 
            // labelSaveTime
            // 
            this.labelSaveTime.AutoSize = true;
            this.labelSaveTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelSaveTime.Location = new System.Drawing.Point(865, 9);
            this.labelSaveTime.Name = "labelSaveTime";
            this.labelSaveTime.Size = new System.Drawing.Size(59, 13);
            this.labelSaveTime.TabIndex = 6;
            this.labelSaveTime.Text = "存單時間";
            // 
            // labelPrintTime
            // 
            this.labelPrintTime.AutoSize = true;
            this.labelPrintTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPrintTime.Location = new System.Drawing.Point(865, 27);
            this.labelPrintTime.Name = "labelPrintTime";
            this.labelPrintTime.Size = new System.Drawing.Size(59, 13);
            this.labelPrintTime.TabIndex = 7;
            this.labelPrintTime.Text = "打單時間";
            // 
            // comboBoxGuoDi
            // 
            this.comboBoxGuoDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGuoDi.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBoxGuoDi.FormattingEnabled = true;
            this.comboBoxGuoDi.Items.AddRange(new object[] {
            "麻辣鍋底",
            "鴛鴦鍋底",
            "清香鍋底"});
            this.comboBoxGuoDi.Location = new System.Drawing.Point(56, 44);
            this.comboBoxGuoDi.Name = "comboBoxGuoDi";
            this.comboBoxGuoDi.Size = new System.Drawing.Size(105, 24);
            this.comboBoxGuoDi.TabIndex = 2;
            this.comboBoxGuoDi.SelectedIndexChanged += new System.EventHandler(this.comboBoxGuoDi_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "鍋底";
            // 
            // groupBoxFood
            // 
            this.groupBoxFood.Controls.Add(this.btnCodeEntry);
            this.groupBoxFood.Controls.Add(this.textBoxVolume);
            this.groupBoxFood.Controls.Add(this.textBoxCode);
            this.groupBoxFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxFood.Location = new System.Drawing.Point(292, 43);
            this.groupBoxFood.Name = "groupBoxFood";
            this.groupBoxFood.Size = new System.Drawing.Size(709, 636);
            this.groupBoxFood.TabIndex = 0;
            this.groupBoxFood.TabStop = false;
            this.groupBoxFood.Text = "菜單";
            // 
            // btnCodeEntry
            // 
            this.btnCodeEntry.Location = new System.Drawing.Point(566, 589);
            this.btnCodeEntry.Name = "btnCodeEntry";
            this.btnCodeEntry.Size = new System.Drawing.Size(75, 23);
            this.btnCodeEntry.TabIndex = 2;
            this.btnCodeEntry.Text = "代碼輸入";
            this.btnCodeEntry.UseVisualStyleBackColor = true;
            this.btnCodeEntry.Click += new System.EventHandler(this.btnCodeEntry_Click);
            // 
            // textBoxVolume
            // 
            this.textBoxVolume.Location = new System.Drawing.Point(638, 557);
            this.textBoxVolume.Name = "textBoxVolume";
            this.textBoxVolume.Size = new System.Drawing.Size(43, 23);
            this.textBoxVolume.TabIndex = 1;
            this.textBoxVolume.Text = "1";
            this.textBoxVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(566, 557);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(66, 23);
            this.textBoxCode.TabIndex = 0;
            // 
            // btnSaveBack
            // 
            this.btnSaveBack.Location = new System.Drawing.Point(87, 631);
            this.btnSaveBack.Name = "btnSaveBack";
            this.btnSaveBack.Size = new System.Drawing.Size(69, 25);
            this.btnSaveBack.TabIndex = 11;
            this.btnSaveBack.Text = "&X 儲存回";
            this.btnSaveBack.UseVisualStyleBackColor = true;
            this.btnSaveBack.Click += new System.EventHandler(this.btnSaveBack_Click);
            // 
            // lvNoDiscount
            // 
            this.lvNoDiscount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvNoDiscount.FullRowSelect = true;
            this.lvNoDiscount.HideSelection = false;
            this.lvNoDiscount.Location = new System.Drawing.Point(2, 339);
            this.lvNoDiscount.Name = "lvNoDiscount";
            this.lvNoDiscount.Size = new System.Drawing.Size(270, 185);
            this.lvNoDiscount.TabIndex = 4;
            this.lvNoDiscount.UseCompatibleStateImageBehavior = false;
            this.lvNoDiscount.View = System.Windows.Forms.View.Details;
            this.lvNoDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvNoDiscount_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "代碼";
            this.columnHeader1.Width = 41;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "品名";
            this.columnHeader2.Width = 125;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "量";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 29;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "金額";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 44;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(7, 631);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(69, 25);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "&Q 返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(7, 600);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 25);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "&W 打單";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 573);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "合計";
            // 
            // labelTotal
            // 
            this.labelTotal.Location = new System.Drawing.Point(176, 574);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(69, 13);
            this.labelTotal.TabIndex = 16;
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPeopleNo
            // 
            this.comboBoxPeopleNo.FormattingEnabled = true;
            this.comboBoxPeopleNo.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxPeopleNo.Location = new System.Drawing.Point(185, 11);
            this.comboBoxPeopleNo.Name = "comboBoxPeopleNo";
            this.comboBoxPeopleNo.Size = new System.Drawing.Size(67, 21);
            this.comboBoxPeopleNo.TabIndex = 19;
            this.comboBoxPeopleNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeopleNo_SelectedIndexChanged);
            // 
            // btnSelectMenu
            // 
            this.btnSelectMenu.Location = new System.Drawing.Point(185, 43);
            this.btnSelectMenu.Name = "btnSelectMenu";
            this.btnSelectMenu.Size = new System.Drawing.Size(69, 25);
            this.btnSelectMenu.TabIndex = 22;
            this.btnSelectMenu.Text = "&Z 酒水單";
            this.btnSelectMenu.UseVisualStyleBackColor = true;
            this.btnSelectMenu.Click += new System.EventHandler(this.btnSelectMenu_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(71, 535);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(41, 25);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(513, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "收款單號";
            // 
            // btnPrintDiscountPart
            // 
            this.btnPrintDiscountPart.Location = new System.Drawing.Point(87, 600);
            this.btnPrintDiscountPart.Name = "btnPrintDiscountPart";
            this.btnPrintDiscountPart.Size = new System.Drawing.Size(69, 25);
            this.btnPrintDiscountPart.TabIndex = 26;
            this.btnPrintDiscountPart.Text = "打折扣項";
            this.btnPrintDiscountPart.UseVisualStyleBackColor = true;
            // 
            // btnPrintUndiscountPart
            // 
            this.btnPrintUndiscountPart.Location = new System.Drawing.Point(167, 600);
            this.btnPrintUndiscountPart.Name = "btnPrintUndiscountPart";
            this.btnPrintUndiscountPart.Size = new System.Drawing.Size(69, 25);
            this.btnPrintUndiscountPart.TabIndex = 27;
            this.btnPrintUndiscountPart.Text = "不折扣項";
            this.btnPrintUndiscountPart.UseVisualStyleBackColor = true;
            // 
            // checkDiscount
            // 
            this.checkDiscount.AutoSize = true;
            this.checkDiscount.Location = new System.Drawing.Point(14, 543);
            this.checkDiscount.Name = "checkDiscount";
            this.checkDiscount.Size = new System.Drawing.Size(51, 17);
            this.checkDiscount.TabIndex = 28;
            this.checkDiscount.Text = "88折";
            this.checkDiscount.UseVisualStyleBackColor = true;
            this.checkDiscount.CheckedChanged += new System.EventHandler(this.checkDiscount_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "优惠";
            // 
            // mtbOrderNo
            // 
            this.mtbOrderNo.Location = new System.Drawing.Point(430, 10);
            this.mtbOrderNo.Mask = "99999999";
            this.mtbOrderNo.Name = "mtbOrderNo";
            this.mtbOrderNo.PromptChar = ' ';
            this.mtbOrderNo.Size = new System.Drawing.Size(63, 23);
            this.mtbOrderNo.TabIndex = 2;
            this.mtbOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbOrderNo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // textBoxTable
            // 
            this.textBoxTable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTable.Location = new System.Drawing.Point(56, 10);
            this.textBoxTable.MaxLength = 4;
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(40, 23);
            this.textBoxTable.TabIndex = 0;
            this.textBoxTable.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTable_Validating);
            // 
            // mtbDeduct
            // 
            this.mtbDeduct.AsciiOnly = true;
            this.mtbDeduct.Location = new System.Drawing.Point(185, 541);
            this.mtbDeduct.Mask = "9999";
            this.mtbDeduct.Name = "mtbDeduct";
            this.mtbDeduct.PromptChar = ' ';
            this.mtbDeduct.Size = new System.Drawing.Size(60, 23);
            this.mtbDeduct.TabIndex = 33;
            this.mtbDeduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbDeduct.Validated += new System.EventHandler(this.maskedTextBoxDeduct_Validated);
            // 
            // mtbInvoiceID
            // 
            this.mtbInvoiceID.Location = new System.Drawing.Point(578, 10);
            this.mtbInvoiceID.Mask = "99999999";
            this.mtbInvoiceID.Name = "mtbInvoiceID";
            this.mtbInvoiceID.PromptChar = ' ';
            this.mtbInvoiceID.Size = new System.Drawing.Size(48, 23);
            this.mtbInvoiceID.TabIndex = 3;
            this.mtbInvoiceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbInvoiceID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mtbServant
            // 
            this.mtbServant.Location = new System.Drawing.Point(313, 10);
            this.mtbServant.Mask = "9999";
            this.mtbServant.Name = "mtbServant";
            this.mtbServant.PromptChar = ' ';
            this.mtbServant.Size = new System.Drawing.Size(48, 23);
            this.mtbServant.TabIndex = 1;
            this.mtbServant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbServant.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 631);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 25);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "&C 儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvCanDiscount
            // 
            this.lvCanDiscount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvCanDiscount.FullRowSelect = true;
            this.lvCanDiscount.HideSelection = false;
            this.lvCanDiscount.Location = new System.Drawing.Point(2, 74);
            this.lvCanDiscount.Name = "lvCanDiscount";
            this.lvCanDiscount.Size = new System.Drawing.Size(270, 269);
            this.lvCanDiscount.TabIndex = 37;
            this.lvCanDiscount.UseCompatibleStateImageBehavior = false;
            this.lvCanDiscount.View = System.Windows.Forms.View.Details;
            this.lvCanDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCanDiscount_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "代碼";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "品名";
            this.columnHeader6.Width = 125;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "量";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 29;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "金額";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 44;
            // 
            // checkOneDollor
            // 
            this.checkOneDollor.AutoSize = true;
            this.checkOneDollor.Location = new System.Drawing.Point(14, 569);
            this.checkOneDollor.Name = "checkOneDollor";
            this.checkOneDollor.Size = new System.Drawing.Size(78, 17);
            this.checkOneDollor.TabIndex = 38;
            this.checkOneDollor.Text = "一元鍋底";
            this.checkOneDollor.UseVisualStyleBackColor = true;
            this.checkOneDollor.CheckedChanged += new System.EventHandler(this.checkOneDollor_CheckedChanged);
            // 
            // mtbCreditID
            // 
            this.mtbCreditID.Location = new System.Drawing.Point(732, 10);
            this.mtbCreditID.Mask = "999999";
            this.mtbCreditID.Name = "mtbCreditID";
            this.mtbCreditID.PromptChar = ' ';
            this.mtbCreditID.Size = new System.Drawing.Size(63, 23);
            this.mtbCreditID.TabIndex = 41;
            this.mtbCreditID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtbCreditID.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(666, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "刷卡號";
            // 
            // basicDataSet
            // 
            this.basicDataSet.DataSetName = "BasicDataSet";
            this.basicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.basicDataSet;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1013, 689);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mtbCreditID);
            this.Controls.Add(this.checkOneDollor);
            this.Controls.Add(this.lvNoDiscount);
            this.Controls.Add(this.lvCanDiscount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mtbServant);
            this.Controls.Add(this.mtbInvoiceID);
            this.Controls.Add(this.mtbDeduct);
            this.Controls.Add(this.textBoxTable);
            this.Controls.Add(this.mtbOrderNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkDiscount);
            this.Controls.Add(this.btnPrintUndiscountPart);
            this.Controls.Add(this.btnPrintDiscountPart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSelectMenu);
            this.Controls.Add(this.comboBoxPeopleNo);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveBack);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxGuoDi);
            this.Controls.Add(this.labelPrintTime);
            this.Controls.Add(this.labelSaveTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxFood);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormOrder";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOrder_FormClosed);
            this.groupBoxFood.ResumeLayout(false);
            this.groupBoxFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSaveTime;
        private System.Windows.Forms.Label labelPrintTime;
        private System.Windows.Forms.ComboBox comboBoxGuoDi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxFood;
        private System.Windows.Forms.Button btnSaveBack;
        private System.Windows.Forms.ListView lvNoDiscount;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ComboBox comboBoxPeopleNo;
        private System.Windows.Forms.Button btnSelectMenu;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintDiscountPart;
        private System.Windows.Forms.Button btnPrintUndiscountPart;
        private System.Windows.Forms.CheckBox checkDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtbOrderNo;
        private System.Windows.Forms.TextBox textBoxTable;
        private System.Windows.Forms.MaskedTextBox mtbDeduct;
        private System.Windows.Forms.MaskedTextBox mtbInvoiceID;
        private System.Windows.Forms.MaskedTextBox mtbServant;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvCanDiscount;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnCodeEntry;
        private System.Windows.Forms.TextBox textBoxVolume;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.CheckBox checkOneDollor;
        private BasicDataSet basicDataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private BasicDataSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private System.Windows.Forms.MaskedTextBox mtbCreditID;
        private System.Windows.Forms.Label label7;
    }
}