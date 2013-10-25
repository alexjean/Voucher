namespace VoucherExpense
{
    partial class FormSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupplier));
            System.Windows.Forms.Label supplierIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label contactPeopleLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label gSMLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label hideLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            this.sQLVEDataSet = new VoucherExpense.SQLVEDataSet();
            this.supplier_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplier_TableAdapter = new VoucherExpense.SQLVEDataSetTableAdapters.Supplier_TableAdapter();
            this.tableAdapterManager = new VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager();
            this.supplier_BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.supplier_BindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.supplier_DataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supplierIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.contactPeopleTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.gSMTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.hideCheckBox = new System.Windows.Forms.CheckBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            supplierIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            contactPeopleLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            gSMLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            hideLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_BindingNavigator)).BeginInit();
            this.supplier_BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sQLVEDataSet
            // 
            this.sQLVEDataSet.DataSetName = "SQLVEDataSet";
            this.sQLVEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supplier_BindingSource
            // 
            this.supplier_BindingSource.DataMember = "Supplier ";
            this.supplier_BindingSource.DataSource = this.sQLVEDataSet;
            // 
            // supplier_TableAdapter
            // 
            this.supplier_TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.InventoryDetailTableAdapter = null;
            this.tableAdapterManager.InventoryProductsTableAdapter = null;
            this.tableAdapterManager.InventoryTableAdapter = null;
            this.tableAdapterManager.ProductScrappedDetailTableAdapter = null;
            this.tableAdapterManager.ProductScrappedTableAdapter = null;
            this.tableAdapterManager.Supplier_TableAdapter = this.supplier_TableAdapter;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.SQLVEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // supplier_BindingNavigator
            // 
            this.supplier_BindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.supplier_BindingNavigator.BindingSource = this.supplier_BindingSource;
            this.supplier_BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.supplier_BindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.supplier_BindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.supplier_BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigatorDeleteItem,
            this.supplier_BindingNavigatorSaveItem});
            this.supplier_BindingNavigator.Location = new System.Drawing.Point(605, 6);
            this.supplier_BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.supplier_BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.supplier_BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.supplier_BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.supplier_BindingNavigator.Name = "supplier_BindingNavigator";
            this.supplier_BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.supplier_BindingNavigator.Size = new System.Drawing.Size(275, 25);
            this.supplier_BindingNavigator.TabIndex = 0;
            this.supplier_BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
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
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 17);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // supplier_BindingNavigatorSaveItem
            // 
            this.supplier_BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.supplier_BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("supplier_BindingNavigatorSaveItem.Image")));
            this.supplier_BindingNavigatorSaveItem.Name = "supplier_BindingNavigatorSaveItem";
            this.supplier_BindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.supplier_BindingNavigatorSaveItem.Text = "保存数据";
            this.supplier_BindingNavigatorSaveItem.Click += new System.EventHandler(this.supplier_BindingNavigatorSaveItem_Click);
            // 
            // supplier_DataGridView
            // 
            this.supplier_DataGridView.AutoGenerateColumns = false;
            this.supplier_DataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            this.supplier_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplier_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewCheckBoxColumn1});
            this.supplier_DataGridView.DataSource = this.supplier_BindingSource;
            this.supplier_DataGridView.Location = new System.Drawing.Point(-2, 1);
            this.supplier_DataGridView.Name = "supplier_DataGridView";
            this.supplier_DataGridView.RowTemplate.Height = 23;
            this.supplier_DataGridView.Size = new System.Drawing.Size(572, 522);
            this.supplier_DataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SupplierID";
            this.dataGridViewTextBoxColumn1.HeaderText = "内码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "简称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ContactPeople";
            this.dataGridViewTextBoxColumn3.HeaderText = "联络人";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn4.HeaderText = "电话";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GSM";
            this.dataGridViewTextBoxColumn5.HeaderText = "手机";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn6.HeaderText = "Address";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn7.HeaderText = "Note";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LastUpdated";
            this.dataGridViewTextBoxColumn8.HeaderText = "LastUpdated";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn9.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Hide";
            this.dataGridViewCheckBoxColumn1.FillWeight = 50F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "隐";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // supplierIDLabel
            // 
            supplierIDLabel.AutoSize = true;
            supplierIDLabel.Location = new System.Drawing.Point(610, 76);
            supplierIDLabel.Name = "supplierIDLabel";
            supplierIDLabel.Size = new System.Drawing.Size(44, 16);
            supplierIDLabel.TabIndex = 2;
            supplierIDLabel.Text = "内码:";
            // 
            // supplierIDTextBox
            // 
            this.supplierIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.supplierIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "SupplierID", true));
            this.supplierIDTextBox.Location = new System.Drawing.Point(675, 76);
            this.supplierIDTextBox.Name = "supplierIDTextBox";
            this.supplierIDTextBox.Size = new System.Drawing.Size(66, 20);
            this.supplierIDTextBox.TabIndex = 3;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(610, 115);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(44, 16);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "简称:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(675, 112);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(233, 27);
            this.nameTextBox.TabIndex = 5;
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(610, 158);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(44, 16);
            fullNameLabel.TabIndex = 6;
            fullNameLabel.Text = "全名:";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "FullName", true));
            this.fullNameTextBox.Location = new System.Drawing.Point(675, 156);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(233, 27);
            this.fullNameTextBox.TabIndex = 7;
            // 
            // contactPeopleLabel
            // 
            contactPeopleLabel.AutoSize = true;
            contactPeopleLabel.Location = new System.Drawing.Point(610, 202);
            contactPeopleLabel.Name = "contactPeopleLabel";
            contactPeopleLabel.Size = new System.Drawing.Size(60, 16);
            contactPeopleLabel.TabIndex = 8;
            contactPeopleLabel.Text = "联络人:";
            // 
            // contactPeopleTextBox
            // 
            this.contactPeopleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "ContactPeople", true));
            this.contactPeopleTextBox.Location = new System.Drawing.Point(675, 198);
            this.contactPeopleTextBox.Name = "contactPeopleTextBox";
            this.contactPeopleTextBox.Size = new System.Drawing.Size(233, 27);
            this.contactPeopleTextBox.TabIndex = 9;
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(610, 243);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(44, 16);
            telephoneLabel.TabIndex = 10;
            telephoneLabel.Text = "电话:";
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "Telephone", true));
            this.telephoneTextBox.Location = new System.Drawing.Point(675, 238);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(233, 27);
            this.telephoneTextBox.TabIndex = 11;
            // 
            // gSMLabel
            // 
            gSMLabel.AutoSize = true;
            gSMLabel.Location = new System.Drawing.Point(610, 275);
            gSMLabel.Name = "gSMLabel";
            gSMLabel.Size = new System.Drawing.Size(44, 16);
            gSMLabel.TabIndex = 12;
            gSMLabel.Text = "手机:";
            // 
            // gSMTextBox
            // 
            this.gSMTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "GSM", true));
            this.gSMTextBox.Location = new System.Drawing.Point(675, 271);
            this.gSMTextBox.Name = "gSMTextBox";
            this.gSMTextBox.Size = new System.Drawing.Size(233, 27);
            this.gSMTextBox.TabIndex = 13;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(610, 309);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(44, 16);
            addressLabel.TabIndex = 14;
            addressLabel.Text = "地址:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(675, 307);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(233, 27);
            this.addressTextBox.TabIndex = 15;
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(610, 345);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(44, 16);
            noteLabel.TabIndex = 16;
            noteLabel.Text = "注记:";
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(675, 347);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(233, 61);
            this.noteTextBox.TabIndex = 17;
            // 
            // hideLabel
            // 
            hideLabel.AutoSize = true;
            hideLabel.Location = new System.Drawing.Point(610, 414);
            hideLabel.Name = "hideLabel";
            hideLabel.Size = new System.Drawing.Size(44, 16);
            hideLabel.TabIndex = 18;
            hideLabel.Text = "隐藏:";
            // 
            // hideCheckBox
            // 
            this.hideCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.supplier_BindingSource, "Hide", true));
            this.hideCheckBox.Location = new System.Drawing.Point(675, 413);
            this.hideCheckBox.Name = "hideCheckBox";
            this.hideCheckBox.Size = new System.Drawing.Size(24, 24);
            this.hideCheckBox.TabIndex = 19;
            this.hideCheckBox.UseVisualStyleBackColor = true;
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(610, 462);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(56, 16);
            lastUpdatedLabel.TabIndex = 20;
            lastUpdatedLabel.Text = "更新日";
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplier_BindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(675, 456);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(231, 20);
            this.lastUpdatedTextBox.TabIndex = 23;
            // 
            // FormSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(950, 525);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(hideLabel);
            this.Controls.Add(this.hideCheckBox);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(gSMLabel);
            this.Controls.Add(this.gSMTextBox);
            this.Controls.Add(telephoneLabel);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(contactPeopleLabel);
            this.Controls.Add(this.contactPeopleTextBox);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(supplierIDLabel);
            this.Controls.Add(this.supplierIDTextBox);
            this.Controls.Add(this.supplier_DataGridView);
            this.Controls.Add(this.supplier_BindingNavigator);
            this.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSupplier";
            this.Text = "客户";
            this.Load += new System.EventHandler(this.FormSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sQLVEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_BindingNavigator)).EndInit();
            this.supplier_BindingNavigator.ResumeLayout(false);
            this.supplier_BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplier_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SQLVEDataSet sQLVEDataSet;
        private System.Windows.Forms.BindingSource supplier_BindingSource;
        private SQLVEDataSetTableAdapters.Supplier_TableAdapter supplier_TableAdapter;
        private SQLVEDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator supplier_BindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton supplier_BindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView supplier_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TextBox supplierIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox contactPeopleTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox gSMTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.CheckBox hideCheckBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
    }
}