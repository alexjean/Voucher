using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#if UseSQLServer
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyHeaderAdapter = VoucherExpense.DamaiDataSetTableAdapters.HeaderTableAdapter;
#else
using MyDataSet = VoucherExpense.BakeryOrderSet;
using MyHeaderAdapter = VoucherExpense.BakeryOrderSetTableAdapters.HeaderTableAdapter;
#endif

namespace VoucherExpense
{
    public partial class MonthlyReportBakery : Form
    {
        
        public MonthlyReportBakery()
        {
            InitializeComponent();
        }

        RevenueCalcBakery Revenue;
        MyDataSet m_DataSet = new MyDataSet();
        private void MonthlyReportBakery_Load(object sender, EventArgs e)
        {
            decimal FeeRate = 1.8m;
            try
            {
                var headerAdapter = new MyHeaderAdapter();
#if (!UseSQLServer)
                headerAdapter.Connection = MapPath.BakeryConnection;
#endif
                headerAdapter.Fill(m_DataSet.Header);
                TitleSetup Setup = new TitleSetup();
                Setup.Load();
                FeeRate = Setup.FeeRate();
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
            }
            int count = m_DataSet.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            var row = m_DataSet.Header[count - 1];
            Revenue = new RevenueCalcBakery(row.DataDate, FeeRate / 100);
            comboBoxMonth.SelectedIndex = row.DataDate.Month - 1;
            labelFeeRate.Text = FeeRate.ToString() + "%";
        }

        void Calc()
        {
            int year = Revenue.Year;
            int month = comboBoxMonth.SelectedIndex + 1;
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份不對!");
                return;
            }
            int count = MyFunction.DayCountOfMonth(month);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            List<MonthlyReportData> list = new List<MonthlyReportData>();
            for (int i = 1; i <= count; i++)
            {
                if (Revenue.LoadData(m_DataSet, month, i)) list.Add(Revenue.Statics(m_DataSet));
                progressBar1.Value = i;
                Application.DoEvents();
            }
            dgViewMonthly.DataSource = list;
            progressBar1.Visible = false;
            MonthlyReportData total = new MonthlyReportData();
            foreach (MonthlyReportData d in list)
            {
                total.Revenue += d.Revenue;
                total.OrderCount += d.OrderCount;
                total.Cash += d.Cash;
                total.CreditCard += d.CreditCard;
                total.CreditFee += d.CreditFee;
                total.CreditNet += d.CreditNet;
            }
            labelCash.Text = total.Cash.ToString();
            labelCredit.Text = total.CreditCard.ToString();
            labelOrderCount.Text = total.OrderCount.ToString();
            labelRevenue.Text = total.Revenue.ToString();
            labelCreditFee.Text = total.CreditFee.ToString();
            labelCreditNet.Text = total.CreditNet.ToString();

        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calc();
            dgViewMonthly.Focus();
        }

        private void checkBoxUse12_CheckedChanged(object sender, EventArgs e)
        {
            Calc();
        }

     


    }


}