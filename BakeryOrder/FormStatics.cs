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
    public partial class FormStatics : Form
    {
        private static class MyLayout
        {
            public static int NoX = 12;
            public static int NoY = 12;
            public static int OffsetX = 10;
            public static int OffsetY = 10;
            public static int NoWidth = 8;
        }

        BakeryOrderSet m_BakeryOrderSet;
        BakeryOrderSetTableAdapters.OrderTableAdapter m_OrderTableAdapter;
        int m_CashierID = 0;
        int m_PosID = 0;
        int m_StoreID = 0;
        PrintInfo m_Printer;
        bool m_DataSealed = false;
        string m_CasherierName = "";
        public FormStatics(BakeryOrderSet bakeryOrderSet,BakeryOrderSetTableAdapters.OrderTableAdapter adapter,int cashierID,PrintInfo printer,bool dataSealed,int posID,int storeID,string cashierName)
        {
            m_BakeryOrderSet    = bakeryOrderSet;
            m_OrderTableAdapter = adapter;
            m_CashierID         = cashierID;
            m_Printer           = printer;
            m_DataSealed        = dataSealed;
            m_PosID             = posID;
            m_StoreID           = storeID;
            m_CasherierName = cashierName;
            InitializeComponent();
        }
        bool isReturn;//是否有退货窗体调用
        public FormStatics(BakeryOrderSet bakeryOrderSet, BakeryOrderSetTableAdapters.OrderTableAdapter adapter, int cashierID, PrintInfo printer, bool dataSealed, int posID,int storeID,bool IsReturn)
        {
            m_BakeryOrderSet = bakeryOrderSet;
            m_OrderTableAdapter = adapter;
            m_CashierID = cashierID;
            m_Printer = printer;
            m_DataSealed = dataSealed;
            m_PosID = posID;
            m_StoreID = storeID;
            isReturn = IsReturn;
            InitializeComponent();
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

        string[] m_ListViewItemBackup;
        private void FormStatics_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen;
            Location = new Point(scr.Bounds.X, scr.Bounds.Y);
            TopMost = true;
//          InitTabControlItem(tabControl1);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            m_ListViewItemBackup=new string[lvItems.Columns.Count]; // 備份給ResetListView用
            for(int i=1;i<lvItems.Columns.Count;i++) 
                m_ListViewItemBackup[i]=lvItems.Columns[i].Text;
            if (isReturn)
            {
                btnSystemSetup.Enabled = false;
            }
        }

        DialogResult MessageBoxShow(string msg,bool returnResult=false)
        {
            Form form = new FormMessage(msg,returnResult);
            return form.ShowDialog();
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
            b.MouseDoubleClick+=new MouseEventHandler(b_MouseDoubleClick);
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
            b.Text += "\r\n"+(Row.ID % 100000).ToString();
            if (!Row.IsPayByNull())
            {
                if      (Row.PayBy == "B") b.Text += "卡";
                else if (Row.PayBy == "C") b.Text += "支";
                else if (Row.PayBy == "D") b.Text += '券';
                else if (Row.PayBy == "E") b.Text += '微';
            }
            decimal income = 0;
            if (!Row.IsIncomeNull()) income = Math.Round(Row.Income,2);
            b.Text += "\r\n" + income.ToString()+"元";
            if (!Row.IsOldIDNull() && Row.OldID > 0) b.BackColor = Color.Red;
            if (!Row.IsDeletedNull() && Row.Deleted) b.BackColor = Color.Green;
            b.Tag = Row;
            b.TextAlign = HorizontalAlignment.Center;
            b.BorderStyle = BorderStyle.Fixed3D;
            tabPage.Controls.Add(b);
        }

        string  FindNameFromProduct(int productID)
        {
            foreach (BakeryOrderSet.ProductRow row in m_BakeryOrderSet.Product)
            {
                if (productID == row.ProductID) return row.Name;
            }
            return "";
        }

        private void b_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_DataSealed)
            {
                MessageBoxShow("今日資料己封印,無法更改刪除狀態!");
                return;
            }
            TextBox t = sender as TextBox;
            BakeryOrderSet.OrderRow order = t.Tag as BakeryOrderSet.OrderRow;
            if (order.CashierID != m_CashierID)
            {
                MessageBoxShow("不是自己的單! 不能改");
                return;
            }
            if (MessageBoxShow("要更改刪除狀態?",true) != DialogResult.Yes)
            {
                return;
            }
            order.BeginEdit();
            if (!order.IsDeletedNull() && order.Deleted)
            {
                order.Deleted = false;
                if (order.OldID > 0)
                {
                    t.BackColor = Color.Red;
                }
                else
                {
                    t.BackColor = tabControl1.TabPages[0].BackColor;
                }
            }
            else
            {
                order.Deleted = true;
                t.BackColor = Color.Green;
            }
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
                    MessageBoxShow(E.Message + "Update(CurrentOrder) 出錯");
                else
                {
                    MessageBoxShow("Update(Order)發生並行違例,可能是別台己經改過這張單子,或新Order有初值未設定!");
                    MessageBoxShow("請重啟程式,你必需重新修改!");
                    this.DialogResult = DialogResult.Abort;  // 傳送.Abort給上層Form,代表ExitProgram
                    Close();
                }
            }
        }

        void ResetListView()
        {
            lvItems.Items.Clear();
            for(int i=1;i<lvItems.Columns.Count;i++)
                lvItems.Columns[i].Text = m_ListViewItemBackup[i];
        }

        Dictionary<char, string> DicPayBy = new Dictionary<char, string> { { 'A', "现金" }, { 'B', "刷卡" }, { 'C', "支付宝" }, { 'D', "券入" }, { 'E', "微信" } };
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
            // 計算折扣
            if (!order.IsDiscountRateNull())
            {
                decimal discountRate = order.DiscountRate;
                if (discountRate != 0m && discountRate != 1m)
                    total = Math.Floor(total * discountRate);
            }

            lvItems.Columns[1].Text = "ID " + (order.ID % 10000).ToString() + (order.Deleted ? " deleted" : "")+(order.RCashierID>0 ? " 退货" : "");
            lvItems.Columns[2].Text = count.ToString();
            lvItems.Columns[3].Text = total.ToString();
            if (!order.IsPayByNull() && order.PayBy.Length>0)
            {
                char c=order.PayBy[0];
                if (DicPayBy.Keys.Contains(c))
                    btnClass.Text = DicPayBy[c];
                else
                    btnClass.Text = DicPayBy.First().Value;
            }
            if (!order.IsDeductNull() && order.Deduct != 0)
            {
                if (order.OldID > 0)
                {
                    total += order.Deduct;
                }
                else
                {
                    total -= order.Deduct;
                }
               
                labelDeduct.Text = "己优惠   " +Math.Abs( order.Deduct).ToString();
            }
            else
                labelDeduct.Text = "";
            decimal income = 0;
            if (!order.IsIncomeNull()) income = Math.Round(order.Income,2);

            if (!order.IsDiscountRateNull() && order.DiscountRate != 1m)
                labelIncome.Text = (order.DiscountRate * 100).ToString("F0") + "折 " + income.ToString("N0");
            else
                labelIncome.Text = income.ToString("N0");

            //labelIncome.Text = income.ToString();
            if (!order.IsMemberIDNull()) labelMemberID.Text = "会员"+order.MemberID;

            labelAlipayNo.Text = "";
            if (order.PayBy[0] == 'D')
            {
                if (!order.IsCouponIncomeNull()) 
                    labelAlipayNo.Text += "收券 "  + order.CouponIncome.ToString();
                if (!order.IsCashIncomeNull() && order.CashIncome!=0m)
                    labelAlipayNo.Text += " 收现 " + order.CashIncome.ToString();
            }
            if (order.IsTradeNoNull() || order.TradeNo == "") labelAlipayNo.Text += "";
            else
            {
                int len=order.TradeNo.Length;
                if (len > 18)
                {
                    labelAlipayNo.Text += "支付号  " + order.TradeNo.Substring(0, 8) + "\r" + order.TradeNo.Substring(8, len - 8);
                }
                else
                    labelAlipayNo.Text += "支付号  " + order.TradeNo;
            }
            if (total != income)
            {
                if (total == -income)
                {
                    if (order.OldID > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBoxShow("計算金額<" + total.ToString() + ">不符 " + order.Income.ToString());
                        return false;
                    }
                }
                else
                {
                    MessageBoxShow("計算金額<" + total.ToString() + ">不符 " + order.Income.ToString());
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
            foreach (BakeryOrderSet.OrderRow row in m_BakeryOrderSet.Order)
            {
                if ((row.ID % 10000) == record.AssociateOrderID)    // bakeryOrderSet.Order內只會讀入今天的, 所以MMDDNN9999 只比對9999部分
                {
                    ShowOrder(row);
                    return;
                }
            }
        }

        private void b_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!ShowOrder(t.Tag as BakeryOrderSet.OrderRow))   // 總額不符,自動跳刪除
                b_MouseDoubleClick(sender, e);
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            TabControl tc = tabControl1;
            // worry about IsPrintTimeNull()
            var groups = from row in m_BakeryOrderSet.Order
                         group row by row.PrintTime.Hour;
            if (groups.Count() == 0) return;
            tc.TabPages.Clear();
            List<BakeryOrderSet.OrderRow> listXX = new List<BakeryOrderSet.OrderRow>();
            TabPage page=null;
            decimal total = 0;
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            decimal total1 = 0;
            decimal total2 = 0;
            foreach (var gr in groups)
            {
                SuspendLayout();
                if (gr.Key > 6 && gr.Key < 22)
                {
                    page=AddTabControl1Item(gr.Key.ToString("d2"));
                    int x = 0,y = 0;
                    foreach (var order in gr)
                    {
                        CreateLabel(page, x, y, order);
                        if (!order.Deleted)
                        {
                            if (order.OldID>0)//退货
                            {
                                count1++;
                                total1 += order.Income;
                            }
                            else//出售
                            {
                                count2++;
                                total2 += order.Income;
                            }
                            count++;
                            total += order.Income;
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
                page=AddTabControl1Item("XX");
                SuspendLayout();
                foreach (var order in listXX)
                {
                    CreateLabel(page, x, y, order);
                    if (!order.Deleted)
                    {
                        count++;
                        total += order.Income;
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
            if (page != null) tc.SelectTab(page);
            ResetListView();
            lvItems.Focus();
            //labelStatics.Text = count.ToString()+"單　共 "+total.ToString() + "元";
            //labelStatics2.Text ="出售：" +count2.ToString() + "單　共 " + total2.ToString() + "元";
            //labelStatics1.Text ="退货："+ count1.ToString() + "單　共 " + total1.ToString() + "元";
            labelStatics.Text = count.ToString();
            labelStatics2.Text =  count2.ToString();
            labelStatics1.Text =  count1.ToString();
            label4.Text="元";
            label5.Text = "元";
            label6.Text = "元";
            label1.Text = "单 共";
            label2.Text = "单 共";
            label3.Text = "单 共";
            label10.Text = "退货";
            label11.Text = "售货";
            label12.Text = "总";
            label7.Text = total1.ToString();
            label8.Text = total2.ToString();
            label9.Text = total.ToString();
            panel1.Visible = true;
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
                    b.Text += Row.AssociateOrderID.ToString();
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
            panel1.Visible = false;
            TabControl tc = tabControl1;
            // worry about IsPrintTimeNull()
            var groups = from row in m_BakeryOrderSet.DrawerRecord
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
            label13.Text = "錢箱共開 " + count.ToString() + "次";
        }

        private void btnSystemSetup_Click(object sender, EventArgs e)
        {
            Form form = new FormSystemSetup(m_BakeryOrderSet, m_CashierID,m_Printer,m_PosID,m_StoreID,m_CasherierName);
            DialogResult result=form.ShowDialog();
            if ((result == DialogResult.Abort) || (result==DialogResult.Cancel))
            {
                this.DialogResult = result;
                Close();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }




    }
}
