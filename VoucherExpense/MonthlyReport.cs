using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class MonthlyReport : Form
    {
        
        public MonthlyReport()
        {
            InitializeComponent();
        }

        RevenueCalc Revenue;
        private void MonthlyReport_Load(object sender, EventArgs e)
        {
            decimal FeeRate = 1.8m;
            try
            {
                headerTableAdapter1.Connection = MapPath.BasicConnection;
                headerTableAdapter1.Fill(basicDataSet1.Header);
                TitleSetup Setup = new TitleSetup();
                Setup.Load();
                FeeRate = Setup.FeeRate();
            }
            catch
            {
                MessageBox.Show("標頭資料讀取錯誤,你的資料庫版本可能不對");
            }
            int count=basicDataSet1.Header.Count;
            if (count == 0)
            {
                MessageBox.Show("無資料!");
                Close();
                return;
            }
            BasicDataSet.HeaderRow row = basicDataSet1.Header[count - 1];
            Revenue = new RevenueCalc(row.DataDate,FeeRate/100);
            comboBoxMonth.SelectedIndex = row.DataDate.Month - 1;
            labelFeeRate.Text = FeeRate.ToString() + "%";
        }

        
//        OrderItemAdapter m_OrderItemAdapter = new OrderItemAdapter();

 

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
                if (Revenue.LoadData(basicDataSet1, year, month, i,checkBoxUse12.Checked))
                    list.Add(Revenue.Statics(basicDataSet1));
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

        private void MonthlyReport_SizeChanged(object sender, EventArgs e)
        {
            dgViewMonthly.Size = new Size(dgViewMonthly.Width, ClientSize.Height - 43);
        }

        private void checkBoxUse12_CheckedChanged(object sender, EventArgs e)
        {
            Calc();
        }


    }

    public class MonthlyReportData
    {
        public uint Date            { get; set; }
        public decimal Revenue      { get; set; }
        public decimal Cash         { get; set; }
        public decimal CreditCard   { get; set; }
        public decimal CreditFee    { get; set; }
        public decimal CreditNet    { get; set; }
        public int OrderCount       { get; set; }
        public decimal AvePerPerson { get; set; }
    }
}