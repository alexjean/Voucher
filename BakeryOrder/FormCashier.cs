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

        private BakeryOrderSet.ProductRow GetFoodMenuItem(int id, int x, int y)
        {
            int x1 = x + id * 10;  // x最多不到10行,所以用x編碼菜單id
            foreach (BakeryOrderSet.ProductRow Row in bakeryOrderSet.Product.Rows)
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
            CalcTotal();
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
                    CreateSmallImage(big, pictureBoxOrdered.Width, pictureBoxOrdered.Height, small);
                }
                Image img = Bitmap.FromFile(small);
                pictureBoxOrdered.Image = img;
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
                CreateSmallImage(big, pictureBoxOrdered.Width, pictureBoxOrdered.Height, small);
            }
            Image img=Bitmap.FromFile(small);
            pictureBoxOrdered.Image = img;
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
                    BakeryOrderSet.ProductRow Row = GetFoodMenuItem(menuId, x, y);
                    if (Row != null)
                    {
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
            var rows = from row in bakeryOrderSet.Product
                       where row.Code < SpeicalRowCodeForMenu
                       orderby row.Code descending
                       select row;
            tabControl1.TabPages.Clear();
            if (rows.Count() == 0)   // 都沒有的話留下預設的
            {
                tabControl1.TabPages.Add("面包");
/*              FormCasiher不需要
                int maxID = (from ro in bakeryOrderSet.Product
                             select ro.ProductID).Max();
                BasicDataSet.ProductRow row = bakeryOrderSet.Product.NewProductRow();
                row.ProductID = ++maxID;
                row.Name = SystemMenuName("面包", 1);
                row.Code = -1;
                row.MenuX = -1;
                row.MenuY = -1;
                bakeryOrderSet.Product.AddProductRow(row);
                SaveProduct();
*/
            }
            else
            {
                String str;
                int i;
                foreach (BakeryOrderSet.ProductRow row in rows)
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

        FormCustomer m_FormCustomer =null;
        FormStatics  m_FormStatics  = null;
        const string m_ProductDir   = "Photos\\Products";
        const string m_SmallDir     = m_ProductDir + "\\Small";
        string       m_PrinterName  = "BTP-R580(U)";
        int          m_PosID        = 0;
        int          m_CashierID    = 1;
        HardwareConfig m_Cfg        = new HardwareConfig();
        OrderAdapter     m_OrderTableAdapter     = new OrderAdapter();
        OrderItemAdapter m_OrderItemTableAdapter = new OrderItemAdapter();

        private void FormCashier_Load(object sender, EventArgs e)
        {
            m_Cfg.Load();
            if (m_Cfg.PrinterName != null) m_PrinterName = m_Cfg.PrinterName;
            m_PosID = m_Cfg.iPosID;
            
//            productTableAdapter1.Connection = MapPath.BasicConnection;
            try
            {

                this.productTableAdapter.Fill(this.bakeryOrderSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取BakeryOrder.Product時出錯! 原因:"+ex.Message);
                Close();
                return;
            }
            DateTime now=DateTime.Now;
            LoadData(now.Month, now.Day);

            // 程式保留row.Code 0做為菜單的寬高,這行不是產品
            var rows = from row in bakeryOrderSet.Product
                       where row.Code == SpeicalRowCodeForMenu
                       select row;
            foreach (BakeryOrderSet.ProductRow row in rows)
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

        void LoadData(int m, int d)
        {
            string sql = "Where INT(ID/1000000)=" + m.ToString("d2") + d.ToString("d2");
            int MaxID = 0;
            try
            {
                m_OrderTableAdapter.FillBySelectStr    (bakeryOrderSet.Order    , "Select * From [Order] "     + sql + " Order by ID");
                m_OrderItemTableAdapter.FillBySelectStr(bakeryOrderSet.OrderItem, "Select * From [OrderItem] " + sql);
                foreach (BakeryOrderSet.OrderRow R in bakeryOrderSet.Order.Rows)
                {
                    int id = R.ID % 10000;       // 資料定義為 MMDDNN9999  N POS机号,此處店號放0不管,店長收資料時,再自動填上
                    if (id > MaxID) MaxID = id;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("BakeryOrder.Header讀取錯誤!" + str);
            }
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
                m = Buf.DefaultEncoding.GetByteCount(s);
                if (m <= 16) break;
                s = s.Substring(0, s.Length - 1);
            } while (true);
            int n = 16 - m + s.Length;
            Buf.AppendPadRight(s, n);
            Buf.Append(d2str(mItem.No, 4));
            Buf.Append(d2str(mItem.Price, 5));
            Buf.Append(d2str(mItem.Money(), 7));
            Buf.Append("\r\n");
        }

        int CreateOrder(out BakeryOrderSet.OrderRow order)
        {
            order = bakeryOrderSet.Order.NewOrderRow();
            DateTime now = DateTime.Now;
            int maxID = 0;
            int id;
            foreach (BakeryOrderSet.OrderRow row in bakeryOrderSet.Order)    // 編號 MMDDNN9999 , MM月 DD日 NN台號 9999單號
            {
                id = row.ID % 10000;
                if (id > maxID) maxID = id;
            }
            id = (m_PosID % 100) + now.Month * 10000 + now.Day * 100;
            order.ID = id*10000+maxID + 1;
            order.DiscountRate = 0.9m;
            order.Income = (decimal)CalcTotal();
            order.CashierID = m_CashierID;
            order.Deleted = false;
            return order.ID;
        }

        string PrintTitle   = "     原麦山丘华宇店";
        string PrintAddress = "地址:中关村南大街2号";
        string PrintTel     = "电话:60956577";
        BakeryOrderSet.OrderRow m_CurrentOrder = null;

        void Print(BakeryOrderSet.OrderRow CurrentOrder)      
        {
            //byte[] PrintChinese = new byte[] { };
            byte[] BorderMode = new byte[] { 0x1c, 0x21, 0x28 };
            byte[] NormalMode = new byte[] { 0x1c, 0x21, 0    };
            byte[] CutPaper   = new byte[] { 0x1B, (byte)'i'  };
            int n;

            ByteBuilder Buf = new ByteBuilder(2048);
            Buf.DefaultEncoding=Encoding.GetEncoding("GB2312");

            CurrentOrder.PrintTime = DateTime.Now;
            if (!SaveOrder(CurrentOrder)) return;

            Buf.Append(BorderMode);                                      // 設定列印模式28
            Buf.Append(PrintTitle+"\r\n");
            Buf.Append(NormalMode);                                      // 設定列印模式正常 

            Buf.Append("\r\n");
            Buf.Append(PrintAddress+"\r\n");
            Buf.AppendPadRight(PrintTel, 19);
            n = (CurrentOrder.ID % 1000);
            Buf.Append("序号:" + n.ToString("d4") + "\r\n");
            Buf.AppendPadRight("时间:" + CurrentOrder.PrintTime.ToString("yy/MM/dd hh:mm"), 19);
            Buf.Append("工号: 001" +  "\r\n\r\n");

            Buf.Append(BorderMode);                                      // 設定列印模式28
            Buf.Append("  品名        数量 单价   金额\r\n");
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
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
                Buf.Append("    以上小计             "); Buf.Append(d2str(discount, 7) + "\r\n");
                Buf.Append("- - - - - - - - - - - - - - - -\r\n");
                discount *= (double)CurrentOrder.DiscountRate;
                Buf.Append("    折扣后      ========>"); Buf.Append(d2str(discount, 7) + "\r\n");
            }
            else
            {
                Buf.Append("- - - - - - - - - - - - - - - -\r\n");
                Buf.Append("合计:        " + d2str(no, 7) + d2str(discount , 12) + "\r\n");
            }
/*
            if (CurrentOrder.Deduct != 0)
            {
                Buf.Append("优惠:              ");
                Buf.Append(d2str((double)-CurrentOrder.Deduct, 13) + "\r\n");
            }
*/
            Buf.Append("现金:              " + d2str((double)CurrentOrder.Income, 13) + "\r\n");
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n");
            Buf.Append("\f");
//            string str = Buf.ToString();
//            File.WriteAllBytes("Test.txt",Encoding.UTF8.GetBytes(str));
            if (!checkBoxTest.Checked)
            {
                RawPrint.SendManagedBytes(m_PrinterName, Buf.ToBytes());
                RawPrint.SendManagedBytes(m_PrinterName, CutPaper);
            }
       }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvItems.Items.Count == 0) return;
            if (m_CurrentOrder == null)
                CreateOrder(out m_CurrentOrder);
            if (m_CurrentOrder.RowState != DataRowState.Detached)
            {
                MessageBox.Show("己經打印過的單子,無法再印! 請按<新單>");
                return;
            }
            m_CurrentOrder.Income = (decimal)CalcTotal();
            Print(m_CurrentOrder);
            btnCashDrawer_Click(null, null);
        }

        private void btnCashDrawer_Click(object sender, EventArgs e)
        {
            
            byte[] CashDrawer = new byte[] { 0x1B, (byte)'p',0,150,100 };
            if (!this.checkBoxTest.Checked)
                RawPrint.SendManagedBytes(m_PrinterName,CashDrawer);
        }

        private void btnStatics_Click(object sender, EventArgs e)
        {
            if (m_FormStatics == null)
                m_FormStatics = new FormStatics(bakeryOrderSet,m_OrderTableAdapter);
            if (m_FormStatics.ShowDialog() == DialogResult.Abort)
                Close();
            else 
                Show();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            int no=CreateOrder(out m_CurrentOrder)%10000;
            foreach (ListViewItem lv in lvItems.Items)
            {
                MenuItemForTag item=lv.Tag as MenuItemForTag;
                Item2List(item, MouseButtons.Right);
                Label l = item.LabelNo;
                l.BorderStyle = BorderStyle.Fixed3D;
                l.Text = item.name;
            }
            lvItems.Columns[1].Text = "序号 " + no.ToString();
            lvItems.Columns[2].Text = "量";
            lvItems.Columns[3].Text = "金额";
        }

        void SetOrderItemFromListViewItem(BakeryOrderSet.OrderItemRow Row, ListViewItem lvItem, int i)
        {   // Row.ID由ParentRow決定不用填
            MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
            Row.Index = (short)i;
            Row.Code  = item.code;
            Row.No    = (decimal)item.No;
            Row.Price = (decimal)item.Price;
            Row.Discount = false;    // 目前不使用打折
        }
        void Update_OrderItemRows(BakeryOrderSet.OrderRow CurrentOrder,BakeryOrderSet.OrderItemRow[] ItemRows, int i, ListViewItem lvItem)
        {
            if (ItemRows[i] == null)
            {
                BakeryOrderSet.OrderItemRow Row = bakeryOrderSet.OrderItem.NewOrderItemRow();
                SetOrderItemFromListViewItem(Row, lvItem, i);
                Row.SetParentRow(CurrentOrder);
                bakeryOrderSet.OrderItem.AddOrderItemRow(Row);
                ItemRows[i] = Row;
            }
            else
            {
                ItemRows[i].BeginEdit();
                SetOrderItemFromListViewItem(ItemRows[i], lvItem, i);  // 原始的資料應該己經設了ParentRow
                ItemRows[i].EndEdit();
            }
        }


        private bool SaveOrder(BakeryOrderSet.OrderRow CurrentOrder)
        {
            bool IsNewRecord = (CurrentOrder.RowState == DataRowState.Detached);
            if (IsNewRecord)
            {
                CurrentOrder.SaveTime = DateTime.Now;
                if (CurrentOrder.IsPrintTimeNull())
                    CurrentOrder.PrintTime = DateTime.Now;
                bakeryOrderSet.Order.AddOrderRow(CurrentOrder);
            }
            try
            {
                if (CurrentOrder.RowState != DataRowState.Unchanged)   // 不用管Deleted,Detached不會發生
                {
                    m_OrderTableAdapter.Update(CurrentOrder);
                    CurrentOrder.AcceptChanges();
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
                return false;
            }

            List<BakeryOrderSet.OrderItemRow> ItemDeleted = new List<BakeryOrderSet.OrderItemRow>();
            BakeryOrderSet.OrderItemRow[]     OrderDetail = CurrentOrder.GetOrderItemRows();
            try
            {
                int count = lvItems.Items.Count;
                BakeryOrderSet.OrderItemRow[] ItemRows = new BakeryOrderSet.OrderItemRow[count];
                if (OrderDetail != null)
                {
                    foreach (BakeryOrderSet.OrderItemRow Row in OrderDetail)
                    {
                        if (Row.Index < count && (ItemRows[Row.Index] == null))   // 有重複的,以第一個為準
                            ItemRows[Row.Index] = Row;
                        else
                            ItemDeleted.Add(Row);
                    }
                }
                int i = 0;
                foreach (ListViewItem lvItem in lvItems.Items)
                {
                    if (i >= count) break;  // 不應發生,以防萬一
                    Update_OrderItemRows(CurrentOrder,ItemRows, i, lvItem);
                    i++;
                }
                OrderDetail = ItemRows;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message + "<OrderItem更新出錯,是否二台在改同一單?>");
                return false;
            }

            try
            {
                if (ItemDeleted.Count != 0) // 處理要刪掉的
                {
                    BakeryOrderSet.OrderItemRow[] RowDeleted = new BakeryOrderSet.OrderItemRow[ItemDeleted.Count];
                    for (int i = 0; i < ItemDeleted.Count; i++)
                    {
                        BakeryOrderSet.OrderItemRow row = ItemDeleted[i];
                        row.Delete();
                        RowDeleted[i] = row;
                    }
                    m_OrderItemTableAdapter.Update(RowDeleted);
                }
                m_OrderItemTableAdapter.Update(OrderDetail);
                this.bakeryOrderSet.OrderItem.AcceptChanges();
            }
            catch (Exception E)
            {
                if (E.GetType() != typeof(System.Data.DBConcurrencyException))
                    MessageBox.Show(E.Message + "Update(OrderItem)出錯");
                else
                {
                    MessageBox.Show("發生並行違例,可能是別台己經改過這張單子,你必需重啟程式,重新修改!");
                    Close();
                }
                return false;
            }
            return true;
        }

    }
}
