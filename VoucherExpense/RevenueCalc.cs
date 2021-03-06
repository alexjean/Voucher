﻿//#define UseSQLServer
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoucherExpense
{
    class WorkingDay
    {
        private DateTime m_Date;
        public int Year { get { return m_Date.Year; } }
        public int Month { get { return m_Date.Month; } }
        public int Day { get { return m_Date.Day; } }
        public DateTime Date { get { return m_Date; } }
        public static int IDTagHead(int y, int m, int d)
        {
            int tag = y % 100;
            tag = tag * 10000 + m * 100 + d;
            return tag;
        }
        public int IDTag()
        {
            DateTime t = m_Date;
            return IDTagHead(t.Year, t.Month, t.Day) * 10000;
        }
        public void Set(DateTime t)
        {
            m_Date = t;
        }

        public string ChineseDateString()
        {
            return Year.ToString("d2") + "年" + Month.ToString("d2") + "月" + Day.ToString("d2") + "日";
        }

        public override string ToString()
        {
            return m_Date.ToShortDateString();
        }
    }

    class RevenueCalc
    {
        WorkingDay m_WorkingDay;
        decimal FeeRate = 0;
        public RevenueCalc(DateTime d,decimal feeRate)
        {
            FeeRate = feeRate;
            m_WorkingDay = new WorkingDay();
            m_WorkingDay.Set(d);
            m_OrderAdapter.Connection = MapPath.BasicConnection;
        }
        public int Year { get { return m_WorkingDay.Year; } }

        
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        public class OrderAdapter : BasicDataSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        string DateStr(int y, int m, int d)
        {
            return (y % 100).ToString() + m.ToString("d2") + d.ToString("d2");
        }

        string CreateSql(int year, int month, int day,bool Use12)
        {
            string str1 = DateStr(year, month, day);
            if (!Use12)
                return "Where INT(ID/10000)=" + str1;
            DateTime prev = new DateTime(year, month, day);
            prev = prev.Subtract(new TimeSpan(24, 0, 0));
            return "Where (INT(ID/10000)=" + DateStr(prev.Year, prev.Month, prev.Day)
                  + " OR INT(ID/10000)=" + str1 + ")";
        }

        public bool LoadData(BasicDataSet basicDataSet1,int year, int month, int day, bool Use12)
        {
            int count = basicDataSet1.Header.Rows.Count;
            if (count == 0) return false;
            if (month < 1 || month > 12) return false;
            if (day < 1 || day > 31) return false;
            if (year < 2008 || year > 2020) return false;
            BasicDataSet.HeaderRow row;
            foreach (BasicDataSet.HeaderRow r in basicDataSet1.Header.Rows)
            {
                if (r.DataDate.Month != month) continue;
                if (r.DataDate.Year != year) continue;
                if (r.DataDate.Day == day)
                {
                    row = r;
                    goto Yes;
                }
            }
            return false;
        Yes:
            string sql = CreateSql(row.DataDate.Year, row.DataDate.Month, row.DataDate.Day,Use12);
            try
            {
                if (Use12)
                {
                    BasicDataSet.OrderDataTable temp = new BasicDataSet.OrderDataTable();
                    m_OrderAdapter.FillBySelectStr(temp, "Select * From [Order] " + sql + " Order by ID");
                    int todayID = WorkingDay.IDTagHead(year, month, day);
                    DateTime d = new DateTime(year, month, day);
                    d = d.Subtract(new TimeSpan(24, 0, 0));
                    int prevID = WorkingDay.IDTagHead(d.Year, d.Month, d.Day);
                    basicDataSet1.Order.Clear();
                    foreach (BasicDataSet.OrderRow r in temp)
                    {
                        int idHead = r.ID / 10000;
                        if (idHead == todayID)
                        {
                            if (r.PrintTime.Hour < 7) continue;
                        }
                        else if (idHead == prevID)
                        {
                            if (r.PrintTime.Hour >= 7) continue;
                        }
                        BasicDataSet.OrderRow oRow = basicDataSet1.Order.NewOrderRow();
                        oRow.ItemArray = r.ItemArray;
                        basicDataSet1.Order.AddOrderRow(oRow);
                    }
                }
                else
                    m_OrderAdapter.FillBySelectStr(basicDataSet1.Order, "Select * From [Order] " + sql + " Order by ID");
                //                m_OrderItemAdapter.FillBySelectStr(basicDataSet1.OrderItem, "Select * From [OrderItem] " + sql);
                m_WorkingDay.Set(row.DataDate);
                return true;
            }
            catch (Exception ex)
            {
                LastErrorString=ex.Message;
            }
            return false;
        }

        public string LastErrorString = "";

        public MonthlyReportData Statics(BasicDataSet basicDataSet1)
        {
            decimal cash = 0, credit = 0,deduct=0;
            int people = 0;
            MonthlyReportData data = new MonthlyReportData();
            foreach (BasicDataSet.OrderRow row in basicDataSet1.Order)
            {
                if (row.IsCreditIDNull() || row.CreditID == 0)
                    cash += row.Income;
                else
                    credit += row.Income;
                if (!row.IsPeopleNoNull())
                    people += row.PeopleNo;
                if (!row.IsDeductNull())
                    deduct+= row.Deduct;
            }
            data.OrderCount = basicDataSet1.Order.Count;
            data.Cash = Math.Round(cash);
            data.Date = m_WorkingDay.Date;
            data.CreditCard = Math.Round(credit);
            data.CreditFee = Math.Round(FeeRate * data.CreditCard, 2);
            data.CreditNet = data.CreditCard - data.CreditFee;
            data.Deduct = Math.Round(deduct);
            if (people != 0)
                data.AvePerPerson = Math.Round((cash + credit) / people, 1);
            data.Revenue = Math.Round(cash + credit);
            return data;
        }
    }

    class RevenueCalcBakery
    {
        public WorkingDay m_WorkingDay;
        decimal FeeRate = 0;
        public int Year { get { return m_WorkingDay.Year; } }
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        // BakeryOrderSet.Order.ID ==> MMDDN99999

#if (UseSQLServer)
        string CreateSql(int m, int d)
        {
            return "Where FLOOR(ID/1000000)=" + m.ToString("d2") + d.ToString("d2");
        }

        public RevenueCalcBakery(DateTime d, decimal feeRate)
        {
            FeeRate = feeRate;
            m_WorkingDay = new WorkingDay();
            m_WorkingDay.Set(d);
        }

        public class OrderAdapter : DamaiDataSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        public bool LoadData(DamaiDataSet orderSet, int month, int day)
        {
            int count = orderSet.Header.Rows.Count;
            if (count == 0) return false;
            if (month < 1 || month > 12) return false;
            if (day < 1 || day > 31) return false;
            DamaiDataSet.HeaderRow row;
            foreach (var r in orderSet.Header)
            {
                if (r.DataDate.Year != MyFunction.IntHeaderYear) continue; 
                if (r.DataDate.Month != month) continue;
                if (r.DataDate.Day == day)
                {
                    row = r;
                    goto Yes;
                }
            }
            return false;
        Yes:
            string sql = CreateSql(row.DataDate.Month, row.DataDate.Day);
            try
            {
                m_OrderAdapter.FillBySelectStr(orderSet.Order, "Select * From [Order] " + sql + " Order by ID");
                m_WorkingDay.Set(row.DataDate);
                return true;
            }
            catch (Exception ex)
            {
                LastErrorString = ex.Message;
                if (MessageBox.Show(LastErrorString, "", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                {
                    throw ex;
                }
            }
            return false;
        }

        public string LastErrorString = "";

        public MonthlyReportData Statics(DamaiDataSet orderSet)
#else
        string CreateSql(int m, int d)
        {
            return "Where INT(ID/1000000)=" + m.ToString("d2") + d.ToString("d2");
        }

        public RevenueCalcBakery(DateTime d, decimal feeRate)
        {
            FeeRate = feeRate;
            m_WorkingDay = new WorkingDay();
            m_WorkingDay.Set(d);
            m_OrderAdapter.Connection = MapPath.BakeryConnection;
        }

        public class OrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }

        public bool LoadData(BakeryOrderSet bakeryOrderSet, int month, int day)
        {
            int count = bakeryOrderSet.Header.Rows.Count;
            if (count == 0) return false;
            if (month < 1 || month > 12) return false;
            if (day < 1 || day > 31) return false;
            BakeryOrderSet.HeaderRow row;
            foreach (BakeryOrderSet.HeaderRow r in bakeryOrderSet.Header.Rows)
            {
                if (r.DataDate.Year != MyFunction.IntHeaderYear) continue; 
                if (r.DataDate.Month != month) continue;
                if (r.DataDate.Day == day)
                {
                    row = r;
                    goto Yes;
                }
            }
            return false;
        Yes:
            string sql = CreateSql(row.DataDate.Month, row.DataDate.Day);
            try
            {
                m_OrderAdapter.FillBySelectStr(bakeryOrderSet.Order, "Select * From [Order] " + sql + " Order by ID");
                m_WorkingDay.Set(row.DataDate);
                return true;
            }
            catch (Exception ex)
            {
                LastErrorString = ex.Message;
                if (MessageBox.Show(ex.Message, "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    throw ex;
                }
            }
            return false;
        }

        public string LastErrorString = "";

        public MonthlyReportData Statics(BakeryOrderSet orderSet)
#endif
        {
            decimal cash = 0, credit = 0, deduct = 0,alipay=0,couponA=0,couponB=0,wxpay=0;
            decimal deletedMoney = 0, returnedMoney = 0, TwentyPDMoney = 0, FifteenPDMoney = 0, TenPDMoney=0;
            int orderCount = 0, deletedCount = 0, returnedCount = 0, TwentyPDCount = 0, FifteenPDCount=0, TenPDCount=0;
            MonthlyReportData data = new MonthlyReportData();
            foreach (var row in orderSet.Order)
            {
                decimal income;
                if (row.IsIncomeNull()) income = 0m;
                else                    income = row.Income;
                if (!row.IsDeletedNull() && row.Deleted)
                {
                    deletedMoney += income;
                    deletedCount++;
                    continue;
                }
                if (row.IsPayByNull() || row.PayBy == "A")   // A現金 B刷卡 C支付宝 D券
                    cash += income;
                else if (row.PayBy == "B")
                    credit += income;
                else if (row.PayBy == "C")
                    alipay += income;
                else if (row.PayBy == "E")
                    wxpay  += income;
                else if (row.PayBy == "D")
                {
                    if (!row.IsCashIncomeNull())
                        cash += row.CashIncome;
                    if (!row.IsCouponIncomeNull())
                    {
                        if (row.CouponIncome > income)
                            couponA += income;            // 收券大於應收,只計應收
                        else
                            couponA += row.CouponIncome;
                    }
                }
                else if (row.PayBy == "F")
                {
                    if (!row.IsCashIncomeNull())
                        cash += row.CashIncome;
                    if (!row.IsCouponIncomeNull())
                    {
                        if (row.CouponIncome > income)
                            couponB += income;            // 收券大於應收,只計應收
                        else
                            couponB += row.CouponIncome;
                    }
                }
                if (!row.IsDeductNull()) deduct += row.Deduct;
                if (income >= 0)     // 退貨的不計入單數
                    orderCount++;    //  一單一人
                else
                {
                    returnedMoney += income;
                    returnedCount++;
                }
                if (!row.IsDiscountRateNull())
                {
                  if(  row.DiscountRate==(decimal)0.80)
                {
                    TwentyPDMoney += income;
                    TwentyPDCount++;
                }
                  if (row.DiscountRate==(decimal)0.85)
                  {
                      FifteenPDMoney += income;
                      FifteenPDCount++;
                  }
                  if (row.DiscountRate==(decimal)0.90)
                  {
                      TenPDMoney += income;
                      TenPDCount++;
                  }
                }
            }
            data.OrderCount = orderCount;
            data.Cash    = Math.Round(cash);
            data.Alipay = Math.Round(alipay);
            data.Wxpay  = Math.Round(wxpay);
            data.CouponA = Math.Round(couponA);
            data.CouponB = Math.Round(couponB);
            data.Deduct = Math.Round(deduct);
            data.Date = m_WorkingDay.Date;
            data.CreditCard = Math.Round(credit);
            data.CreditFee = Math.Round(FeeRate * data.CreditCard, 2);
            data.CreditNet = data.CreditCard - data.CreditFee;
            if (orderCount != 0)
                data.AvePerPerson = Math.Round((cash + credit + alipay+wxpay+couponA+couponB) / orderCount, 1);
            data.Revenue = Math.Round(cash + credit + alipay+wxpay+couponA+couponB);

            data.DeletedCount = deletedCount;
            data.DeletedMoney = Math.Round(deletedMoney);

            data.ReturnedCount = returnedCount;
            data.ReturnedMoney = Math.Round(returnedMoney);
            data.TwentyPDCount = TwentyPDCount;
            data.TwentyPDMoney = Math.Round(TwentyPDMoney);
            return data;
        }
    }
}
