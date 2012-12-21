namespace BakeryOrder
{
    partial class FormSystemSetup
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnExitProgram = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnInvoicesMatch = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(576, 258);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(88, 56);
            this.btnChangePassword.TabIndex = 10;
            this.btnChangePassword.Text = "修改密碼";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnExitProgram
            // 
            this.btnExitProgram.Location = new System.Drawing.Point(576, 356);
            this.btnExitProgram.Name = "btnExitProgram";
            this.btnExitProgram.Size = new System.Drawing.Size(88, 56);
            this.btnExitProgram.TabIndex = 11;
            this.btnExitProgram.Text = "离开程式";
            this.btnExitProgram.UseVisualStyleBackColor = true;
            this.btnExitProgram.Click += new System.EventHandler(this.btnExitProgram_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(18, 356);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(88, 56);
            this.btnReturn.TabIndex = 12;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnInvoicesMatch
            // 
            this.btnInvoicesMatch.Location = new System.Drawing.Point(461, 356);
            this.btnInvoicesMatch.Name = "btnInvoicesMatch";
            this.btnInvoicesMatch.Size = new System.Drawing.Size(88, 56);
            this.btnInvoicesMatch.TabIndex = 13;
            this.btnInvoicesMatch.Text = "對帳列印";
            this.btnInvoicesMatch.UseVisualStyleBackColor = true;
            this.btnInvoicesMatch.Click += new System.EventHandler(this.btnInvoicesMatch_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(18, 258);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 56);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnExitProgram);
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnInvoicesMatch);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 425);
            this.panel1.TabIndex = 15;
            // 
            // FormSystemSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.BackgroundImage = global::BakeryOrder.Properties.Resources.Wheat;
            this.ClientSize = new System.Drawing.Size(701, 449);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSystemSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系統設定";
            this.Load += new System.EventHandler(this.FormSystemSetup_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnExitProgram;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnInvoicesMatch;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
    }
}