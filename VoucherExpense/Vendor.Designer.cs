namespace VoucherExpense
{
    partial class Vendor
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
            System.Windows.Forms.Label vendorIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label contactPeopleLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label gSMLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label hideLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vendor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vendorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.vendorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.vendorDataGridView = new System.Windows.Forms.DataGridView();
            this.columnVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HideBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vendorIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.contactPeopleTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.gSMTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.hideCheckBox = new System.Windows.Forms.CheckBox();
            this.vendorTableAdapter = new VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            vendorIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            contactPeopleLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            gSMLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            hideLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingNavigator)).BeginInit();
            this.vendorBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // vendorIDLabel
            // 
            vendorIDLabel.AutoSize = true;
            vendorIDLabel.Location = new System.Drawing.Point(610, 76);
            vendorIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            vendorIDLabel.Name = "vendorIDLabel";
            vendorIDLabel.Size = new System.Drawing.Size(44, 16);
            vendorIDLabel.TabIndex = 2;
            vendorIDLabel.Text = "內碼:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(610, 113);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(44, 16);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "簡稱:";
            // 
            // contactPeopleLabel
            // 
            contactPeopleLabel.AutoSize = true;
            contactPeopleLabel.Location = new System.Drawing.Point(610, 185);
            contactPeopleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            contactPeopleLabel.Name = "contactPeopleLabel";
            contactPeopleLabel.Size = new System.Drawing.Size(60, 16);
            contactPeopleLabel.TabIndex = 6;
            contactPeopleLabel.Text = "連絡人:";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(610, 222);
            telephoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(44, 16);
            telephoneLabel.TabIndex = 8;
            telephoneLabel.Text = "電話:";
            // 
            // gSMLabel
            // 
            gSMLabel.AutoSize = true;
            gSMLabel.Location = new System.Drawing.Point(610, 259);
            gSMLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            gSMLabel.Name = "gSMLabel";
            gSMLabel.Size = new System.Drawing.Size(44, 16);
            gSMLabel.TabIndex = 10;
            gSMLabel.Text = "手機:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(610, 297);
            addressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(44, 16);
            addressLabel.TabIndex = 12;
            addressLabel.Text = "地址:";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(610, 334);
            noteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(44, 16);
            noteLabel.TabIndex = 14;
            noteLabel.Text = "註記:";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(610, 433);
            lastUpdatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(56, 16);
            lastUpdatedLabel.TabIndex = 16;
            lastUpdatedLabel.Text = "更新日";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(610, 149);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(44, 16);
            fullNameLabel.TabIndex = 18;
            fullNameLabel.Text = "全名:";
            // 
            // hideLabel
            // 
            hideLabel.AutoSize = true;
            hideLabel.Location = new System.Drawing.Point(612, 399);
            hideLabel.Name = "hideLabel";
            hideLabel.Size = new System.Drawing.Size(44, 16);
            hideLabel.TabIndex = 20;
            hideLabel.Text = "隱藏:";
            // 
            // vendorBindingNavigator
            // 
            this.vendorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.vendorBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.vendorBindingNavigator.BindingSource = this.vendorBindingSource;
            this.vendorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.vendorBindingNavigator.DeleteItem = null;
            this.vendorBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.vendorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.vendorBindingNavigatorSaveItem});
            this.vendorBindingNavigator.Location = new System.Drawing.Point(607, 1);
            this.vendorBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.vendorBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.vendorBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.vendorBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.vendorBindingNavigator.Name = "vendorBindingNavigator";
            this.vendorBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.vendorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.vendorBindingNavigator.Size = new System.Drawing.Size(276, 27);
            this.vendorBindingNavigator.TabIndex = 0;
            this.vendorBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataMember = "Vendor";
            this.vendorBindingSource.DataSource = this.vEDataSet;
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 24);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // vendorBindingNavigatorSaveItem
            // 
            this.vendorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vendorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("vendorBindingNavigatorSaveItem.Image")));
            this.vendorBindingNavigatorSaveItem.Name = "vendorBindingNavigatorSaveItem";
            this.vendorBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.vendorBindingNavigatorSaveItem.Text = "儲存資料";
            this.vendorBindingNavigatorSaveItem.Click += new System.EventHandler(this.vendorBindingNavigatorSaveItem_Click);
            // 
            // vendorDataGridView
            // 
            this.vendorDataGridView.AllowUserToAddRows = false;
            this.vendorDataGridView.AllowUserToDeleteRows = false;
            this.vendorDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.vendorDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.vendorDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.vendorDataGridView.AutoGenerateColumns = false;
            this.vendorDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vendorDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.vendorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnVendorID,
            this.dataGridViewTextBoxColumn2,
            this.ContactPeople,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.HideBox});
            this.vendorDataGridView.DataSource = this.vendorBindingSource;
            this.vendorDataGridView.EnableHeadersVisualStyles = false;
            this.vendorDataGridView.Location = new System.Drawing.Point(0, 1);
            this.vendorDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.vendorDataGridView.Name = "vendorDataGridView";
            this.vendorDataGridView.ReadOnly = true;
            this.vendorDataGridView.RowTemplate.Height = 24;
            this.vendorDataGridView.Size = new System.Drawing.Size(572, 522);
            this.vendorDataGridView.TabIndex = 1;
            this.vendorDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.vendorDataGridView_CellBeginEdit);
            // 
            // columnVendorID
            // 
            this.columnVendorID.DataPropertyName = "VendorID";
            this.columnVendorID.HeaderText = "內碼";
            this.columnVendorID.Name = "columnVendorID";
            this.columnVendorID.ReadOnly = true;
            this.columnVendorID.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "簡稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // ContactPeople
            // 
            this.ContactPeople.DataPropertyName = "ContactPeople";
            this.ContactPeople.HeaderText = "連絡人";
            this.ContactPeople.Name = "ContactPeople";
            this.ContactPeople.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn4.HeaderText = "電話";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GSM";
            this.dataGridViewTextBoxColumn5.HeaderText = "手機";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // HideBox
            // 
            this.HideBox.DataPropertyName = "Hide";
            this.HideBox.HeaderText = "隱";
            this.HideBox.Name = "HideBox";
            this.HideBox.ReadOnly = true;
            this.HideBox.Width = 25;
            // 
            // vendorIDTextBox
            // 
            this.vendorIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.vendorIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vendorIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "VendorID", true));
            this.vendorIDTextBox.Location = new System.Drawing.Point(676, 76);
            this.vendorIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.vendorIDTextBox.Name = "vendorIDTextBox";
            this.vendorIDTextBox.ReadOnly = true;
            this.vendorIDTextBox.Size = new System.Drawing.Size(32, 20);
            this.vendorIDTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(676, 110);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(213, 27);
            this.nameTextBox.TabIndex = 5;
            // 
            // contactPeopleTextBox
            // 
            this.contactPeopleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "ContactPeople", true));
            this.contactPeopleTextBox.Location = new System.Drawing.Point(676, 182);
            this.contactPeopleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contactPeopleTextBox.Name = "contactPeopleTextBox";
            this.contactPeopleTextBox.Size = new System.Drawing.Size(213, 27);
            this.contactPeopleTextBox.TabIndex = 7;
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "Telephone", true));
            this.telephoneTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.telephoneTextBox.Location = new System.Drawing.Point(676, 219);
            this.telephoneTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(213, 27);
            this.telephoneTextBox.TabIndex = 9;
            // 
            // gSMTextBox
            // 
            this.gSMTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "GSM", true));
            this.gSMTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.gSMTextBox.Location = new System.Drawing.Point(676, 256);
            this.gSMTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.gSMTextBox.Name = "gSMTextBox";
            this.gSMTextBox.Size = new System.Drawing.Size(213, 27);
            this.gSMTextBox.TabIndex = 11;
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(676, 294);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(213, 27);
            this.addressTextBox.TabIndex = 13;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(676, 331);
            this.noteTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(213, 58);
            this.noteTextBox.TabIndex = 15;
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "FullName", true));
            this.fullNameTextBox.Location = new System.Drawing.Point(676, 146);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(213, 27);
            this.fullNameTextBox.TabIndex = 19;
            // 
            // hideCheckBox
            // 
            this.hideCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.vendorBindingSource, "Hide", true));
            this.hideCheckBox.Location = new System.Drawing.Point(676, 396);
            this.hideCheckBox.Name = "hideCheckBox";
            this.hideCheckBox.Size = new System.Drawing.Size(104, 24);
            this.hideCheckBox.TabIndex = 21;
            // 
            // vendorTableAdapter
            // 
            this.vendorTableAdapter.ClearBeforeFill = true;
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vendorBindingSource, "LastUpdated", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "g"));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(676, 433);
            this.lastUpdatedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(213, 20);
            this.lastUpdatedTextBox.TabIndex = 17;
            // 
            // Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(920, 523);
            this.Controls.Add(hideLabel);
            this.Controls.Add(this.hideCheckBox);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(this.fullNameTextBox);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(vendorIDLabel);
            this.Controls.Add(this.vendorIDTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(contactPeopleLabel);
            this.Controls.Add(this.contactPeopleTextBox);
            this.Controls.Add(telephoneLabel);
            this.Controls.Add(this.telephoneTextBox);
            this.Controls.Add(gSMLabel);
            this.Controls.Add(this.gSMTextBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(noteLabel);
            this.Controls.Add(this.noteTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.vendorDataGridView);
            this.Controls.Add(this.vendorBindingNavigator);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Vendor";
            this.Text = "供應商";
            this.Load += new System.EventHandler(this.Vendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingNavigator)).EndInit();
            this.vendorBindingNavigator.ResumeLayout(false);
            this.vendorBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private VoucherExpense.VEDataSetTableAdapters.VendorTableAdapter vendorTableAdapter;
        private System.Windows.Forms.BindingNavigator vendorBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton vendorBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView vendorDataGridView;
        private System.Windows.Forms.TextBox vendorIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox contactPeopleTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.TextBox gSMTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.CheckBox hideCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HideBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;

    }
}