namespace VoucherExpense
{
    partial class EditBakeryProduct
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
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label classLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label menuXLabel;
            System.Windows.Forms.Label menuYLabel;
            System.Windows.Forms.Label unitLabel;
            System.Windows.Forms.Label evaluatedCostLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBakeryProduct));
            this.productIDTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.menuXTextBox = new System.Windows.Forms.TextBox();
            this.menuYTextBox = new System.Windows.Forms.TextBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaluatedCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.儲存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeletetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.productTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.ProductTableAdapter();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.orderItemTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.OrderItemTableAdapter();
            this.orderTableAdapter = new VoucherExpense.BakeryOrderSetTableAdapters.OrderTableAdapter();
            this.tableAdapterManager = new VoucherExpense.BakeryOrderSetTableAdapters.TableAdapterManager();
            this.evaluatedCostTextBox = new System.Windows.Forms.TextBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grossTextBox = new System.Windows.Forms.TextBox();
            this.grossPercentTextBox = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            codeLabel = new System.Windows.Forms.Label();
            classLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            menuXLabel = new System.Windows.Forms.Label();
            menuYLabel = new System.Windows.Forms.Label();
            unitLabel = new System.Windows.Forms.Label();
            evaluatedCostLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new System.Drawing.Point(654, 79);
            codeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(44, 16);
            codeLabel.TabIndex = 3;
            codeLabel.Text = "代碼:";
            // 
            // classLabel
            // 
            classLabel.AutoSize = true;
            classLabel.Location = new System.Drawing.Point(654, 116);
            classLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            classLabel.Name = "classLabel";
            classLabel.Size = new System.Drawing.Size(44, 16);
            classLabel.TabIndex = 5;
            classLabel.Text = "類別:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(654, 153);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(60, 16);
            nameLabel.TabIndex = 7;
            nameLabel.Text = "產品名:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(654, 191);
            priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(44, 16);
            priceLabel.TabIndex = 9;
            priceLabel.Text = "價格:";
            // 
            // menuXLabel
            // 
            menuXLabel.AutoSize = true;
            menuXLabel.Location = new System.Drawing.Point(654, 565);
            menuXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            menuXLabel.Name = "menuXLabel";
            menuXLabel.Size = new System.Drawing.Size(55, 16);
            menuXLabel.TabIndex = 11;
            menuXLabel.Text = "位置X:";
            // 
            // menuYLabel
            // 
            menuYLabel.AutoSize = true;
            menuYLabel.Location = new System.Drawing.Point(654, 602);
            menuYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            menuYLabel.Name = "menuYLabel";
            menuYLabel.Size = new System.Drawing.Size(55, 16);
            menuYLabel.TabIndex = 13;
            menuYLabel.Text = "位置Y:";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new System.Drawing.Point(654, 259);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new System.Drawing.Size(40, 16);
            unitLabel.TabIndex = 19;
            unitLabel.Text = "單位";
            // 
            // evaluatedCostLabel
            // 
            evaluatedCostLabel.AutoSize = true;
            evaluatedCostLabel.Location = new System.Drawing.Point(654, 224);
            evaluatedCostLabel.Name = "evaluatedCostLabel";
            evaluatedCostLabel.Size = new System.Drawing.Size(72, 16);
            evaluatedCostLabel.TabIndex = 20;
            evaluatedCostLabel.Text = "估算成本";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(854, 191);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 16);
            label1.TabIndex = 23;
            label1.Text = "毛利";
            // 
            // productIDTextBox
            // 
            this.productIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.productIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "ProductID", true));
            this.productIDTextBox.Location = new System.Drawing.Point(728, 41);
            this.productIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.productIDTextBox.Name = "productIDTextBox";
            this.productIDTextBox.ReadOnly = true;
            this.productIDTextBox.Size = new System.Drawing.Size(148, 27);
            this.productIDTextBox.TabIndex = 2;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            this.productBindingSource.Filter = "Code>0";
            this.productBindingSource.CurrentChanged += new System.EventHandler(this.productBindingSource_CurrentChanged);
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codeTextBox
            // 
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.codeTextBox.Location = new System.Drawing.Point(728, 77);
            this.codeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(148, 27);
            this.codeTextBox.TabIndex = 4;
            this.codeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.codeTextBox_Validating);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(728, 149);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(148, 27);
            this.nameTextBox.TabIndex = 8;
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Price", true));
            this.priceTextBox.Location = new System.Drawing.Point(728, 185);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(80, 27);
            this.priceTextBox.TabIndex = 10;
            this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.priceTextBox_Validating);
            // 
            // menuXTextBox
            // 
            this.menuXTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "MenuX", true));
            this.menuXTextBox.Enabled = false;
            this.menuXTextBox.Location = new System.Drawing.Point(719, 561);
            this.menuXTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.menuXTextBox.Name = "menuXTextBox";
            this.menuXTextBox.Size = new System.Drawing.Size(148, 27);
            this.menuXTextBox.TabIndex = 12;
            // 
            // menuYTextBox
            // 
            this.menuYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "MenuY", true));
            this.menuYTextBox.Enabled = false;
            this.menuYTextBox.Location = new System.Drawing.Point(719, 598);
            this.menuYTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.menuYTextBox.Name = "menuYTextBox";
            this.menuYTextBox.Size = new System.Drawing.Size(148, 27);
            this.menuYTextBox.TabIndex = 14;
            // 
            // classTextBox
            // 
            this.classTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Class", true));
            this.classTextBox.Location = new System.Drawing.Point(728, 113);
            this.classTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(148, 27);
            this.classTextBox.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProductID,
            this.codeColumn,
            this.classDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.Unit,
            this.EvaluatedCost,
            this.menuXDataGridViewTextBoxColumn,
            this.menuYDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(631, 629);
            this.dataGridView1.TabIndex = 16;
            // 
            // ColumnProductID
            // 
            this.ColumnProductID.DataPropertyName = "ProductID";
            this.ColumnProductID.HeaderText = "內碼 ";
            this.ColumnProductID.Name = "ColumnProductID";
            this.ColumnProductID.ReadOnly = true;
            this.ColumnProductID.Width = 64;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "Code";
            this.codeColumn.HeaderText = "代碼";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 64;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            this.classDataGridViewTextBoxColumn.HeaderText = "類";
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            this.classDataGridViewTextBoxColumn.ReadOnly = true;
            this.classDataGridViewTextBoxColumn.Width = 32;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "品名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 176;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceDataGridViewTextBoxColumn.HeaderText = "價格";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 64;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "單位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 64;
            // 
            // EvaluatedCost
            // 
            this.EvaluatedCost.DataPropertyName = "EvaluatedCost";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.EvaluatedCost.DefaultCellStyle = dataGridViewCellStyle3;
            this.EvaluatedCost.HeaderText = "成本";
            this.EvaluatedCost.Name = "EvaluatedCost";
            this.EvaluatedCost.ReadOnly = true;
            this.EvaluatedCost.Width = 64;
            // 
            // menuXDataGridViewTextBoxColumn
            // 
            this.menuXDataGridViewTextBoxColumn.DataPropertyName = "MenuX";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.menuXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.menuXDataGridViewTextBoxColumn.HeaderText = "X";
            this.menuXDataGridViewTextBoxColumn.Name = "menuXDataGridViewTextBoxColumn";
            this.menuXDataGridViewTextBoxColumn.ReadOnly = true;
            this.menuXDataGridViewTextBoxColumn.Width = 32;
            // 
            // menuYDataGridViewTextBoxColumn
            // 
            this.menuYDataGridViewTextBoxColumn.DataPropertyName = "MenuY";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.menuYDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.menuYDataGridViewTextBoxColumn.HeaderText = "Y";
            this.menuYDataGridViewTextBoxColumn.Name = "menuYDataGridViewTextBoxColumn";
            this.menuYDataGridViewTextBoxColumn.ReadOnly = true;
            this.menuYDataGridViewTextBoxColumn.Width = 32;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BackgroundImage = global::VoucherExpense.Properties.Resources.NavBar_Back;
            this.bindingNavigator.BindingSource = this.productBindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.儲存SToolStripButton,
            this.DeletetoolStripButton});
            this.bindingNavigator.Location = new System.Drawing.Point(631, 0);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(226, 27);
            this.bindingNavigator.TabIndex = 17;
            this.bindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 24);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // 儲存SToolStripButton
            // 
            this.儲存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.儲存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("儲存SToolStripButton.Image")));
            this.儲存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.儲存SToolStripButton.Name = "儲存SToolStripButton";
            this.儲存SToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.儲存SToolStripButton.Text = "儲存(&S)";
            this.儲存SToolStripButton.Click += new System.EventHandler(this.儲存SToolStripButton_Click);
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
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "點菜單n      X 0-3 +n*10  "});
            this.listBox1.Location = new System.Drawing.Point(657, 525);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 16);
            this.listBox1.TabIndex = 18;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // unitTextBox
            // 
            this.unitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Unit", true));
            this.unitTextBox.Location = new System.Drawing.Point(728, 257);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(80, 27);
            this.unitTextBox.TabIndex = 20;
            // 
            // orderItemTableAdapter
            // 
            this.orderItemTableAdapter.ClearBeforeFill = true;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BakeryConfigTableAdapter = null;
            this.tableAdapterManager.CashierTableAdapter = null;
            this.tableAdapterManager.DrawerRecordTableAdapter = null;
            this.tableAdapterManager.HeaderTableAdapter = null;
            this.tableAdapterManager.OrderItemTableAdapter = this.orderItemTableAdapter;
            this.tableAdapterManager.OrderTableAdapter = this.orderTableAdapter;
            this.tableAdapterManager.ProductTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.UpdateOrder = VoucherExpense.BakeryOrderSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // evaluatedCostTextBox
            // 
            this.evaluatedCostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "EvaluatedCost", true));
            this.evaluatedCostTextBox.Location = new System.Drawing.Point(728, 221);
            this.evaluatedCostTextBox.Name = "evaluatedCostTextBox";
            this.evaluatedCostTextBox.Size = new System.Drawing.Size(80, 27);
            this.evaluatedCostTextBox.TabIndex = 21;
            this.evaluatedCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.evaluatedCostTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.evaluatedCostTextBox_Validating);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.Azure;
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoPictureBox.Location = new System.Drawing.Point(657, 311);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(219, 189);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoPictureBox.TabIndex = 22;
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.photoPictureBox_MouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            // 
            // grossTextBox
            // 
            this.grossTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.grossTextBox.Location = new System.Drawing.Point(814, 221);
            this.grossTextBox.Name = "grossTextBox";
            this.grossTextBox.Size = new System.Drawing.Size(80, 27);
            this.grossTextBox.TabIndex = 24;
            this.grossTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grossPercentTextBox
            // 
            this.grossPercentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.grossPercentTextBox.Location = new System.Drawing.Point(814, 256);
            this.grossPercentTextBox.Name = "grossPercentTextBox";
            this.grossPercentTextBox.Size = new System.Drawing.Size(80, 27);
            this.grossPercentTextBox.TabIndex = 25;
            this.grossPercentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(877, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 27);
            this.btnExcel.TabIndex = 26;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // EditBakeryProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(943, 629);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.grossPercentTextBox);
            this.Controls.Add(this.grossTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.photoPictureBox);
            this.Controls.Add(evaluatedCostLabel);
            this.Controls.Add(this.evaluatedCostTextBox);
            this.Controls.Add(unitLabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bindingNavigator);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(this.productIDTextBox);
            this.Controls.Add(codeLabel);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(classLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(menuXLabel);
            this.Controls.Add(this.menuXTextBox);
            this.Controls.Add(menuYLabel);
            this.Controls.Add(this.menuYTextBox);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditBakeryProduct";
            this.Text = "產品表";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private BakeryOrderSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.TextBox productIDTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox menuXTextBox;
        private System.Windows.Forms.TextBox menuYTextBox;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripButton 儲存SToolStripButton;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.ToolStripButton DeletetoolStripButton;
        private BakeryOrderSetTableAdapters.OrderItemTableAdapter orderItemTableAdapter;
        private BakeryOrderSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private BakeryOrderSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox evaluatedCostTextBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvaluatedCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuYDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox grossTextBox;
        private System.Windows.Forms.TextBox grossPercentTextBox;
        private System.Windows.Forms.Button btnExcel;
    }
}