using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BakeryOrder
{
    public partial class FormSystemSetup : Form
    {
        BakeryOrderSet m_BakeryOrderSet;
        int m_CashierID;
        string m_PrinterName;
        public FormSystemSetup(BakeryOrderSet bakeryOrderSet,int id,string printerName)
        {
            m_CashierID = id;
            m_BakeryOrderSet = bakeryOrderSet;
            m_PrinterName = printerName;
            InitializeComponent();
        }

        DialogResult MessageBoxShow(string msg,bool returnResult=false)
        {
            Form form = new FormMessage(msg,returnResult);
            return form.ShowDialog();
        }

        private void FormSystemSetup_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Form form = new ModifyPassword(m_BakeryOrderSet, m_CashierID);
            form.ShowDialog();
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        string CashierName(int id)
        {
            var cashiers = from row in m_BakeryOrderSet.Cashier where (row.CashierID == id) select row;
            if (cashiers.Count() != 0)
            {
                var cashier = cashiers.First();
                if (cashier.IsCashierNameNull()) return "";
                return cashier.CashierName;
            }
            return "";
        }

        void Print()
        {
            byte[] BorderMode = new byte[] { 0x1c, 0x21, 0x28 };
            byte[] NormalMode = new byte[] { 0x1c, 0x21, 0 };
            byte[] CutPaper = new byte[] { 0x1B, (byte)'i' };

            ByteBuilder Buf = new ByteBuilder(4096);
            Buf.DefaultEncoding = Encoding.GetEncoding("GB2312");
            //            Buf.Append(BorderMode);                                      // 設定列印模式28
            Buf.Append(NormalMode);                                      // 設定列印模式正常 

            Buf.Append("对帐明细\r\n");
            Buf.AppendPadRight("时间:" + DateTime.Now.ToString("yy/MM/dd HH:mm"), 19);
            string cashierIDName = m_CashierID.ToString("d03") + "  " + CashierName(m_CashierID);
            Buf.Append("\r\n收银: " + cashierIDName + "\r\n");
            Buf.Append(NormalMode);                                      // 設定列印模式正常 
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
            int count = 0;
            decimal total = 0m;
            foreach (var order in m_BakeryOrderSet.Order)
            {
                if (order.RowState == DataRowState.Deleted) continue;
                if (order.CashierID == m_CashierID)
                {
                    int id = order.ID % 100000;
                    Buf.Append(id.ToString("d3") + " " + order.PrintTime.ToString("HH:mm:ss") + " " + order.Income.ToString("f0"));
                    if (!order.IsDeletedNull() && order.Deleted)
                        Buf.Append(" 删");
                    if (!order.IsPayByNull())
                    {
                        if      (order.PayBy =="B") Buf.Append(" 卡");
                        else if (order.PayBy =="C") Buf.Append(" 券");
                    }
                    
                    Buf.Append("\r\n");
                    count++;
                    total += order.Income;
                }
            }
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
            Buf.Append("收银: " + cashierIDName + "\r\n");
            Buf.Append("共 " + count.ToString("d") + " 笔," + total.ToString("f0") + "元\r\n");
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n");
            Buf.Append("\f");
//            string str = Buf.ToString();
//            File.WriteAllBytes("Test.txt", Encoding.UTF8.GetBytes(str));
            RawPrint.SendManagedBytes(m_PrinterName, Buf.ToBytes());
            RawPrint.SendManagedBytes(m_PrinterName, CutPaper);
        }

        private void btnInvoicesMatch_Click(object sender, EventArgs e)
        {
            if (MessageBoxShow("列印 收銀員<" + m_CashierID.ToString() + "> 今日對帳明細嗎?", true) != DialogResult.Yes) return;
            Print();
        }


    }
}
