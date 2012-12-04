namespace VoucherExpense
{
    partial class FormShiftDetail
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
            this.checkedListBoxEmployee = new System.Windows.Forms.CheckedListBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.panelBase = new System.Windows.Forms.Panel();
            this.listBoxHelp = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.shiftDetailTableAdapter = new VoucherExpense.VEDataSetTableAdapters.ShiftDetailTableAdapter();
            this.panelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxEmployee
            // 
            this.checkedListBoxEmployee.FormattingEnabled = true;
            this.checkedListBoxEmployee.Location = new System.Drawing.Point(2, 41);
            this.checkedListBoxEmployee.Name = "checkedListBoxEmployee";
            this.checkedListBoxEmployee.Size = new System.Drawing.Size(147, 488);
            this.checkedListBoxEmployee.TabIndex = 0;
            this.checkedListBoxEmployee.DoubleClick += new System.EventHandler(this.checkedListBoxEmployee_DoubleClick);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(12, 9);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(59, 20);
            this.checkBoxAll.TabIndex = 1;
            this.checkBoxAll.Text = "全部";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(112, 5);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(37, 27);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = ">>";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // panelBase
            // 
            this.panelBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBase.AutoScroll = true;
            this.panelBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBase.Controls.Add(this.listBoxHelp);
            this.panelBase.Location = new System.Drawing.Point(155, 5);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(765, 599);
            this.panelBase.TabIndex = 4;
            // 
            // listBoxHelp
            // 
            this.listBoxHelp.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxHelp.FormattingEnabled = true;
            this.listBoxHelp.ItemHeight = 19;
            this.listBoxHelp.Items.AddRange(new object[] {
            "",
            "  請選擇要排班的員工(打勾)",
            "",
            "  按 >>  按鈕至右方排班表",
            "",
            "  双擊左方姓名加入",
            "",
            "  双擊右方姓名移除",
            "",
            "  排班表上粉紅底為周日",
            "",
            "  請輸入代号",
            "",
            "  輸入數字代表小時數",
            "  ",
            "   "});
            this.listBoxHelp.Location = new System.Drawing.Point(47, 44);
            this.listBoxHelp.Name = "listBoxHelp";
            this.listBoxHelp.Size = new System.Drawing.Size(284, 308);
            this.listBoxHelp.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 29);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(2, 575);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(61, 29);
            this.btnLeave.TabIndex = 6;
            this.btnLeave.Text = "離開";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Location = new System.Drawing.Point(88, 535);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 29);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(2, 535);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 29);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // shiftDetailTableAdapter
            // 
            this.shiftDetailTableAdapter.ClearBeforeFill = true;
            // 
            // FormShiftDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(921, 605);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.checkedListBoxEmployee);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShiftDetail";
            this.ShowIcon = false;
            this.Text = "編修值班表";
            this.Load += new System.EventHandler(this.FormShiftDetail_Load);
            this.panelBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxEmployee;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.ListBox listBoxHelp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPrint;
        private VEDataSetTableAdapters.ShiftDetailTableAdapter shiftDetailTableAdapter;
    }
}