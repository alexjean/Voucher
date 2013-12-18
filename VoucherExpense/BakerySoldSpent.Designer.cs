namespace VoucherExpense
{
    partial class BakerySoldSpent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bakeryOrderSet = new VoucherExpense.BakeryOrderSet();
            this.cbBoxTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dgViewSale = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSaleItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgViewStock = new System.Windows.Forms.DataGridView();
            this.stockItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelStockTotal = new System.Windows.Forms.Label();
            this.labelSaleTotal = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.volumeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSaleItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.bakeryOrderSet;
            this.productBindingSource.Filter = "Class <> 0";
            this.productBindingSource.Sort = "";
            // 
            // bakeryOrderSet
            // 
            this.bakeryOrderSet.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbBoxTable
            // 
            this.cbBoxTable.FormattingEnabled = true;
            this.cbBoxTable.Location = new System.Drawing.Point(471, 15);
            this.cbBoxTable.Name = "cbBoxTable";
            this.cbBoxTable.Size = new System.Drawing.Size(94, 24);
            this.cbBoxTable.TabIndex = 1;
            this.cbBoxTable.SelectedIndexChanged += new System.EventHandler(this.cbBoxTable_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "銷貨";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "進貨";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(407, 570);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "編修";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(537, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(395, 568);
            this.textBoxName.MaxLength = 10;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 27);
            this.textBoxName.TabIndex = 7;
            this.textBoxName.Visible = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(322, 573);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(56, 16);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "存檔名";
            this.labelName.Visible = false;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "",
            "一月",
            "二月",
            "三月",
            "四月",
            "五月",
            "六月",
            "七月",
            "八月",
            "九月",
            "十月",
            "十一月",
            "十二月"});
            this.comboBoxMonth.Location = new System.Drawing.Point(36, 15);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(91, 24);
            this.comboBoxMonth.TabIndex = 60;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // dgViewSale
            // 
            this.dgViewSale.AllowUserToResizeRows = false;
            this.dgViewSale.AutoGenerateColumns = false;
            this.dgViewSale.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgViewSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.volumeDataGridViewTextBoxColumn,
            this.Unit,
            this.Price,
            this.Total});
            this.dgViewSale.DataSource = this.cSaleItemBindingSource;
            this.dgViewSale.Location = new System.Drawing.Point(12, 54);
            this.dgViewSale.Name = "dgViewSale";
            this.dgViewSale.RowHeadersWidth = 25;
            this.dgViewSale.RowTemplate.Height = 24;
            this.dgViewSale.Size = new System.Drawing.Size(437, 501);
            this.dgViewSale.TabIndex = 0;
            this.dgViewSale.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgViewSale_DataError);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProductID";
            this.Column1.DataSource = this.productBindingSource;
            this.Column1.DisplayMember = "Name";
            this.Column1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column1.HeaderText = "產品";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.ValueMember = "ProductID";
            this.Column1.Width = 160;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.volumeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.volumeDataGridViewTextBoxColumn.HeaderText = "量";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 56;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Unit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Unit.HeaderText = "";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 32;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "價";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 48;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "總計";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 92;
            // 
            // cSaleItemBindingSource
            // 
            this.cSaleItemBindingSource.AllowNew = true;
            this.cSaleItemBindingSource.DataSource = typeof(VoucherExpense.CSaleItem);
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataMember = "Ingredient";
            this.ingredientBindingSource.DataSource = this.vEDataSet;
            this.ingredientBindingSource.Filter = "CanPurchase";
            // 
            // dgViewStock
            // 
            this.dgViewStock.AllowUserToResizeRows = false;
            this.dgViewStock.AutoGenerateColumns = false;
            this.dgViewStock.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.volumeDataGridViewTextBoxColumn1,
            this.idUnit,
            this.UnitCost,
            this.TotalCost});
            this.dgViewStock.DataSource = this.stockItemBindingSource;
            this.dgViewStock.Location = new System.Drawing.Point(446, 54);
            this.dgViewStock.Name = "dgViewStock";
            this.dgViewStock.RowHeadersWidth = 25;
            this.dgViewStock.RowTemplate.Height = 24;
            this.dgViewStock.Size = new System.Drawing.Size(443, 501);
            this.dgViewStock.TabIndex = 2;
            this.dgViewStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgViewStock_DataError);
            // 
            // stockItemBindingSource
            // 
            this.stockItemBindingSource.DataSource = typeof(VoucherExpense.CStockItem);
            // 
            // labelStockTotal
            // 
            this.labelStockTotal.Location = new System.Drawing.Point(791, 17);
            this.labelStockTotal.Name = "labelStockTotal";
            this.labelStockTotal.Size = new System.Drawing.Size(79, 20);
            this.labelStockTotal.TabIndex = 61;
            this.labelStockTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSaleTotal
            // 
            this.labelSaleTotal.Location = new System.Drawing.Point(341, 17);
            this.labelSaleTotal.Name = "labelSaleTotal";
            this.labelSaleTotal.Size = new System.Drawing.Size(79, 20);
            this.labelSaleTotal.TabIndex = 62;
            this.labelSaleTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPercent
            // 
            this.labelPercent.Location = new System.Drawing.Point(572, 15);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(62, 24);
            this.labelPercent.TabIndex = 63;
            this.labelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(671, 570);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 64;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(795, 570);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 65;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(36, 570);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 23);
            this.btnExport.TabIndex = 66;
            this.btnExport.Text = "匯出設定";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(154, 570);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 23);
            this.btnImport.TabIndex = 67;
            this.btnImport.Text = "匯入設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IngredientID";
            this.Column2.DataSource = this.ingredientBindingSource;
            this.Column2.DisplayMember = "Name";
            this.Column2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column2.HeaderText = "食材";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.ValueMember = "IngredientID";
            this.Column2.Width = 160;
            // 
            // volumeDataGridViewTextBoxColumn1
            // 
            this.volumeDataGridViewTextBoxColumn1.DataPropertyName = "Volume";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.volumeDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.volumeDataGridViewTextBoxColumn1.HeaderText = "數量";
            this.volumeDataGridViewTextBoxColumn1.Name = "volumeDataGridViewTextBoxColumn1";
            this.volumeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn1.Width = 64;
            // 
            // idUnit
            // 
            this.idUnit.DataPropertyName = "IngredientID";
            this.idUnit.DataSource = this.ingredientBindingSource;
            this.idUnit.DisplayMember = "Unit";
            this.idUnit.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.idUnit.HeaderText = "";
            this.idUnit.Name = "idUnit";
            this.idUnit.ReadOnly = true;
            this.idUnit.ValueMember = "IngredientID";
            this.idUnit.Width = 32;
            // 
            // UnitCost
            // 
            this.UnitCost.DataPropertyName = "UnitCost";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            this.UnitCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.UnitCost.HeaderText = "單價";
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.ReadOnly = true;
            this.UnitCost.Width = 64;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalCost.HeaderText = "總計";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.Width = 80;
            // 
            // BakerySoldSpent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(901, 607);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.labelSaleTotal);
            this.Controls.Add(this.labelStockTotal);
            this.Controls.Add(this.dgViewStock);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBoxTable);
            this.Controls.Add(this.dgViewSale);
            this.Controls.Add(this.textBoxName);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BakerySoldSpent";
            this.Text = "烘焙銷貨進貨並列";
            this.Load += new System.EventHandler(this.SaleSpendRatio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSaleItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBoxTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private BakeryOrderSet bakeryOrderSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.DataGridView dgViewSale;
        private System.Windows.Forms.BindingSource cSaleItemBindingSource;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private System.Windows.Forms.BindingSource stockItemBindingSource;
        private System.Windows.Forms.DataGridView dgViewStock;
        private System.Windows.Forms.Label labelStockTotal;
        private System.Windows.Forms.Label labelSaleTotal;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn idUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
    }
}