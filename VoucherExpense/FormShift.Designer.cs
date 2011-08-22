namespace VoucherExpense
{
    partial class FormShift
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.全勤 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.房補 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.奬金 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.罰金 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownHeight = 216;
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.IntegralHeight = false;
            this.comboBoxMonth.Items.AddRange(new object[] {
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
            this.comboBoxMonth.Location = new System.Drawing.Point(13, 13);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(74, 24);
            this.comboBoxMonth.TabIndex = 55;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // dgvShift
            // 
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.全勤,
            this.房補,
            this.奬金,
            this.罰金,
            this.姓名});
            this.dgvShift.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvShift.Location = new System.Drawing.Point(0, 56);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.RowHeadersVisible = false;
            this.dgvShift.RowTemplate.Height = 24;
            this.dgvShift.Size = new System.Drawing.Size(896, 559);
            this.dgvShift.TabIndex = 56;
            this.dgvShift.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvShift_DataError);
            // 
            // 全勤
            // 
            this.全勤.HeaderText = "全勤";
            this.全勤.Name = "全勤";
            this.全勤.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.全勤.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.全勤.Width = 32;
            // 
            // 房補
            // 
            this.房補.HeaderText = "房補";
            this.房補.Name = "房補";
            this.房補.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.房補.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.房補.Width = 32;
            // 
            // 奬金
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.奬金.DefaultCellStyle = dataGridViewCellStyle5;
            this.奬金.HeaderText = "奬";
            this.奬金.Name = "奬金";
            this.奬金.Width = 64;
            // 
            // 罰金
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.罰金.DefaultCellStyle = dataGridViewCellStyle6;
            this.罰金.HeaderText = "罰";
            this.罰金.Name = "罰金";
            this.罰金.Width = 64;
            // 
            // 姓名
            // 
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.Width = 72;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(896, 615);
            this.Controls.Add(this.dgvShift);
            this.Controls.Add(this.comboBoxMonth);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormShift";
            this.Text = "輪班表";
            this.Load += new System.EventHandler(this.FormShift_Load);
            this.SizeChanged += new System.EventHandler(this.FormShift_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DataGridView dgvShift;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 全勤;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 房補;
        private System.Windows.Forms.DataGridViewTextBoxColumn 奬金;
        private System.Windows.Forms.DataGridViewTextBoxColumn 罰金;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
    }
}