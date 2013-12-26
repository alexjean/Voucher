namespace SyncCloud
{
    partial class FormEditPass
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
            this.tbxLocalServer = new System.Windows.Forms.TextBox();
            this.tbxLocalDb = new System.Windows.Forms.TextBox();
            this.tbxLocalUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxLocalPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCloudPassword = new System.Windows.Forms.TextBox();
            this.tbxCloudUserId = new System.Windows.Forms.TextBox();
            this.tbxCloudDb = new System.Windows.Forms.TextBox();
            this.tbxCloudServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTestLocal = new System.Windows.Forms.Button();
            this.btnTestCloud = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnGetLocalName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxLocalServer
            // 
            this.tbxLocalServer.Location = new System.Drawing.Point(154, 82);
            this.tbxLocalServer.Name = "tbxLocalServer";
            this.tbxLocalServer.Size = new System.Drawing.Size(119, 27);
            this.tbxLocalServer.TabIndex = 0;
            // 
            // tbxLocalDb
            // 
            this.tbxLocalDb.Location = new System.Drawing.Point(154, 131);
            this.tbxLocalDb.Name = "tbxLocalDb";
            this.tbxLocalDb.Size = new System.Drawing.Size(119, 27);
            this.tbxLocalDb.TabIndex = 1;
            // 
            // tbxLocalUserId
            // 
            this.tbxLocalUserId.Location = new System.Drawing.Point(154, 180);
            this.tbxLocalUserId.Name = "tbxLocalUserId";
            this.tbxLocalUserId.Size = new System.Drawing.Size(119, 27);
            this.tbxLocalUserId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "伺服器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "資料庫名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "用戶名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "密碼";
            // 
            // tbxLocalPassword
            // 
            this.tbxLocalPassword.Location = new System.Drawing.Point(154, 229);
            this.tbxLocalPassword.Name = "tbxLocalPassword";
            this.tbxLocalPassword.Size = new System.Drawing.Size(119, 27);
            this.tbxLocalPassword.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "本机";
            // 
            // tbxCloudPassword
            // 
            this.tbxCloudPassword.Location = new System.Drawing.Point(308, 229);
            this.tbxCloudPassword.Name = "tbxCloudPassword";
            this.tbxCloudPassword.Size = new System.Drawing.Size(119, 27);
            this.tbxCloudPassword.TabIndex = 12;
            // 
            // tbxCloudUserId
            // 
            this.tbxCloudUserId.Location = new System.Drawing.Point(308, 180);
            this.tbxCloudUserId.Name = "tbxCloudUserId";
            this.tbxCloudUserId.Size = new System.Drawing.Size(119, 27);
            this.tbxCloudUserId.TabIndex = 11;
            // 
            // tbxCloudDb
            // 
            this.tbxCloudDb.Location = new System.Drawing.Point(308, 131);
            this.tbxCloudDb.Name = "tbxCloudDb";
            this.tbxCloudDb.Size = new System.Drawing.Size(119, 27);
            this.tbxCloudDb.TabIndex = 10;
            // 
            // tbxCloudServer
            // 
            this.tbxCloudServer.Location = new System.Drawing.Point(308, 82);
            this.tbxCloudServer.Name = "tbxCloudServer";
            this.tbxCloudServer.Size = new System.Drawing.Size(119, 27);
            this.tbxCloudServer.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "雲端";
            // 
            // btnTestLocal
            // 
            this.btnTestLocal.Location = new System.Drawing.Point(167, 275);
            this.btnTestLocal.Name = "btnTestLocal";
            this.btnTestLocal.Size = new System.Drawing.Size(96, 29);
            this.btnTestLocal.TabIndex = 14;
            this.btnTestLocal.Text = "試連本机";
            this.btnTestLocal.UseVisualStyleBackColor = true;
            this.btnTestLocal.Click += new System.EventHandler(this.btnTestLocal_Click);
            // 
            // btnTestCloud
            // 
            this.btnTestCloud.Location = new System.Drawing.Point(319, 275);
            this.btnTestCloud.Name = "btnTestCloud";
            this.btnTestCloud.Size = new System.Drawing.Size(96, 29);
            this.btnTestCloud.TabIndex = 15;
            this.btnTestCloud.Text = "試連雲端";
            this.btnTestCloud.UseVisualStyleBackColor = true;
            this.btnTestCloud.Click += new System.EventHandler(this.btnTestCloud_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(329, 342);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 27);
            this.btnSaveConfig.TabIndex = 16;
            this.btnSaveConfig.Text = "存檔";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "下次登入密碼";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(154, 342);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(119, 27);
            this.tbxPassword.TabIndex = 17;
            // 
            // btnGetLocalName
            // 
            this.btnGetLocalName.Location = new System.Drawing.Point(154, 36);
            this.btnGetLocalName.Name = "btnGetLocalName";
            this.btnGetLocalName.Size = new System.Drawing.Size(50, 34);
            this.btnGetLocalName.TabIndex = 19;
            this.btnGetLocalName.Text = "取得";
            this.btnGetLocalName.UseVisualStyleBackColor = true;
            this.btnGetLocalName.Click += new System.EventHandler(this.btnGetLocalName_Click);
            // 
            // FormEditPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 400);
            this.Controls.Add(this.btnGetLocalName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.btnTestCloud);
            this.Controls.Add(this.btnTestLocal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxCloudPassword);
            this.Controls.Add(this.tbxCloudUserId);
            this.Controls.Add(this.tbxCloudDb);
            this.Controls.Add(this.tbxCloudServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxLocalPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxLocalUserId);
            this.Controls.Add(this.tbxLocalDb);
            this.Controls.Add(this.tbxLocalServer);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEditPass";
            this.Text = "編修 資料庫 參數";
            this.Load += new System.EventHandler(this.FormEditPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLocalServer;
        private System.Windows.Forms.TextBox tbxLocalDb;
        private System.Windows.Forms.TextBox tbxLocalUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxLocalPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCloudPassword;
        private System.Windows.Forms.TextBox tbxCloudUserId;
        private System.Windows.Forms.TextBox tbxCloudDb;
        private System.Windows.Forms.TextBox tbxCloudServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTestLocal;
        private System.Windows.Forms.Button btnTestCloud;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnGetLocalName;
    }
}