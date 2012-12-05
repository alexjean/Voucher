using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace VoucherExpense
{
    class BackupData
    {
        private static bool FileCheckCopy(string source, string dest)
        {
            try
            {
                string str = Path.GetDirectoryName(dest);
                if (!Directory.Exists(str))
                {
                    if (MessageBox.Show("目錄<" + str + ">不存在!\r\n按OK新增目錄", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                        return false;
                    Directory.CreateDirectory(str);
                }
                File.Copy(source, dest, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public static void DoBackup(HardwareConfig Config)
        {
            string voucher = "VoucherExpense.mdb";
#if (Define_Bakery)            
            string income = "BakeryOrder.mdb";
#else
            string income  = "BasicData.mdb";
#endif
            string voucherFile, incomeFile;
            if (!Config.IsServer)
            {
                voucherFile = Config.DataDir + "\\" + voucher;
                incomeFile  = Config.DataDir + "\\" + income;
            }
            else
            {
                voucherFile = voucher;
                incomeFile  = income;
            }
            if (Config.BackupDir.Length == 0)
            {
                MessageBox.Show("請輸入備份位置! 按存檔");
                return;
            }

            string dir1 = Path.GetDirectoryName(Path.GetFullPath(voucherFile));
            string dir2 = Path.GetDirectoryName(Path.GetFullPath(Config.BackupDir + "\\"));

            if (dir1 == dir2)
            {
                MessageBox.Show("不能備份至主資料目錄!");
                return;
            }
            string destVoucher = Config.BackupDir + "\\" + voucher;
            string destIncome  = Config.BackupDir + "\\" + income;

            if (FileCheckCopy(voucherFile, destVoucher))
            {
                if (FileCheckCopy(incomeFile, destIncome))
                {
                    MessageBox.Show("己備份至<" + Path.GetFullPath(Config.BackupDir) + ">");
                    return;
                }
            }
            MessageBox.Show("備份失敗!");
        }

    }
}
