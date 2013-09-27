using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VoucherExpense
{
    public partial class FormHardware : Form
    {
        public FormHardware()
        {
            InitializeComponent();
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

        HardwareConfig Config = new HardwareConfig();
        
        private void FormHardware_Load(object sender, EventArgs e)
        {
            try
            {
                headerTableAdapter1.Connection =    MapPath.VEConnection;
                headerTableAdapter1.Fill(veDataSet1.Header);
            }
            catch (Exception ex)
            {
                MessageBox.Show("程式錯誤!:" + ex.Message);
            }
            Config.Load();
            cbBoxRS232.Text       = Config.ComPortName;
            textBoxPrinter.Text   = Config.PrinterName;
            textBoxDotPrinter.Text = Config.DotPrinterName;
            ckBoxIsServer.Checked = Config.IsServer;
            textBoxDataDir.Text = Config.DataDir;
            textBoxUserName.Text  = Config.UserName;
            textBoxPassword.Text  = Config.Password;
            textBoxBackupDir.Text = Config.BackupDir;
            labelProgramVersion.Text = "程式版本 "+Application.ProductVersion.ToString();
            string version="未註明";
            if (veDataSet1.Header.Count>0)
            {
                var header=veDataSet1.Header[0];
                if (!header.IsVersionNull())
                    version=header.Version.Trim();
            }
            labelRequiredVersion.Text = "要求版本 " + version;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.ComPortName= cbBoxRS232.Text;
            Config.PrinterName= textBoxPrinter.Text;
            Config.DotPrinterName = textBoxDotPrinter.Text;
            Config.IsServer = ckBoxIsServer.Checked;
            Config.DataDir    = textBoxDataDir.Text.Trim();
            Config.UserName   = textBoxUserName.Text.Trim();
            Config.Password   = textBoxPassword.Text.Trim();
            Config.BackupDir  = textBoxBackupDir.Text.Trim();
            Config.Save();
            MessageBox.Show("存檔完成! 重新啟動程式後, 設定方生效.");
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

        private void textBoxPrinter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateRequiedVersion_Click(object sender, EventArgs e)
        {
            try
            {
                if (veDataSet1.Header.Count<=0) return;
                var header = veDataSet1.Header[0];
                if (!header.IsVersionNull() && header.Version.Trim() == Application.ProductVersion.Trim())
                {
                    MessageBox.Show("版本号相同不需更換!");
                    return;
                }
                header.Version = Application.ProductVersion.Trim();
                headerTableAdapter1.Update(veDataSet1.Header);
                labelRequiredVersion.Text = "要求版本 " + header.Version;
            }
            catch (Exception ex)
            {
                MessageBox.Show("錯誤:" + ex.Message);
            }
        }

 
    }
}
