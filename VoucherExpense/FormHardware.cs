using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
#if UseSQLServer
using MyVEHeaderAdapter = VoucherExpense.DamaiDataSetTableAdapters.VEHeaderTableAdapter;
using MyVEHeaderTable = VoucherExpense.DamaiDataSet.VEHeaderDataTable;
#else
using MyVEHeaderAdapter = VoucherExpense.VEDataSetTableAdapters.HeaderTableAdapter;
using MyVEHeaderTable = VoucherExpense.VEDataSet.HeaderDataTable;
#endif
namespace VoucherExpense
{
    public partial class FormHardware : Form
    {
        HardwareConfig Config;
        public FormHardware()
        {
            InitializeComponent();
            Config = MyFunction.HardwareCfg;
        }

        private void btnFindPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog()==DialogResult.OK)
                textBoxPrinter.Text=printDialog1.PrinterSettings.PrinterName;
        }

        private void btnFindDotPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                textBoxDotPrinter.Text = printDialog1.PrinterSettings.PrinterName;
        }


        void SetIsServer(bool notServer)
        {
            textBoxDataDir.Enabled = notServer;
            textBoxUserName.Enabled = textBoxPassword.Enabled = notServer;
            labelShareName.Enabled = notServer;
            labelUser.Enabled = labelPass.Enabled = notServer;
        }

        private void ckBoxIsServer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            SetIsServer(!box.Checked);
        }

        MyVEHeaderTable m_VEHeader = new MyVEHeaderTable();
        MyVEHeaderAdapter VEHeaderAdapter = new MyVEHeaderAdapter();
        private void FormHardware_Load(object sender, EventArgs e)
        {
            try
            {
#if UseSQLServer
                VEHeaderAdapter.Fill(m_VEHeader);
                labelDataBase.Text = "資料庫為MsSQL";
#else
                VEHeaderAdapter.Connection =    MapPath.VEConnection;
                VEHeaderAdapter.Fill(m_VEHeader);
                labelDataBase.Text = "資料庫為Access";
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式錯誤!:" + ex.Message);
            }
//            Config.Load();
            cbBoxRS232.Text         = Config.ComPortName;
            textBoxProfileName.Text = Config.ProfileName;
            textBoxPrinter.Text     = Config.PrinterName;
            textBoxDotPrinter.Text  = Config.DotPrinterName;
            ckBoxIsServer.Checked   = Config.IsServer;
            textBoxDataDir.Text     = Config.DataDir;
            textBoxUserName.Text    = Config.UserName;
            textBoxPassword.Text    = Config.Password;
            textBoxBackupDir.Text   = Config.BackupDir;

            textBoxSqlServerIP.Text = Config.SqlServerIP;
            textBoxSqlDatabase.Text = Config.SqlDatabase;
            textBoxSqlUserID.Text   = Config.SqlUserID;
            textBoxSqlPassword.Text = Config.SqlPassword;
            

            labelProgramVersion.Text = "程式版本 "+Application.ProductVersion.ToString();
            labelRequiredVersion.Text = "要求版本 " + GetVersion();

        }

        string GetVersion()
        {
            if (m_VEHeader.Count > 0)
            {
                var header = m_VEHeader[0];
                if (!header.IsVersionNull())
                    return header.Version.Trim();
            }
            return "未註明";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.ProfileName = textBoxProfileName.Text.Trim();
            Config.ComPortName = cbBoxRS232.Text.Trim();
            Config.PrinterName = textBoxPrinter.Text.Trim();
            Config.DotPrinterName = textBoxDotPrinter.Text.Trim();
            Config.IsServer    = ckBoxIsServer.Checked;
            Config.DataDir     = textBoxDataDir.Text.Trim();
            Config.UserName    = textBoxUserName.Text.Trim();
            Config.Password    = textBoxPassword.Text.Trim();
            Config.BackupDir   = textBoxBackupDir.Text.Trim();
            Config.Save();
            MessageBox.Show("Mdb及備份設定 存檔完成! 重新啟動程式後, 設定方生效.");
        }


        private void btnSaveSql_Click(object sender, EventArgs e)
        {
            Config.ProfileName = textBoxProfileName.Text.Trim();
            Config.SqlServerIP = textBoxSqlServerIP.Text.Trim();
            Config.SqlDatabase = textBoxSqlDatabase.Text.Trim();
            Config.SqlUserID   = textBoxSqlUserID.Text.Trim();
            Config.SqlPassword = textBoxSqlPassword.Text.Trim();
            Config.Save();
            MessageBox.Show("SQL設定存檔完成! 重新啟動程式後, 設定方生效.");
        }



        private void btnFolerBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            this.textBoxBackupDir.Text=folderBrowserDialog1.SelectedPath;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupData.DoBackup(Config);
        }


        private void btnUpdateRequiedVersion_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_VEHeader.Count<=0) return;
                var header = m_VEHeader[0];
                if (!header.IsVersionNull() && header.Version.Trim() == Application.ProductVersion.Trim())
                {
                    MessageBox.Show("版本号相同不需更換!");
                    return;
                }
                string ver = Application.ProductVersion.Trim();
#if UseSQLServer
                string fullDest = Path.GetFullPath(Application.ExecutablePath).ToLower();
                byte[] zipped=null;
                byte[] md5 = null;
                
                if (MyFunction.CompressFileToBuf(fullDest, out zipped,out md5))
                {
                    var programAdapter = new VoucherExpense.DamaiDataSetTableAdapters.ProgramTableAdapter();
                    var cmd = new System.Data.SqlClient.SqlCommand("DELETE FROM [dbo].[Program] WHERE 1=1");
                    cmd.Connection = programAdapter.Connection;
                    programAdapter.Connection.Open();
                    cmd.ExecuteNonQuery();
                    var table = new VoucherExpense.DamaiDataSet.ProgramDataTable();
                    var programRow = table.NewProgramRow();
                    programRow.ID = Guid.NewGuid();
                    programRow.ProgramVersion = ver;
                    programRow.UpdatedTime = DateTime.Now;
                    programRow.ZippedImage = zipped;
                    programRow.MD5 = md5;
                    table.AddProgramRow(programRow);
                    labelRequiredVersion.Text = ver+" 正在上傳";
                    Application.DoEvents();
                    programAdapter.Update(table);    
                    programAdapter.Connection.Dispose();
                }
#endif 
                header.Version = ver;
                VEHeaderAdapter.Update(m_VEHeader);
                labelRequiredVersion.Text = "要求版本 " + header.Version;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
        }
    }
}
