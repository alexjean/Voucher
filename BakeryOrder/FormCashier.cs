using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace BakeryOrder
{
    public partial class FormCashier : Form
    {
        // FormCashe的BasicDataSet.xsd是以 VoucherExpense內的BasicData.mdb建成的,沒有Copy到BakeryOrder目錄

        class MenuItemForTag
        {
            public int id;
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
            int count=lvItems.Items.Count;
            if ( count> 0)                      // 取消產品, 顯示ListView上最後一個品項
            {
                MenuItemForTag  tag= lvItems.Items[count - 1].Tag as MenuItemForTag;
                string idStr = tag.id.ToString();
                string small = m_SmallDir + "\\" + idStr + ".jpg";
                if (!File.Exists(small))
                {
                    string big = m_ProductDir + "\\" + idStr + ".jpg";
                    CreateSmallImage(big, pictureBox1.Width, pictureBox1.Height, small);
                }
                Image img = Bitmap.FromFile(small);
                pictureBox1.Image = img;
                m_FormCustomer.SetPicture(img);
            }
        }

        void CreateSmallImage(string sourceFile, int w, int h,string destFile)
        {
            if (!File.Exists(sourceFile))
            {
                Bitmap img1=new Bitmap(1, 1);
                img1.Save(destFile);
                return;
            }
            Bitmap img = new Bitmap(sourceFile);
            int x = img.Size.Width;
            int y = img.Size.Height;
            {
                int x1 = w;
                int y1 = y * x1 / x;
                Bitmap newbmp = new Bitmap(x1, y1);//新建一个放大后大小的图片
                double times = ((double)x1) / x;
                if (times >= 1)
                    newbmp = img;
                else
                {
                    Graphics g = Graphics.FromImage(newbmp);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(img, new Rectangle(0, 0, x1, y1), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
                newbmp.Save(destFile);
            }
            
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
            string idStr = item.id.ToString();
            string small=m_SmallDir+"\\" + idStr + ".jpg";
            if (!File.Exists(small))
            {
                string big = m_ProductDir + "\\" + idStr + ".jpg";
                CreateSmallImage(big, pictureBox1.Width, pictureBox1.Height, small);
            }
            Image img=Bitmap.FromFile(small);
            pictureBox1.Image = img;
            m_FormCustomer.SetPicture(img);
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
                        content.id = Row.ProductID;
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
        const string m_ProductDir = "Products";
        const string m_SmallDir = m_ProductDir + "\\Small";
        private void FormCashier_Load(object sender, EventArgs e)
        {
//            productTableAdapter1.Connection = MapPath.BasicConnection;
            this.productTableAdapter.Fill(this.basicDataSet1.Product);
            this.orderTableAdapter1.Fill(this.basicDataSet1.Order);
            this.orderItemTableAdapter1.Fill(this.basicDataSet1.OrderItem);

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

            if (!Directory.Exists(m_ProductDir))
                Directory.CreateDirectory(m_ProductDir);
            if (!Directory.Exists(m_SmallDir))
                Directory.CreateDirectory(m_SmallDir);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (m_FormCustomer!=null)
                m_FormCustomer.Close();
            Close();
        }

        string d2str(double d, int width)
        {
            string s;
            if ((d - Math.Floor(d)) < 0.01)   // 小於一分 ,不印 x.0
                s = d.ToString("f0") + "  ";
            else
                s = d.ToString("f1");
            if (s.Length >= width) return s;
            return s.PadLeft(width);
        }

        void Item2Buffer(ByteBuilder Buf, MenuItemForTag mItem)
        {
            string s = mItem.name.Trim();
            int m;
            do
            {
                m = GB2312.GetByteCount(s);
                if (m <= 16) break;
                s = s.Substring(0, s.Length - 1);
            } while (true);
            int n = 16 - m + s.Length;
            Buf.AppendPadRight(s, n, GB2312);
            Buf.Append(d2str(mItem.No, 4), GB2312);
            Buf.Append(d2str(mItem.Price, 5), GB2312);
            Buf.Append(d2str(mItem.Money(), 7), GB2312);
            Buf.Append("\r\n", GB2312);
        }

        BasicDataSet.OrderRow CreateCurrentOrder()
        {
            BasicDataSet.OrderRow CurrentOrder = basicDataSet1.Order.NewOrderRow();
            CurrentOrder.PrintTime = DateTime.Now;
            int maxID = 0;
            foreach (BasicDataSet.OrderRow row in basicDataSet1.Order)
            {
                if (row.ID > maxID) maxID = row.ID;
            }
            CurrentOrder.ID = maxID + 1;
            CurrentOrder.DiscountRate = 0.9m;
            CurrentOrder.Income = (decimal)CalcTotal();
            return CurrentOrder;
        }

        Encoding GB2312     = Encoding.GetEncoding("GB2312");
        string PrintTitle   = "     原麦山丘华宇店";
        string PrintAddress = "地址:中关村南大街2号";
        string PrintTel     = "电话:60956577";
        string PrinterName = "BTP-R580(U)";

        void Print()      
        {
            //byte[] PrintChinese = new byte[] { };
            byte[] BorderMode = new byte[] { 0x1c, 0x21, 0x28 };
            byte[] NormalMode = new byte[] { 0x1c, 0x21, 0 };
            byte[] CutPaper = new byte[] { 0x1B, (byte)'i' };
            int n;

            BasicDataSet.OrderRow CurrentOrder = null;
            CurrentOrder=CreateCurrentOrder();

            ByteBuilder Buf = new ByteBuilder(2048);
            Buf.SetEncoding(GB2312);

//            ShowTime();
//            if (!SaveOrder()) return;

            Buf.Append(BorderMode);                                      // 設定列印模式28
            Buf.Append(PrintTitle+"\r\n", GB2312);
            Buf.Append(NormalMode);                                      // 設定列印模式正常 

            Buf.Append("\r\n");
            Buf.Append(PrintAddress+"\r\n", GB2312);
            Buf.AppendPadRight(PrintTel, 19, GB2312);
            n = (CurrentOrder.ID % 1000);
            Buf.Append("序号:" + n.ToString("d4") + "\r\n", GB2312);
            Buf.AppendPadRight("时间:" + CurrentOrder.PrintTime.ToString("yy/MM/dd hh:mm"), 19, GB2312);
            Buf.Append("工号: 001" +  "\r\n\r\n", GB2312);
/*
            try
            {
                n = Int32.Parse(textBoxTable.Text);
                if (n > 0)
                    Buf.Append("桌号:" + n.ToString("d2") + "              服务:" + mtbServant.Text + "\r\n", GB2312);
            }
            catch { }
*/
            Buf.Append(BorderMode);                                      // 設定列印模式28

            Buf.Append("  品名        数量 单价   金额\r\n", GB2312);
            Buf.Append("- - - - - - - - - - - - - - - -\r\n", GB2312);
            MenuItemForTag mItem;
            double no = 0;
            double discount = 0;

            foreach (ListViewItem item in lvItems.Items)  // 印可折扣項
            {
                mItem = (MenuItemForTag)item.Tag;
                Item2Buffer(Buf, mItem);
                no += mItem.No;
                discount += mItem.Money();
            }
            if (checkBoxDiscount.Checked)
            {
                Buf.Append("    以上小计             ", GB2312); Buf.Append(d2str(discount, 7) + "\r\n", GB2312);
                Buf.Append("- - - - - - - - - - - - - - - -\r\n", GB2312);
                discount *= (double)CurrentOrder.DiscountRate;
                Buf.Append("    折扣后      ========>", GB2312); Buf.Append(d2str(discount, 7) + "\r\n", GB2312);
            }
            else
            {
                Buf.Append("- - - - - - - - - - - - - - - -\r\n", GB2312);
                Buf.Append("合计:        " + d2str(no, 7) + d2str(discount , 12) + "\r\n", GB2312);
            }
/*
            if (CurrentOrder.Deduct != 0)
            {
                Buf.Append("优惠:              ", GB2312);
                Buf.Append(d2str((double)-CurrentOrder.Deduct, 13) + "\r\n", GB2312);
            }
*/
            Buf.Append("现金:              " + d2str((double)CurrentOrder.Income, 13) + "\r\n", GB2312);
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n", GB2312);
            Buf.Append("\f", GB2312);
//            string str = Buf.ToString();
//            File.WriteAllBytes("Test.txt",Encoding.UTF8.GetBytes(str));
            RawPrint.SendManagedBytes(PrinterName, Buf.ToBytes());
            RawPrint.SendManagedBytes(PrinterName, CutPaper);
       }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvItems.Items.Count == 0) return;
            Print();
        }

        private void btnCashDrawer_Click(object sender, EventArgs e)
        {
            byte[] CashDrawer = new byte[] { 0x1B, (byte)'p',0,100,200 };
            RawPrint.SendManagedBytes(PrinterName,CashDrawer);
        }
    }
}
