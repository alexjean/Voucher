﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public FormStatics(BakeryOrderSet bakeryOrderSet,BakeryOrderSetTableAdapters.OrderTableAdapter adapter)
        {
            m_BakeryOrderSet = bakeryOrderSet;
            m_OrderTableAdapter = adapter;
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            Close();
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }


        private void FormStatics_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen;
            Location = new Point(scr.Bounds.X, scr.Bounds.Y);
            TopMost = true;

//            InitTabControlItem(tabControl1);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
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
            b.Text =  (Row.ID % 10000).ToString();
            if (!Row.IsPrintTimeNull())
                b.Text += "\r\n" + Row.PrintTime.ToString("hh:mm");
            b.Text += "\r\n" + Row.Income.ToString()+"元";
            if (!Row.IsDeletedNull() &&　Row.Deleted) b.BackColor = Color.Green;
            b.Tag = Row;
            b.TextAlign = HorizontalAlignment.Center;
            b.BorderStyle = BorderStyle.Fixed3D;
            tabPage.Controls.Add(b);
        }

        string  FindNameFromProduct(int code)
        {
            foreach (BakeryOrderSet.ProductRow row in m_BakeryOrderSet.Product)
            {
                if (code == row.Code) return row.Name;
            }
            return "";
        }

        private void b_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox t = sender as TextBox;
            BakeryOrderSet.OrderRow order = t.Tag as BakeryOrderSet.OrderRow;
            if (MessageBox.Show("要更改刪除狀態?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            if (!order.IsDeletedNull() && order.Deleted)
            {
                order.Deleted = false;
                t.BackColor = tabControl1.TabPages[0].BackColor;
            }
            else
            {
                order.Deleted = true;
                t.BackColor = Color.Green;
            }
            try
            {
                if (order.RowState != DataRowState.Unchanged)   // 不用管Deleted,Detached不會發生
                {
                    m_OrderTableAdapter.Update(order);
                    order.AcceptChanges();
                }
            }
            catch (Exception E)
            {
                if (E.GetType() != typeof(System.Data.DBConcurrencyException))
                    MessageBox.Show(E.Message + "Update(CurrentOrder) 出錯");
                else
                {
                    MessageBox.Show("發生並行違例,可能是別台己經改過這張單子,請重啟程式,你必需重新修改!");
                    Close();
                }
                
            }

        }

        private void b_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox t = (TextBox)sender;
            BakeryOrderSet.OrderRow order = t.Tag as BakeryOrderSet.OrderRow;
            BakeryOrderSet.OrderItemRow[] items=order.GetOrderItemRows();
            lvItems.Items.Clear();
            decimal total = 0, count = 0; ;
            foreach (BakeryOrderSet.OrderItemRow item in items)
            {
                decimal no = item.No;
                decimal money = item.Price*no;
                int code = item.Code;
                ListViewItem lvItem = lvItems.Items.Add(code.ToString());
                lvItem.SubItems.Add(FindNameFromProduct(code));
                lvItem.SubItems.Add(no.ToString());
                lvItem.SubItems.Add(money.ToString());
                total += money;
                count++;
            }
            lvItems.Columns[1].Text = "ID " + (order.ID % 10000).ToString()+(order.Deleted?" deleted":"");
            lvItems.Columns[2].Text = count.ToString();
            if (total!= order.Income)
            {
                MessageBox.Show("計算金額<"+total.ToString()+">不符 "+order.Income.ToString());
            }
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
            lvItems.Items.Clear();
            lvItems.Focus();
            labelTotal.Text = count.ToString()+"單　共 "+total.ToString() + "元";
        }

    }
}
