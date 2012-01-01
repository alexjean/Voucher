namespace VoucherExpense
{
    partial class FormInitNewYear
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
            this.basicDataSet1 = new VoucherExpense.BasicDataSet();
            this.veDataSet1 = new VoucherExpense.VEDataSet();
            this.chListBoxBasic = new System.Windows.Forms.CheckedListBox();
            this.chListBoxVE = new System.Windows.Forms.CheckedListBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.basicHeaderAdapter = new VoucherExpense.BasicDataSetTableAdapters.HeaderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // basicDataSet1
            // 
            this.basicDataSet1.DataSetName = "BasicDataSet";
            this.basicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // veDataSet1
            // 
            this.veDataSet1.DataSetName = "VEDataSet";
            this.veDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chListBoxBasic
            // 
            this.chListBoxBasic.FormattingEnabled = true;
            this.chListBoxBasic.Location = new System.Drawing.Point(49, 160);
            this.chListBoxBasic.Name = "chListBoxBasic";
            this.chListBoxBasic.Size = new System.Drawing.Size(216, 356);
            this.chListBoxBasic.TabIndex = 1;
            this.chListBoxBasic.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chListBoxVE_ItemCheck);
            // 
            // chListBoxVE
            // 
            this.chListBoxVE.FormattingEnabled = true;
            this.chListBoxVE.Location = new System.Drawing.Point(318, 160);
            this.chListBoxVE.Name = "chListBoxVE";
            this.chListBoxVE.Size = new System.Drawing.Size(216, 356);
            this.chListBoxVE.TabIndex = 2;
            this.chListBoxVE.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chListBoxVE_ItemCheck);
            // 
            // labelYear
            // 
            this.labelYear.Location = new System.Drawing.Point(46, 28);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(488, 25);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "Year";
            // 
            // labelNote
            // 
            this.labelNote.Location = new System.Drawing.Point(46, 55);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(488, 25);
            this.labelNote.TabIndex = 4;
            this.labelNote.Text = "Note";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(46, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "打勾的資料表將被保留,其餘的清空";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(46, 82);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(810, 25);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Path";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(642, 206);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(90, 69);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "開始行動";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Location = new System.Drawing.Point(554, 326);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(273, 25);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // basicHeaderAdapter
            // 
            this.basicHeaderAdapter.ClearBeforeFill = true;
            // 
            // FormInitNewYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(868, 528);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.chListBoxVE);
            this.Controls.Add(this.chListBoxBasic);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInitNewYear";
            this.Text = "起始新年度";
            this.Load += new System.EventHandler(this.FormInitNewYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basicDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BasicDataSet basicDataSet1;
        private VEDataSet veDataSet1;
        private System.Windows.Forms.CheckedListBox chListBoxBasic;
        private System.Windows.Forms.CheckedListBox chListBoxVE;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label labelMessage;
        private BasicDataSetTableAdapters.HeaderTableAdapter basicHeaderAdapter;
    }
}