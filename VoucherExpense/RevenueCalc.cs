using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VoucherExpense
{
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

        class WorkingDay
        {
            private DateTime m_Date;
            public int Year { get { return m_Date.Year; } }
            public int Month { get { return m_Date.Month; } }
            public int Day { get { return m_Date.Day; } }
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
            public BasicDataSet.HeaderRow HeaderRow(BasicDataSet.HeaderDataTable header)
            {
                foreach (BasicDataSet.HeaderRow row in header)
                {
                    if (row.DataDate.Day != m_Date.Day) continue;
                    if (row.DataDate.Month != m_Date.Month) continue;
                    if (row.DataDate.Year != m_Date.Year) continue;
                    return row;
                }
                return null;
            }
            public override string ToString()
            {
                return m_Date.ToShortDateString();
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
            decimal cash = 0, credit = 0;
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
            }
            data.OrderCount = basicDataSet1.Order.Count;
            data.Cash = Math.Round(cash);
            data.Date = (uint)m_WorkingDay.Day;
            data.CreditCard = Math.Round(credit);
            data.CreditFee = Math.Round(FeeRate * data.CreditCard, 2);
            data.CreditNet = data.CreditCard - data.CreditFee;
            if (people != 0)
                data.AvePerPerson = Math.Round((cash + credit) / people, 1);
            data.Revenue = Math.Round(cash + credit);
            return data;
        }
    }
}
