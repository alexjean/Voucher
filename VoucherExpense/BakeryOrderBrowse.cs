using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class BakeryOrderBrowse : Form
    {
        private static class MyLayout
        {
            public static int NoX = 10;
            public static int NoY = 10;
            public static int OffsetX = 8;
            public static int OffsetY = 8;
            public static int NoWidth = 8;
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
        private void BakeryOrderBrowse_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Connection = MapPath.BakeryConnection;
            m_OrderTableAdapter.Connection      = MapPath.BakeryConnection;
            m_OrderItemTableAdapter.Connection  = MapPath.BakeryConnection;
            m_DrawerReocrdAdapter.Connection    = MapPath.BakeryConnection;


            m_ListViewItemBackup=new string[lvItems.Columns.Count]; // 備份給ResetListView用
            for(int i=1;i<lvItems.Columns.Count;i++) 
                m_ListViewItemBackup[i]=lvItems.Columns[i].Text;

            try
            {
                this.productTableAdapter.Fill(bakeryOrderSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入烘焙產品表時出錯,原因:" + ex.Message);
            }
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

        class OrderAdapter : BakeryOrderSetTableAdapters.OrderTableAdapter
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
        class OrderItemAdapter : BakeryOrderSetTableAdapters.OrderItemTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.OrderItemDataTable dataTable, string SelectStr)
            {
                SaveStr = base.CommandCollection[0].CommandText;
                base.CommandCollection[0].CommandText = SelectStr;
                int result = Fill(dataTable);
                base.CommandCollection[0].CommandText = SaveStr;
                return result;
            }
        }
        class DrawerRecordAdapter : BakeryOrderSetTableAdapters.DrawerRecordTableAdapter
        {
            string SaveStr;
            public int FillBySelectStr(BakeryOrderSet.DrawerRecordDataTable dataTable, string SelectStr)
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

        int LoadData(int m, int d)
        {
            string sql = "Where INT(ID/1000000)=" + m.ToString("d2") + d.ToString("d2");
            int MaxID = 0;
            try
            {
                m_OrderTableAdapter.FillBySelectStr(bakeryOrderSet.Order, "Select * From [Order] " + sql + " Order by ID");
                m_OrderItemTableAdapter.FillBySelectStr(bakeryOrderSet.OrderItem, "Select * From [OrderItem] " + sql);
                foreach (BakeryOrderSet.OrderRow R in bakeryOrderSet.Order.Rows)
                {
                    int id = PureID(R.ID);       // 資料定義為 MMDDNN9999  N POS机号,店長收資料時,再自動填上
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("BakeryOrder.Order OrderItem讀取錯誤!" + str);
                return -1;
            }
        }

        int LoadDrawerRecordData(int m, int d)
        {
            string sql = "Where INT(DrawerRecordID/1000000)=" + m.ToString("d2") + d.ToString("d2");
            int MaxID = 0;
            try
            {
                m_DrawerReocrdAdapter.FillBySelectStr(bakeryOrderSet.DrawerRecord, "Select * From [DrawerRecord] " + sql);
                foreach (BakeryOrderSet.DrawerRecordRow R in bakeryOrderSet.DrawerRecord.Rows)
                {
                    int id = PureID(R.DrawerRecordID);       // 資料定義為 MMDDN99999  N POS机号比Order.ID少一位, id最多10萬筆多十倍
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("BakeryOrder.DrawerRecord讀取錯誤!" + str);
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

        void CreateLabel(TabPage tabPage, int x, int y, BakeryOrderSet.OrderRow Row)
        {
            if (Row == null) return;
            string mark = "St" + tabPage.Name + DateTime.Now.Ticks.ToString();  //避免多次進入,label重名了
            int WidthX = (tabPage.Width - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (tabPage.Height - MyLayout.OffsetY) / MyLayout.NoY;
            int xx, yy;
            xx = MyLayout.OffsetX + x * WidthX;
            yy = MyLayout.OffsetY + y * HeightY;
            TextBox b = new TextBox();
            b.MouseClick+=new MouseEventHandler(b_MouseClick);
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
                else if (Row.PayBy == "C") b.Text += "券";
            }
            decimal income = 0;
            income = Math.Round(Row.Income, 2);
            b.Text += "\r\n" + income.ToString()+"元";
            if (!Row.IsDeletedNull() &&　Row.Deleted) b.BackColor = Color.Green;
            b.Tag = Row;
            b.TextAlign = HorizontalAlignment.Center;
            b.BorderStyle = BorderStyle.Fixed3D;
            tabPage.Controls.Add(b);
        }

        string  FindNameFromProduct(int productID)
        {
            foreach (BakeryOrderSet.ProductRow row in bakeryOrderSet.Product)
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

        private bool ShowOrder(BakeryOrderSet.OrderRow order)
        {
            BakeryOrderSet.OrderItemRow[] items = order.GetOrderItemRows();
            lvItems.Items.Clear();
            decimal total = 0, count = 0; ;
            foreach (BakeryOrderSet.OrderItemRow item in items)
            {
                if (item.IsNoNull()) continue;
                if (item.IsProductIDNull()) continue;
                if (item.IsPriceNull()) item.Price = 0m;
                decimal no = item.No;
                decimal money = item.Price * no;
                int productID = item.ProductID;
                ListViewItem lvItem = lvItems.Items.Add(productID.ToString());
                lvItem.SubItems.Add(FindNameFromProduct(productID));
                lvItem.SubItems.Add(no.ToString());
                lvItem.SubItems.Add(money.ToString());
                total += money;
                count++;
            }
            lvItems.Columns[1].Text = "ID " + PureIDStr(order.ID) + (order.Deleted ? " deleted" : "");
            lvItems.Columns[2].Text = count.ToString();
            lvItems.Columns[3].Text = total.ToString();
            if (!order.IsDeductNull())
            {
                total -= order.Deduct;
            }
            if (!order.IsIncomeNull())
            {
                decimal income = Math.Round(order.Income, 2);
                if (total != order.Income)
                {
                    MessageBox.Show("計算金額<" + total.ToString() + ">不符 " + income.ToString());
                    return false;
                }
            }
            return true;
        }

        private void b_DrawerRecordMouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            BakeryOrderSet.DrawerRecordRow record = t.Tag as BakeryOrderSet.DrawerRecordRow;
            ResetListView();
            if (record.IsAssociateOrderIDNull() || record.AssociateOrderID < 0) return;
            var Orders = from row in bakeryOrderSet.Order where (row.ID%1000000 == record.AssociateOrderID) select row;   // 要含Pos机号
            if (Orders.Count() > 0) ShowOrder(Orders.First());
        }

        private void b_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            BakeryOrderSet.OrderRow row = t.Tag as BakeryOrderSet.OrderRow;
            labelDeductLabel.Visible = false;
            if ((!row.IsDeductNull()) && row.Deduct != 0)
            {
                labelDeductLabel.Visible = true;
                labelDeduct.Visible = true;
                labelDeduct.Text = row.Deduct.ToString();
            }
            else
            {
                labelDeduct.Visible = false;
                labelDeductLabel.Visible = false;
            }
            decimal income = 0;
            if (!row.IsIncomeNull())
                income=Math.Round( row.Income,2);
            labelTotal.Text =  income.ToString();
            if (!ShowOrder(row))         // return false 總額不符
                labelTotal.Text +=  "???";

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
            var groups = from row in bakeryOrderSet.Order
                         group row by row.PrintTime.Hour;
            if (groups.Count() == 0)
            {
                MessageBox.Show(mon.ToString() + "月" + day.ToString() + "日沒有資料!");
                return;
            }
            tc.TabPages.Clear();
            tc.TabPages.Add(m_TabPageStatics);
            List<BakeryOrderSet.OrderRow> listXX = new List<BakeryOrderSet.OrderRow>();
            SortableBindingList<HourStatics> listStatics = new SortableBindingList<HourStatics>();
            labelDgvTitle.Text=mon.ToString()+"月"+day.ToString()+"日統計表";
            TabPage page=null;
            decimal total = 0;
            int count = 0;

            foreach (var gr in groups)
            {
                SuspendLayout();
                if (gr.Key > 6 && gr.Key < 23)
                {
                    page=AddTabControl1Item(gr.Key.ToString("d2"));
                    HourStatics st = new HourStatics(gr.Key);
                    listStatics.Add(st);
                    int x = 0,y = 0;
                    foreach (var order in gr)
                    {
                        CreateLabel(page, x, y, order);
                        if (!order.Deleted)
                        {
                            count++;
                            total += order.Income;
                            st.OrderCount++;
                            st.Revenue += order.Income;
                        }
                        if (++x >= MyLayout.NoX)
                        {
                            x = 0;
                            if (++y >= MyLayout.NoY)
                            {
                                y = 0;
                                page = AddTabControl1Item(gr.Key.ToString("d2")+'.');
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
                page = AddTabControl1Item("XX");
                HourStatics st = new HourStatics(99);
                listStatics.Add(st);

                foreach (var order in listXX)
                {
                    CreateLabel(page, x, y, order);
                    if (!order.Deleted)
                    {
                        count++;
                        total += order.Income;
                        st.OrderCount++;
                        st.Revenue += order.Income;
                    }
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

        void CreateRecordLabel(TabPage tabPage, int x, int y, BakeryOrderSet.DrawerRecordRow Row)
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
            var groups = from row in bakeryOrderSet.DrawerRecord
                         group row by row.OpenTime.Hour;
            if (groups.Count() == 0) return;
            tc.TabPages.Clear();
            List<BakeryOrderSet.DrawerRecordRow> listXX = new List<BakeryOrderSet.DrawerRecordRow>();
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


    }
}
