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
        PrintInfo m_Printer;
        int m_PosID = 0;
        string m_CashierName="";
        public bool isReturn=false;//是否有退货员使用
        public FormSystemSetup(BakeryOrderSet bakeryOrderSet,int id,PrintInfo printer,int posID,string cashierName)
        {
            m_CashierID = id;
            m_BakeryOrderSet = bakeryOrderSet;
            m_Printer   = printer;
            m_PosID     = posID;
            m_CashierName=cashierName;
            InitializeComponent();
        }

        DialogResult MessageBoxShow(string msg,bool returnResult=false)
        {
            Form form = new FormMessage(msg,returnResult);
            return form.ShowDialog();
        }

        private void FormSystemSetup_Load(object sender, EventArgs e)
        {
            if (isReturn)
            {
                btnLoginReturn.Text = "退出退货";
            }
            this.TopMost = true;
            Config.Load();
            textBoxPrinter.Text = Config.PrinterName;
            ShowInfomation();
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

            Buf.Append(m_Printer.Title+"对帐明细\r\n");
            Buf.AppendPadRight("时间:" + DateTime.Now.ToString("yy/MM/dd HH:mm"), 19);
            string cashierIDName = m_CashierID.ToString("d03") + "  " + CashierName(m_CashierID);
            Buf.Append("\r\n收银: " + cashierIDName + "\r\n");
            Buf.Append(NormalMode);                                      // 設定列印模式正常 
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
            int count = 0;
            int deletedCount = 0, payByBCount = 0, payByCCount = 0,returnedCount=0;
            decimal total = 0m;
            
            DateTime first=new DateTime(2050,10,31);
            DateTime last =new DateTime(2012,10,31);
            foreach (var order in m_BakeryOrderSet.Order)
            {
                if (order.RowState == DataRowState.Deleted) continue;
                if (order.CashierID == m_CashierID)
                {
                    int id = order.ID % 100000;
                    bool shouldPrint = false;
                    decimal income = 0;
                    if (!order.IsIncomeNull())
                    {
                        income = order.Income;
                        if (income < 0)
                            returnedCount++;
                        if (income <= 0) shouldPrint = true;
                    }
                    if (!order.IsDeletedNull() && order.Deleted)
                    {
                        shouldPrint = true;    // 刪單的要印出
                        deletedCount++;
                    }
                    if (!order.IsPayByNull())
                    {
                        if (order.PayBy == "B" || order.PayBy == "C") shouldPrint = true;    // 刷卡和券的要印出
                        if (order.PayBy == "B") payByBCount++;
                        if (order.PayBy == "C") payByCCount++;
                    }
                    DateTime printTime = new DateTime(2013, 10, 31);
                    if (!order.IsPrintTimeNull())
                    {
                        printTime = order.PrintTime;
                        if (order.PrintTime < first) first = printTime;
                        if (order.PrintTime > last)  last  = printTime;
                    }
                    if (shouldPrint)
                    {
                        Buf.Append(id.ToString("d3") + " " + printTime.ToString("HH:mm:ss") + " " + income.ToString("f0"));
                        if (!order.IsDeletedNull() && order.Deleted)
                            Buf.Append(" 删");
                        if (!order.IsPayByNull())
                        {
                            if (order.PayBy == "B") Buf.Append(" 卡");
                            else if (order.PayBy == "C") Buf.Append(" 券");
                        }
                        if (income < 0) Buf.Append(" 退");
                        Buf.Append("\r\n");
                    }
                    count++;
                    total += income;
                }
            }
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
            Buf.Append("收银: " + cashierIDName + "\r\n");
            Buf.Append("首單時間" + first.ToString("HH:mm:ss") + "\r\n");
            Buf.Append("末單時間" + last.ToString("HH:mm:ss")  + "\r\n");
            Buf.Append("刷卡 "+payByBCount.ToString()   + " 笔, 用券 " +payByCCount.ToString()+" 笔\r\n");
            Buf.Append("删单 "+ deletedCount.ToString() + " 笔, 退货 " +returnedCount.ToString() + " 笔\r\n");

            Buf.Append("共 " + count.ToString("d") + " 笔, " + total.ToString("f0") + "元\r\n");
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n");
            Buf.Append("\f");
            string str = Buf.ToString();
            //File.WriteAllBytes("Test.txt", Encoding.UTF8.GetBytes(str));
            RawPrint.SendManagedBytes(m_Printer.PrinterName, Buf.ToBytes());
            RawPrint.SendManagedBytes(m_Printer.PrinterName, CutPaper);
        }

        private void btnInvoicesMatch_Click(object sender, EventArgs e)
        {
            if (MessageBoxShow("列印 收銀員<" + m_CashierID.ToString() + "> 今日對帳明細嗎?", true) != DialogResult.Yes) return;
            Print();
        }

        HardwareConfig Config = new HardwareConfig();
        private void btnSetupPrinter_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                Config.PrinterName=textBoxPrinter.Text = printDialog1.PrinterSettings.PrinterName;
                Config.Save();
            }
        }

        private void ShowInfomation()
        {
            listBoxInfo.Items.Add(m_Printer.Title);
            listBoxInfo.Items.Add(m_Printer.Address);
            listBoxInfo.Items.Add(m_Printer.Tel);
            listBoxInfo.Items.Add("");
            listBoxInfo.Items.Add("");
            listBoxInfo.Items.Add(CashierName(m_CashierID) + "你好!, 你的登入号是 " + m_CashierID.ToString() + " 号");
            DateTime now=DateTime.Now;
            listBoxInfo.Items.Add("今天是"+now.ToString("MM月dd日")+" "+now.DayOfWeek.ToString());
            if (m_PosID <= 0 || m_PosID>9)
                listBoxInfo.Items.Add("店長尚未指定本机机号");
            else
                listBoxInfo.Items.Add("店長指定本机為 <收銀机" + m_PosID + ">");
        }

        private void btnLoginReturns_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
            Form formreturnpurchase = new FormReturnedPurchase(m_CashierID,m_Printer,m_PosID,m_CashierName);
            this.Hide();
            formreturnpurchase.ShowDialog();
            
        }
    }
}
