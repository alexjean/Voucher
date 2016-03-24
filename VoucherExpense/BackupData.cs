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

        static string voucher = "VoucherExpense.mdb";
#if (Define_Bakery)
        static string income = "BakeryOrder.mdb";
#else
        static string income  = "BasicData.mdb";
#endif
        public static void DoBackup(string fromDir, string toDir)
        {
            string voucherFile, incomeFile;
            voucherFile = fromDir+"\\"+voucher;
            incomeFile = fromDir+"\\"+income;
            if (toDir.Length == 0)
            {
                MessageBox.Show("請輸入備份位置!");
                return;
            }

            string dir1 = Path.GetDirectoryName(Path.GetFullPath(voucherFile));
            string dir2 = Path.GetDirectoryName(Path.GetFullPath(toDir + "\\"));

            if (dir1 == dir2)
            {
                MessageBox.Show("不能備份同一資料目錄!");
                return;
            }
            string destVoucher = toDir + "\\" + voucher;
            string destIncome  = toDir + "\\" + income;

            if (FileCheckCopy(voucherFile, destVoucher))
            {
                if (FileCheckCopy(incomeFile, destIncome))
                {
                    MessageBox.Show("己備份至<" + Path.GetFullPath(toDir) + ">");
                    return;
                }
            }
            MessageBox.Show("備份失敗!");
        }


        public static void DoBackup(bool IsServer,string DataDir,string BackupDir)
        {
            string voucherFile, incomeFile;
            if (!IsServer)
            {
                voucherFile = DataDir + "\\" + voucher;
                incomeFile  = DataDir + "\\" + income;
            }
            else
            {
                voucherFile = voucher;
                incomeFile  = income;
            }
            if (BackupDir.Length == 0)
            {
                MessageBox.Show("請輸入備份位置! 按存檔");
                return;
            }

            string dir1 = Path.GetDirectoryName(Path.GetFullPath(voucherFile));
            string dir2 = Path.GetDirectoryName(Path.GetFullPath(BackupDir + "\\"));

            if (dir1 == dir2)
            {
                MessageBox.Show("不能備份至主資料目錄!");
                return;
            }
            string destVoucher = BackupDir + "\\" + voucher;
            string destIncome  = BackupDir + "\\" + income;

            if (FileCheckCopy(voucherFile, destVoucher))
            {
                if (FileCheckCopy(incomeFile, destIncome))
                {
                    MessageBox.Show("己備份至<" + Path.GetFullPath(BackupDir) + ">");
                    return;
                }
            }
            MessageBox.Show("備份失敗!");
        }

    }
}
