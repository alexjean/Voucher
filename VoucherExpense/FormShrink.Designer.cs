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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.formShrink_TimeDataDataGridView = new System.Windows.Forms.DataGridView();
            this.formShrink_TimeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientsAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerScrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shrink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerShrink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formShrink_TimeDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // formShrink_TimeDataDataGridView
            // 
            this.formShrink_TimeDataDataGridView.AllowUserToAddRows = false;
            this.formShrink_TimeDataDataGridView.AllowUserToDeleteRows = false;
            this.formShrink_TimeDataDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.formShrink_TimeDataDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.formShrink_TimeDataDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formShrink_TimeDataDataGridView.AutoGenerateColumns = false;
            this.formShrink_TimeDataDataGridView.BackgroundColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.formShrink_TimeDataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.formShrink_TimeDataDataGridView.ColumnHeadersHeight = 25;
            this.formShrink_TimeDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.IngredientsBefore,
            this.IngredientsAfter,
            this.ProductBefore,
            this.ProductAfter,
            this.Stock,
            this.Spent,
            this.Scrap,
            this.PerScrap,
            this.Sold,
            this.PerSold,
            this.Shrink,
            this.PerShrink});
            this.formShrink_TimeDataDataGridView.DataSource = this.formShrink_TimeDataBindingSource;
            this.formShrink_TimeDataDataGridView.Location = new System.Drawing.Point(0, 34);
            this.formShrink_TimeDataDataGridView.MultiSelect = false;
            this.formShrink_TimeDataDataGridView.Name = "formShrink_TimeDataDataGridView";
            this.formShrink_TimeDataDataGridView.ReadOnly = true;
            this.formShrink_TimeDataDataGridView.RowHeadersVisible = false;
            this.formShrink_TimeDataDataGridView.RowTemplate.Height = 23;
            this.formShrink_TimeDataDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.formShrink_TimeDataDataGridView.Size = new System.Drawing.Size(962, 695);
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
            this.progressBar1.Size = new System.Drawing.Size(963, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TimeStr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "盘点时间段";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // IngredientsBefore
            // 
            this.IngredientsBefore.DataPropertyName = "IngredientsBefore";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.IngredientsBefore.DefaultCellStyle = dataGridViewCellStyle4;
            this.IngredientsBefore.HeaderText = "食材前库存";
            this.IngredientsBefore.Name = "IngredientsBefore";
            this.IngredientsBefore.ReadOnly = true;
            this.IngredientsBefore.Visible = false;
            // 
            // IngredientsAfter
            // 
            this.IngredientsAfter.DataPropertyName = "IngredientsAfter";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            this.IngredientsAfter.DefaultCellStyle = dataGridViewCellStyle5;
            this.IngredientsAfter.HeaderText = "食材库存";
            this.IngredientsAfter.Name = "IngredientsAfter";
            this.IngredientsAfter.ReadOnly = true;
            // 
            // ProductBefore
            // 
            this.ProductBefore.DataPropertyName = "ProductBefore";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            this.ProductBefore.DefaultCellStyle = dataGridViewCellStyle6;
            this.ProductBefore.HeaderText = "产品前库存";
            this.ProductBefore.Name = "ProductBefore";
            this.ProductBefore.ReadOnly = true;
            this.ProductBefore.Visible = false;
            // 
            // ProductAfter
            // 
            this.ProductAfter.DataPropertyName = "ProductAfter";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N1";
            this.ProductAfter.DefaultCellStyle = dataGridViewCellStyle7;
            this.ProductAfter.HeaderText = "产品库存";
            this.ProductAfter.Name = "ProductAfter";
            this.ProductAfter.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N1";
            this.Stock.DefaultCellStyle = dataGridViewCellStyle8;
            this.Stock.HeaderText = "进货";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Spent
            // 
            this.Spent.DataPropertyName = "Spent";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N1";
            this.Spent.DefaultCellStyle = dataGridViewCellStyle9;
            this.Spent.HeaderText = "總耗用";
            this.Spent.Name = "Spent";
            this.Spent.ReadOnly = true;
            // 
            // Scrap
            // 
            this.Scrap.DataPropertyName = "Scrap";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N1";
            this.Scrap.DefaultCellStyle = dataGridViewCellStyle10;
            this.Scrap.HeaderText = "报废试吃";
            this.Scrap.Name = "Scrap";
            this.Scrap.ReadOnly = true;
            this.Scrap.Width = 80;
            // 
            // PerScrap
            // 
            this.PerScrap.DataPropertyName = "PerScrap";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N1";
            dataGridViewCellStyle11.NullValue = null;
            this.PerScrap.DefaultCellStyle = dataGridViewCellStyle11;
            this.PerScrap.HeaderText = "%";
            this.PerScrap.Name = "PerScrap";
            this.PerScrap.ReadOnly = true;
            this.PerScrap.Width = 60;
            // 
            // Sold
            // 
            this.Sold.DataPropertyName = "Sold";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N1";
            this.Sold.DefaultCellStyle = dataGridViewCellStyle12;
            this.Sold.HeaderText = "售出成本";
            this.Sold.Name = "Sold";
            this.Sold.ReadOnly = true;
            this.Sold.Width = 80;
            // 
            // PerSold
            // 
            this.PerSold.DataPropertyName = "PerSold";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N1";
            dataGridViewCellStyle13.NullValue = null;
            this.PerSold.DefaultCellStyle = dataGridViewCellStyle13;
            this.PerSold.HeaderText = "%";
            this.PerSold.Name = "PerSold";
            this.PerSold.ReadOnly = true;
            this.PerSold.Width = 60;
            // 
            // Shrink
            // 
            this.Shrink.DataPropertyName = "Shrink";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N1";
            this.Shrink.DefaultCellStyle = dataGridViewCellStyle14;
            this.Shrink.HeaderText = "未知损耗";
            this.Shrink.Name = "Shrink";
            this.Shrink.ReadOnly = true;
            this.Shrink.Width = 80;
            // 
            // PerShrink
            // 
            this.PerShrink.DataPropertyName = "PerShrink";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N1";
            this.PerShrink.DefaultCellStyle = dataGridViewCellStyle15;
            this.PerShrink.HeaderText = "%";
            this.PerShrink.Name = "PerShrink";
            this.PerShrink.ReadOnly = true;
            this.PerShrink.Width = 60;
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(212, 9);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(440, 22);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "双擊時間段開始計算";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormShrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(964, 729);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.formShrink_TimeDataDataGridView);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Spent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerScrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shrink;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerShrink;
        private System.Windows.Forms.Label labelMessage;



    }
}