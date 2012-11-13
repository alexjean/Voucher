namespace BakeryOrder
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
            this.cashierTableAdapter = new BakeryOrder.BakeryOrderSetTableAdapters.CashierTableAdapter();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNumber9 = new System.Windows.Forms.Button();
            this.btnNumber8 = new System.Windows.Forms.Button();
            this.btnNumber7 = new System.Windows.Forms.Button();
            this.btnNumber6 = new System.Windows.Forms.Button();
            this.btnNumber5 = new System.Windows.Forms.Button();
            this.btnNumber4 = new System.Windows.Forms.Button();
            this.btnNumber3 = new System.Windows.Forms.Button();
            this.btnNumber2 = new System.Windows.Forms.Button();
            this.btnNumber1 = new System.Windows.Forms.Button();
            this.btnNumber0 = new System.Windows.Forms.Button();
            oldPassLabel = new System.Windows.Forms.Label();
            newPassLabel = new System.Windows.Forms.Label();
            comfirmPassLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oldPassLabel
            // 
            oldPassLabel.AutoSize = true;
            oldPassLabel.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            oldPassLabel.Location = new System.Drawing.Point(40, 64);
            oldPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            oldPassLabel.Name = "oldPassLabel";
            oldPassLabel.Size = new System.Drawing.Size(122, 29);
            oldPassLabel.TabIndex = 25;
            oldPassLabel.Text = "舊密碼:";
            // 
            // newPassLabel
            // 
            newPassLabel.AutoSize = true;
            newPassLabel.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            newPassLabel.Location = new System.Drawing.Point(40, 154);
            newPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            newPassLabel.Name = "newPassLabel";
            newPassLabel.Size = new System.Drawing.Size(122, 29);
            newPassLabel.TabIndex = 27;
            newPassLabel.Text = "新密碼:";
            // 
            // comfirmPassLabel
            // 
            comfirmPassLabel.AutoSize = true;
            comfirmPassLabel.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            comfirmPassLabel.Location = new System.Drawing.Point(40, 244);
            comfirmPassLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            comfirmPassLabel.Name = "comfirmPassLabel";
            comfirmPassLabel.Size = new System.Drawing.Size(91, 29);
            comfirmPassLabel.TabIndex = 29;
            comfirmPassLabel.Text = "確認:";
            // 
            // oldPassTextBox
            // 
            this.oldPassTextBox.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.oldPassTextBox.Location = new System.Drawing.Point(170, 57);
            this.oldPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.oldPassTextBox.MaxLength = 6;
            this.oldPassTextBox.Name = "oldPassTextBox";
            this.oldPassTextBox.PasswordChar = '*';
            this.oldPassTextBox.Size = new System.Drawing.Size(126, 42);
            this.oldPassTextBox.TabIndex = 26;
            this.oldPassTextBox.Enter += new System.EventHandler(this.oldPassTextBox_Enter);
            // 
            // newPassTextBox
            // 
            this.newPassTextBox.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.newPassTextBox.Location = new System.Drawing.Point(170, 147);
            this.newPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.newPassTextBox.MaxLength = 6;
            this.newPassTextBox.Name = "newPassTextBox";
            this.newPassTextBox.PasswordChar = '*';
            this.newPassTextBox.Size = new System.Drawing.Size(126, 42);
            this.newPassTextBox.TabIndex = 28;
            this.newPassTextBox.Enter += new System.EventHandler(this.newPassTextBox_Enter);
            // 
            // comfirmPassTextBox
            // 
            this.comfirmPassTextBox.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comfirmPassTextBox.Location = new System.Drawing.Point(170, 237);
            this.comfirmPassTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.comfirmPassTextBox.MaxLength = 6;
            this.comfirmPassTextBox.Name = "comfirmPassTextBox";
            this.comfirmPassTextBox.PasswordChar = '*';
            this.comfirmPassTextBox.Size = new System.Drawing.Size(126, 42);
            this.comfirmPassTextBox.TabIndex = 30;
            this.comfirmPassTextBox.Enter += new System.EventHandler(this.comfirmPassTextBox_Enter);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AutoSize = true;
            this.btnChangePassword.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChangePassword.Location = new System.Drawing.Point(170, 327);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(126, 74);
            this.btnChangePassword.TabIndex = 31;
            this.btnChangePassword.Text = "更換";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // cashierTableAdapter
            // 
            this.cashierTableAdapter.ClearBeforeFill = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(567, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 74);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(461, 327);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 74);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNumber9
            // 
            this.btnNumber9.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber9.Location = new System.Drawing.Point(567, 237);
            this.btnNumber9.Name = "btnNumber9";
            this.btnNumber9.Size = new System.Drawing.Size(90, 74);
            this.btnNumber9.TabIndex = 40;
            this.btnNumber9.Text = "9";
            this.btnNumber9.UseVisualStyleBackColor = true;
            // 
            // btnNumber8
            // 
            this.btnNumber8.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber8.Location = new System.Drawing.Point(461, 237);
            this.btnNumber8.Name = "btnNumber8";
            this.btnNumber8.Size = new System.Drawing.Size(90, 74);
            this.btnNumber8.TabIndex = 39;
            this.btnNumber8.Text = "8";
            this.btnNumber8.UseVisualStyleBackColor = true;
            // 
            // btnNumber7
            // 
            this.btnNumber7.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber7.Location = new System.Drawing.Point(355, 237);
            this.btnNumber7.Name = "btnNumber7";
            this.btnNumber7.Size = new System.Drawing.Size(90, 74);
            this.btnNumber7.TabIndex = 38;
            this.btnNumber7.Text = "7";
            this.btnNumber7.UseVisualStyleBackColor = true;
            // 
            // btnNumber6
            // 
            this.btnNumber6.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber6.Location = new System.Drawing.Point(567, 147);
            this.btnNumber6.Name = "btnNumber6";
            this.btnNumber6.Size = new System.Drawing.Size(90, 74);
            this.btnNumber6.TabIndex = 37;
            this.btnNumber6.Text = "6";
            this.btnNumber6.UseVisualStyleBackColor = true;
            // 
            // btnNumber5
            // 
            this.btnNumber5.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber5.Location = new System.Drawing.Point(461, 147);
            this.btnNumber5.Name = "btnNumber5";
            this.btnNumber5.Size = new System.Drawing.Size(90, 74);
            this.btnNumber5.TabIndex = 36;
            this.btnNumber5.Text = "5";
            this.btnNumber5.UseVisualStyleBackColor = true;
            // 
            // btnNumber4
            // 
            this.btnNumber4.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber4.Location = new System.Drawing.Point(355, 147);
            this.btnNumber4.Name = "btnNumber4";
            this.btnNumber4.Size = new System.Drawing.Size(90, 74);
            this.btnNumber4.TabIndex = 35;
            this.btnNumber4.Text = "4";
            this.btnNumber4.UseVisualStyleBackColor = true;
            // 
            // btnNumber3
            // 
            this.btnNumber3.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber3.Location = new System.Drawing.Point(567, 57);
            this.btnNumber3.Name = "btnNumber3";
            this.btnNumber3.Size = new System.Drawing.Size(90, 74);
            this.btnNumber3.TabIndex = 34;
            this.btnNumber3.Text = "3";
            this.btnNumber3.UseVisualStyleBackColor = true;
            // 
            // btnNumber2
            // 
            this.btnNumber2.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber2.Location = new System.Drawing.Point(461, 57);
            this.btnNumber2.Name = "btnNumber2";
            this.btnNumber2.Size = new System.Drawing.Size(90, 74);
            this.btnNumber2.TabIndex = 33;
            this.btnNumber2.Text = "2";
            this.btnNumber2.UseVisualStyleBackColor = true;
            // 
            // btnNumber1
            // 
            this.btnNumber1.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber1.Location = new System.Drawing.Point(355, 57);
            this.btnNumber1.Name = "btnNumber1";
            this.btnNumber1.Size = new System.Drawing.Size(90, 74);
            this.btnNumber1.TabIndex = 32;
            this.btnNumber1.Text = "1";
            this.btnNumber1.UseVisualStyleBackColor = true;
            // 
            // btnNumber0
            // 
            this.btnNumber0.Font = new System.Drawing.Font("標楷體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnNumber0.Location = new System.Drawing.Point(355, 327);
            this.btnNumber0.Name = "btnNumber0";
            this.btnNumber0.Size = new System.Drawing.Size(90, 74);
            this.btnNumber0.TabIndex = 41;
            this.btnNumber0.Text = "0";
            this.btnNumber0.UseVisualStyleBackColor = true;
            // 
            // ModifyPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(706, 451);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNumber9);
            this.Controls.Add(this.btnNumber8);
            this.Controls.Add(this.btnNumber7);
            this.Controls.Add(this.btnNumber6);
            this.Controls.Add(this.btnNumber5);
            this.Controls.Add(this.btnNumber4);
            this.Controls.Add(this.btnNumber3);
            this.Controls.Add(this.btnNumber2);
            this.Controls.Add(this.btnNumber1);
            this.Controls.Add(this.btnNumber0);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.comfirmPassTextBox);
            this.Controls.Add(comfirmPassLabel);
            this.Controls.Add(this.newPassTextBox);
            this.Controls.Add(newPassLabel);
            this.Controls.Add(this.oldPassTextBox);
            this.Controls.Add(oldPassLabel);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyPassword";
            this.Text = "修改密碼";
            this.Load += new System.EventHandler(this.ModifyPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldPassTextBox;
        private System.Windows.Forms.TextBox newPassTextBox;
        private System.Windows.Forms.TextBox comfirmPassTextBox;
        private System.Windows.Forms.Button btnChangePassword;
        private BakeryOrderSetTableAdapters.CashierTableAdapter cashierTableAdapter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNumber9;
        private System.Windows.Forms.Button btnNumber8;
        private System.Windows.Forms.Button btnNumber7;
        private System.Windows.Forms.Button btnNumber6;
        private System.Windows.Forms.Button btnNumber5;
        private System.Windows.Forms.Button btnNumber4;
        private System.Windows.Forms.Button btnNumber3;
        private System.Windows.Forms.Button btnNumber2;
        private System.Windows.Forms.Button btnNumber1;
        private System.Windows.Forms.Button btnNumber0;


    }
}