using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class SaleSpendRatio : Form
    {
        OrderAdapter m_OrderAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemAdapter = new OrderItemAdapter();

        class OrderAdapter : BasicDataSetTableAdapters.OrderTableAdapter
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
        class OrderItemAdapter : BasicDataSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BasicDataSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        string DateStr(DateTime da)
        {
            return DateStr(da.Year, da.Month, da.Day);
        }
        string DateStr(int y, int m, int d)
        {
            return (y % 100).ToString() + m.ToString("d2") + d.ToString("d2");
        }
        int IDTagHead(int y, int m, int d)
        {
            int tag = y % 100;
            tag = tag * 10000 + m * 100 + d;
            return tag;
        }
        void LoadData(int year, int month, int from, int to, bool Use12)
        {
            string sql;
            try
            {
                if (Use12)
                {
                    TimeSpan oneDay = new TimeSpan(24, 0, 0);
                    DateTime prev = new DateTime(year, month, from).Subtract(oneDay);
                    DateTime next = new DateTime(year, month, to);
                    sql = "Where (INT(ID/10000)>=" + DateStr(prev)
                        + " And INT(ID/10000)<=" + DateStr(next) + ")";
                    BasicDataSet.OrderDataTable temp = new BasicDataSet.OrderDataTable();
                    m_OrderAdapter.FillBySelectStr(temp, "Select * From [Order] " + sql + " Order by ID");
                    int nextID = IDTagHead(next.Year, next.Month, next.Day);
                    int prevID = IDTagHead(prev.Year, prev.Month, prev.Day);
                    basicDataSet.Order.Clear();
                    foreach (BasicDataSet.OrderRow r in temp)
                    {
                        int idHead = r.ID / 10000;
                        if (idHead == nextID)
                        {
                            if (r.PrintTime.Hour < 7) continue;
                        }
                        else if (idHead == prevID)
                        {
                            if (r.PrintTime.Hour >= 7) continue;
                        }
                        BasicDataSet.OrderRow oRow = basicDataSet.Order.NewOrderRow();
                        oRow.ItemArray = r.ItemArray;
                        basicDataSet.Order.AddOrderRow(oRow);
                    }
                }
                else
                {
                    sql = "Where (INT(ID/10000)>=" + DateStr(year, month, from)
                        + " And INT(ID/10000)<=" + DateStr(year, month, to) + ")";
                    m_OrderAdapter.FillBySelectStr(basicDataSet.Order, "Select * From [Order] " + sql + " Order by ID");
                }
                m_OrderItemAdapter.FillBySelectStr(basicDataSet.OrderItem, "Select * From [OrderItem] " + sql);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("訂菜單資料庫讀取錯誤!");
            }
        }

        private decimal CalcSaleList(int month)
        {
            if (month < 1 || month > 12)
            {
                MessageBox.Show("所選月份<" + month.ToString() + ">不對!");
                return 0;
            }
            int count = m_SaleList.Count;
            if (count <= 1) return 0;
            int year = MyFunction.IntHeaderYear;
            int to = MyFunction.DayCountOfMonth(month);
            if (month == 2 && DateTime.IsLeapYear(year)) to = 29;
            LoadData(year, month, 1, to, true);   // 一律稅控制
            foreach (CSaleItem m in m_SaleList)
            {
                m.Total = 0;
                m.Volume = 0;
            }
            bool[] debug = new bool[count];   // items code會重複, 不知為何 ,只好用此辦法
            foreach (BasicDataSet.OrderRow row in basicDataSet.Order)
            {
                BasicDataSet.OrderItemRow[] items = row.GetOrderItemRows();
                for (int i = 0; i < count; i++) debug[i] = false;
                foreach (BasicDataSet.OrderItemRow it in items)
                {
                    for (int i = 0; i < m_SaleList.Count; i++)
                    {
                        CSaleItem m = m_SaleList[i];
                        if (m.Code == it.Code)
                        {
                            if (debug[i]) break;        // 重複算了二次, items存入有bug,只好先跳掉
                            debug[i] = true;
                            m.Volume += it.No;
                            if (it.Discount)
                                m.Total += it.Price * it.No * 0.88m;
                            else
                                m.Total += it.Price * it.No;
                            break;
                        }
                    }
                }
            }
            decimal sum=0;
            foreach (CSaleItem item in m_SaleList) sum += item.Total;
            return sum;
            
//            materialBindingSource.ResetBindings(false);
//            Text = "物料統計 " + month.ToString() + "月 " + from.ToString() + "日 至 " + to.ToString() + "日";
//            if (ckBoxUse12.Checked) Text += "  稅控制";
        }

        decimal CalcStockList(int month)
        {
            List<StockItem> list = new List<StockItem>();
            foreach (StockItem item in m_StockList)
                list.Add(new StockItem(item.Code));
            VEDataSet.VoucherDataTable voucher = new VEDataSet.VoucherDataTable();
            int count = 0, checkedCount = 0;
            foreach (VEDataSet.VoucherRow vr in vEDataSet.Voucher)
            {
                if (vr.IsStockTimeNull()) continue;
                if (month != 0)
                {
                    if (vr.StockTime.Month != month) continue;
                }
                if (vr.StockTime.Year != MyFunction.IntHeaderYear) continue;
                if (!vr.IsRemovedNull())
                    if (vr.Removed) continue;
                VEDataSet.VoucherRow row = voucher.NewVoucherRow();
                row.ItemArray = vr.ItemArray;
                voucher.AddVoucherRow(row);
                count++;
                if (vr.Locked) checkedCount++;
                decimal checkSum = 0;
                foreach (VEDataSet.VoucherDetailRow dr in vr.GetVoucherDetailRows())
                {
                    if (dr.IsIngredientCodeNull()) continue;

                    decimal co = 0, vo = 0;
                    if (!dr.IsCostNull()) co = dr.Cost;
                    
                    checkSum += co;
                    int code = dr.IngredientCode;
                    foreach (StockItem p in list)
                    {
                        if (p.Code == code)
                        {
                            p.TotalCost += co;
                            p.OrderCount++;
                            if (!dr.IsVolumeNull()) vo = dr.Volume;
                            p.Volume += vo;
                            if (p.Volume != 0)
                                p.UnitCost = p.TotalCost / p.Volume;
                            break;
                        }
                    }
                }
                decimal vrCost = 0;
                if (!vr.IsCostNull()) vrCost = vr.Cost;
                if (checkSum != vrCost)
                    MessageBox.Show("警告!<" + vr.VoucherID.ToString() +
                        ">號細項和" + checkSum.ToString("f1") +
                        "和總和" + vr.Cost.ToString("f1") + "不符!");
            }
            m_StockList = list;
            decimal sum = 0;
            foreach (StockItem p in list)
                sum += p.TotalCost;
            return sum;
            
//            textBox1.Text = sum.ToString("N1");

//            labelCount.Text = "共 " + checkedCount.ToString() + "單(" + count.ToString() + ")";
//            this.dataGridView1.DataSource = list;
//            this.voucherDGView.DataSource = voucher;
        }


    }
}
