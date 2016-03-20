namespace VoucherExpense
{
    partial class Ingredient
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
            System.Windows.Forms.Label IngredientIDLabel;
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label unitLabel;
            System.Windows.Forms.Label lastUpdatedLabel;
            System.Windows.Forms.Label titleCodeLabel;
            System.Windows.Forms.Label unitWeightLabel;
            System.Windows.Forms.Label vendorIDLabel;
            System.Windows.Forms.Label specsLabel;
            System.Windows.Forms.Label minOrderLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingredient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.IngredientBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.IngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.damaiDataSet = new VoucherExpense.DamaiDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.IngredientBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.DeletetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dgvIngredient = new System.Windows.Forms.DataGridView();
            this.columnIngredientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanPurchase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTitleCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.accountingTitleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientIDTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.lastUpdatedTextBox = new System.Windows.Forms.TextBox();
            this.canPurchaseCheckBox = new System.Windows.Forms.CheckBox();
            this.titleCodeComboBox = new System.Windows.Forms.ComboBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.unitWeightTextBox = new System.Windows.Forms.TextBox();
            this.vendorIDComboBox = new System.Windows.Forms.ComboBox();
            this.cNameIDForComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specsTextBox = new System.Windows.Forms.TextBox();
            this.minOrderTextBox = new System.Windows.Forms.TextBox();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxCostPerGram = new System.Windows.Forms.TextBox();
            IngredientIDLabel = new System.Windows.Forms.Label();
            codeLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            unitLabel = new System.Windows.Forms.Label();
            lastUpdatedLabel = new System.Windows.Forms.Label();
            titleCodeLabel = new System.Windows.Forms.Label();
            unitWeightLabel = new System.Windows.Forms.Label();
            vendorIDLabel = new System.Windows.Forms.Label();
            specsLabel = new System.Windows.Forms.Label();
            minOrderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingNavigator)).BeginInit();
            this.IngredientBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // IngredientIDLabel
            // 
            IngredientIDLabel.AutoSize = true;
            IngredientIDLabel.Location = new System.Drawing.Point(626, 42);
            IngredientIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            IngredientIDLabel.Name = "IngredientIDLabel";
            IngredientIDLabel.Size = new System.Drawing.Size(40, 16);
            IngredientIDLabel.TabIndex = 2;
            IngredientIDLabel.Text = "內碼";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new System.Drawing.Point(626, 79);
            codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(40, 16);
            codeLabel.TabIndex = 4;
            codeLabel.Text = "代号";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(626, 116);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(40, 16);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "品名";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(626, 190);
            priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(56, 16);
            priceLabel.TabIndex = 10;
            priceLabel.Text = "參考價";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new System.Drawing.Point(626, 227);
            unitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new System.Drawing.Size(40, 16);
            unitLabel.TabIndex = 16;
            unitLabel.Text = "單位";
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new System.Drawing.Point(626, 412);
            lastUpdatedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new System.Drawing.Size(56, 16);
            lastUpdatedLabel.TabIndex = 22;
            lastUpdatedLabel.Text = "更新日";
            // 
            // titleCodeLabel
            // 
            titleCodeLabel.AutoSize = true;
            titleCodeLabel.Location = new System.Drawing.Point(626, 301);
            titleCodeLabel.Name = "titleCodeLabel";
            titleCodeLabel.Size = new System.Drawing.Size(40, 16);
            titleCodeLabel.TabIndex = 27;
            titleCodeLabel.Text = "科目";
            // 
            // unitWeightLabel
            // 
            unitWeightLabel.AutoSize = true;
            unitWeightLabel.Location = new System.Drawing.Point(626, 259);
            unitWeightLabel.Name = "unitWeightLabel";
            unitWeightLabel.Size = new System.Drawing.Size(60, 16);
            unitWeightLabel.TabIndex = 47;
            unitWeightLabel.Text = "克/單位";
            // 
            // vendorIDLabel
            // 
            vendorIDLabel.AutoSize = true;
            vendorIDLabel.Location = new System.Drawing.Point(626, 153);
            vendorIDLabel.Name = "vendorIDLabel";
            vendorIDLabel.Size = new System.Drawing.Size(56, 16);
            vendorIDLabel.TabIndex = 48;
            vendorIDLabel.Text = "供貨商";
            // 
            // specsLabel
            // 
            specsLabel.AutoSize = true;
            specsLabel.Location = new System.Drawing.Point(626, 338);
            specsLabel.Name = "specsLabel";
            specsLabel.Size = new System.Drawing.Size(40, 16);
            specsLabel.TabIndex = 49;
            specsLabel.Text = "規格";
            // 
            // minOrderLabel
            // 
            minOrderLabel.AutoSize = true;
            minOrderLabel.Location = new System.Drawing.Point(626, 375);
            minOrderLabel.Name = "minOrderLabel";
            minOrderLabel.Size = new System.Drawing.Size(72, 16);
            minOrderLabel.TabIndex = 50;
            minOrderLabel.Text = "最小起訂";
            // 
            // IngredientBindingNavigator
            // 
            this.IngredientBindingNavigator.AddNewItem = null;
            this.IngredientBindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.IngredientBindingNavigator.BindingSource = this.IngredientBindingSource;
            this.IngredientBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.IngredientBindingNavigator.DeleteItem = null;
            this.IngredientBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.IngredientBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.IngredientBindingNavigatorSaveItem,
            this.DeletetoolStripButton});
            this.IngredientBindingNavigator.Location = new System.Drawing.Point(621, 0);
            this.IngredientBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.IngredientBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.IngredientBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.IngredientBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.IngredientBindingNavigator.Name = "IngredientBindingNavigator";
            this.IngredientBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.IngredientBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.IngredientBindingNavigator.Size = new System.Drawing.Size(285, 27);
            this.IngredientBindingNavigator.TabIndex = 3;
            this.IngredientBindingNavigator.Text = "bindingNavigator1";
            // 
            // IngredientBindingSource
            // 
            this.IngredientBindingSource.DataMember = "Ingredient";
            this.IngredientBindingSource.DataSource = this.damaiDataSet;
            this.IngredientBindingSource.CurrentChanged += new System.EventHandler(this.IngredientBindingSource_CurrentChanged);
            // 
            // damaiDataSet
            // 
            this.damaiDataSet.DataSetName = "DamaiDataSet";
            this.damaiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 24);
            this.bindingNavigatorCountItem.Text = "/{0}";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(64, 27);
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
            // IngredientBindingNavigatorSaveItem
            // 
            this.IngredientBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IngredientBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("IngredientBindingNavigatorSaveItem.Image")));
            this.IngredientBindingNavigatorSaveItem.Name = "IngredientBindingNavigatorSaveItem";
            this.IngredientBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 24);
            this.IngredientBindingNavigatorSaveItem.Text = "儲存資料";
            this.IngredientBindingNavigatorSaveItem.Click += new System.EventHandler(this.IngredientBindingNavigatorSaveItem_Click);
            // 
            // DeletetoolStripButton
            // 
            this.DeletetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletetoolStripButton.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeletetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletetoolStripButton.Image")));
            this.DeletetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletetoolStripButton.Name = "DeletetoolStripButton";
            this.DeletetoolStripButton.Size = new System.Drawing.Size(23, 24);
            this.DeletetoolStripButton.Text = "刪除";
            this.DeletetoolStripButton.Click += new System.EventHandler(this.DeletetoolStripButton_Click);
            // 
            // dgvIngredient
            // 
            this.dgvIngredient.AllowUserToAddRows = false;
            this.dgvIngredient.AllowUserToDeleteRows = false;
            this.dgvIngredient.AllowUserToOrderColumns = true;
            this.dgvIngredient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvIngredient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredient.AutoGenerateColumns = false;
            this.dgvIngredient.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngredient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIngredientID,
            this.CanPurchase,
            this.columnCode,
            this.columnName,
            this.Unit,
            this.columnTitleCode,
            this.columnPrice});
            this.dgvIngredient.DataSource = this.IngredientBindingSource;
            this.dgvIngredient.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvIngredient.EnableHeadersVisualStyles = false;
            this.dgvIngredient.Location = new System.Drawing.Point(0, 0);
            this.dgvIngredient.Margin = new System.Windows.Forms.Padding(4);
            this.dgvIngredient.Name = "dgvIngredient";
            this.dgvIngredient.RowHeadersWidth = 25;
            this.dgvIngredient.RowTemplate.Height = 24;
            this.dgvIngredient.Size = new System.Drawing.Size(617, 702);
            this.dgvIngredient.TabIndex = 2;
            this.dgvIngredient.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.IngredientDataGridView_CellBeginEdit);
            this.dgvIngredient.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.IngredientDataGridView_DataError);
            // 
            // columnIngredientID
            // 
            this.columnIngredientID.DataPropertyName = "IngredientID";
            this.columnIngredientID.HeaderText = "內碼";
            this.columnIngredientID.Name = "columnIngredientID";
            this.columnIngredientID.Width = 50;
            // 
            // CanPurchase
            // 
            this.CanPurchase.DataPropertyName = "CanPurchase";
            this.CanPurchase.HeaderText = "可";
            this.CanPurchase.Name = "CanPurchase";
            this.CanPurchase.Width = 32;
            // 
            // columnCode
            // 
            this.columnCode.DataPropertyName = "Code";
            this.columnCode.HeaderText = "代号";
            this.columnCode.Name = "columnCode";
            this.columnCode.Width = 70;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "品名";
            this.columnName.Name = "columnName";
            this.columnName.Width = 200;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "單位";
            this.Unit.Name = "Unit";
            this.Unit.Width = 55;
            // 
            // columnTitleCode
            // 
            this.columnTitleCode.DataPropertyName = "TitleCode";
            this.columnTitleCode.DataSource = this.accountingTitleBindingSource;
            this.columnTitleCode.DisplayMember = "Name";
            this.columnTitleCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.columnTitleCode.HeaderText = "科目";
            this.columnTitleCode.MaxDropDownItems = 16;
            this.columnTitleCode.Name = "columnTitleCode";
            this.columnTitleCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnTitleCode.ValueMember = "TitleCode";
            // 
            // accountingTitleBindingSource
            // 
            this.accountingTitleBindingSource.DataMember = "AccountingTitle";
            this.accountingTitleBindingSource.DataSource = this.damaiDataSet;
            this.accountingTitleBindingSource.Filter = "TitleCode like \'5*\' ";
            // 
            // columnPrice
            // 
            this.columnPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.columnPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnPrice.HeaderText = "參考";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.Width = 55;
            // 
            // IngredientIDTextBox
            // 
            this.IngredientIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.IngredientIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IngredientIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "IngredientID", true));
            this.IngredientIDTextBox.Location = new System.Drawing.Point(716, 40);
            this.IngredientIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IngredientIDTextBox.Name = "IngredientIDTextBox";
            this.IngredientIDTextBox.ReadOnly = true;
            this.IngredientIDTextBox.Size = new System.Drawing.Size(79, 20);
            this.IngredientIDTextBox.TabIndex = 3;
            // 
            // codeTextBox
            // 
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Code", true));
            this.codeTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.codeTextBox.Location = new System.Drawing.Point(716, 74);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(121, 27);
            this.codeTextBox.TabIndex = 5;
            this.codeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.codeTextBox_Validating);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Name", true));
            this.nameTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameTextBox.Location = new System.Drawing.Point(716, 111);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(201, 27);
            this.nameTextBox.TabIndex = 9;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Price", true));
            this.priceTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.priceTextBox.Location = new System.Drawing.Point(716, 185);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(100, 27);
            this.priceTextBox.TabIndex = 11;
            this.priceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.priceTextBox_Validating);
            this.priceTextBox.Validated += new System.EventHandler(this.priceTextBox_Validated);
            // 
            // unitTextBox
            // 
            this.unitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Unit", true));
            this.unitTextBox.Location = new System.Drawing.Point(716, 222);
            this.unitTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(100, 27);
            this.unitTextBox.TabIndex = 17;
            // 
            // lastUpdatedTextBox
            // 
            this.lastUpdatedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.lastUpdatedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastUpdatedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "LastUpdated", true));
            this.lastUpdatedTextBox.Location = new System.Drawing.Point(716, 410);
            this.lastUpdatedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastUpdatedTextBox.Name = "lastUpdatedTextBox";
            this.lastUpdatedTextBox.ReadOnly = true;
            this.lastUpdatedTextBox.Size = new System.Drawing.Size(184, 20);
            this.lastUpdatedTextBox.TabIndex = 26;
            // 
            // canPurchaseCheckBox
            // 
            this.canPurchaseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.IngredientBindingSource, "CanPurchase", true));
            this.canPurchaseCheckBox.Location = new System.Drawing.Point(812, 38);
            this.canPurchaseCheckBox.Name = "canPurchaseCheckBox";
            this.canPurchaseCheckBox.Size = new System.Drawing.Size(87, 24);
            this.canPurchaseCheckBox.TabIndex = 27;
            this.canPurchaseCheckBox.Text = "能進貨";
            // 
            // titleCodeComboBox
            // 
            this.titleCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.IngredientBindingSource, "TitleCode", true));
            this.titleCodeComboBox.DataSource = this.accountingTitleBindingSource;
            this.titleCodeComboBox.DisplayMember = "Name";
            this.titleCodeComboBox.FormattingEnabled = true;
            this.titleCodeComboBox.Location = new System.Drawing.Point(716, 297);
            this.titleCodeComboBox.MaxDropDownItems = 16;
            this.titleCodeComboBox.Name = "titleCodeComboBox";
            this.titleCodeComboBox.Size = new System.Drawing.Size(100, 24);
            this.titleCodeComboBox.TabIndex = 28;
            this.titleCodeComboBox.ValueMember = "TitleCode";
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoPictureBox.Location = new System.Drawing.Point(659, 437);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(240, 240);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoPictureBox.TabIndex = 47;
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.photoPictureBox_MouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "請選擇本食材的圖片";
            // 
            // unitWeightTextBox
            // 
            this.unitWeightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "UnitWeight", true));
            this.unitWeightTextBox.Location = new System.Drawing.Point(717, 256);
            this.unitWeightTextBox.Name = "unitWeightTextBox";
            this.unitWeightTextBox.Size = new System.Drawing.Size(99, 27);
            this.unitWeightTextBox.TabIndex = 48;
            this.unitWeightTextBox.Validated += new System.EventHandler(this.unitWeightTextBox_Validated);
            // 
            // vendorIDComboBox
            // 
            this.vendorIDComboBox.CausesValidation = false;
            this.vendorIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.IngredientBindingSource, "VendorID", true));
            this.vendorIDComboBox.DataSource = this.cNameIDForComboBoxBindingSource;
            this.vendorIDComboBox.DisplayMember = "Name";
            this.vendorIDComboBox.FormattingEnabled = true;
            this.vendorIDComboBox.Location = new System.Drawing.Point(716, 149);
            this.vendorIDComboBox.Name = "vendorIDComboBox";
            this.vendorIDComboBox.Size = new System.Drawing.Size(100, 24);
            this.vendorIDComboBox.TabIndex = 49;
            this.vendorIDComboBox.ValueMember = "ID";
            // 
            // cNameIDForComboBoxBindingSource
            // 
            this.cNameIDForComboBoxBindingSource.DataSource = typeof(VoucherExpense.CNameIDForComboBox);
            // 
            // specsTextBox
            // 
            this.specsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "Specs", true));
            this.specsTextBox.Location = new System.Drawing.Point(713, 333);
            this.specsTextBox.Name = "specsTextBox";
            this.specsTextBox.Size = new System.Drawing.Size(204, 27);
            this.specsTextBox.TabIndex = 50;
            // 
            // minOrderTextBox
            // 
            this.minOrderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.IngredientBindingSource, "MinOrder", true));
            this.minOrderTextBox.Location = new System.Drawing.Point(713, 370);
            this.minOrderTextBox.Name = "minOrderTextBox";
            this.minOrderTextBox.Size = new System.Drawing.Size(204, 27);
            this.minOrderTextBox.TabIndex = 51;
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataMember = "Vendor";
            this.vendorBindingSource.DataSource = this.damaiDataSet;
            // 
            // textBoxCostPerGram
            // 
            this.textBoxCostPerGram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.textBoxCostPerGram.Location = new System.Drawing.Point(818, 256);
            this.textBoxCostPerGram.Name = "textBoxCostPerGram";
            this.textBoxCostPerGram.Size = new System.Drawing.Size(99, 27);
            this.textBoxCostPerGram.TabIndex = 52;
            // 
            // Ingredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(943, 702);
            this.Controls.Add(this.textBoxCostPerGram);
            this.Controls.Add(minOrderLabel);
            this.Controls.Add(this.minOrderTextBox);
            this.Controls.Add(specsLabel);
            this.Controls.Add(this.specsTextBox);
            this.Controls.Add(vendorIDLabel);
            this.Controls.Add(this.vendorIDComboBox);
            this.Controls.Add(unitWeightLabel);
            this.Controls.Add(this.unitWeightTextBox);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(this.titleCodeComboBox);
            this.Controls.Add(titleCodeLabel);
            this.Controls.Add(this.canPurchaseCheckBox);
            this.Controls.Add(this.lastUpdatedTextBox);
            this.Controls.Add(IngredientIDLabel);
            this.Controls.Add(this.IngredientIDTextBox);
            this.Controls.Add(codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(unitLabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(lastUpdatedLabel);
            this.Controls.Add(this.dgvIngredient);
            this.Controls.Add(this.IngredientBindingNavigator);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ingredient";
            this.ShowIcon = false;
            this.Text = "食材表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ingredient_FormClosing);
            this.Load += new System.EventHandler(this.Ingredient_Load);
            this.Shown += new System.EventHandler(this.Ingredient_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingNavigator)).EndInit();
            this.IngredientBindingNavigator.ResumeLayout(false);
            this.IngredientBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.damaiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingTitleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNameIDForComboBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource IngredientBindingSource;
        private System.Windows.Forms.BindingNavigator IngredientBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton IngredientBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvIngredient;
        private System.Windows.Forms.TextBox IngredientIDTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.TextBox lastUpdatedTextBox;
        private System.Windows.Forms.CheckBox canPurchaseCheckBox;
        private System.Windows.Forms.BindingSource accountingTitleBindingSource;
        private System.Windows.Forms.ComboBox titleCodeComboBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton DeletetoolStripButton;
        private System.Windows.Forms.TextBox unitWeightTextBox;
        private System.Windows.Forms.ComboBox vendorIDComboBox;
        private System.Windows.Forms.TextBox specsTextBox;
        private System.Windows.Forms.TextBox minOrderTextBox;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private System.Windows.Forms.TextBox textBoxCostPerGram;
        private System.Windows.Forms.BindingSource cNameIDForComboBoxBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIngredientID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnTitleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
        private DamaiDataSet damaiDataSet;

    }
}