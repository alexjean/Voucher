namespace VoucherExpense
{
    partial class FormBillList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBillList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.requestsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.requestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.requestsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
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
            this.requestsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.requestsTableAdapter = new VoucherExpense.VEDataSetTableAdapters.RequestsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingNavigator)).BeginInit();
            this.requestsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.requestsBindingNavigator);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.requestsDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 732);
            this.splitContainer1.SplitterDistance = 491;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // requestsBindingNavigator
            // 
            this.requestsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.requestsBindingNavigator.BindingSource = this.requestsBindingSource;
            this.requestsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.requestsBindingNavigator.DeleteItem = null;
            this.requestsBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.requestsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.requestsBindingNavigatorSaveItem});
            this.requestsBindingNavigator.Location = new System.Drawing.Point(838, 39);
            this.requestsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.requestsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.requestsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.requestsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.requestsBindingNavigator.Name = "requestsBindingNavigator";
            this.requestsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.requestsBindingNavigator.Size = new System.Drawing.Size(248, 25);
            this.requestsBindingNavigator.TabIndex = 10;
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
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click_1);
            // 
            // requestsBindingSource
            // 
            this.requestsBindingSource.DataMember = "Requests";
            this.requestsBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(28, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
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
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 425);
            this.panel1.TabIndex = 11;
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
            // requestsDataGridView
            // 
            this.requestsDataGridView.AllowUserToAddRows = false;
            this.requestsDataGridView.AllowUserToDeleteRows = false;
            this.requestsDataGridView.AutoGenerateColumns = false;
            this.requestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2});
            this.requestsDataGridView.DataSource = this.requestsBindingSource;
            this.requestsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.requestsDataGridView.Name = "requestsDataGridView";
            this.requestsDataGridView.ReadOnly = true;
            this.requestsDataGridView.RowHeadersVisible = false;
            this.requestsDataGridView.RowTemplate.Height = 23;
            this.requestsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.requestsDataGridView.Size = new System.Drawing.Size(1196, 236);
            this.requestsDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RequestsID";
            this.dataGridViewTextBoxColumn1.HeaderText = "RequestsID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ListNumber";
            this.dataGridViewTextBoxColumn2.HeaderText = "ListNumber";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OperatorID";
            this.dataGridViewTextBoxColumn3.HeaderText = "OperatorID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Department";
            this.dataGridViewTextBoxColumn4.HeaderText = "Department";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Applicant";
            this.dataGridViewTextBoxColumn5.HeaderText = "Applicant";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RequestsUse";
            this.dataGridViewTextBoxColumn6.HeaderText = "RequestsUse";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UintName";
            this.dataGridViewTextBoxColumn7.HeaderText = "UintName";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BankOfDeposit";
            this.dataGridViewTextBoxColumn8.HeaderText = "BankOfDeposit";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Account";
            this.dataGridViewTextBoxColumn9.HeaderText = "Account";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MoneyA";
            this.dataGridViewTextBoxColumn10.HeaderText = "MoneyA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MoneyAa";
            this.dataGridViewTextBoxColumn11.HeaderText = "MoneyAa";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PaymenMethods";
            this.dataGridViewTextBoxColumn12.HeaderText = "PaymenMethods";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "HandoverPoeple";
            this.dataGridViewTextBoxColumn13.HeaderText = "HandoverPoeple";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "BillingDate";
            this.dataGridViewTextBoxColumn14.HeaderText = "BillingDate";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DateOfPayment";
            this.dataGridViewTextBoxColumn15.HeaderText = "DateOfPayment";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsLock";
            this.dataGridViewCheckBoxColumn1.HeaderText = "IsLock";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsCancel";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsCancel";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // requestsTableAdapter
            // 
            this.requestsTableAdapter.ClearBeforeFill = true;
            // 
            // FormBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 732);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBillList";
            this.Text = "FormBillList";
            this.Load += new System.EventHandler(this.FormBillList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingNavigator)).EndInit();
            this.requestsBindingNavigator.ResumeLayout(false);
            this.requestsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
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
        private System.Windows.Forms.TextBox txbDepartment;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource requestsBindingSource;
        private VEDataSetTableAdapters.RequestsTableAdapter requestsTableAdapter;
        private System.Windows.Forms.BindingNavigator requestsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton requestsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView requestsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;



    }
}