using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyOrderRow        = VoucherExpense.DamaiDataSet.OrderRow;
using MyDrawerRecordRow = VoucherExpense.DamaiDataSet.DrawerRecordRow;
using Com.Alipay;

namespace VoucherExpense
{
    public partial class BakeryOrderBrowse : Form
    {
        private static class MyLayout
        {
            public static int NoX = 10;
            public static int NoY = 10;
            public static int OffsetX = 6;
            public static int OffsetY = 6;
            public static int NoWidth = 2;
        }

        public class HourStatics
        {
            public int Hour { get; set; }
            public int OrderCount { get; set; }
            public decimal Revenue { get; set; }
            public decimal Average { get; set; }
            public HourStatics(int hour) { Hour = hour; }
        }

        public BakeryOrderBrowse()
        {
            InitializeComponent();
        }

        string[] m_ListViewItemBackup;
        TabPage m_TabPageStatics = null;

        DamaiDataSet m_OrderSet = new DamaiDataSet();
        string FloorStr = "FLOOR";
        class OrderAdapter : DamaiDataSetTableAdapters.OrderTableAdapter
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
        class OrderItemAdapter : DamaiDataSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        class DrawerRecordAdapter : DamaiDataSetTableAdapters.DrawerRecordTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(DamaiDataSet.DrawerRecordDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        OrderAdapter m_OrderTableAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemTableAdapter = new OrderItemAdapter();
        DrawerRecordAdapter m_DrawerReocrdAdapter = new DrawerRecordAdapter();
        private void BakeryOrderBrowse_Load(object sender, EventArgs e)
        {

            var productAdapter = new DamaiDataSetTableAdapters.ProductTableAdapter();
            productAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
            try
            {
                productAdapter.Fill(m_OrderSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入烘焙產品表時出錯,原因:" + ex.Message);
            }
            m_ListViewItemBackup = new string[lvItems.Columns.Count]; // 備份給ResetListView用
            for (int i = 1; i < lvItems.Columns.Count; i++)
                m_ListViewItemBackup[i] = lvItems.Columns[i].Text;
            cbBoxMonth.SelectedIndexChanged += new EventHandler(cbBoxMonth_SelectedIndexChanged);
            cbBoxMonth.SelectedIndex = DateTime.Now.Month - 1;
            cbBoxDay.SelectedIndex = DateTime.Now.Day - 1;
            if (tabControl1.TabCount < 1)
            {
                MessageBox.Show("程式錯誤! 應該有統計頁!");
            }
            else 
                m_TabPageStatics = this.tabControl1.TabPages[0];     // 為避免被清除,存起統計頁
        }

        int LoadData(int m, int d)
        {

            string sql = "Where "+FloorStr+"(ID/1000000)=" + m.ToString("d2") + d.ToString("d2");
            int MaxID = 0;
            try
            {
                m_OrderSet.OrderItem.Rows.Clear();
                m_OrderSet.Order.Rows.Clear();
                m_OrderTableAdapter.FillBySelectStr(m_OrderSet.Order, "Select * From [Order] " + sql + " Order by ID");
                m_OrderItemTableAdapter.FillBySelectStr(m_OrderSet.OrderItem, "Select * From [OrderItem] " + sql);
                foreach (var R in m_OrderSet.Order)
                {
                    int id = PureID(R.ID);       // 資料定義為 MMDDNN9999  N POS机号,店長收資料時,再自動填上
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("Order OrderItem讀取錯誤!" + str);
                return -1;
            }
        }

        int LoadDrawerRecordData(int m, int d)
        {
            string sql = "Where "+FloorStr+"(DrawerRecordID/1000000)=" + m.ToString("d2") + d.ToString("d2");
            int MaxID = 0;
            try
            {
                m_DrawerReocrdAdapter.FillBySelectStr(m_OrderSet.DrawerRecord, "Select * From [DrawerRecord] " + sql);
                foreach (var R in m_OrderSet.DrawerRecord)
                {
                    int id = PureID(R.DrawerRecordID);       // 資料定義為 MMDDN99999  N POS机号比Order.ID少一位, id最多10萬筆多十倍
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("DrawerRecord讀取錯誤!" + str);
                return -1;
            }
        }

        int PureID(int id)
        {
            return id % 100000;
        }
        string PureIDStr(int id)
        {
            return (id%100000).ToString();
        }

        string PurePosNoStr(int id)
        {
            id = (id / 100000)%10;
            return id.ToString();
        }



        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Regular);
                //                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshBack = new SolidBrush(Color.FromArgb(216, 228, 248));
                bshFore = Brushes.Black;
                // 把標簽後的Control色填成背景色
                int count = tabControl1.TabPages.Count - 1;
                if (count < 0) return;
                Rectangle endRect = tabControl1.GetTabRect(count);
                Point pt = new Point(endRect.X + endRect.Width, endRect.Y);
                Size sz = new Size(tabControl1.Width - endRect.X - endRect.Width, endRect.Height);
                Rectangle headerRect = new Rectangle(pt, sz);
                e.Graphics.FillRectangle(new SolidBrush(Color.Azure), headerRect);
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.Azure);
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X + 3, recTab.Y + 3, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        private TabPage AddTabControl1Item(string name)
        {
            tabControl1.TabPages.Add(name);
            TabPage page = tabControl1.TabPages[tabControl1.TabCount - 1];
            page.BackColor = Color.FromArgb(216,228,248);
            page.Font = new Font("標楷體", 14.25f);
            return page;
        }
        void CreateLabel(TabPage tabPage, int x, int y, MyOrderRow Row,int WidthX,int HeightY )
        {
            if (Row == null) return;
            string mark = "St" + tabPage.Name + DateTime.Now.Ticks.ToString();  //避免多次進入,label重名了
            int xx, yy;
            xx = MyLayout.OffsetX + x * WidthX;
            yy = MyLayout.OffsetY + y * HeightY;
            TextBox b = new TextBox();
            b.MouseClick+=new MouseEventHandler(b_MouseClick);
            b.MouseDoubleClick += new MouseEventHandler(b_MouseDoubleClick);
            b.Multiline = true;
            b.Font = SystemFonts.MenuFont;
            b.AutoSize = false;
            b.Location = new System.Drawing.Point(xx, yy);
            b.Name = mark + "X" + x.ToString() + "Y" + y.ToString();
            b.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
            b.TabIndex = 0;
            b.BackColor = tabPage.BackColor;
            if (!Row.IsPrintTimeNull())
                b.Text =  Row.PrintTime.ToString("mm:ss");
            b.Text += "\r\n" + PurePosNoStr(Row.ID)+"-"+PureIDStr(Row.ID);
            if (!Row.IsPayByNull())
            {
                if (Row.PayBy == "B")      b.Text += "卡";
                else if (Row.PayBy == "C") b.Text += "支";
                else if (Row.PayBy == "D") b.Text += "A";
                else if (Row.PayBy == "E") b.Text += "微";
                else if (Row.PayBy == "F") b.Text += "B";
            }
            decimal income = 0;
            if (!Row.IsIncomeNull())
                income = Math.Round(Row.Income, 2);
            b.Text += "\r\n" + income.ToString("N0")+"元";

            if (!Row.IsDeletedNull() && Row.Deleted)         b.BackColor = Color.Green;
            else if (income < 0)                             b.BackColor = Color.Pink;
            else if (!Row.IsDeductNull() && Row.Deduct != 0) b.BackColor = Color.Azure;
            b.Tag = Row;
            b.TextAlign = HorizontalAlignment.Center;
            b.BorderStyle = BorderStyle.Fixed3D;
            tabPage.Controls.Add(b);
        }

        string  FindNameFromProduct(int productID)
        {
            foreach (var row in m_OrderSet.Product)
            {
                if (productID == row.ProductID) return row.Name;
            }
            return "";
        }

        void ResetListView()
        {
            lvItems.Items.Clear();
            for(int i=1;i<lvItems.Columns.Count;i++)
                lvItems.Columns[i].Text = m_ListViewItemBackup[i];
        }

        private bool ShowOrder(MyOrderRow order)
        {
            var items = order.GetOrderItemRows();
            lvItems.Items.Clear();
            decimal total = 0;
            int count = 0; ;
            foreach (var item in items)
            {
                if (item.RowState == DataRowState.Deleted) continue;
                if (item.IsNoNull()) continue;
                if (item.IsProductIDNull()) continue;
                if (item.IsPriceNull()) item.Price = 0m;
                decimal no = item.No;
                decimal money = item.Price * no;
                int productID = item.ProductID;
                ListViewItem lvItem = lvItems.Items.Add(productID.ToString());
                lvItem.SubItems.Add(FindNameFromProduct(productID));
                lvItem.SubItems.Add(no.ToString("N0"));
                lvItem.SubItems.Add(money.ToString("N0"));
                total += money;
                count++;
            }
            // 計算折扣
            if (!order.IsDiscountRateNull())
            {
                decimal discountRate = order.DiscountRate;
                if (discountRate != 0m && discountRate != 1m)
                    total = Math.Floor(total * discountRate);
            }

            lvItems.Columns[1].Text = "ID " + PureIDStr(order.ID) + (order.Deleted ? " deleted" : "");
            lvItems.Columns[2].Text = count.ToString();
            lvItems.Columns[3].Text = total.ToString("N0");

            labelReturned.Visible = false;
            labelMemberID.Visible = false;
            if (!order.IsIncomeNull())
            {
                if (!order.IsDeductNull())
                {
                    if (order.Income < 0) total += order.Deduct;
                    else                  total -= order.Deduct;
                }
                decimal income = Math.Round(order.Income, 2);
                if (total != order.Income)
                {
                    if (order.Income < 0 && total == (-order.Income))
                    {
                        labelReturned.Text = "收銀" + order.CashierID + " 授權" + order.RCashierID.ToString() + "  退單" + order.OldID.ToString();
                        labelReturned.Visible = true;
                        return true;
                    }
                    MessageBox.Show("計算金額<" + total.ToString() + ">不符 " + income.ToString());
                    return false;
                }
                else
                {
                    labelReturned.Text = "收銀 " + order.CashierID;
                    if (!order.IsPrintTimeNull())
                        labelReturned.Text+="     時間 " + order.PrintTime.ToString("HH:mm:ss");
                    labelReturned.Visible = true;
                }
            }
            if (!order.IsMemberIDNull() && order.MemberID!="")
            {
                labelMemberID.Text = "会员" + order.MemberID;
                labelMemberID.Visible = true;
            }
            return true;
        }

        private void b_DrawerRecordMouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            BakeryOrderSet.DrawerRecordRow record = t.Tag as BakeryOrderSet.DrawerRecordRow;
            ResetListView();
            if (record.IsAssociateOrderIDNull() || record.AssociateOrderID < 0) return;
            var Orders = from row in m_OrderSet.Order where (row.ID%1000000 == record.AssociateOrderID) select row;   // 要含Pos机号
            if (Orders.Count() > 0) ShowOrder(Orders.First());
        }

        private void b_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            var row = t.Tag as MyOrderRow;
            labelDeductLabel.Visible = false;
            if ((!row.IsDeductNull()) && row.Deduct != 0)
            {
                labelDeductLabel.Visible = true;
                labelDeduct.Visible = true;
                labelDeduct.Text = row.Deduct.ToString("N0");
            }
            else
            {
                labelDeduct.Visible = false;
                labelDeductLabel.Visible = false;
            }
            decimal income = 0;
            if (!row.IsIncomeNull())
                income=Math.Round( row.Income,2);
            if (!row.IsDiscountRateNull() && row.DiscountRate != 1m)
                labelTotal.Text = (row.DiscountRate*100).ToString("F0") + "折 "+income.ToString("N0");
            else
                labelTotal.Text = income.ToString("N0");

            labelAlipayNo.Text = "";
            if (row.PayBy[0] == 'D' || row.PayBy[0]=='F')
            {
                if (row.PayBy[0]=='D') labelAlipayNo.Text += "收券A ";
                else                   labelAlipayNo.Text += "收券B ";
                if (!row.IsCouponIncomeNull())
                    labelAlipayNo.Text += row.CouponIncome.ToString("N0");
                if (!row.IsCashIncomeNull() && row.CashIncome != 0m)
                    labelAlipayNo.Text += " 收现 " + row.CashIncome.ToString("N0");
                labelAlipayNo.Text += "\r\n";
                labelAlipayNo.Visible = true;
            }
            if (row.IsTradeNoNull() || row.TradeNo=="")
            {
//                labelAlipayNo.Visible = false;
                btnAlipayRefund.Visible = false;
            }
            else
            {
                m_OutTradeNo = m_TradeNo = null;
                if ((!row.IsOpenIDNull()) && row.OpenID == "00000")
                    m_OutTradeNo = row.TradeNo;
                else
                    m_TradeNo    = row.TradeNo;
                m_Amount  = row.Income;
                m_OrderRow = row;
                m_LastClick = t;
                labelAlipayNo.Text += "支付号" + row.TradeNo;
                labelAlipayNo.Visible = true;

                btnAlipayRefund.Visible = false;
                if (!row.IsDeletedNull() && row.Deleted)  // 只有己刪單的才准作業支付宝和微信
                {
                    btnAlipayRefund.Visible = true;
                    if (row.PayBy == "C")
                    {
                        btnAlipayRefund.Enabled = true;
                        btnAlipayRefund.Text = "支付宝作业";
                    }
                    else if (row.PayBy == "E")
                    {
                        btnAlipayRefund.Enabled = true;
                        btnAlipayRefund.Text = "微信作业";
                    }
                }
            }
            if (!ShowOrder(row))         // return false 總額不符
                labelTotal.Text +=  "???";

        }

        private void UpdateDeletedMark(MyOrderRow order, bool mark)
        {
            order.BeginEdit();
            order.Deleted = mark;
            order.EndEdit();
            try
            {
                if (order.RowState != DataRowState.Unchanged)   // 不用管Deleted,Detached不會發生
                {
                    m_OrderTableAdapter.Update(order);
                    order.AcceptChanges();     // Update應該隱含AcceptChanges
                }
            }
            catch (Exception E)
            {
                if (E.GetType() != typeof(System.Data.DBConcurrencyException))
                    MessageBox.Show(E.Message + "Update(CurrentOrder) 出錯");
                else
                {
                    MessageBox.Show("Update(Order)發生並行違例,可能是別台己經改過這張單子,或新Order有初值未設定!");
                    MessageBox.Show("請重啟程式,你必需重新修改!");
                }
            }
        }

        private void b_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("無法從店長電腦更改刪除狀態!請在相對應收銀机更改後重新收取");
            return;
            //if (m_DataSealed)
            //{
            //    MessageBox.Show("今日資料己封印,無法更改刪除狀態!");
            //    return;
            //}
            /*
            TextBox t = (TextBox)sender;
            var order = t.Tag as MyOrderRow;
            if (MessageBox.Show("要更改刪除狀態?","",MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            bool deleted=true;
            if (!order.IsDeletedNull() && order.Deleted)
            {
                deleted = false;
                if (order.OldID > 0)  t.BackColor = Color.Red;
                else                  t.BackColor = tabControl1.TabPages[0].BackColor;
            }
            else
                t.BackColor = Color.Green;
            UpdateDeletedMark(order, deleted);
            */
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            int mon = cbBoxMonth.SelectedIndex+1;
            int day = cbBoxDay.SelectedIndex+1;
            if (mon < 1 || mon > 12 || day < 1 || day > 31)
            {
                MessageBox.Show("所選日期有誤!");
                return;
            }
            LoadData(mon, day);
            TabControl tc = tabControl1;
            // worry about IsPrintTimeNull()
            var groups = from row in m_OrderSet.Order orderby row.PrintTime
                         group row by row.PrintTime.Hour;
            if (groups.Count() == 0)
            {
                MessageBox.Show(mon.ToString() + "月" + day.ToString() + "日沒有資料!");
                return;
            }
            tc.TabPages.Clear();
            tc.TabPages.Add(m_TabPageStatics);
            var listXX = new List<MyOrderRow>();
            SortableBindingList<HourStatics> listStatics = new SortableBindingList<HourStatics>();
            labelDgvTitle.Text=mon.ToString()+"月"+day.ToString()+"日統計表";
            TabPage page=null;
            decimal total = 0;
            int count = 0;
            // 一直加Tab,加行時 Height會改變, 所以先在前面算好餘裕
            int WidthX = (m_TabPageStatics.Width - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (m_TabPageStatics.Height - MyLayout.OffsetY - 60) / MyLayout.NoY;

            foreach (var gr in groups)
            {
                SuspendLayout();
                if (gr.Key > 6 && gr.Key < 23)
                {
                    string tabName = gr.Key.ToString("d2");
                    page = null;
                    HourStatics st = new HourStatics(gr.Key);
                    listStatics.Add(st);
                    int x = 0,y = 0;
                    foreach (var order in gr)
                    {
                        if (page == null)
                            page=AddTabControl1Item(tabName);
                        CreateLabel(page, x, y, order,WidthX,HeightY);
                        if (!order.Deleted)
                        {
                            total += order.Income;
                            st.Revenue += order.Income;
                            if (!order.IsIncomeNull() && order.Income >= 0)  // 退貨的不加入單數
                            {
                                count++;
                                st.OrderCount++;
                            }
                        }
                        if (++x >= MyLayout.NoX)
                        {
                            x = 0;
                            if (++y >= MyLayout.NoY)
                            {
                                y = 0;
                                page = null;
                                tabName += '.';
                            }
                        }
                    }

                }
                else
                {
                    foreach (var order in gr)
                        listXX.Add(order);
                }
                ResumeLayout();
                PerformLayout();
            }
            if (listXX.Count != 0)
            {
                int x = 0, y = 0;
                SuspendLayout();
                string tabName = "99";
                page = null;
                HourStatics st = new HourStatics(99);
                listStatics.Add(st);

                foreach (var order in listXX)
                {
                    if (page==null)
                        page = AddTabControl1Item(tabName);
                    CreateLabel(page, x, y, order,WidthX,HeightY);
                    if (!order.Deleted)
                    {
                        total += order.Income;
                        st.Revenue += order.Income;
                        if (!order.IsIncomeNull() && order.Income >= 0)  // 退貨的不加入單數
                        {
                            count++;
                            st.OrderCount++;
                        }
                    }
                    if (++x >= MyLayout.NoX)
                    {
                        x = 0;
                        if (++y >= MyLayout.NoY)
                        {
                            y = 0;
                            page = null;
                            tabName += '.';
                        }
                    }
                }
                ResumeLayout();
                PerformLayout();
            }
            // 統計頁
            foreach (HourStatics hs in listStatics)
            {
                if (hs.OrderCount != 0)
                    hs.Average = Math.Round(hs.Revenue / hs.OrderCount, 1);
            }
            dgvStatics.DataSource = listStatics;
            tc.SelectedIndex = 0;
//          if (page != null) tc.SelectTab(page);
            ResetListView();
            lvItems.Focus();
            labelOrderCount.Text   = count.ToString();
            labelTotalRevenue.Text = total.ToString("N1");
            if (count!=0)
                labelTotalAverage.Text = Math.Round(total / count, 1).ToString();
        }

        void CreateRecordLabel(TabPage tabPage, int x, int y, MyDrawerRecordRow Row)
        {
            if (Row == null) return;
            string mark = "St" + tabPage.Name + DateTime.Now.Ticks.ToString();  //避免多次進入,label重名了
            int WidthX = (tabPage.Width - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (tabPage.Height - MyLayout.OffsetY) / MyLayout.NoY;
            int xx, yy;
            xx = MyLayout.OffsetX + x * WidthX;
            yy = MyLayout.OffsetY + y * HeightY;
            TextBox b = new TextBox();
            b.MouseClick +=new MouseEventHandler(b_DrawerRecordMouseClick);
            b.Multiline = true;
            b.Font = SystemFonts.MenuFont;
            b.AutoSize = false;
            b.Location = new System.Drawing.Point(xx, yy);
            b.Name = mark + "X" + x.ToString() + "Y" + y.ToString();
            b.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
            b.TabIndex = 0;
            b.BackColor = tabPage.BackColor;
//            b.Text = (Row.DrawerRecordID % 1000000).ToString();     // NN999999, NN是POS号
            if (!Row.IsOpenTimeNull())
                b.Text = Row.OpenTime.Minute.ToString("d2")+":"+Row.OpenTime.Second.ToString("d2");
            else
                b.Text = "??:??";
            b.Text += "\r\n";
            if (!Row.IsAssociateOrderIDNull())
            {
                if (Row.AssociateOrderID > 0)
                {
                    int id = Row.AssociateOrderID;
                    b.Text += PurePosNoStr(id)+"-"+PureIDStr(id);
                }
            }
            if (Row.IsCashierIDNull() || Row.CashierID < 0)
                b.Text += "\r\n";
            else
                b.Text += "\r\n<" + Row.CashierID.ToString() + ">";
            b.Tag = Row;
            b.TextAlign = HorizontalAlignment.Center;
            b.BorderStyle = BorderStyle.Fixed3D;
            tabPage.Controls.Add(b);
        }
        private void btnDrawerOpenedList_Click(object sender, EventArgs e)
        {
            int mon = cbBoxMonth.SelectedIndex + 1;
            int day = cbBoxDay.SelectedIndex + 1;
            if (mon < 1 || mon > 12 || day < 1 || day > 31)
            {
                MessageBox.Show("所選日期有誤!");
                return;
            }
            LoadData(mon, day);
            LoadDrawerRecordData(mon, day);

            TabControl tc = tabControl1;
            // worry about IsPrintTimeNull()
            var groups = from row in m_OrderSet.DrawerRecord
                         group row by row.OpenTime.Hour;
            if (groups.Count() == 0) return;
            tc.TabPages.Clear();
            var listXX = new List<MyDrawerRecordRow>();
            TabPage page = null;
            int count = 0;

            foreach (var gr in groups)
            {
                SuspendLayout();
                if (gr.Key > 6 && gr.Key < 22)
                {
                    page = AddTabControl1Item(gr.Key.ToString("d2"));
                    int x = 0, y = 0;
                    foreach (var record in gr)
                    {
                        CreateRecordLabel(page, x, y, record);
                        count++;
                        if (++x >= MyLayout.NoX)
                        {
                            x = 0;
                            if (++y >= MyLayout.NoY)
                            {
                                y = 0;
                                page = AddTabControl1Item(gr.Key.ToString("d2") + '.');
                            }
                        }
                    }
                }
                else
                {
                    foreach (var record in gr)
                        listXX.Add(record);
                }
                ResumeLayout();
                PerformLayout();
            }
            if (listXX.Count != 0)
            {
                int x = 0, y = 0;
                page = AddTabControl1Item("XX");
                SuspendLayout();
                foreach (var record in listXX)
                {
                    CreateRecordLabel(page, x, y, record);
                    count++;
                    if (++x >= MyLayout.NoX)
                    {
                        x = 0;
                        if (++y >= MyLayout.NoY)
                        {
                            y = 0;
                            page = AddTabControl1Item("XX.");
                        }
                    }
                }
                ResumeLayout();
                PerformLayout();
            }
            if (page != null) tc.SelectTab(page);
            lvItems.Items.Clear();
            lvItems.Focus();
            labelTotal.Text = "錢箱共開 " + count.ToString() + "次";
        }

        private void cbBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int month = box.SelectedIndex;
            if (month < 0 || month >= 12) return;

            int count = MyFunction.DayCountOfMonth(month+1);
            cbBoxDay.Items.Clear();
            int result;
            for (int i = 1; i <= count; i++)
            {
                result=cbBoxDay.Items.Add(i.ToString() + "日");
            }
            cbBoxDay.SelectedIndex = 0;
        }


        DoAlipay m_Alipay=null;
        string m_TradeNo;       // m_TradeNo m_Amount在 MouseClick()時,是支付宝支付 填入值
        string m_OutTradeNo;    // 假如 order.OpenID=="00000" 表示是 OutTradeNo
        decimal m_Amount;
        MyOrderRow m_OrderRow;  // 在MouseClick時填入
        TextBox m_LastClick;    // 在MouseClick時填入
        private void btnAlipayRefund_Click(object sender, EventArgs e)
        {
            if (m_OrderRow.PayBy == "C")
            {
                if (m_Alipay == null)
                {
                    m_Alipay = new DoAlipay();
                    m_Alipay.Setup();
                }
                Form form = new FormAlipay1(m_Alipay, m_TradeNo, m_OutTradeNo, m_Amount.ToString("N2"));
                form.ShowDialog();
                if (m_Alipay.RefundedOrCanceled)   // 在FormAlipay1裏面設定
                {
                    if (m_LastClick != null)
                    {
                        m_LastClick.BackColor = Color.Green;
                        UpdateDeletedMark(m_OrderRow, true);
                    }
                }
            }
            else if (m_OrderRow.PayBy == "E")
            {
                Form form=new FormWxPay1(m_TradeNo,m_OutTradeNo,m_Amount.ToString("N2"));
                form.ShowDialog();
                // 因FormWxPay1 尚未返回狀態,且目前只有己刪單才能進入微信作業,故暫時Markout
                // m_LastClick.BackColor = Color.Green;
                // UpdateDeletedMark(m_OrderRow, true);  
            }
        }


    }
}
