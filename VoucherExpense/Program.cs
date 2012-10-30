using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VoucherExpense
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string EncryptedPasword = "mpwfCblfsz";   // loveBakery
            string password = "";
            foreach (char c in EncryptedPasword) password += (char)(c - 1);
            global::VoucherExpense.Properties.Settings.Default.BakeryOrderConnectionString += password;
            Application.Run(new FormLogin());
        }
    }
}