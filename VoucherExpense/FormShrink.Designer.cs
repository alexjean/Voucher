namespace VoucherExpense
{
    partial class FormShrink
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.formShrink_TimeDataDataGridView = new System.Windows.Forms.DataGridView();
            this.formShrink_TimeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bakeryOrderSet1 = new VoucherExpense.BakeryOrderSet();
            this.InventoryTimeBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryTimeAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerScrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shrink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerShrink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // formShrink_TimeDataDataGridView
            // 
            this.formShrink_TimeDataDataGridView.AutoGenerateColumns = false;
            this.formShrink_TimeDataDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.formShrink_TimeDataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.formShrink_TimeDataDataGridView.ColumnHeadersHeight = 25;
            this.formShrink_TimeDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryTimeBefore,
            this.InventoryTimeAfter,
            this.dataGridViewTextBoxColumn3,
            this.IngredientsBefore,
            this.IngredientsAfter,
            this.ProductBefore,
            this.ProductAfter,
            this.Stock,
            this.Scrap,
            this.PerScrap,
            this.Sold,
            this.PerSold,
            this.Shrink,
            this.PerShrink});
            this.formShrink_TimeDataDataGridView.DataSource = this.formShrink_TimeDataBindingSource;
            this.formShrink_TimeDataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formShrink_TimeDataDataGridView.Location = new System.Drawing.Point(0, 0);
            this.formShrink_TimeDataDataGridView.Name = "formShrink_TimeDataDataGridView";
            this.formShrink_TimeDataDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.formShrink_TimeDataDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.formShrink_TimeDataDataGridView.RowTemplate.Height = 23;
            this.formShrink_TimeDataDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formShrink_TimeDataDataGridView.Size = new System.Drawing.Size(1256, 729);
            this.formShrink_TimeDataDataGridView.TabIndex = 6;
            this.formShrink_TimeDataDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.formShrink_TimeDataDataGridView_CellDoubleClick);
            // 
            // formShrink_TimeDataBindingSource
            // 
            this.formShrink_TimeDataBindingSource.DataSource = typeof(VoucherExpense.FormShrink.TimeData);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(-1, 683);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1255, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // bakeryOrderSet1
            // 
            this.bakeryOrderSet1.DataSetName = "BakeryOrderSet";
            this.bakeryOrderSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InventoryTimeBefore
            // 
            this.InventoryTimeBefore.DataPropertyName = "InventoryTimeBefore";
            this.InventoryTimeBefore.HeaderText = "InventoryTimeBefore";
            this.InventoryTimeBefore.Name = "InventoryTimeBefore";
            this.InventoryTimeBefore.Visible = false;
            // 
            // InventoryTimeAfter
            // 
            this.InventoryTimeAfter.DataPropertyName = "InventoryTimeAfter";
            this.InventoryTimeAfter.HeaderText = "InventoryTimeAfter";
            this.InventoryTimeAfter.Name = "InventoryTimeAfter";
            this.InventoryTimeAfter.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TimeStr";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "盘点时间段";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // IngredientsBefore
            // 
            this.IngredientsBefore.DataPropertyName = "IngredientsBefore";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.IngredientsBefore.DefaultCellStyle = dataGridViewCellStyle3;
            this.IngredientsBefore.HeaderText = "食材前库存";
            this.IngredientsBefore.Name = "IngredientsBefore";
            // 
            // IngredientsAfter
            // 
            this.IngredientsAfter.DataPropertyName = "IngredientsAfter";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.IngredientsAfter.DefaultCellStyle = dataGridViewCellStyle4;
            this.IngredientsAfter.HeaderText = "食材后库存";
            this.IngredientsAfter.Name = "IngredientsAfter";
            // 
            // ProductBefore
            // 
            this.ProductBefore.DataPropertyName = "ProductBefore";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.ProductBefore.DefaultCellStyle = dataGridViewCellStyle5;
            this.ProductBefore.HeaderText = "产品前库存";
            this.ProductBefore.Name = "ProductBefore";
            // 
            // ProductAfter
            // 
            this.ProductAfter.DataPropertyName = "ProductAfter";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.ProductAfter.DefaultCellStyle = dataGridViewCellStyle6;
            this.ProductAfter.HeaderText = "产品后库存";
            this.ProductAfter.Name = "ProductAfter";
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle7;
            this.Stock.HeaderText = "进货";
            this.Stock.Name = "Stock";
            // 
            // Scrap
            // 
            this.Scrap.DataPropertyName = "Scrap";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Scrap.DefaultCellStyle = dataGridViewCellStyle8;
            this.Scrap.HeaderText = "报废试吃";
            this.Scrap.Name = "Scrap";
            // 
            // PerScrap
            // 
            this.PerScrap.DataPropertyName = "PerScrap";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N4";
            dataGridViewCellStyle9.NullValue = null;
            this.PerScrap.DefaultCellStyle = dataGridViewCellStyle9;
            this.PerScrap.HeaderText = "";
            this.PerScrap.Name = "PerScrap";
            this.PerScrap.Width = 80;
            // 
            // Sold
            // 
            this.Sold.DataPropertyName = "Sold";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.Sold.DefaultCellStyle = dataGridViewCellStyle10;
            this.Sold.HeaderText = "售出成本";
            this.Sold.Name = "Sold";
            // 
            // PerSold
            // 
            this.PerSold.DataPropertyName = "PerSold";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N4";
            dataGridViewCellStyle11.NullValue = null;
            this.PerSold.DefaultCellStyle = dataGridViewCellStyle11;
            this.PerSold.HeaderText = "";
            this.PerSold.Name = "PerSold";
            this.PerSold.Width = 80;
            // 
            // Shrink
            // 
            this.Shrink.DataPropertyName = "Shrink";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.Shrink.DefaultCellStyle = dataGridViewCellStyle12;
            this.Shrink.HeaderText = "未知损耗";
            this.Shrink.Name = "Shrink";
            this.Shrink.ReadOnly = true;
            // 
            // PerShrink
            // 
            this.PerShrink.DataPropertyName = "PerShrink";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N4";
            this.PerShrink.DefaultCellStyle = dataGridViewCellStyle13;
            this.PerShrink.HeaderText = "";
            this.PerShrink.Name = "PerShrink";
            this.PerShrink.Width = 80;
            // 
            // FormShrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1256, 729);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.formShrink_TimeDataDataGridView);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShrink";
            this.Text = "未知損耗估計表";
            this.Load += new System.EventHandler(this.FormShrink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bakeryOrderSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource formShrink_TimeDataBindingSource;
        private System.Windows.Forms.DataGridView formShrink_TimeDataDataGridView;
        private System.Windows.Forms.ProgressBar progressBar1;
        private BakeryOrderSet bakeryOrderSet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTimeBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTimeAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shrink;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerShrink;



    }
}