namespace VoucherExpense
{
    partial class FormSoldIngredients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ckBoxUse12 = new System.Windows.Forms.CheckBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.ckBoxWholeMonth = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBoxTo = new System.Windows.Forms.ComboBox();
            this.cbBoxFrom = new System.Windows.Forms.ComboBox();
            this.cbBoxMonth = new System.Windows.Forms.ComboBox();
            this.dgViewSale = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basicDataSet = new VoucherExpense.BasicDataSet();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnPrintSmall = new System.Windows.Forms.Button();
            this.cbBoxTable = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelMessage = new System.Windows.Forms.Label();
            this.productTableAdapter = new VoucherExpense.BasicDataSetTableAdapters.ProductTableAdapter();
            this.codeColumnSale = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSaleItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSaleItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ckBoxUse12
            // 
            this.ckBoxUse12.AutoSize = true;
            this.ckBoxUse12.Checked = true;
            this.ckBoxUse12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBoxUse12.Location = new System.Drawing.Point(54, 167);
            this.ckBoxUse12.Margin = new System.Windows.Forms.Padding(4);
            this.ckBoxUse12.Name = "ckBoxUse12";
            this.ckBoxUse12.Size = new System.Drawing.Size(75, 20);
            this.ckBoxUse12.TabIndex = 17;
            this.ckBoxUse12.Text = "0_24時";
            this.ckBoxUse12.UseVisualStyleBackColor = true;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(54, 208);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 16;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // ckBoxWholeMonth
            // 
            this.ckBoxWholeMonth.AutoSize = true;
            this.ckBoxWholeMonth.Location = new System.Drawing.Point(54, 130);
            this.ckBoxWholeMonth.Margin = new System.Windows.Forms.Padding(4);
            this.ckBoxWholeMonth.Name = "ckBoxWholeMonth";
            this.ckBoxWholeMonth.Size = new System.Drawing.Size(59, 20);
            this.ckBoxWholeMonth.TabIndex = 15;
            this.ckBoxWholeMonth.Text = "全月";
            this.ckBoxWholeMonth.UseVisualStyleBackColor = true;
            this.ckBoxWholeMonth.CheckedChanged += new System.EventHandler(this.ckBoxWholeMonth_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "自";
            // 
            // cbBoxTo
            // 
            this.cbBoxTo.FormattingEnabled = true;
            this.cbBoxTo.Location = new System.Drawing.Point(54, 98);
            this.cbBoxTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxTo.Name = "cbBoxTo";
            this.cbBoxTo.Size = new System.Drawing.Size(75, 24);
            this.cbBoxTo.TabIndex = 12;
            this.cbBoxTo.SelectedIndexChanged += new System.EventHandler(this.cbBoxTo_SelectedIndexChanged);
            // 
            // cbBoxFrom
            // 
            this.cbBoxFrom.FormattingEnabled = true;
            this.cbBoxFrom.Location = new System.Drawing.Point(54, 66);
            this.cbBoxFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxFrom.Name = "cbBoxFrom";
            this.cbBoxFrom.Size = new System.Drawing.Size(75, 24);
            this.cbBoxFrom.TabIndex = 11;
            this.cbBoxFrom.SelectedIndexChanged += new System.EventHandler(this.cbBoxFrom_SelectedIndexChanged);
            // 
            // cbBoxMonth
            // 
            this.cbBoxMonth.FormattingEnabled = true;
            this.cbBoxMonth.Location = new System.Drawing.Point(54, 34);
            this.cbBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbBoxMonth.Name = "cbBoxMonth";
            this.cbBoxMonth.Size = new System.Drawing.Size(75, 24);
            this.cbBoxMonth.TabIndex = 10;
            this.cbBoxMonth.SelectedIndexChanged += new System.EventHandler(this.cbBoxMonth_SelectedIndexChanged);
            // 
            // dgViewSale
            // 
            this.dgViewSale.AllowUserToResizeRows = false;
            this.dgViewSale.AutoGenerateColumns = false;
            this.dgViewSale.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgViewSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumnSale,
            this.volumeDataGridViewTextBoxColumn,
            this.Unit,
            this.Price,
            this.Total});
            this.dgViewSale.DataSource = this.cSaleItemBindingSource;
            this.dgViewSale.Location = new System.Drawing.Point(160, 34);
            this.dgViewSale.Name = "dgViewSale";
            this.dgViewSale.RowHeadersWidth = 25;
            this.dgViewSale.RowTemplate.Height = 24;
            this.dgViewSale.Size = new System.Drawing.Size(437, 544);
            this.dgViewSale.TabIndex = 18;
            this.dgViewSale.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgViewSale_DataError);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.basicDataSet;
            // 
            // basicDataSet
            // 
            this.basicDataSet.DataSetName = "BasicDataSet";
            this.basicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(663, 476);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 23);
            this.btnImport.TabIndex = 75;
            this.btnImport.Text = "匯入設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(663, 435);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 23);
            this.btnExport.TabIndex = 74;
            this.btnExport.Text = "匯出設定";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(663, 390);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 73;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(663, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(665, 168);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(56, 16);
            this.labelName.TabIndex = 71;
            this.labelName.Text = "存檔名";
            this.labelName.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(663, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(663, 98);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "編修";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(663, 204);
            this.textBoxName.MaxLength = 10;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 27);
            this.textBoxName.TabIndex = 70;
            this.textBoxName.Visible = false;
            // 
            // btnPrintSmall
            // 
            this.btnPrintSmall.Location = new System.Drawing.Point(54, 380);
            this.btnPrintSmall.Name = "btnPrintSmall";
            this.btnPrintSmall.Size = new System.Drawing.Size(85, 23);
            this.btnPrintSmall.TabIndex = 76;
            this.btnPrintSmall.Text = "列印小表";
            this.btnPrintSmall.UseVisualStyleBackColor = true;
            this.btnPrintSmall.Click += new System.EventHandler(this.btnPrintSmall_Click);
            // 
            // cbBoxTable
            // 
            this.cbBoxTable.FormattingEnabled = true;
            this.cbBoxTable.Location = new System.Drawing.Point(663, 34);
            this.cbBoxTable.Name = "cbBoxTable";
            this.cbBoxTable.Size = new System.Drawing.Size(94, 24);
            this.cbBoxTable.TabIndex = 77;
            this.cbBoxTable.SelectedIndexChanged += new System.EventHandler(this.cbBoxTable_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(160, 15);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(437, 13);
            this.progressBar1.TabIndex = 78;
            this.progressBar1.Visible = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(51, 254);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(94, 20);
            this.labelMessage.TabIndex = 79;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // codeColumnSale
            // 
            this.codeColumnSale.DataPropertyName = "Code";
            this.codeColumnSale.DataSource = this.productBindingSource;
            this.codeColumnSale.DisplayMember = "Name";
            this.codeColumnSale.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.codeColumnSale.HeaderText = "菜名";
            this.codeColumnSale.MaxDropDownItems = 24;
            this.codeColumnSale.Name = "codeColumnSale";
            this.codeColumnSale.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codeColumnSale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.codeColumnSale.ValueMember = "Code";
            this.codeColumnSale.Width = 160;
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
            // cSaleItemBindingSource
            // 
            this.cSaleItemBindingSource.DataSource = typeof(VoucherExpense.CSaleItem);
            // 
            // FormSoldIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(824, 601);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cbBoxTable);
            this.Controls.Add(this.btnPrintSmall);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dgViewSale);
            this.Controls.Add(this.ckBoxUse12);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.ckBoxWholeMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBoxTo);
            this.Controls.Add(this.cbBoxFrom);
            this.Controls.Add(this.cbBoxMonth);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSoldIngredients";
            this.Text = "銷售物料統計";
            this.Load += new System.EventHandler(this.FormSoldIngredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSaleItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckBoxUse12;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.CheckBox ckBoxWholeMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxTo;
        private System.Windows.Forms.ComboBox cbBoxFrom;
        private System.Windows.Forms.ComboBox cbBoxMonth;
        private System.Windows.Forms.BindingSource cSaleItemBindingSource;
        private System.Windows.Forms.DataGridView dgViewSale;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnPrintSmall;
        private BasicDataSet basicDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private VoucherExpense.BasicDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn codeColumnSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ComboBox cbBoxTable;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelMessage;
    }
}