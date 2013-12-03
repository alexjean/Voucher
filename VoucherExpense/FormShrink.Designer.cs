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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.formShrink_TimeDataDataGridView = new System.Windows.Forms.DataGridView();
            this.formShrink_TimeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.InventoryTimeBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryTimeAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataBindingSource)).BeginInit();
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
            this.Sold,
            this.Shink});
            this.formShrink_TimeDataDataGridView.DataSource = this.formShrink_TimeDataBindingSource;
            this.formShrink_TimeDataDataGridView.Location = new System.Drawing.Point(-1, 3);
            this.formShrink_TimeDataDataGridView.Name = "formShrink_TimeDataDataGridView";
            this.formShrink_TimeDataDataGridView.RowHeadersVisible = false;
            this.formShrink_TimeDataDataGridView.RowTemplate.Height = 23;
            this.formShrink_TimeDataDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formShrink_TimeDataDataGridView.Size = new System.Drawing.Size(1197, 722);
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
            this.progressBar1.Size = new System.Drawing.Size(1197, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "盘点时间段";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
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
            // Sold
            // 
            this.Sold.DataPropertyName = "Sold";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.Sold.DefaultCellStyle = dataGridViewCellStyle9;
            this.Sold.HeaderText = "售出成本";
            this.Sold.Name = "Sold";
            // 
            // Shink
            // 
            this.Shink.DataPropertyName = "Shink";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.Shink.DefaultCellStyle = dataGridViewCellStyle10;
            this.Shink.HeaderText = "未知损耗";
            this.Shink.Name = "Shink";
            this.Shink.ReadOnly = true;
            // 
            // FormShrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1198, 729);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.formShrink_TimeDataDataGridView);
            this.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShrink";
            this.Text = "未知損耗估計表";
            this.Load += new System.EventHandler(this.FormShrink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource formShrink_TimeDataBindingSource;
        private System.Windows.Forms.DataGridView formShrink_TimeDataDataGridView;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTimeBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTimeAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientsAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shink;



    }
}