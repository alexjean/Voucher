namespace GetMoney
{
    partial class FormGetMoney
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGetMoney));
            this.getMoneyDataSet = new GetMoney.GetMoneyDataSet();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestsTableAdapter = new GetMoney.GetMoneyDataSetTableAdapters.RequestsTableAdapter();
            this.tableAdapterManager = new GetMoney.GetMoneyDataSetTableAdapters.TableAdapterManager();
            this.requestsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.requestsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.requestsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listNumberTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.paymenMethodsTextBox = new System.Windows.Forms.TextBox();
            this.moneyAaTextBox = new System.Windows.Forms.TextBox();
            this.moneyATextBox = new System.Windows.Forms.TextBox();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.bankOfDepositTextBox = new System.Windows.Forms.TextBox();
            this.dateOfPaymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateOfPaymentTextBox = new System.Windows.Forms.TextBox();
            this.uintNameTextBox = new System.Windows.Forms.TextBox();
            this.requestsUseTextBox = new System.Windows.Forms.TextBox();
            this.billingDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.billingDateTextBox = new System.Windows.Forms.TextBox();
            this.applicantTextBox = new System.Windows.Forms.TextBox();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCorp = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.getMoneyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingNavigator)).BeginInit();
            this.requestsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getMoneyDataSet
            // 
            this.getMoneyDataSet.DataSetName = "GetMoneyDataSet";
            this.getMoneyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestsBindingSource
            // 
            this.requestsBindingSource.DataMember = "Requests";
            this.requestsBindingSource.DataSource = this.getMoneyDataSet;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ApplierTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.OperatorTableAdapter = null;
            this.tableAdapterManager.RequestsTableAdapter = this.requestsTableAdapter;
            this.tableAdapterManager.UpdateOrder = GetMoney.GetMoneyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // requestsBindingNavigator
            // 
            this.requestsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.requestsBindingNavigator.BindingSource = this.requestsBindingSource;
            this.requestsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.requestsBindingNavigator.DeleteItem = null;
            this.requestsBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.requestsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.requestsBindingNavigatorSaveItem});
            this.requestsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.requestsBindingNavigator.MoveFirstItem = null;
            this.requestsBindingNavigator.MoveLastItem = null;
            this.requestsBindingNavigator.MoveNextItem = null;
            this.requestsBindingNavigator.MovePreviousItem = null;
            this.requestsBindingNavigator.Name = "requestsBindingNavigator";
            this.requestsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.requestsBindingNavigator.Size = new System.Drawing.Size(149, 25);
            this.requestsBindingNavigator.TabIndex = 0;
            this.requestsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // requestsBindingNavigatorSaveItem
            // 
            this.requestsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.requestsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("requestsBindingNavigatorSaveItem.Image")));
            this.requestsBindingNavigatorSaveItem.Name = "requestsBindingNavigatorSaveItem";
            this.requestsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.requestsBindingNavigatorSaveItem.Text = "儲存資料";
            this.requestsBindingNavigatorSaveItem.Click += new System.EventHandler(this.requestsBindingNavigatorSaveItem_Click);
            // 
            // requestsDataGridView
            // 
            this.requestsDataGridView.AllowUserToAddRows = false;
            this.requestsDataGridView.AllowUserToDeleteRows = false;
            this.requestsDataGridView.AllowUserToOrderColumns = true;
            this.requestsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requestsDataGridView.AutoGenerateColumns = false;
            this.requestsDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2});
            this.requestsDataGridView.DataSource = this.requestsBindingSource;
            this.requestsDataGridView.Location = new System.Drawing.Point(0, 29);
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.RowHeadersVisible = false;
            this.requestsDataGridView.RowTemplate.Height = 24;
            this.requestsDataGridView.Size = new System.Drawing.Size(448, 685);
            this.requestsDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RequestsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RequestsID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 2;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ListNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "单号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "BillingDate";
            this.dataGridViewTextBoxColumn14.HeaderText = "日";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 48;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Applicant";
            this.dataGridViewTextBoxColumn5.HeaderText = "申办";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 64;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RequestsUse";
            this.dataGridViewTextBoxColumn6.HeaderText = "用途说明";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MoneyAa";
            this.dataGridViewTextBoxColumn11.HeaderText = "金额";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsLock";
            this.dataGridViewCheckBoxColumn1.HeaderText = "付訖";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 64;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsCancel";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsCancel";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 32;
            // 
            // cbMonth
            // 
            this.cbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(259, 1);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(121, 24);
            this.cbMonth.TabIndex = 2;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "月份";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::GetMoney.Properties.Resources.Requests;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.listNumberTextBox);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.paymenMethodsTextBox);
            this.panel1.Controls.Add(this.moneyAaTextBox);
            this.panel1.Controls.Add(this.moneyATextBox);
            this.panel1.Controls.Add(this.accountTextBox);
            this.panel1.Controls.Add(this.bankOfDepositTextBox);
            this.panel1.Controls.Add(this.dateOfPaymentDateTimePicker);
            this.panel1.Controls.Add(this.dateOfPaymentTextBox);
            this.panel1.Controls.Add(this.uintNameTextBox);
            this.panel1.Controls.Add(this.requestsUseTextBox);
            this.panel1.Controls.Add(this.billingDateDateTimePicker);
            this.panel1.Controls.Add(this.billingDateTextBox);
            this.panel1.Controls.Add(this.applicantTextBox);
            this.panel1.Controls.Add(this.departmentTextBox);
            this.panel1.Location = new System.Drawing.Point(454, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 684);
            this.panel1.TabIndex = 0;
            // 
            // listNumberTextBox
            // 
            this.listNumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "ListNumber", true));
            this.listNumberTextBox.Enabled = false;
            this.listNumberTextBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listNumberTextBox.Location = new System.Drawing.Point(631, 152);
            this.listNumberTextBox.Name = "listNumberTextBox";
            this.listNumberTextBox.Size = new System.Drawing.Size(132, 20);
            this.listNumberTextBox.TabIndex = 13;
            this.listNumberTextBox.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("新宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(130, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 31);
            this.textBox1.TabIndex = 41;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // paymenMethodsTextBox
            // 
            this.paymenMethodsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.paymenMethodsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.paymenMethodsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "PaymenMethods", true));
            this.paymenMethodsTextBox.Enabled = false;
            this.paymenMethodsTextBox.Location = new System.Drawing.Point(682, 437);
            this.paymenMethodsTextBox.Name = "paymenMethodsTextBox";
            this.paymenMethodsTextBox.Size = new System.Drawing.Size(110, 20);
            this.paymenMethodsTextBox.TabIndex = 9;
            // 
            // moneyAaTextBox
            // 
            this.moneyAaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.moneyAaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moneyAaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "MoneyAa", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.moneyAaTextBox.Enabled = false;
            this.moneyAaTextBox.Location = new System.Drawing.Point(492, 437);
            this.moneyAaTextBox.Name = "moneyAaTextBox";
            this.moneyAaTextBox.Size = new System.Drawing.Size(103, 20);
            this.moneyAaTextBox.TabIndex = 8;
            this.moneyAaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // moneyATextBox
            // 
            this.moneyATextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.moneyATextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.moneyATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "MoneyA", true));
            this.moneyATextBox.Enabled = false;
            this.moneyATextBox.Location = new System.Drawing.Point(142, 437);
            this.moneyATextBox.Name = "moneyATextBox";
            this.moneyATextBox.Size = new System.Drawing.Size(302, 20);
            this.moneyATextBox.TabIndex = 38;
            // 
            // accountTextBox
            // 
            this.accountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.accountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.accountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "Account", true));
            this.accountTextBox.Enabled = false;
            this.accountTextBox.Location = new System.Drawing.Point(492, 392);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(300, 20);
            this.accountTextBox.TabIndex = 6;
            // 
            // bankOfDepositTextBox
            // 
            this.bankOfDepositTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.bankOfDepositTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bankOfDepositTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "BankOfDeposit", true));
            this.bankOfDepositTextBox.Enabled = false;
            this.bankOfDepositTextBox.Location = new System.Drawing.Point(130, 392);
            this.bankOfDepositTextBox.Name = "bankOfDepositTextBox";
            this.bankOfDepositTextBox.Size = new System.Drawing.Size(314, 20);
            this.bankOfDepositTextBox.TabIndex = 5;
            // 
            // dateOfPaymentDateTimePicker
            // 
            this.dateOfPaymentDateTimePicker.Enabled = false;
            this.dateOfPaymentDateTimePicker.Font = new System.Drawing.Font("新細明體", 12F);
            this.dateOfPaymentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfPaymentDateTimePicker.Location = new System.Drawing.Point(761, 349);
            this.dateOfPaymentDateTimePicker.Name = "dateOfPaymentDateTimePicker";
            this.dateOfPaymentDateTimePicker.Size = new System.Drawing.Size(17, 27);
            this.dateOfPaymentDateTimePicker.TabIndex = 35;
            this.dateOfPaymentDateTimePicker.Value = new System.DateTime(2013, 9, 29, 0, 0, 0, 0);
            // 
            // dateOfPaymentTextBox
            // 
            this.dateOfPaymentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dateOfPaymentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "DateOfPayment", true));
            this.dateOfPaymentTextBox.Enabled = false;
            this.dateOfPaymentTextBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.dateOfPaymentTextBox.Location = new System.Drawing.Point(602, 349);
            this.dateOfPaymentTextBox.Name = "dateOfPaymentTextBox";
            this.dateOfPaymentTextBox.Size = new System.Drawing.Size(161, 23);
            this.dateOfPaymentTextBox.TabIndex = 7;
            this.dateOfPaymentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uintNameTextBox
            // 
            this.uintNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.uintNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uintNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "UintName", true));
            this.uintNameTextBox.Enabled = false;
            this.uintNameTextBox.Location = new System.Drawing.Point(142, 349);
            this.uintNameTextBox.Name = "uintNameTextBox";
            this.uintNameTextBox.Size = new System.Drawing.Size(376, 20);
            this.uintNameTextBox.TabIndex = 4;
            // 
            // requestsUseTextBox
            // 
            this.requestsUseTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.requestsUseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.requestsUseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "RequestsUse", true));
            this.requestsUseTextBox.Enabled = false;
            this.requestsUseTextBox.Location = new System.Drawing.Point(50, 253);
            this.requestsUseTextBox.Multiline = true;
            this.requestsUseTextBox.Name = "requestsUseTextBox";
            this.requestsUseTextBox.Size = new System.Drawing.Size(728, 77);
            this.requestsUseTextBox.TabIndex = 3;
            // 
            // billingDateDateTimePicker
            // 
            this.billingDateDateTimePicker.Enabled = false;
            this.billingDateDateTimePicker.Font = new System.Drawing.Font("新細明體", 12F);
            this.billingDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.billingDateDateTimePicker.Location = new System.Drawing.Point(775, 191);
            this.billingDateDateTimePicker.Name = "billingDateDateTimePicker";
            this.billingDateDateTimePicker.Size = new System.Drawing.Size(17, 27);
            this.billingDateDateTimePicker.TabIndex = 31;
            // 
            // billingDateTextBox
            // 
            this.billingDateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.billingDateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "BillingDate", true));
            this.billingDateTextBox.Enabled = false;
            this.billingDateTextBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.billingDateTextBox.Location = new System.Drawing.Point(682, 191);
            this.billingDateTextBox.Name = "billingDateTextBox";
            this.billingDateTextBox.Size = new System.Drawing.Size(96, 23);
            this.billingDateTextBox.TabIndex = 2;
            this.billingDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // applicantTextBox
            // 
            this.applicantTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.applicantTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.applicantTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "Applicant", true));
            this.applicantTextBox.Enabled = false;
            this.applicantTextBox.Location = new System.Drawing.Point(359, 191);
            this.applicantTextBox.Name = "applicantTextBox";
            this.applicantTextBox.Size = new System.Drawing.Size(207, 20);
            this.applicantTextBox.TabIndex = 1;
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.departmentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.departmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.requestsBindingSource, "Department", true));
            this.departmentTextBox.Enabled = false;
            this.departmentTextBox.Location = new System.Drawing.Point(79, 191);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.Size = new System.Drawing.Size(185, 20);
            this.departmentTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "公司";
            // 
            // cbCorp
            // 
            this.cbCorp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.cbCorp.FormattingEnabled = true;
            this.cbCorp.Location = new System.Drawing.Point(517, 4);
            this.cbCorp.Name = "cbCorp";
            this.cbCorp.Size = new System.Drawing.Size(225, 24);
            this.cbCorp.TabIndex = 4;
            // 
            // FormGetMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1311, 714);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCorp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.requestsDataGridView);
            this.Controls.Add(this.requestsBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGetMoney";
            this.Text = " 請款單";
            this.Load += new System.EventHandler(this.FormGetMoney_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getMoneyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingNavigator)).EndInit();
            this.requestsBindingNavigator.ResumeLayout(false);
            this.requestsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GetMoneyDataSet getMoneyDataSet;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private GetMoneyDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private GetMoneyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator requestsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton requestsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView requestsDataGridView;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.TextBox applicantTextBox;
        private System.Windows.Forms.TextBox billingDateTextBox;
        private System.Windows.Forms.DateTimePicker billingDateDateTimePicker;
        private System.Windows.Forms.TextBox requestsUseTextBox;
        private System.Windows.Forms.TextBox uintNameTextBox;
        private System.Windows.Forms.TextBox dateOfPaymentTextBox;
        private System.Windows.Forms.DateTimePicker dateOfPaymentDateTimePicker;
        private System.Windows.Forms.TextBox bankOfDepositTextBox;
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.TextBox moneyATextBox;
        private System.Windows.Forms.TextBox moneyAaTextBox;
        private System.Windows.Forms.TextBox paymenMethodsTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox listNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCorp;
    }
}

