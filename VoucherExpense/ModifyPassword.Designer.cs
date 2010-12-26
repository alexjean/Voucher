namespace VoucherExpense
{
    partial class ModifyPassword
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
            System.Windows.Forms.Label oldPassLabel;
            System.Windows.Forms.Label newPassLabel;
            System.Windows.Forms.Label comfirmPassLabel;
            this.oldPassTextBox = new System.Windows.Forms.TextBox();
            this.newPassTextBox = new System.Windows.Forms.TextBox();
            this.comfirmPassTextBox = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.veDataSet1 = new VoucherExpense.VEDataSet();
            this.operatorTableAdapter1 = new VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter();
            oldPassLabel = new System.Windows.Forms.Label();
            newPassLabel = new System.Windows.Forms.Label();
            comfirmPassLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // oldPassLabel
            // 
            oldPassLabel.AutoSize = true;
            oldPassLabel.Location = new System.Drawing.Point(68, 62);
            oldPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            oldPassLabel.Name = "oldPassLabel";
            oldPassLabel.Size = new System.Drawing.Size(60, 16);
            oldPassLabel.TabIndex = 25;
            oldPassLabel.Text = "舊密碼:";
            // 
            // newPassLabel
            // 
            newPassLabel.AutoSize = true;
            newPassLabel.Location = new System.Drawing.Point(68, 99);
            newPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            newPassLabel.Name = "newPassLabel";
            newPassLabel.Size = new System.Drawing.Size(60, 16);
            newPassLabel.TabIndex = 27;
            newPassLabel.Text = "新密碼:";
            // 
            // comfirmPassLabel
            // 
            comfirmPassLabel.AutoSize = true;
            comfirmPassLabel.Location = new System.Drawing.Point(68, 136);
            comfirmPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            comfirmPassLabel.Name = "comfirmPassLabel";
            comfirmPassLabel.Size = new System.Drawing.Size(44, 16);
            comfirmPassLabel.TabIndex = 29;
            comfirmPassLabel.Text = "確認:";
            // 
            // oldPassTextBox
            // 
            this.oldPassTextBox.Location = new System.Drawing.Point(152, 57);
            this.oldPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.oldPassTextBox.Name = "oldPassTextBox";
            this.oldPassTextBox.PasswordChar = '*';
            this.oldPassTextBox.Size = new System.Drawing.Size(191, 27);
            this.oldPassTextBox.TabIndex = 26;
            // 
            // newPassTextBox
            // 
            this.newPassTextBox.Location = new System.Drawing.Point(152, 94);
            this.newPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.newPassTextBox.Name = "newPassTextBox";
            this.newPassTextBox.PasswordChar = '*';
            this.newPassTextBox.Size = new System.Drawing.Size(191, 27);
            this.newPassTextBox.TabIndex = 28;
            // 
            // comfirmPassTextBox
            // 
            this.comfirmPassTextBox.Location = new System.Drawing.Point(152, 131);
            this.comfirmPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.comfirmPassTextBox.Name = "comfirmPassTextBox";
            this.comfirmPassTextBox.PasswordChar = '*';
            this.comfirmPassTextBox.Size = new System.Drawing.Size(191, 27);
            this.comfirmPassTextBox.TabIndex = 30;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AutoSize = true;
            this.btnChangePassword.Location = new System.Drawing.Point(71, 202);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 26);
            this.btnChangePassword.TabIndex = 31;
            this.btnChangePassword.Text = "更換";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(268, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // veDataSet1
            // 
            this.veDataSet1.DataSetName = "VEDataSet";
            this.veDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorTableAdapter1
            // 
            this.operatorTableAdapter1.ClearBeforeFill = true;
            // 
            // ModifyPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(406, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.comfirmPassTextBox);
            this.Controls.Add(comfirmPassLabel);
            this.Controls.Add(this.newPassTextBox);
            this.Controls.Add(newPassLabel);
            this.Controls.Add(this.oldPassTextBox);
            this.Controls.Add(oldPassLabel);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModifyPassword";
            this.Text = "修改密碼";
            this.Load += new System.EventHandler(this.ModifyPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.veDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldPassTextBox;
        private System.Windows.Forms.TextBox newPassTextBox;
        private System.Windows.Forms.TextBox comfirmPassTextBox;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCancel;
        private VEDataSet veDataSet1;
        private VoucherExpense.VEDataSetTableAdapters.OperatorTableAdapter operatorTableAdapter1;


    }
}