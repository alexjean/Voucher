namespace VoucherExpense
{
    partial class FormScraps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScraps));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.vEDataSet = new VoucherExpense.VEDataSet();
            this.productScrappedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ProductScrappedTableAdapter();
            this.productScrappedBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.productScrappedBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dgvProductScrapped = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productScrappedDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productScrappedDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ProductScrappedDetailTableAdapter();
            this.dgvScrappedDetail = new System.Windows.Forms.DataGridView();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.chBoxHide = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).BeginInit();
            this.productScrappedBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(531, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 27);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "報癈日期";
            // 
            // vEDataSet
            // 
            this.vEDataSet.DataSetName = "VEDataSet";
            this.vEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productScrappedBindingSource
            // 
            this.productScrappedBindingSource.DataMember = "ProductScrapped";
            this.productScrappedBindingSource.DataSource = this.vEDataSet;
            // 
            // productScrappedTableAdapter
            // 
            this.productScrappedTableAdapter.ClearBeforeFill = true;
            // 
            // productScrappedBindingNavigator
            // 
            this.productScrappedBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.productScrappedBindingNavigator.BindingSource = this.productScrappedBindingSource;
            this.productScrappedBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.productScrappedBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.productScrappedBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.productScrappedBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.productScrappedBindingNavigatorSaveItem});
            this.productScrappedBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.productScrappedBindingNavigator.MoveFirstItem = null;
            this.productScrappedBindingNavigator.MoveLastItem = null;
            this.productScrappedBindingNavigator.MoveNextItem = null;
            this.productScrappedBindingNavigator.MovePreviousItem = null;
            this.productScrappedBindingNavigator.Name = "productScrappedBindingNavigator";
            this.productScrappedBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.productScrappedBindingNavigator.Size = new System.Drawing.Size(174, 25);
            this.productScrappedBindingNavigator.TabIndex = 2;
            this.productScrappedBindingNavigator.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // productScrappedBindingNavigatorSaveItem
            // 
            this.productScrappedBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.productScrappedBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("productScrappedBindingNavigatorSaveItem.Image")));
            this.productScrappedBindingNavigatorSaveItem.Name = "productScrappedBindingNavigatorSaveItem";
            this.productScrappedBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.productScrappedBindingNavigatorSaveItem.Text = "儲存資料";
            this.productScrappedBindingNavigatorSaveItem.Click += new System.EventHandler(this.productScrappedBindingNavigatorSaveItem_Click);
            // 
            // dgvProductScrapped
            // 
            this.dgvProductScrapped.AllowUserToAddRows = false;
            this.dgvProductScrapped.AllowUserToDeleteRows = false;
            this.dgvProductScrapped.AutoGenerateColumns = false;
            this.dgvProductScrapped.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvProductScrapped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductScrapped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn3});
            this.dgvProductScrapped.DataSource = this.productScrappedBindingSource;
            this.dgvProductScrapped.Location = new System.Drawing.Point(0, 28);
            this.dgvProductScrapped.Name = "dgvProductScrapped";
            this.dgvProductScrapped.RowHeadersWidth = 24;
            this.dgvProductScrapped.RowTemplate.Height = 24;
            this.dgvProductScrapped.Size = new System.Drawing.Size(434, 742);
            this.dgvProductScrapped.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductScrappedID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ProductScrappedID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ScrappedDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "報癈日";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SoldValue";
            this.dataGridViewTextBoxColumn4.HeaderText = "價值";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 64;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "IngredientsCost";
            this.dataGridViewTextBoxColumn5.HeaderText = "成本";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 64;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Reason";
            this.dataGridViewTextBoxColumn6.HeaderText = "原因";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 64;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "EvaluatedDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "估值日";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Locked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "核";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 32;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LastUpdated";
            this.dataGridViewTextBoxColumn7.HeaderText = "更新";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KeyinID";
            this.dataGridViewTextBoxColumn3.HeaderText = "輸入";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // productScrappedDetailBindingSource
            // 
            this.productScrappedDetailBindingSource.DataMember = "ProductScrappedProductScrappedDetail";
            this.productScrappedDetailBindingSource.DataSource = this.productScrappedBindingSource;
            // 
            // productScrappedDetailTableAdapter
            // 
            this.productScrappedDetailTableAdapter.ClearBeforeFill = true;
            // 
            // dgvScrappedDetail
            // 
            this.dgvScrappedDetail.AutoGenerateColumns = false;
            this.dgvScrappedDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.dgvScrappedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScrappedDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvScrappedDetail.DataSource = this.productScrappedDetailBindingSource;
            this.dgvScrappedDetail.Location = new System.Drawing.Point(440, 85);
            this.dgvScrappedDetail.Name = "dgvScrappedDetail";
            this.dgvScrappedDetail.RowHeadersWidth = 24;
            this.dgvScrappedDetail.RowTemplate.Height = 24;
            this.dgvScrappedDetail.Size = new System.Drawing.Size(511, 685);
            this.dgvScrappedDetail.TabIndex = 4;
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Location = new System.Drawing.Point(679, 7);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(92, 29);
            this.btnEvaluate.TabIndex = 71;
            this.btnEvaluate.Text = "重估此單";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            // 
            // chBoxHide
            // 
            this.chBoxHide.AutoSize = true;
            this.chBoxHide.Checked = true;
            this.chBoxHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxHide.Location = new System.Drawing.Point(777, 12);
            this.chBoxHide.Name = "chBoxHide";
            this.chBoxHide.Size = new System.Drawing.Size(123, 20);
            this.chBoxHide.TabIndex = 74;
            this.chBoxHide.Text = "隱藏無資料行";
            this.chBoxHide.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ProdcutScrappedID";
            this.dataGridViewTextBoxColumn10.HeaderText = "ProdcutScrappedID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn11.HeaderText = "產品";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 144;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Volume";
            this.dataGridViewTextBoxColumn12.HeaderText = "量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn13.HeaderText = "價格";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "EvaluatedCost";
            this.dataGridViewTextBoxColumn14.HeaderText = "成本";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // FormScraps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(953, 771);
            this.Controls.Add(this.chBoxHide);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.dgvScrappedDetail);
            this.Controls.Add(this.dgvProductScrapped);
            this.Controls.Add(this.productScrappedBindingNavigator);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormScraps";
            this.Text = "報癈 試吃 登記表";
            this.Load += new System.EventHandler(this.FormScraps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedBindingNavigator)).EndInit();
            this.productScrappedBindingNavigator.ResumeLayout(false);
            this.productScrappedBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductScrapped)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productScrappedDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrappedDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private VEDataSet vEDataSet;
        private System.Windows.Forms.BindingSource productScrappedBindingSource;
        private VEDataSetTableAdapters.ProductScrappedTableAdapter productScrappedTableAdapter;
        private System.Windows.Forms.BindingNavigator productScrappedBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton productScrappedBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dgvProductScrapped;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource productScrappedDetailBindingSource;
        private VEDataSetTableAdapters.ProductScrappedDetailTableAdapter productScrappedDetailTableAdapter;
        private System.Windows.Forms.DataGridView dgvScrappedDetail;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.CheckBox chBoxHide;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}