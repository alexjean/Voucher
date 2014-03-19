namespace VoucherExpense
{
    partial class FormTitleSetup
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label cashIncomeLabel;
            System.Windows.Forms.Label cashReceivableLabel;
            System.Windows.Forms.Label creditIncomeLabel;
            System.Windows.Forms.Label creditReceivableLabel;
            System.Windows.Forms.Label defaultAssetLabel;
            System.Windows.Forms.Label defaultCostLabel;
            System.Windows.Forms.Label defaultExpenseLabel;
            System.Windows.Forms.Label defaultIncomeLabel;
            System.Windows.Forms.Label defualtLiabilityLabel;
            System.Windows.Forms.Label ownersEquityLabel;
            System.Windows.Forms.Label voucherShouldPayLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.assetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTitleTableAdapter = new VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter();
            this.cashIncomeComboBox = new System.Windows.Forms.ComboBox();
            this.incomeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cashReceivableComboBox = new System.Windows.Forms.ComboBox();
            this.creditIncomeComboBox = new System.Windows.Forms.ComboBox();
            this.income1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creditReceivableComboBox = new System.Windows.Forms.ComboBox();
            this.asset1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cardFeeRateTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.defaultExpenseComboBox = new System.Windows.Forms.ComboBox();
            this.expenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultCostComboBox = new System.Windows.Forms.ComboBox();
            this.costBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultIncomeComboBox = new System.Windows.Forms.ComboBox();
            this.income2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defualtLiabilityComboBox = new System.Windows.Forms.ComboBox();
            this.liability2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultAssetComboBox = new System.Windows.Forms.ComboBox();
            this.asset2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ownersEquityComboBox = new System.Windows.Forms.ComboBox();
            this.ownersEquityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.voucherShouldPayComboBox = new System.Windows.Forms.ComboBox();
            this.liabilityTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxSoldOnCredit = new System.Windows.Forms.ComboBox();
            this.income3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbxReceivable = new System.Windows.Forms.ComboBox();
            this.asset3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.titleSetupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            cashIncomeLabel = new System.Windows.Forms.Label();
            cashReceivableLabel = new System.Windows.Forms.Label();
            creditIncomeLabel = new System.Windows.Forms.Label();
            creditReceivableLabel = new System.Windows.Forms.Label();
            defaultAssetLabel = new System.Windows.Forms.Label();
            defaultCostLabel = new System.Windows.Forms.Label();
            defaultExpenseLabel = new System.Windows.Forms.Label();
            defaultIncomeLabel = new System.Windows.Forms.Label();
            defualtLiabilityLabel = new System.Windows.Forms.Label();
            ownersEquityLabel = new System.Windows.Forms.Label();
            voucherShouldPayLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.income1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset1BindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.income2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liability2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownersEquityBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityTitleBindingSource)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.income3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleSetupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cashIncomeLabel
            // 
            cashIncomeLabel.AutoSize = true;
            cashIncomeLabel.Location = new System.Drawing.Point(92, 61);
            cashIncomeLabel.Name = "cashIncomeLabel";
            cashIncomeLabel.Size = new System.Drawing.Size(81, 16);
            cashIncomeLabel.TabIndex = 1;
            cashIncomeLabel.Text = "營收-現金:";
            // 
            // cashReceivableLabel
            // 
            cashReceivableLabel.AutoSize = true;
            cashReceivableLabel.Location = new System.Drawing.Point(41, 26);
            cashReceivableLabel.Name = "cashReceivableLabel";
            cashReceivableLabel.Size = new System.Drawing.Size(76, 16);
            cashReceivableLabel.TabIndex = 3;
            cashReceivableLabel.Text = "待存現金:";
            // 
            // creditIncomeLabel
            // 
            creditIncomeLabel.AutoSize = true;
            creditIncomeLabel.Location = new System.Drawing.Point(92, 131);
            creditIncomeLabel.Name = "creditIncomeLabel";
            creditIncomeLabel.Size = new System.Drawing.Size(81, 16);
            creditIncomeLabel.TabIndex = 5;
            creditIncomeLabel.Text = "營收-刷卡:";
            // 
            // creditReceivableLabel
            // 
            creditReceivableLabel.AutoSize = true;
            creditReceivableLabel.Location = new System.Drawing.Point(41, 96);
            creditReceivableLabel.Name = "creditReceivableLabel";
            creditReceivableLabel.Size = new System.Drawing.Size(92, 16);
            creditReceivableLabel.TabIndex = 7;
            creditReceivableLabel.Text = "待入帳刷卡:";
            // 
            // defaultAssetLabel
            // 
            defaultAssetLabel.AutoSize = true;
            defaultAssetLabel.Location = new System.Drawing.Point(41, 29);
            defaultAssetLabel.Name = "defaultAssetLabel";
            defaultAssetLabel.Size = new System.Drawing.Size(76, 16);
            defaultAssetLabel.TabIndex = 9;
            defaultAssetLabel.Text = "預設資產:";
            // 
            // defaultCostLabel
            // 
            defaultCostLabel.AutoSize = true;
            defaultCostLabel.Location = new System.Drawing.Point(41, 131);
            defaultCostLabel.Name = "defaultCostLabel";
            defaultCostLabel.Size = new System.Drawing.Size(76, 16);
            defaultCostLabel.TabIndex = 11;
            defaultCostLabel.Text = "預設成本:";
            // 
            // defaultExpenseLabel
            // 
            defaultExpenseLabel.AutoSize = true;
            defaultExpenseLabel.Location = new System.Drawing.Point(41, 165);
            defaultExpenseLabel.Name = "defaultExpenseLabel";
            defaultExpenseLabel.Size = new System.Drawing.Size(76, 16);
            defaultExpenseLabel.TabIndex = 13;
            defaultExpenseLabel.Text = "預設費用:";
            // 
            // defaultIncomeLabel
            // 
            defaultIncomeLabel.AutoSize = true;
            defaultIncomeLabel.Location = new System.Drawing.Point(41, 97);
            defaultIncomeLabel.Name = "defaultIncomeLabel";
            defaultIncomeLabel.Size = new System.Drawing.Size(76, 16);
            defaultIncomeLabel.TabIndex = 15;
            defaultIncomeLabel.Text = "預設收入:";
            // 
            // defualtLiabilityLabel
            // 
            defualtLiabilityLabel.AutoSize = true;
            defualtLiabilityLabel.Location = new System.Drawing.Point(41, 63);
            defualtLiabilityLabel.Name = "defualtLiabilityLabel";
            defualtLiabilityLabel.Size = new System.Drawing.Size(76, 16);
            defualtLiabilityLabel.TabIndex = 17;
            defualtLiabilityLabel.Text = "預設負債:";
            // 
            // ownersEquityLabel
            // 
            ownersEquityLabel.AutoSize = true;
            ownersEquityLabel.Location = new System.Drawing.Point(41, 199);
            ownersEquityLabel.Name = "ownersEquityLabel";
            ownersEquityLabel.Size = new System.Drawing.Size(76, 16);
            ownersEquityLabel.TabIndex = 19;
            ownersEquityLabel.Text = "股東權益:";
            // 
            // voucherShouldPayLabel
            // 
            voucherShouldPayLabel.AutoSize = true;
            voucherShouldPayLabel.Location = new System.Drawing.Point(92, 30);
            voucherShouldPayLabel.Name = "voucherShouldPayLabel";
            voucherShouldPayLabel.Size = new System.Drawing.Size(76, 16);
            voucherShouldPayLabel.TabIndex = 21;
            voucherShouldPayLabel.Text = "應付貨款:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(92, 167);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 16);
            label1.TabIndex = 30;
            label1.Text = "手續費率%";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 16);
            label2.TabIndex = 21;
            label2.Text = "應收貨款";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(176, 63);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 16);
            label3.TabIndex = 23;
            label3.Text = "營收-賖銷";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Azure;
            this.listBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "　本設定為計算損益表及資產負債表時使用之會計科目",
            "",
            "　為避免銀行帳目消失在某月虛科目上,",
            "　<銀行存款X>傳票二方均規定為實科目.  ",
            "　借貸一方必為銀行存款,另一方只能是資產或負債",
            "　為了查帳方便,   請設定多個科目的應收應付,",
            "　去對應相對的收入 成本 費用, 可方便查出錯誤.",
            "",
            "　銀行帳號所使用之科目在 銀行帳號 功能內設定",
            "　其中零用金為特殊帳戶,規定為第一個銀行帳戶",
            "　費用=><零用金>        , 預設貸方為零用金",
            "",
            "　現金收入          借計 <待存現金>   ,貸計<營收-現金>, ",
            "　存入銀行時      借計 <銀行存款X>,貸計<待存現金> ",
            "",
            "　刷卡收入          借計 <待入帳刷卡>,貸計<營收-刷卡>, ",
            "　入帳時  　　　借計 <銀行存款X> ,貸計<待入帳刷卡>",
            "",
            "    此處設定之手續費率, 在 \"收入月報\" 計算,僅供參考",
            "　手續費部分, 必需另以 \"轉帳傳票\" 手工列明, ",
            "　                          借計<刷卡手續費> 貸計<待入帳刷卡>",
            "",
            "　進貨單　　　  借計<成本科目>,貸計<應付貨款>",
            "",
            "    出貨單              借計<應收貨款>,貸計<營收-賒銷>"});
            this.listBox1.Location = new System.Drawing.Point(390, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(401, 436);
            this.listBox1.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(165, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 40);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assetBindingSource
            // 
            this.assetBindingSource.DataMember = "AccountingTitle";
            this.assetBindingSource.DataSource = this.vEDataSet;
            this.assetBindingSource.Filter = "TitleCode like \'1*\'";
            // 
            // accountingTitleTableAdapter
            // 
            this.accountingTitleTableAdapter.ClearBeforeFill = true;
            // 
            // cashIncomeComboBox
            // 
            this.cashIncomeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "CashIncome", true));
            this.cashIncomeComboBox.DataSource = this.incomeBindingSource;
            this.cashIncomeComboBox.DisplayMember = "Name";
            this.cashIncomeComboBox.FormattingEnabled = true;
            this.cashIncomeComboBox.Location = new System.Drawing.Point(179, 58);
            this.cashIncomeComboBox.Name = "cashIncomeComboBox";
            this.cashIncomeComboBox.Size = new System.Drawing.Size(121, 24);
            this.cashIncomeComboBox.TabIndex = 25;
            this.cashIncomeComboBox.ValueMember = "TitleCode";
            // 
            // incomeBindingSource
            // 
            this.incomeBindingSource.DataMember = "AccountingTitle";
            this.incomeBindingSource.DataSource = this.vEDataSet;
            this.incomeBindingSource.Filter = "TitleCode like \'4*\'";
            // 
            // cashReceivableComboBox
            // 
            this.cashReceivableComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "CashReceivable", true));
            this.cashReceivableComboBox.DataSource = this.assetBindingSource;
            this.cashReceivableComboBox.DisplayMember = "Name";
            this.cashReceivableComboBox.FormattingEnabled = true;
            this.cashReceivableComboBox.Location = new System.Drawing.Point(179, 23);
            this.cashReceivableComboBox.Name = "cashReceivableComboBox";
            this.cashReceivableComboBox.Size = new System.Drawing.Size(121, 24);
            this.cashReceivableComboBox.TabIndex = 26;
            this.cashReceivableComboBox.ValueMember = "TitleCode";
            // 
            // creditIncomeComboBox
            // 
            this.creditIncomeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "CardIncome", true));
            this.creditIncomeComboBox.DataSource = this.income1BindingSource;
            this.creditIncomeComboBox.DisplayMember = "Name";
            this.creditIncomeComboBox.FormattingEnabled = true;
            this.creditIncomeComboBox.Location = new System.Drawing.Point(179, 128);
            this.creditIncomeComboBox.Name = "creditIncomeComboBox";
            this.creditIncomeComboBox.Size = new System.Drawing.Size(121, 24);
            this.creditIncomeComboBox.TabIndex = 27;
            this.creditIncomeComboBox.ValueMember = "TitleCode";
            // 
            // income1BindingSource
            // 
            this.income1BindingSource.DataMember = "AccountingTitle";
            this.income1BindingSource.DataSource = this.vEDataSet;
            this.income1BindingSource.Filter = "TitleCode like \'4*\'";
            // 
            // creditReceivableComboBox
            // 
            this.creditReceivableComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "CardReceivable", true));
            this.creditReceivableComboBox.DataSource = this.asset1BindingSource;
            this.creditReceivableComboBox.DisplayMember = "Name";
            this.creditReceivableComboBox.FormattingEnabled = true;
            this.creditReceivableComboBox.Location = new System.Drawing.Point(179, 93);
            this.creditReceivableComboBox.Name = "creditReceivableComboBox";
            this.creditReceivableComboBox.Size = new System.Drawing.Size(121, 24);
            this.creditReceivableComboBox.TabIndex = 28;
            this.creditReceivableComboBox.ValueMember = "TitleCode";
            // 
            // asset1BindingSource
            // 
            this.asset1BindingSource.DataMember = "AccountingTitle";
            this.asset1BindingSource.DataSource = this.vEDataSet;
            this.asset1BindingSource.Filter = "TitleCode like \'1*\'";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.cardFeeRateTextBox);
            this.groupBox1.Controls.Add(this.creditIncomeComboBox);
            this.groupBox1.Controls.Add(this.creditReceivableComboBox);
            this.groupBox1.Controls.Add(cashReceivableLabel);
            this.groupBox1.Controls.Add(creditReceivableLabel);
            this.groupBox1.Controls.Add(this.cashIncomeComboBox);
            this.groupBox1.Controls.Add(this.cashReceivableComboBox);
            this.groupBox1.Controls.Add(cashIncomeLabel);
            this.groupBox1.Controls.Add(creditIncomeLabel);
            this.groupBox1.Location = new System.Drawing.Point(43, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 202);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "POS机營收";
            // 
            // cardFeeRateTextBox
            // 
            this.cardFeeRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.titleSetupBindingSource, "CardFeeRate", true));
            this.cardFeeRateTextBox.Location = new System.Drawing.Point(179, 164);
            this.cardFeeRateTextBox.Name = "cardFeeRateTextBox";
            this.cardFeeRateTextBox.Size = new System.Drawing.Size(121, 27);
            this.cardFeeRateTextBox.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.defaultExpenseComboBox);
            this.groupBox2.Controls.Add(this.defaultCostComboBox);
            this.groupBox2.Controls.Add(this.defaultIncomeComboBox);
            this.groupBox2.Controls.Add(this.defualtLiabilityComboBox);
            this.groupBox2.Controls.Add(this.defaultAssetComboBox);
            this.groupBox2.Controls.Add(this.ownersEquityComboBox);
            this.groupBox2.Controls.Add(ownersEquityLabel);
            this.groupBox2.Controls.Add(defualtLiabilityLabel);
            this.groupBox2.Controls.Add(defaultIncomeLabel);
            this.groupBox2.Controls.Add(defaultExpenseLabel);
            this.groupBox2.Controls.Add(defaultAssetLabel);
            this.groupBox2.Controls.Add(defaultCostLabel);
            this.groupBox2.Location = new System.Drawing.Point(43, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 234);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "未輸入時預設科目";
            // 
            // defaultExpenseComboBox
            // 
            this.defaultExpenseComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefaultExpense", true));
            this.defaultExpenseComboBox.DataSource = this.expenseBindingSource;
            this.defaultExpenseComboBox.DisplayMember = "Name";
            this.defaultExpenseComboBox.FormattingEnabled = true;
            this.defaultExpenseComboBox.Location = new System.Drawing.Point(179, 161);
            this.defaultExpenseComboBox.Name = "defaultExpenseComboBox";
            this.defaultExpenseComboBox.Size = new System.Drawing.Size(121, 24);
            this.defaultExpenseComboBox.TabIndex = 25;
            this.defaultExpenseComboBox.ValueMember = "TitleCode";
            // 
            // expenseBindingSource
            // 
            this.expenseBindingSource.DataMember = "AccountingTitle";
            this.expenseBindingSource.DataSource = this.vEDataSet;
            this.expenseBindingSource.Filter = "TitleCode like \'6*\'";
            // 
            // defaultCostComboBox
            // 
            this.defaultCostComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefaultCost", true));
            this.defaultCostComboBox.DataSource = this.costBindingSource;
            this.defaultCostComboBox.DisplayMember = "Name";
            this.defaultCostComboBox.FormattingEnabled = true;
            this.defaultCostComboBox.Location = new System.Drawing.Point(179, 127);
            this.defaultCostComboBox.Name = "defaultCostComboBox";
            this.defaultCostComboBox.Size = new System.Drawing.Size(121, 24);
            this.defaultCostComboBox.TabIndex = 24;
            this.defaultCostComboBox.ValueMember = "TitleCode";
            // 
            // costBindingSource
            // 
            this.costBindingSource.DataMember = "AccountingTitle";
            this.costBindingSource.DataSource = this.vEDataSet;
            this.costBindingSource.Filter = "TitleCode like \'5*\'";
            // 
            // defaultIncomeComboBox
            // 
            this.defaultIncomeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefaultIncome", true));
            this.defaultIncomeComboBox.DataSource = this.income2BindingSource;
            this.defaultIncomeComboBox.DisplayMember = "Name";
            this.defaultIncomeComboBox.FormattingEnabled = true;
            this.defaultIncomeComboBox.Location = new System.Drawing.Point(179, 93);
            this.defaultIncomeComboBox.Name = "defaultIncomeComboBox";
            this.defaultIncomeComboBox.Size = new System.Drawing.Size(121, 24);
            this.defaultIncomeComboBox.TabIndex = 23;
            this.defaultIncomeComboBox.ValueMember = "TitleCode";
            // 
            // income2BindingSource
            // 
            this.income2BindingSource.DataMember = "AccountingTitle";
            this.income2BindingSource.DataSource = this.vEDataSet;
            this.income2BindingSource.Filter = "TitleCode like \'4*\'";
            // 
            // defualtLiabilityComboBox
            // 
            this.defualtLiabilityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefualtLiability", true));
            this.defualtLiabilityComboBox.DataSource = this.liability2BindingSource;
            this.defualtLiabilityComboBox.DisplayMember = "Name";
            this.defualtLiabilityComboBox.FormattingEnabled = true;
            this.defualtLiabilityComboBox.Location = new System.Drawing.Point(179, 59);
            this.defualtLiabilityComboBox.Name = "defualtLiabilityComboBox";
            this.defualtLiabilityComboBox.Size = new System.Drawing.Size(121, 24);
            this.defualtLiabilityComboBox.TabIndex = 22;
            this.defualtLiabilityComboBox.ValueMember = "TitleCode";
            // 
            // liability2BindingSource
            // 
            this.liability2BindingSource.DataMember = "AccountingTitle";
            this.liability2BindingSource.DataSource = this.vEDataSet;
            this.liability2BindingSource.Filter = "TitleCode like \'2*\'";
            // 
            // defaultAssetComboBox
            // 
            this.defaultAssetComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefaultAsset", true));
            this.defaultAssetComboBox.DataSource = this.asset2BindingSource;
            this.defaultAssetComboBox.DisplayMember = "Name";
            this.defaultAssetComboBox.FormattingEnabled = true;
            this.defaultAssetComboBox.Location = new System.Drawing.Point(179, 25);
            this.defaultAssetComboBox.Name = "defaultAssetComboBox";
            this.defaultAssetComboBox.Size = new System.Drawing.Size(121, 24);
            this.defaultAssetComboBox.TabIndex = 21;
            this.defaultAssetComboBox.ValueMember = "TitleCode";
            // 
            // asset2BindingSource
            // 
            this.asset2BindingSource.DataMember = "AccountingTitle";
            this.asset2BindingSource.DataSource = this.vEDataSet;
            this.asset2BindingSource.Filter = "TitleCode like \'1*\'";
            // 
            // ownersEquityComboBox
            // 
            this.ownersEquityComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "DefaultOwnersEquity", true));
            this.ownersEquityComboBox.DataSource = this.ownersEquityBindingSource;
            this.ownersEquityComboBox.DisplayMember = "Name";
            this.ownersEquityComboBox.FormattingEnabled = true;
            this.ownersEquityComboBox.Location = new System.Drawing.Point(179, 195);
            this.ownersEquityComboBox.Name = "ownersEquityComboBox";
            this.ownersEquityComboBox.Size = new System.Drawing.Size(121, 24);
            this.ownersEquityComboBox.TabIndex = 20;
            this.ownersEquityComboBox.ValueMember = "TitleCode";
            // 
            // ownersEquityBindingSource
            // 
            this.ownersEquityBindingSource.DataMember = "AccountingTitle";
            this.ownersEquityBindingSource.DataSource = this.vEDataSet;
            this.ownersEquityBindingSource.Filter = "TitleCode like \'3*\'";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.voucherShouldPayComboBox);
            this.groupBox3.Controls.Add(voucherShouldPayLabel);
            this.groupBox3.Location = new System.Drawing.Point(43, 463);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 70);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "進貨貸方";
            // 
            // voucherShouldPayComboBox
            // 
            this.voucherShouldPayComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "VoucherShouldPay", true));
            this.voucherShouldPayComboBox.DataSource = this.liabilityTitleBindingSource;
            this.voucherShouldPayComboBox.DisplayMember = "Name";
            this.voucherShouldPayComboBox.FormattingEnabled = true;
            this.voucherShouldPayComboBox.Location = new System.Drawing.Point(179, 27);
            this.voucherShouldPayComboBox.Name = "voucherShouldPayComboBox";
            this.voucherShouldPayComboBox.Size = new System.Drawing.Size(121, 24);
            this.voucherShouldPayComboBox.TabIndex = 22;
            this.voucherShouldPayComboBox.ValueMember = "TitleCode";
            // 
            // liabilityTitleBindingSource
            // 
            this.liabilityTitleBindingSource.DataMember = "AccountingTitle";
            this.liabilityTitleBindingSource.DataSource = this.vEDataSet;
            this.liabilityTitleBindingSource.Filter = "TitleCode like \'2*\'";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxSoldOnCredit);
            this.groupBox4.Controls.Add(label3);
            this.groupBox4.Controls.Add(this.cbxReceivable);
            this.groupBox4.Controls.Add(label2);
            this.groupBox4.Location = new System.Drawing.Point(390, 463);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(401, 106);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "出貨單";
            // 
            // cbxSoldOnCredit
            // 
            this.cbxSoldOnCredit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "SoldOnCreditIncome", true));
            this.cbxSoldOnCredit.DataSource = this.income3BindingSource;
            this.cbxSoldOnCredit.DisplayMember = "Name";
            this.cbxSoldOnCredit.FormattingEnabled = true;
            this.cbxSoldOnCredit.Location = new System.Drawing.Point(258, 60);
            this.cbxSoldOnCredit.Name = "cbxSoldOnCredit";
            this.cbxSoldOnCredit.Size = new System.Drawing.Size(121, 24);
            this.cbxSoldOnCredit.TabIndex = 24;
            this.cbxSoldOnCredit.ValueMember = "TitleCode";
            // 
            // income3BindingSource
            // 
            this.income3BindingSource.DataMember = "AccountingTitle";
            this.income3BindingSource.DataSource = this.vEDataSet;
            this.income3BindingSource.Filter = "TitleCode like \'4*\'";
            // 
            // cbxReceivable
            // 
            this.cbxReceivable.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.titleSetupBindingSource, "SoldOnCreditReceivable", true));
            this.cbxReceivable.DataSource = this.asset3BindingSource;
            this.cbxReceivable.DisplayMember = "Name";
            this.cbxReceivable.FormattingEnabled = true;
            this.cbxReceivable.Location = new System.Drawing.Point(99, 30);
            this.cbxReceivable.Name = "cbxReceivable";
            this.cbxReceivable.Size = new System.Drawing.Size(121, 24);
            this.cbxReceivable.TabIndex = 22;
            this.cbxReceivable.ValueMember = "TitleCode";
            // 
            // asset3BindingSource
            // 
            this.asset3BindingSource.DataMember = "AccountingTitle";
            this.asset3BindingSource.DataSource = this.vEDataSet;
            this.asset3BindingSource.Filter = "TitleCode like \'1*\'";
            // 
            // titleSetupBindingSource
            // 
            this.titleSetupBindingSource.DataSource = typeof(VoucherExpense.TitleSetup);
            // 
            // FormTitleSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(831, 635);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTitleSetup";
            this.Text = "傳票設定";
            this.Load += new System.EventHandler(this.FormTitleSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incomeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.income1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset1BindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.income2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liability2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownersEquityBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liabilityTitleBindingSource)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.income3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleSetupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSave;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource assetBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.AccountingTitleTableAdapter accountingTitleTableAdapter;
        private System.Windows.Forms.ComboBox cashIncomeComboBox;
        private System.Windows.Forms.ComboBox cashReceivableComboBox;
        private System.Windows.Forms.ComboBox creditIncomeComboBox;
        private System.Windows.Forms.ComboBox creditReceivableComboBox;
        private System.Windows.Forms.BindingSource incomeBindingSource;
        private System.Windows.Forms.BindingSource income1BindingSource;
        private System.Windows.Forms.BindingSource asset1BindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox voucherShouldPayComboBox;
        private System.Windows.Forms.BindingSource liabilityTitleBindingSource;
        private System.Windows.Forms.ComboBox ownersEquityComboBox;
        private System.Windows.Forms.BindingSource ownersEquityBindingSource;
        private System.Windows.Forms.ComboBox defaultIncomeComboBox;
        private System.Windows.Forms.ComboBox defualtLiabilityComboBox;
        private System.Windows.Forms.BindingSource liability2BindingSource;
        private System.Windows.Forms.ComboBox defaultAssetComboBox;
        private System.Windows.Forms.BindingSource asset2BindingSource;
        private System.Windows.Forms.ComboBox defaultExpenseComboBox;
        private System.Windows.Forms.BindingSource expenseBindingSource;
        private System.Windows.Forms.ComboBox defaultCostComboBox;
        private System.Windows.Forms.BindingSource costBindingSource;
        private System.Windows.Forms.BindingSource income2BindingSource;
        private System.Windows.Forms.TextBox cardFeeRateTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbxSoldOnCredit;
        private System.Windows.Forms.ComboBox cbxReceivable;
        private System.Windows.Forms.BindingSource titleSetupBindingSource;
        private System.Windows.Forms.BindingSource asset3BindingSource;
        private System.Windows.Forms.BindingSource income3BindingSource;
    }
}