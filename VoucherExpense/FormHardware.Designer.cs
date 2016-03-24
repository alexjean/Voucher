namespace VoucherExpense
{
    partial class FormHardware
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelProgramVersion = new System.Windows.Forms.Label();
            this.labelRequiredVersion = new System.Windows.Forms.Label();
            this.btnUpdateRequiedVersion = new System.Windows.Forms.Button();
            this.btnFindDotPrinter = new System.Windows.Forms.Button();
            this.textBoxDotPrinter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.textBoxSqlServerIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSqlDatabase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckBoxIsServer = new System.Windows.Forms.CheckBox();
            this.textBoxSharedDatabase = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnTestCloud = new System.Windows.Forms.Button();
            this.btnTestLocal = new System.Windows.Forms.Button();
            this.chBoxCloudSync = new System.Windows.Forms.CheckBox();
            this.textBoxSqlUserIDCloud = new System.Windows.Forms.TextBox();
            this.textBoxSqlPasswordCloud = new System.Windows.Forms.TextBox();
            this.textBoxSqlServerIPCloud = new System.Windows.Forms.TextBox();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSqlUserID = new System.Windows.Forms.TextBox();
            this.textBoxSqlPassword = new System.Windows.Forms.TextBox();
            this.btnSaveSql = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "",
            " 1 云端資料庫, 分單店庫及共享庫. 云端單店庫名稱規定和店机端同名.",
            "    所以需設定\'共享庫\'(含產品 食材 配方 部門 登入權限),才能登入云端.",
            "",
            " 2 為免錯誤\'共享庫\'名稱規定以Region結尾",
            "",
            " 3 \'店机\' 有打勾時, 全部資料表都在\'店資料庫\' ",
            "",
            " 4  雲端登入或部門切換後,\'店机\'此勾不打.  不打勾時,",
            "     (產品 食材 配方 部門 登入權限)會從區域\'共享庫\'讀取,",
            "",
            " 5  若[Apartment]內的 SharedDatabase 或 IP位置帳密 未設置正確,",
            "     云端登入將失敗.",
            "",
            "",
            "",
            "",
            "---------------------------------------------------------------------------------" +
                "--------------",
            "",
            "            XP資料庫目錄共享設定 (以 \\Voucher 為例)",
            "",
            " 1 主機一定要是XP Professional , NTFS格式. Home Edition不行",
            "",
            " 2 網路上的芳鄰=>設定家用或小型辦公室網路=> ．．．=>．．． ",
            "    要確認 開啟檔案與印表機共用,  一路繼續到完成",
            "",
            " 3 控制台=>Windows防火牆，檢查 例外 \"檔案與印表機共用\" 己經勾起",
            "",
            " 4 工具=>資料夾選項=>檢視=>使用簡易檔案共用   勾勾拿掉",
            "    (Win7   資料夾選項=>檢視=>使用共用精靈    取消掉)",
            "",
            " 5 我的電腦 按右鍵=>管理=>本機使用者和群組=>使用者 按右鍵=>",
            "    新使用者.    在該機器上建立一個帳號 ( 例 remote  密碼為 password) ,",
            "    只勾 \"使用者不能變更密碼\" 及 \"密碼永久有效\"",
            "    remote的 內容=>成員隸屬=>移除=> users , 避免出現在登入畫面",
            "",
            " 6 在 \\Voucher的目錄  滑鼠右鍵=>共用和安全性=> 安全性=>",
            "    新增 => remote 權限為完全控制",
            "",
            " 7 共用=>共用此資料夾   <名稱> 尾巴加$以便隱形 (例  Voucher1$)",
            "    =>使用權限 移除everyone ,加入 remote 打開所有權限",
            "",
            "8 資料主機的 ShareDocs=>使用權限 移除everyone ,加入 remote 打開所有權限",
            "   請勿分享其他文件夾, 以避免其他機器以 anonymous 登入.  ",
            "",
            "9 Win7 遠端因為要Map Network Driver, 必需以系統管理員執行."});
            this.listBox1.Location = new System.Drawing.Point(373, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(554, 228);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 596);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "本處所設資料存於 HardwareCfg.xml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 621);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "每台机器需單獨設定";
            // 
            // labelProgramVersion
            // 
            this.labelProgramVersion.AutoSize = true;
            this.labelProgramVersion.Location = new System.Drawing.Point(25, 32);
            this.labelProgramVersion.Name = "labelProgramVersion";
            this.labelProgramVersion.Size = new System.Drawing.Size(114, 16);
            this.labelProgramVersion.TabIndex = 18;
            this.labelProgramVersion.Text = "Program Version";
            // 
            // labelRequiredVersion
            // 
            this.labelRequiredVersion.AutoSize = true;
            this.labelRequiredVersion.Location = new System.Drawing.Point(25, 62);
            this.labelRequiredVersion.Name = "labelRequiredVersion";
            this.labelRequiredVersion.Size = new System.Drawing.Size(118, 16);
            this.labelRequiredVersion.TabIndex = 22;
            this.labelRequiredVersion.Text = "Required Version";
            // 
            // btnUpdateRequiedVersion
            // 
            this.btnUpdateRequiedVersion.Location = new System.Drawing.Point(184, 55);
            this.btnUpdateRequiedVersion.Name = "btnUpdateRequiedVersion";
            this.btnUpdateRequiedVersion.Size = new System.Drawing.Size(124, 30);
            this.btnUpdateRequiedVersion.TabIndex = 23;
            this.btnUpdateRequiedVersion.Text = "更新要求版本";
            this.btnUpdateRequiedVersion.UseVisualStyleBackColor = true;
            this.btnUpdateRequiedVersion.Click += new System.EventHandler(this.btnUpdateRequiedVersion_Click);
            // 
            // btnFindDotPrinter
            // 
            this.btnFindDotPrinter.Location = new System.Drawing.Point(6, 296);
            this.btnFindDotPrinter.Name = "btnFindDotPrinter";
            this.btnFindDotPrinter.Size = new System.Drawing.Size(118, 26);
            this.btnFindDotPrinter.TabIndex = 25;
            this.btnFindDotPrinter.Text = "點陣印表机";
            this.btnFindDotPrinter.UseVisualStyleBackColor = true;
            this.btnFindDotPrinter.Click += new System.EventHandler(this.btnFindDotPrinter_Click);
            // 
            // textBoxDotPrinter
            // 
            this.textBoxDotPrinter.Location = new System.Drawing.Point(130, 296);
            this.textBoxDotPrinter.Name = "textBoxDotPrinter";
            this.textBoxDotPrinter.Size = new System.Drawing.Size(386, 27);
            this.textBoxDotPrinter.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDataBase);
            this.groupBox2.Controls.Add(this.btnUpdateRequiedVersion);
            this.groupBox2.Controls.Add(this.labelProgramVersion);
            this.groupBox2.Controls.Add(this.labelRequiredVersion);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 97);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "版本要求";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(190, 32);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(91, 16);
            this.labelDataBase.TabIndex = 24;
            this.labelDataBase.Text = "SQL or MDB";
            // 
            // textBoxSqlServerIP
            // 
            this.textBoxSqlServerIP.Location = new System.Drawing.Point(106, 79);
            this.textBoxSqlServerIP.Name = "textBoxSqlServerIP";
            this.textBoxSqlServerIP.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlServerIP.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Server IP";
            // 
            // textBoxSqlDatabase
            // 
            this.textBoxSqlDatabase.Location = new System.Drawing.Point(106, 115);
            this.textBoxSqlDatabase.Name = "textBoxSqlDatabase";
            this.textBoxSqlDatabase.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlDatabase.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "店資料庫";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnFindDotPrinter);
            this.groupBox4.Controls.Add(this.ckBoxIsServer);
            this.groupBox4.Controls.Add(this.textBoxSharedDatabase);
            this.groupBox4.Controls.Add(this.textBoxDotPrinter);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnTestCloud);
            this.groupBox4.Controls.Add(this.btnTestLocal);
            this.groupBox4.Controls.Add(this.chBoxCloudSync);
            this.groupBox4.Controls.Add(this.textBoxSqlUserIDCloud);
            this.groupBox4.Controls.Add(this.textBoxSqlPasswordCloud);
            this.groupBox4.Controls.Add(this.textBoxSqlServerIPCloud);
            this.groupBox4.Controls.Add(this.textBoxProfileName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxSqlUserID);
            this.groupBox4.Controls.Add(this.textBoxSqlPassword);
            this.groupBox4.Controls.Add(this.btnSaveSql);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxSqlDatabase);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBoxSqlServerIP);
            this.groupBox4.Location = new System.Drawing.Point(373, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(554, 342);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "設定";
            // 
            // ckBoxIsServer
            // 
            this.ckBoxIsServer.Location = new System.Drawing.Point(106, 44);
            this.ckBoxIsServer.Name = "ckBoxIsServer";
            this.ckBoxIsServer.Size = new System.Drawing.Size(221, 20);
            this.ckBoxIsServer.TabIndex = 0;
            this.ckBoxIsServer.Text = "店機 (Region合併於店庫)";
            this.ckBoxIsServer.UseVisualStyleBackColor = true;
            this.ckBoxIsServer.CheckedChanged += new System.EventHandler(this.ckBoxIsServer_CheckedChanged);
            // 
            // textBoxSharedDatabase
            // 
            this.textBoxSharedDatabase.Location = new System.Drawing.Point(347, 115);
            this.textBoxSharedDatabase.Name = "textBoxSharedDatabase";
            this.textBoxSharedDatabase.Size = new System.Drawing.Size(169, 27);
            this.textBoxSharedDatabase.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "共享庫";
            // 
            // btnTestCloud
            // 
            this.btnTestCloud.Location = new System.Drawing.Point(395, 229);
            this.btnTestCloud.Name = "btnTestCloud";
            this.btnTestCloud.Size = new System.Drawing.Size(96, 29);
            this.btnTestCloud.TabIndex = 27;
            this.btnTestCloud.Text = "試連雲端";
            this.btnTestCloud.UseVisualStyleBackColor = true;
            this.btnTestCloud.Click += new System.EventHandler(this.btnTestCloud_Click);
            // 
            // btnTestLocal
            // 
            this.btnTestLocal.Location = new System.Drawing.Point(109, 229);
            this.btnTestLocal.Name = "btnTestLocal";
            this.btnTestLocal.Size = new System.Drawing.Size(96, 29);
            this.btnTestLocal.TabIndex = 26;
            this.btnTestLocal.Text = "試連本机";
            this.btnTestLocal.UseVisualStyleBackColor = true;
            this.btnTestLocal.Click += new System.EventHandler(this.btnTestLocal_Click);
            // 
            // chBoxCloudSync
            // 
            this.chBoxCloudSync.AutoSize = true;
            this.chBoxCloudSync.Location = new System.Drawing.Point(347, 44);
            this.chBoxCloudSync.Name = "chBoxCloudSync";
            this.chBoxCloudSync.Size = new System.Drawing.Size(123, 20);
            this.chBoxCloudSync.TabIndex = 24;
            this.chBoxCloudSync.Text = "啟動雲端同步";
            this.chBoxCloudSync.UseVisualStyleBackColor = true;
            // 
            // textBoxSqlUserIDCloud
            // 
            this.textBoxSqlUserIDCloud.Location = new System.Drawing.Point(347, 152);
            this.textBoxSqlUserIDCloud.Name = "textBoxSqlUserIDCloud";
            this.textBoxSqlUserIDCloud.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlUserIDCloud.TabIndex = 22;
            // 
            // textBoxSqlPasswordCloud
            // 
            this.textBoxSqlPasswordCloud.Location = new System.Drawing.Point(347, 185);
            this.textBoxSqlPasswordCloud.Name = "textBoxSqlPasswordCloud";
            this.textBoxSqlPasswordCloud.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlPasswordCloud.TabIndex = 23;
            // 
            // textBoxSqlServerIPCloud
            // 
            this.textBoxSqlServerIPCloud.Location = new System.Drawing.Point(347, 79);
            this.textBoxSqlServerIPCloud.Name = "textBoxSqlServerIPCloud";
            this.textBoxSqlServerIPCloud.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlServerIPCloud.TabIndex = 20;
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(106, 0);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(169, 27);
            this.textBoxProfileName.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "帳號";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "密碼";
            // 
            // textBoxSqlUserID
            // 
            this.textBoxSqlUserID.Location = new System.Drawing.Point(106, 155);
            this.textBoxSqlUserID.Name = "textBoxSqlUserID";
            this.textBoxSqlUserID.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlUserID.TabIndex = 14;
            // 
            // textBoxSqlPassword
            // 
            this.textBoxSqlPassword.Location = new System.Drawing.Point(106, 188);
            this.textBoxSqlPassword.Name = "textBoxSqlPassword";
            this.textBoxSqlPassword.Size = new System.Drawing.Size(169, 27);
            this.textBoxSqlPassword.TabIndex = 15;
            // 
            // btnSaveSql
            // 
            this.btnSaveSql.Location = new System.Drawing.Point(252, 228);
            this.btnSaveSql.Name = "btnSaveSql";
            this.btnSaveSql.Size = new System.Drawing.Size(96, 30);
            this.btnSaveSql.TabIndex = 16;
            this.btnSaveSql.Text = "存檔";
            this.btnSaveSql.UseVisualStyleBackColor = true;
            this.btnSaveSql.Click += new System.EventHandler(this.btnSaveSql_Click);
            // 
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(929, 648);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHardware";
            this.Text = "硬體環境設定";
            this.Load += new System.EventHandler(this.FormHardware_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labelProgramVersion;
        private System.Windows.Forms.Label labelRequiredVersion;
        private System.Windows.Forms.Button btnUpdateRequiedVersion;
        private System.Windows.Forms.Button btnFindDotPrinter;
        private System.Windows.Forms.TextBox textBoxDotPrinter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSqlServerIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSqlDatabase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSqlUserID;
        private System.Windows.Forms.TextBox textBoxSqlPassword;
        private System.Windows.Forms.Button btnSaveSql;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.CheckBox chBoxCloudSync;
        private System.Windows.Forms.TextBox textBoxSqlUserIDCloud;
        private System.Windows.Forms.TextBox textBoxSqlPasswordCloud;
        private System.Windows.Forms.TextBox textBoxSqlServerIPCloud;
        private System.Windows.Forms.Button btnTestLocal;
        private System.Windows.Forms.Button btnTestCloud;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSharedDatabase;
        private System.Windows.Forms.CheckBox ckBoxIsServer;
    }
}