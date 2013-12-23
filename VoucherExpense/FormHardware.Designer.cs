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
            this.label1 = new System.Windows.Forms.Label();
            this.cbBoxRS232 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrinter = new System.Windows.Forms.TextBox();
            this.btnFindPrinter = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckBoxIsServer = new System.Windows.Forms.CheckBox();
            this.textBoxDataDir = new System.Windows.Forms.TextBox();
            this.labelShareName = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBoxBackupDir = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolerBrowse = new System.Windows.Forms.Button();
            this.labelProgramVersion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRequiredVersion = new System.Windows.Forms.Label();
            this.btnUpdateRequiedVersion = new System.Windows.Forms.Button();
            this.btnFindDotPrinter = new System.Windows.Forms.Button();
            this.textBoxDotPrinter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxSqlServerIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSqlDatabase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSqlUserID = new System.Windows.Forms.TextBox();
            this.textBoxSqlPassword = new System.Windows.Forms.TextBox();
            this.btnSaveSql = new System.Windows.Forms.Button();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.listBox1.Location = new System.Drawing.Point(344, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(536, 276);
            this.listBox1.TabIndex = 0;
            this.listBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "收機机串口";
            // 
            // cbBoxRS232
            // 
            this.cbBoxRS232.FormattingEnabled = true;
            this.cbBoxRS232.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbBoxRS232.Location = new System.Drawing.Point(184, 26);
            this.cbBoxRS232.Name = "cbBoxRS232";
            this.cbBoxRS232.Size = new System.Drawing.Size(111, 24);
            this.cbBoxRS232.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "小票机名稱";
            // 
            // textBoxPrinter
            // 
            this.textBoxPrinter.Location = new System.Drawing.Point(23, 91);
            this.textBoxPrinter.Name = "textBoxPrinter";
            this.textBoxPrinter.Size = new System.Drawing.Size(277, 27);
            this.textBoxPrinter.TabIndex = 6;
            // 
            // btnFindPrinter
            // 
            this.btnFindPrinter.Location = new System.Drawing.Point(184, 64);
            this.btnFindPrinter.Name = "btnFindPrinter";
            this.btnFindPrinter.Size = new System.Drawing.Size(111, 26);
            this.btnFindPrinter.TabIndex = 5;
            this.btnFindPrinter.Text = "找印表机";
            this.btnFindPrinter.UseVisualStyleBackColor = true;
            this.btnFindPrinter.Click += new System.EventHandler(this.btnFindPrinter_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "本處所設資料存於 HardwareCfg.xml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "每台机器需單獨設定";
            // 
            // ckBoxIsServer
            // 
            this.ckBoxIsServer.Location = new System.Drawing.Point(18, 26);
            this.ckBoxIsServer.Name = "ckBoxIsServer";
            this.ckBoxIsServer.Size = new System.Drawing.Size(221, 20);
            this.ckBoxIsServer.TabIndex = 0;
            this.ckBoxIsServer.Text = "我是主機  (資料庫位於本機)";
            this.ckBoxIsServer.UseVisualStyleBackColor = true;
            this.ckBoxIsServer.CheckedChanged += new System.EventHandler(this.ckBoxIsServer_CheckedChanged);
            // 
            // textBoxDataDir
            // 
            this.textBoxDataDir.Location = new System.Drawing.Point(18, 85);
            this.textBoxDataDir.Name = "textBoxDataDir";
            this.textBoxDataDir.Size = new System.Drawing.Size(277, 27);
            this.textBoxDataDir.TabIndex = 1;
            // 
            // labelShareName
            // 
            this.labelShareName.AutoSize = true;
            this.labelShareName.Location = new System.Drawing.Point(18, 66);
            this.labelShareName.Name = "labelShareName";
            this.labelShareName.Size = new System.Drawing.Size(216, 16);
            this.labelShareName.TabIndex = 7;
            this.labelShareName.Text = "資料庫目錄     \\\\主机名\\共享名";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(18, 136);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(40, 16);
            this.labelUser.TabIndex = 12;
            this.labelUser.Text = "帳號";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(18, 169);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(40, 16);
            this.labelPass.TabIndex = 13;
            this.labelPass.Text = "密碼";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(64, 131);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(231, 27);
            this.textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(64, 164);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(231, 27);
            this.textBoxPassword.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(119, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBoxBackupDir
            // 
            this.textBoxBackupDir.Location = new System.Drawing.Point(6, 21);
            this.textBoxBackupDir.Name = "textBoxBackupDir";
            this.textBoxBackupDir.Size = new System.Drawing.Size(425, 27);
            this.textBoxBackupDir.TabIndex = 14;
            // 
            // btnBackup
            // 
            this.btnBackup.AutoSize = true;
            this.btnBackup.Location = new System.Drawing.Point(180, 57);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(98, 30);
            this.btnBackup.TabIndex = 16;
            this.btnBackup.Text = "進行備份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnFolerBrowse
            // 
            this.btnFolerBrowse.Location = new System.Drawing.Point(437, 21);
            this.btnFolerBrowse.Name = "btnFolerBrowse";
            this.btnFolerBrowse.Size = new System.Drawing.Size(93, 30);
            this.btnFolerBrowse.TabIndex = 17;
            this.btnFolerBrowse.Text = "瀏覽位置";
            this.btnFolerBrowse.UseVisualStyleBackColor = true;
            this.btnFolerBrowse.Click += new System.EventHandler(this.btnFolerBrowse_Click);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "同一店內POS机編号不可相同";
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
            this.btnFindDotPrinter.Location = new System.Drawing.Point(184, 126);
            this.btnFindDotPrinter.Name = "btnFindDotPrinter";
            this.btnFindDotPrinter.Size = new System.Drawing.Size(111, 26);
            this.btnFindDotPrinter.TabIndex = 25;
            this.btnFindDotPrinter.Text = "找印表机";
            this.btnFindDotPrinter.UseVisualStyleBackColor = true;
            this.btnFindDotPrinter.Click += new System.EventHandler(this.btnFindDotPrinter_Click);
            // 
            // textBoxDotPrinter
            // 
            this.textBoxDotPrinter.Location = new System.Drawing.Point(20, 153);
            this.textBoxDotPrinter.Name = "textBoxDotPrinter";
            this.textBoxDotPrinter.Size = new System.Drawing.Size(277, 27);
            this.textBoxDotPrinter.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "點陣印表机名稱";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDataDir);
            this.groupBox1.Controls.Add(this.labelShareName);
            this.groupBox1.Controls.Add(this.labelUser);
            this.groupBox1.Controls.Add(this.labelPass);
            this.groupBox1.Controls.Add(this.textBoxUserName);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.ckBoxIsServer);
            this.groupBox1.Location = new System.Drawing.Point(13, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 239);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mdb 設定";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDataBase);
            this.groupBox2.Controls.Add(this.btnUpdateRequiedVersion);
            this.groupBox2.Controls.Add(this.labelProgramVersion);
            this.groupBox2.Controls.Add(this.labelRequiredVersion);
            this.groupBox2.Location = new System.Drawing.Point(567, 541);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 97);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "版本要求";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxBackupDir);
            this.groupBox3.Controls.Add(this.btnBackup);
            this.groupBox3.Controls.Add(this.btnFolerBrowse);
            this.groupBox3.Location = new System.Drawing.Point(13, 540);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(536, 97);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mdb備份設定";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbBoxRS232);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnFindDotPrinter);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.textBoxDotPrinter);
            this.groupBox5.Controls.Add(this.btnFindPrinter);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.textBoxPrinter);
            this.groupBox5.Location = new System.Drawing.Point(13, 100);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(313, 189);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            // 
            // textBoxSqlServerIP
            // 
            this.textBoxSqlServerIP.Location = new System.Drawing.Point(106, 29);
            this.textBoxSqlServerIP.Name = "textBoxSqlServerIP";
            this.textBoxSqlServerIP.Size = new System.Drawing.Size(277, 27);
            this.textBoxSqlServerIP.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Server IP";
            // 
            // textBoxSqlDatabase
            // 
            this.textBoxSqlDatabase.Location = new System.Drawing.Point(106, 85);
            this.textBoxSqlDatabase.Name = "textBoxSqlDatabase";
            this.textBoxSqlDatabase.Size = new System.Drawing.Size(277, 27);
            this.textBoxSqlDatabase.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "資料庫";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxSqlUserID);
            this.groupBox4.Controls.Add(this.textBoxSqlPassword);
            this.groupBox4.Controls.Add(this.btnSaveSql);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxSqlDatabase);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBoxSqlServerIP);
            this.groupBox4.Location = new System.Drawing.Point(344, 295);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(536, 240);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SQL設定";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "帳號";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "密碼";
            // 
            // textBoxSqlUserID
            // 
            this.textBoxSqlUserID.Location = new System.Drawing.Point(106, 131);
            this.textBoxSqlUserID.Name = "textBoxSqlUserID";
            this.textBoxSqlUserID.Size = new System.Drawing.Size(231, 27);
            this.textBoxSqlUserID.TabIndex = 14;
            // 
            // textBoxSqlPassword
            // 
            this.textBoxSqlPassword.Location = new System.Drawing.Point(106, 164);
            this.textBoxSqlPassword.Name = "textBoxSqlPassword";
            this.textBoxSqlPassword.Size = new System.Drawing.Size(231, 27);
            this.textBoxSqlPassword.TabIndex = 15;
            // 
            // btnSaveSql
            // 
            this.btnSaveSql.Location = new System.Drawing.Point(180, 203);
            this.btnSaveSql.Name = "btnSaveSql";
            this.btnSaveSql.Size = new System.Drawing.Size(75, 30);
            this.btnSaveSql.TabIndex = 16;
            this.btnSaveSql.Text = "存檔";
            this.btnSaveSql.UseVisualStyleBackColor = true;
            this.btnSaveSql.Click += new System.EventHandler(this.btnSaveSql_Click);
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
            // FormHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(892, 638);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHardware";
            this.Text = "硬體環境設定";
            this.Load += new System.EventHandler(this.FormHardware_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxRS232;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrinter;
        private System.Windows.Forms.Button btnFindPrinter;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckBoxIsServer;
        private System.Windows.Forms.TextBox textBoxDataDir;
        private System.Windows.Forms.Label labelShareName;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBoxBackupDir;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolerBrowse;
        private System.Windows.Forms.Label labelProgramVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRequiredVersion;
        private System.Windows.Forms.Button btnUpdateRequiedVersion;
        private System.Windows.Forms.Button btnFindDotPrinter;
        private System.Windows.Forms.TextBox textBoxDotPrinter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
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
    }
}