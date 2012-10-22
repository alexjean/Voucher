using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BakeryOrder
{
    public partial class FormCashier : Form
    {
        // FormCashe的BasicDataSet.xsd是以 VoucherExpense內的BasicData.mdb建成的,沒有Copy到BakeryOrder目錄

        class MenuItemForTag
        {
            public int code;
            public string name;
            public double No;
            public double Price;
            public short classcode;
            public Label LabelNo;
            public double Money() { return Price * No; }
            public void SetZero() { No = 0; }
            public string NoToString() { return No.ToString(); }
        }

        #region ======== Shared function with EditBakeryMenu.cs ======
        private static class MyLayout
        {
            public static int NoX = 4;
            public static int NoY = 6;
            public static int OffsetX = 10;
            public static int OffsetY = 10;
            public static int NoWidth = 10;
        }

        const int SpeicalRowCodeForMenu = 0;

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;

            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Regular);
                //                bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshBack = new SolidBrush(Color.Azure);
                bshFore = Brushes.Black;
                // 把標簽後的Control色填成背景色
                int count = tabControl1.TabPages.Count - 1;
                if (count < 0) return;
                Rectangle endRect = tabControl1.GetTabRect(count);
                Point pt = new Point(endRect.X + endRect.Width, endRect.Y);
                Size sz = new Size(tabControl1.Width - endRect.X - endRect.Width, endRect.Height);
                Rectangle headerRect = new Rectangle(pt, sz);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(216, 228, 248)), headerRect);
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.FromArgb(216, 228, 248));
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X + 3, recTab.Y + 3, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        void UpdateAllFoodMenu()
        {
            int i = 0;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tp.Controls.Clear();
                Label[,] l;
                InitFoodMenu(tp, i++, out l);
                tp.Tag = l;
            }
        }

        private BasicDataSet.ProductRow GetFoodMenuItem(int id, int x, int y)
        {
            int x1 = x + id * 10;  // x最多不到10行,所以用x編碼菜單id
            foreach (BasicDataSet.ProductRow Row in basicDataSet1.Product.Rows)
            {
                if (Row.MenuX == x1 && Row.MenuY == y) return Row;
            }
            return null;
        }

        #region ====== ListView Operate ======
        private ListViewItem FindByCodeFromList(int code)
        {
            foreach (ListViewItem lvItem in lvItems.Items)
            {
                MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
                if (code == item.code) return lvItem;
            }
            return null;
        }

        private void Add2List(MenuItemForTag item, bool AtFirst)
        {
            ListViewItem lvItem = FindByCodeFromList(item.code);
            double no = item.No;

            double money = item.Money();
            if (lvItem != null)
            {
                lvItem.SubItems[2].Text = no.ToString();
                lvItem.SubItems[3].Text = money.ToString(); ;
            }
            else
            {
               if (AtFirst)
                   lvItem = lvItems.Items.Insert(0, item.code.ToString());
               else
                   lvItem = lvItems.Items.Add(item.code.ToString());
                lvItem.SubItems.Add(item.name);
                lvItem.SubItems.Add(no.ToString());
                lvItem.SubItems.Add(money.ToString());
            }
            lvItem.Tag = item;
            CalcTotal();
        }

        // ListView的tag 指向MenuItem
        private bool Sub2List(MenuItemForTag item)
        {
            ListViewItem lvItem = FindByCodeFromList(item.code);
            if (lvItem == null) return false; // 沒東西刪
            if (item.No > 0)
            {
                lvItem.SubItems[2].Text = item.NoToString();
                lvItem.SubItems[3].Text = item.Money().ToString();
            }
            else
            {
                lvItem.Remove();
            }
            m_FormCustomer.Item2List(item.code, item.name, item.No, item.Money());
            CalcTotal();
            return true;            // 刪除成功
        }

        private void Item2List(MenuItemForTag item, MouseButtons btn)
        {
            if (item == null) return;
            if (btn == MouseButtons.Right)
            {
                if (item.No == 0) return;
                item.No = 0;
                Sub2List(item);
            }
            else if (btn == MouseButtons.Left)
            {
                item.No += 1;
                Add2List(item, false);
            }
            m_FormCustomer.Item2List(item.code, item.name, item.No, item.Money());
            return;
        }

        private double CalcTotal()
        {
            double total = 0;
            double no = 0, sum = 0;
            foreach (ListViewItem lvItem in lvItems.Items)
            {
                MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
                sum += item.Money();
                no += item.No;
            }
            sum = Math.Round(sum, 1);
            lvItems.Columns[2].Text = no.ToString();
            lvItems.Columns[3].Text = sum.ToString();
            if (checkBoxDiscount.Checked)  sum = sum * 0.9;
            total = sum;
/*
            if (mtbDeduct.Text != "")
            {
                int deduct = Int32.Parse(mtbDeduct.Text);
                total -= deduct;
            }
*/
            total = Math.Round(total, 0, MidpointRounding.AwayFromZero);
            labelTotal.Text = total.ToString();
            m_FormCustomer.ShowTotal(total);
            return total;
        }

        private void checkBoxDiscount_CheckedChanged(object sender, EventArgs e)
        {
            CalcTotal();
        }
        #endregion

        private void MenuDoubleClick(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            MenuItemForTag item = (MenuItemForTag)l.Tag;
            Item2List(item, MouseButtons.Right);
            l.BorderStyle = BorderStyle.Fixed3D;
            item.LabelNo.Text = item.name;
        }

        private void MenuClick(object sender, MouseEventArgs e)
        {
            m_FormCustomer.SetTimer(30000);   // 停止轉圖
            Label l = (Label)sender;
            MenuItemForTag item = (MenuItemForTag)l.Tag;
            Item2List(item, e.Button);
            if (item.No > 0)
                l.BorderStyle = BorderStyle.FixedSingle;
            else l.BorderStyle = BorderStyle.Fixed3D;
            if (item.No == 1 || item.No == 0)
                item.LabelNo.Text = item.name;
            else
                item.LabelNo.Text = item.name+"  "+item.NoToString();
        }
        // 輸出的Label[,] 放到tabPage.Tag去
        private void InitFoodMenu(TabPage tabPage, int menuId, out Label[,] FoodName)
        {
            SuspendLayout();
            string mark = "F" + menuId.ToString() + DateTime.Now.Ticks.ToString();  //避免多次進入,label重名了
            int WidthX = (tabPage.Width - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (tabPage.Height - MyLayout.OffsetY) / MyLayout.NoY;
            FoodName = new Label[MyLayout.NoX, MyLayout.NoY];
            int x, y;
            for (x = 0; x < MyLayout.NoX; x++)
                for (y = 0; y < MyLayout.NoY; y++)
                {
                    int xx, yy;
                    xx = MyLayout.OffsetX + x * WidthX;
                    yy = MyLayout.OffsetY + y * HeightY;
                    Label l = new Label();
                    // Create Name Label
                    l = new Label();
                    FoodName[x, y] = l;
                    l.AutoSize = false;
                    l.Location = new System.Drawing.Point(xx, yy);
                    l.Name = mark + "X" + x.ToString() + "Y" + y.ToString();
                    l.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
                    l.TabIndex = 0;
                    BasicDataSet.ProductRow Row = GetFoodMenuItem(menuId, x, y);
                    if (Row != null)
                    {
                        l.Tag = Row;
                        if (Row.IsNameNull()) l.Text = "";
                        else l.Text = Row.Name.ToString();

                        MenuItemForTag content = new MenuItemForTag();
                        content.No = 0;
                        content.Price = Row.Price;
                        content.code = Row.Code;
                        content.classcode = Row.Class;
                        content.LabelNo = l;  
                        content.name = Row.Name.ToString();
                        l.Tag = content;
                        l.Text = content.name;
                        l.MouseClick += new MouseEventHandler(this.MenuClick);
                        l.MouseDoubleClick+=new MouseEventHandler(this.MenuDoubleClick);
                    }
                    else
                    {
                        l.Tag = null;
                        l.Text = "";
                    }
/*                  FormCashier不需要
                    l.DragEnter += new DragEventHandler(this.LabelDragEnter);
                    l.DragLeave += new EventHandler(this.LabelDragLeave);
                    l.DragDrop += new DragEventHandler(LabelDragDrop);
                    l.MouseDown += new MouseEventHandler(LabelMouseDown);
*/
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.BorderStyle = BorderStyle.Fixed3D;
//                    l.AllowDrop = true;
                    tabPage.Controls.Add(l);
                }

            ResumeLayout();
            PerformLayout();
        }

        private void LoadTabControlItem()
        {

            // 小於0的是菜單名負一排最前面
            var rows = from row in basicDataSet1.Product
                       where row.Code < SpeicalRowCodeForMenu
                       orderby row.Code descending
                       select row;
            tabControl1.TabPages.Clear();
            if (rows.Count() == 0)   // 都沒有的話留下預設的
            {
                tabControl1.TabPages.Add("面包");
/*              FormCasiher不需要
                int maxID = (from ro in basicDataSet1.Product
                             select ro.ProductID).Max();
                BasicDataSet.ProductRow row = basicDataSet1.Product.NewProductRow();
                row.ProductID = ++maxID;
                row.Name = SystemMenuName("面包", 1);
                row.Code = -1;
                row.MenuX = -1;
                row.MenuY = -1;
                basicDataSet1.Product.AddProductRow(row);
                SaveProduct();
*/
            }
            else
            {
                String str;
                int i;
                foreach (BasicDataSet.ProductRow row in rows)
                {
                    str = row.Name;
                    i = str.IndexOf('_');    // 以底線做分割, 前面是菜單名
                    if (i > 1) str = str.Substring(0, i);
                    tabControl1.TabPages.Add(str);
                }
            }
            foreach (TabPage page in tabControl1.TabPages)
            {
                page.BackColor = Color.Azure;
                page.Font = new Font("標楷體", 14.25f);
            }
        }
        #endregion

        public FormCashier()
        {
            InitializeComponent();
        }

        FormCustomer m_FormCustomer=null;
        private void FormCashier_Load(object sender, EventArgs e)
        {
//            productTableAdapter1.Connection = MapPath.BasicConnection;
            this.productTableAdapter.Fill(this.basicDataSet1.Product);
            // 程式保留row.Code 0做為菜單的寬高,這行不是產品
            var rows = from row in basicDataSet1.Product
                       where row.Code == SpeicalRowCodeForMenu
                       select row;
            foreach (BasicDataSet.ProductRow row in rows)
            {
                MyLayout.NoX = -row.MenuX;
                MyLayout.NoY = -row.MenuY;
            }
            LoadTabControlItem();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            UpdateAllFoodMenu();

            m_FormCustomer = new FormCustomer();
            Screen scr = Screen.PrimaryScreen;
            Location = new Point(scr.Bounds.X, scr.Bounds.Y);
            m_FormCustomer.Show();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (m_FormCustomer!=null)
                m_FormCustomer.Close();
            Close();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basicDataSet1);

        }

 
    }
}
