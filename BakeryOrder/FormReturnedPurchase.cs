using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Drawing.Drawing2D;

namespace BakeryOrder
{
    public partial class FormReturnedPurchase : Form
    {

        public FormReturnedPurchase(int Cashierid, PrintInfo printer, int posID,int storeID,string Cashiername)
        {
            m_CashierID = Cashierid;
            m_Printer = printer;
            m_PosID = posID;
            m_StoreID = storeID;
            m_CashierName = Cashiername;
            InitializeComponent();
        }

        private void btnDoCashier_Click(object sender, EventArgs e)
        {
            //Form form = new FormReturnCheckout(tabControl1.Left + 8, 8);
            //form.ShowDialog();
            if (m_DataSealed)
            {
                MessageBoxShow("今日資料己封印! 無法打單");
                return;
            }
            if (lvItems.Items.Count == 0)
                return;
            if (m_CurrentOrder == null)
            {
                CreateOrder(out m_CurrentOrder, m_MaxOrderID);
                if (m_CurrentOrder == null) return;
            }
            if (m_CurrentOrder.RowState != DataRowState.Detached)
            {
                MessageBoxShow("己經打印過的單子,無法再印! 請按<新單>");
                return;
            }
            decimal moneyGot = 0;
           // Form form = new FormCheckout(tabControl1.Left + 8, 8, m_CurrentOrder, (decimal)CalcTotal());
            Form form = new FormReturnCheckout(tabControl1.Left + 8, 8, m_CurrentOrder, (decimal)CalcTotal());
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.Tag.GetType() == typeof(decimal))
                    moneyGot = (decimal)(form.Tag);
                else
                    moneyGot = 0m;
                if (m_CurrentOrder.IsIncomeNull())
                {
                    MessageBox.Show("沒有應收數字! 無法打單");
                    return;
                }
                if ((!m_CurrentOrder.IsDeductNull()) && m_CurrentOrder.Deduct != 0)
                {
                    labelDeduct.Text = m_CurrentOrder.Deduct.ToString();
                    labelDeduct.Visible = labelDeductTitle.Visible = true;
                    labelTotal.Text = m_CurrentOrder.Income.ToString();
                }
                labelClass.Text = PayByChinese(m_CurrentOrder.PayBy[0]);
                Print(m_CurrentOrder, (double)moneyGot);
                if (!this.checkBoxTest.Checked)
                    RawPrint.SendManagedBytes(m_Printer.PrinterName, m_CashDrawer);   // 彈出錢箱
                CreateUpdateDrawerRecord(ref m_MaxDrawerRecordID, m_CurrentOrder.ID % 10000);
            }
        }

        private void btnStatics_Click(object sender, EventArgs e)
        {
            if (m_FormStatics == null)
                m_FormStatics = new FormStatics(bakeryOrderSet, m_OrderTableAdapter, m_CashierID, m_Printer, m_DataSealed, m_PosID,m_StoreID,true);
            DialogResult result = m_FormStatics.ShowDialog();
            if (result == DialogResult.Abort)
            {
                Close();
            }
            else if (result == DialogResult.Cancel)
            {
                SetLoginStatus(false);
                m_CashierID = -1;
                textBoxCashierID.Text = "";
                textBoxPassword.Text = "";
                textBoxCashierID.Focus();
                Show();
            }
            else if (result == DialogResult.OK)
                Show();
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
            recTab = new Rectangle(recTab.X + 3, recTab.Y + 13, recTab.Width, recTab.Height - 4);
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
        private ListViewItem FindByProductIDFromList(int productID)
        {
            foreach (ListViewItem lvItem in lvItems.Items)
            {
                MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
                if (productID == item.ProductID) return lvItem;
            }
            return null;
        }

        private void Add2List(MenuItemForTag item, bool AtFirst)
        {
            ListViewItem lvItem = FindByProductIDFromList(item.ProductID);
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
                    lvItem = lvItems.Items.Insert(0, item.ProductID.ToString());
                else
                    lvItem = lvItems.Items.Add(item.ProductID.ToString());
                lvItem.SubItems.Add(item.name);
                lvItem.SubItems.Add(no.ToString());
                lvItem.SubItems.Add(money.ToString());
            }
            lvItem.Tag = item;
        }

        // ListView的tag 指向MenuItem
        private bool Sub2List(MenuItemForTag item)
        {
            ListViewItem lvItem = FindByProductIDFromList(item.ProductID);
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
            if (m_FormCustomer != null)
                m_FormCustomer.Item2List(item.ProductID, item.name, item.No, item.Money());
            return;
        }

        private double CalcTotal()
        {
            double total = 0;
            double no = 0, sum = 0;
            foreach (ListViewItem lvItem in lvItems.Items)
            {
                MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
                sum -= item.Money();
                no += item.No;
            }
            sum = Math.Round(sum, 1);
            lvItems.Columns[2].Text = no.ToString();
            lvItems.Columns[3].Text = sum.ToString();
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
            if (m_FormCustomer != null)
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
            if (m_CurrentOrder != null && m_CurrentOrder.RowState != DataRowState.Detached)    // 打印過的單子先清,再加
            {
                MessageBox.Show("打印過的單子,無法刪除!");
                return;
            }
            Label l = (Label)sender;
            MenuItemForTag item = (MenuItemForTag)l.Tag;
            Item2List(item, MouseButtons.Right);
            l.BorderStyle = BorderStyle.Fixed3D;
            item.LabelNo.Text = item.name;
            int count = lvItems.Items.Count;
            if (count > 0)                      // 取消產品, 顯示ListView上最後一個品項
            {
                MenuItemForTag tag = lvItems.Items[count - 1].Tag as MenuItemForTag;
                string idStr = tag.id.ToString();
                string small = m_SmallDir + "\\" + idStr + ".jpg";
                if (!File.Exists(small))
                {
                    string big = m_ProductDir + "\\" + idStr + ".jpg";
                    CreateSmallImage(big, pictureBoxOrdered.Width, pictureBoxOrdered.Height, small);
                }
                Image img = Bitmap.FromFile(small);
                pictureBoxOrdered.Image = img;
                if (m_FormCustomer != null)
                    m_FormCustomer.SetPicture(img);
            }
        }

        void CreateSmallImage(string sourceFile, int w, int h, string destFile)
        {
            if (!File.Exists(sourceFile))
            {
                Bitmap img1 = new Bitmap(1, 1);
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
                newbmp.Save(destFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            GC.Collect();
        }

        private void MenuClick(object sender, MouseEventArgs e)
        {
            if (m_CurrentOrder != null && m_CurrentOrder.RowState != DataRowState.Detached)    // 打印過的單子先清,再加
            {
                DoNewOrder();
            }

            Label l = (Label)sender;
            MenuItemForTag item = (MenuItemForTag)l.Tag;
            Item2List(item, e.Button);
            if (item.No > 0)
                l.BorderStyle = BorderStyle.FixedSingle;
            else l.BorderStyle = BorderStyle.Fixed3D;
            if (item.No == 1 || item.No == 0)
                item.LabelNo.Text = item.name;
            else
                item.LabelNo.Text = item.name + "  " + item.NoToString();
            string idStr = item.id.ToString();
            string small = m_SmallDir + "\\" + idStr + ".jpg";
            if (!File.Exists(small))
            {
                string big = m_ProductDir + "\\" + idStr + ".jpg";
                CreateSmallImage(big, pictureBoxOrdered.Width, pictureBoxOrdered.Height, small);
            }
            Image img = Bitmap.FromFile(small);
            pictureBoxOrdered.Image = img;
            Application.DoEvents();           // 先把前面做的顯示出來
            if (m_FormCustomer != null)
            {
                m_FormCustomer.SetTimer(45000);   // 停止轉圖, 同時會把Dock改成Right,露出結帳單
                m_FormCustomer.SetPicture(img);
            }
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
                        content.ProductID = Row.ProductID;
                        content.classcode = Row.Class;
                        content.LabelNo = l;
                        content.name = Row.Name.ToString();
                        l.Tag = content;
                        l.Text = content.name;
                        l.MouseClick += new MouseEventHandler(this.MenuClick);
                       //l.MouseDoubleClick += new MouseEventHandler(this.MenuDoubleClick);
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





        FormCustomer m_FormCustomer = null;
        FormStatics m_FormStatics = null;
        const string m_ProductDir = "Photos\\Products";
        const string m_SmallDir = m_ProductDir + "\\Small";
        int m_PosID = 0;    // FormCashier的m_PosID己經不使用,由店長收取資料時填取
        int m_StoreID = 0;
        int m_CashierID = -1;
        int m_CashierID1 = -1;
        string m_CashierName = "";
        string m_CashierName1 = "";
        PrintInfo m_Printer = new PrintInfo();
        bool m_DataSealed = false;
        int m_MaxOrderID = 0;
        int m_MaxDrawerRecordID = 0;
        HardwareConfig m_Cfg = new HardwareConfig();
        OrderAdapter m_OrderTableAdapter = new OrderAdapter();
        OrderItemAdapter m_OrderItemTableAdapter = new OrderItemAdapter();
        DrawerRecordAdapter m_DrawerReocrdAdapter = new DrawerRecordAdapter();
        DateTime m_Today = DateTime.Now;

        BakeryConfig m_BakeryConfig = new BakeryConfig(".");
        string BakeryConfigName = "FormCashier";
        string BakeryTableName = "PrintTitle";

        //void LoadBakeryConfig()
        //{
        //    XmlNode root = m_BakeryConfig.Load(BakeryConfigName, BakeryTableName);
        //    if (root == null) return;
        //    XmlNode node = root.FirstChild;
        //    if (node == null) return;
        //    if (node.Name == "Print")
        //    {
        //        XmlAttribute attr;
        //        attr = node.Attributes["Title"];
        //        if (attr != null) m_Printer.Title = attr.Value;
        //        attr = node.Attributes["Addr"];
        //        if (attr != null) m_Printer.Address = attr.Value;
        //        attr = node.Attributes["Tel"];
        //        if (attr != null) m_Printer.Tel = attr.Value;
        //        attr = node.Attributes["PosNo"];
        //        if (attr != null && attr.Value != null) int.TryParse(attr.Value, out m_PosID);
        //    }
        //}


        void ReLoadAllData()
        {

            m_Cfg.Load();
           // if (m_Cfg.PrinterName != null) m_Printer.PrinterName = m_Cfg.PrinterName;
           // LoadBakeryConfig();
            m_Today = DateTime.Now;
            //            productTableAdapter1.Connection = MapPath.BasicConnection;
            try
            {
                headerTableAdapter.Fill(bakeryOrderSet.Header);
                productTableAdapter.Fill(bakeryOrderSet.Product);
                cashierTableAdapter.Fill(bakeryOrderSet.Cashier);
                //// m_PosID存在 [Cashier.CashierName] where CashierID= int.Max , 每次店長修改權限存檔時放進去
                //var cashiers = from row in bakeryOrderSet.Cashier where (row.CashierID == int.MinValue) select row;
                //if (cashiers.Count() != 0)
                //{
                //    var cashier = cashiers.First();
                //    string name=cashier.CashierName;
                //    if (name.Substring(0, 6) == "PosID=")
                //    {
                //        int result;
                //        if (int.TryParse(name.Substring(6), out result)) m_PosID = result;
                //    }
                //}
                // 讀取封印資訊
                var headers = from row in bakeryOrderSet.Header where (row.DataDate.Date == m_Today.Date) select row;
                m_DataSealed = false;
                if (headers.Count() > 0)
                {
                    var header = headers.First();
                    if (!header.IsClosedNull() && header.Closed) m_DataSealed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow("讀取BakeryOrder.Product Cashier時出錯! 原因:" + ex.Message);
                Close();
                return;
            }
            DateTime now = DateTime.Now;
            m_MaxDrawerRecordID = LoadDrawerRecordData(now.Month, now.Day);
            m_MaxOrderID = LoadData(now.Month, now.Day);

            // 程式保留row.Code 0做為菜單的寬高,這行不是產品
            var rows = from row in bakeryOrderSet.Product
                       where row.Code == SpeicalRowCodeForMenu
                       select row;
            BakeryOrderSet.ProductRow rowSpecial = rows.First();
            MyLayout.NoX = -rowSpecial.MenuX;
            MyLayout.NoY = -rowSpecial.MenuY;
            LoadTabControlItem();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            UpdateAllFoodMenu();
            m_CurrentOrder = null;
        }

        private void FormReturnedPurchase_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen;
            Location = new Point(scr.Bounds.Left, scr.Bounds.Top);

#if DEBUG
            checkBoxTest.Visible = true;
            checkBoxTest.Checked = true;
            btnTest.Visible = true;
            m_CashierID1 = 1; m_CashierName = "测试员";
#endif
            for (int i = 0; i <= 9; i++)
            {
                string name = "btnNumber" + i.ToString();
                foreach (Control ctl in panelLogin.Controls)
                    if (ctl.Name == name)
                    {
                        ctl.Click += this.btnNumberX_Click;
                        break;
                    }
            }


            ReLoadAllData();
            if (Screen.AllScreens.Count() > 1)
            {
                m_FormCustomer = new FormCustomer();
                m_FormCustomer.Show();
            }
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            if (!Directory.Exists(m_ProductDir))
                Directory.CreateDirectory(m_ProductDir);
            if (!Directory.Exists(m_SmallDir))
                Directory.CreateDirectory(m_SmallDir);
            if (m_CashierID1 < 0)
            {
                SetLoginStatus(false);
            }
            else
                SetLoginStatus(true);

        }

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
                    int id = R.ID % 10000;       // 資料定義為 MMDDNN9999  N POS机号,店長收資料時,再自動填上
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBoxShow("BakeryOrder.Order OrderItem讀取錯誤:" + str);
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
                    int id = R.DrawerRecordID % 100000;       // 資料定義為 MMDDN99999  N POS机号比Order.ID少一位, id最多10萬筆多十倍
                    if (id > MaxID) MaxID = id;
                }
                return MaxID;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBoxShow("BakeryOrder.DrawerRecord讀取錯誤!" + str);
                return -1;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (m_FormCustomer != null)
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

        // m_MaxOrderID在SaveOrder時才去更新
        int CreateOrder(out BakeryOrderSet.OrderRow order, int maxID)
        {
            try
            {
                order = bakeryOrderSet.Order.NewOrderRow();
                DateTime now = DateTime.Now;
                int id;
                id = (m_PosID % 10) + now.Month * 1000 + now.Day * 10;
                order.ID = id * 100000 + maxID + 1;
                order.DiscountRate = 1m;
                order.Income = (decimal)CalcTotal();
                order.CashierID = m_CashierID;
                order.RCashierID = m_CashierID1;
                order.Deleted = false;
                // PrintTime在後面會設,NewRecord 如果有任一個Field沒設定是IsNull,再次Upate就會 並行違例.
                // 舊的Record因為從Database讀出來時,就會有預設資料所以不會有問題
                order.BranchID = 0;
                order.Deduct = 0;
                order.PayBy = DicPayBy.First().Key.ToString();
                return order.ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CreateOrder錯誤,原因:" + ex.Message);
                order = null;
                return 0;
            }
        }

        int CreateUpdateDrawerRecord(ref int maxID, int associateOrderID)
        {
            BakeryOrderSet.DrawerRecordRow record = bakeryOrderSet.DrawerRecord.NewDrawerRecordRow();
            DateTime now = DateTime.Now;
            int id;
            id = (m_PosID % 10) + now.Month * 1000 + now.Day * 10;
            record.DrawerRecordID = id * 100000 + maxID + 1;
            record.CashierID = m_CashierID;
            record.OpenTime = now;
            record.AssociateOrderID = associateOrderID;
            try
            {
                bakeryOrderSet.DrawerRecord.AddDrawerRecordRow(record);
                m_DrawerReocrdAdapter.Update(bakeryOrderSet.DrawerRecord);
                maxID++;  // 存成功了才去更新maxID
            }
            catch (Exception ex)
            {
                MessageBoxShow("更新BakeryOrder.DrawerRecord時出錯,原因:" + ex.Message);
                return -1;
            }
            return record.DrawerRecordID;
        }


        //ESC　*　设置图形点阵
        //格式:   ASCII：　ESC　 *　 m　 n1　 n2　 D1，D2 … Dk
        //        十进制：　27 42 m　 n1　 n2　 D1，D2 … Dk
        //该命令用来设置点阵图形模式（m）和横向图形点阵。
        //m = 0，1： 表示打印密度。
        //0≤n1≤255，0≤n2≤1，0≤Dk≤255，k= n1+ n2×256。
        //n1，n2为两位十六进制数，n1这低字节，n2这高字节，k= n1+ n2×256，
        //表示该命令下载的要打印图形的横向点数，该值应小于打印机的最大行宽打印点数。
        //如果下送的点图数据超出一行的最大行宽打印点数时，超出的部分被忽略。
        //m 垂直方向点数 点密度 最大点数 图形打印模式
        //0 8 单密度 210 相邻点打印
        //1 8 双密度 420 相邻点不打印


        BakeryOrderSet.OrderRow m_CurrentOrder = null;

        void Print(BakeryOrderSet.OrderRow CurrentOrder, double moneyGot)
        {
            //byte[] PrintChinese = new byte[] { };
            byte[] BorderMode = new byte[] { 0x1c, 0x21, 0x28 };
            byte[] NormalMode = new byte[] { 0x1c, 0x21, 0 };
            byte[] CutPaper = new byte[] { 0x1B, (byte)'i' };
            int n;

            ByteBuilder Buf = new ByteBuilder(2048);
            Buf.DefaultEncoding = Encoding.GetEncoding("GB2312");

            CurrentOrder.PrintTime = DateTime.Now;
            string oldOrderId= CurrentOrder.OldID.ToString();
           int length= oldOrderId.Length;
           string No = oldOrderId.Remove(0,length-4);
           string posNo = oldOrderId.Remove(0, length - 6).Remove(1);
            string datetime=oldOrderId.Remove(4);
            if (length==9)
	        {
		         datetime=0+oldOrderId.Remove(3);
	        }

            if (!SaveOrder(CurrentOrder)) return;

            Buf.Append(BorderMode);                                      // 設定列印模式28
            Buf.Append(m_Printer.Title + " （退单）"+"\r\n");
            Buf.Append(NormalMode);                                      // 設定列印模式正常 

            Buf.Append("\r\n");
            Buf.Append(m_Printer.Address + "\r\n");
            Buf.AppendPadRight(m_Printer.Tel, 19);
            n = (CurrentOrder.ID % 1000);
            Buf.Append("序号:" + m_PosID.ToString() + "-" + n.ToString("d4") + "\r\n");
            Buf.AppendPadRight("时间:" + CurrentOrder.PrintTime.ToString("yy/MM/dd HH:mm"), 19);
            Buf.Append("收银" + m_CashierID.ToString("d03") + m_CashierName + "\r\n");
            Buf.Append("旧单信息:" + "\r\n");
            Buf.AppendPadRight("时间:" +datetime.Insert(2, "/")+"  序号:"+posNo+"-"+No,20);
            Buf.Append("授权" + m_CashierID1.ToString("d03") + m_CashierName1 + "\r\n\r\n");

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
            Buf.Append("- - - - - - - - - - - - - - - -\r\n");
            Buf.Append("小计:        " + d2str(no, 7) + d2str(-discount, 12) + "\r\n");
            if ((!CurrentOrder.IsDeductNull()) && (CurrentOrder.Deduct != 0))
            {
                Buf.Append("优惠:              ");
                Buf.Append(d2str((double)CurrentOrder.Deduct, 13) + "\r\n");
                Buf.Append("应收:   ========>  ");
                Buf.Append(d2str((double)CurrentOrder.Income, 13) + "\r\n");
            }


            if (moneyGot > 0)
            {
                Buf.Append("        实退             "); Buf.Append(d2str(moneyGot, 7) + "\r\n");
                Buf.Append("        收零             "); Buf.Append(d2str(moneyGot - (double)CurrentOrder.Income, 7) + "\r\n");
            }
            else
                Buf.Append(PayByChinese(CurrentOrder.PayBy[0]) + ":              " + d2str((double)CurrentOrder.Income, 13) + "\r\n");
            Buf.Append(NormalMode);
            Buf.Append("* * * * * * * * * * * * * * * *\r\n\r\n\r\n\r\n\r\n\r\n");
            Buf.Append("\f");
            if (!checkBoxTest.Checked)
            {
                RawPrint.SendManagedBytes(m_Printer.PrinterName, Buf.ToBytes());
                RawPrint.SendManagedBytes(m_Printer.PrinterName, CutPaper);
            }
            else
            {
                string str = Buf.ToString();
                File.WriteAllBytes("Test.txt", Encoding.UTF8.GetBytes(str));
            }
        }

        byte[] m_CashDrawer = new byte[] { 0x1B, (byte)'p', 0, 150, 100 };
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (m_DataSealed)
            {
                MessageBoxShow("今日資料己封印! 無法打單");
                return;
            }
            if (lvItems.Items.Count == 0) return;
            if (m_CurrentOrder == null)
            {
                CreateOrder(out m_CurrentOrder, m_MaxOrderID);
                if (m_CurrentOrder == null) return; // 產生錯誤
            }
            if (m_CurrentOrder.RowState != DataRowState.Detached)
            {
                MessageBoxShow("己經打印過的單子,無法再印! 請按<新單>");
                return;
            }
            m_CurrentOrder.Income = (decimal)CalcTotal();
            //            m_CurrentOrder.PayBy = PayByFromBtn().ToString();
            Print(m_CurrentOrder, 0);
            if (!this.checkBoxTest.Checked)
                RawPrint.SendManagedBytes(m_Printer.PrinterName, m_CashDrawer);
            CreateUpdateDrawerRecord(ref m_MaxDrawerRecordID, m_CurrentOrder.ID % 10000);
            //            DoNewOrder();
        }

        private void btnCashDrawer_Click(object sender, EventArgs e)
        {
            if (!this.checkBoxTest.Checked)
                RawPrint.SendManagedBytes(m_Printer.PrinterName, m_CashDrawer);
            CreateUpdateDrawerRecord(ref m_MaxDrawerRecordID, -1);  // 沒有相應的訂單
        }

        //private void btnStatics_Click(object sender, EventArgs e)
        //{
        //    if (m_FormStatics == null)
        //        m_FormStatics = new FormStatics(bakeryOrderSet, m_OrderTableAdapter, m_CashierID, m_Printer, m_DataSealed, m_PosID);
        //    DialogResult result = m_FormStatics.ShowDialog();
        //    if (result == DialogResult.Abort)
        //    {
        //        Close();
        //    }
        //    else if (result == DialogResult.Cancel)
        //    {
        //        SetLoginStatus(false);
        //        m_CashierID = -1;
        //        textBoxCashierID.Text = "";
        //        textBoxPassword.Text = "";
        //        textBoxCashierID.Focus();
        //        Show();
        //    }
        //    else if (result == DialogResult.OK)
        //        Show();
        //}

        void ClearOrderInfoOnScreen()
        {
            lvItems.Columns[2].Text = "量";
            lvItems.Columns[3].Text = "金额";

            labelDeduct.Text = "";
            labelDeduct.Visible = labelDeductTitle.Visible = false;
            labelTotal.Text = "";
            labelClass.Text = DicPayBy.First().Value;
        }

        private void DoNewOrder()
        {
            int no = CreateOrder(out m_CurrentOrder, m_MaxOrderID) % 10000;
            if (m_CurrentOrder == null) return;    // 錯誤產生
            foreach (ListViewItem lv in lvItems.Items)
            {
                MenuItemForTag item = lv.Tag as MenuItemForTag;
                Item2List(item, MouseButtons.Right);
                Label l = item.LabelNo;
                l.BorderStyle = BorderStyle.Fixed3D;
                l.Text = item.name;
            }
            lvItems.Columns[1].Text = "序号 " + no.ToString();
            ClearOrderInfoOnScreen();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            DoNewOrder();
        }

        void SetOrderItemFromListViewItem(BakeryOrderSet.OrderItemRow Row, ListViewItem lvItem, int i)
        {   // Row.ID由ParentRow決定不用填
            MenuItemForTag item = (MenuItemForTag)lvItem.Tag;
            Row.Index = (short)i;
            Row.ProductID = item.ProductID;
            Row.No = (decimal)item.No;
            Row.Price = (decimal)item.Price;
            Row.Discount = false;    // 目前不使用打折
        }
        void Update_OrderItemRows(BakeryOrderSet.OrderRow CurrentOrder, BakeryOrderSet.OrderItemRow[] ItemRows, int i, ListViewItem lvItem)
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

        void MessageBoxShow(string msg)
        {
            Form form = new FormMessage(msg);
            form.ShowDialog();
        }

        private bool SaveOrder(BakeryOrderSet.OrderRow CurrentOrder)
        {
            if (CurrentOrder == null)
            {
                MessageBox.Show("Error on SaveOrder ,CurrentOrder not allow null!");
                return false;
            }
            bool IsNewRecord = (CurrentOrder.RowState == DataRowState.Detached);
            if (IsNewRecord)
            {
                if (CurrentOrder.IsPrintTimeNull())
                    CurrentOrder.PrintTime = DateTime.Now;
                bakeryOrderSet.Order.AddOrderRow(CurrentOrder);
            }
            try
            {
                if (CurrentOrder.RowState == DataRowState.Deleted)
                {
                    MessageBoxShow("程式不准刪,而此單是被刪除的,資料奇怪 ,無法存檔!");    // 本程式不准刪
                    return false;
                }
                else if (CurrentOrder.RowState == DataRowState.Detached)
                {
                    MessageBoxShow("Order Detached! 不應該發生! 程式有誤!");
                    return false;
                }
                if (CurrentOrder.RowState != DataRowState.Unchanged)   // Unchanged不存, Added Modified要存,程式不准改,理論上不會有Modified
                {
                    m_OrderTableAdapter.Update(CurrentOrder);          // Update內含了AcceptChanges,不用再呼叫 
                }
            }
            catch (Exception E)
            {
                if (E.GetType() != typeof(System.Data.DBConcurrencyException))
                    MessageBoxShow(E.Message + "Update(CurrentOrder) 出錯");
                else
                {
                    MessageBoxShow("Update(Order)發生並行違例,可能是別台己經改過這張單子,請重啟程式,你必需重新修改!");
                    Close();
                }
                return false;
            }
            int maxID = CurrentOrder.ID % 10000;
            if (maxID > m_MaxOrderID) m_MaxOrderID = maxID;

            List<BakeryOrderSet.OrderItemRow> ItemDeleted = new List<BakeryOrderSet.OrderItemRow>();
            BakeryOrderSet.OrderItemRow[] OrderDetail = CurrentOrder.GetOrderItemRows();
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
                    Update_OrderItemRows(CurrentOrder, ItemRows, i, lvItem);
                    i++;
                }
                OrderDetail = ItemRows;
            }
            catch (Exception E)
            {
                MessageBoxShow(E.Message + "<OrderItem更新出錯,是否二台在改同一單?>");
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
                    MessageBoxShow(E.Message + "Update(OrderItem)出錯");
                else
                {
                    MessageBoxShow("Update(OrderItem)發生並行違例,可能是別台己經改過這張單子,你必需重啟程式,重新修改!");
                    Close();
                }
                return false;
            }
            return true;
        }

        void SetLoginStatus(bool isLogin)
        {
            panelLogin.Visible = !isLogin;
            tabControl1.Visible = isLogin;
            btnCashDrawer.Enabled = isLogin;
            //btnStatics.Enabled = isLogin;
            btnPrint.Enabled = isLogin;
            btnNewOrder.Enabled = isLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ReLoadAllData();
            if (m_FormStatics != null)
            {
                m_FormStatics.Close();
                m_FormStatics = null;
            }
            string sID = textBoxCashierID.Text.Trim();
            string sPass = textBoxPassword.Text.Trim();
            if (sPass.Length < 2)
            {
                MessageBoxShow("密碼太短!");
                return;
            }
            if (sID.Length < 1)
            {
                MessageBoxShow("請輸入收銀員号!");
                return;
            }
            int id;
            if (!int.TryParse(sID, out id))
            {
                MessageBoxShow("ID只能是數字!");
                return;
            }
            foreach (BakeryOrderSet.CashierRow cashier in bakeryOrderSet.Cashier)
            {
                if (cashier.CashierID == id)
                {
                    if (cashier.IsInPositionNull() || (!cashier.InPosition))
                    {
                        MessageBoxShow("此收銀員己封印! 阿彌陀佛!");
                        return;
                    }
                    if (cashier.CashierPassword.CompareTo(sPass) == 0)
                    {
                        if (cashier.IsCashierNameNull()) m_CashierName = "收银" + cashier.CashierID.ToString();
                        else m_CashierName = cashier.CashierName;
                        m_CashierID1 = cashier.CashierID;
                       // MessageBoxShow("歡迎 <" + m_CashierName + "> \r\n今天是" + DateTime.Now.ToShortDateString());
                        if (cashier.Return)
                        {
                             SetLoginStatus(true);
                            ClearOrderInfoOnScreen();
                            lvItems.Items.Clear();
                            return;
                        }
                        else
                        {
                            MessageBoxShow("没有此权限!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxShow("密碼不符!");
                        return;
                    }
                }
            }
            MessageBoxShow("沒有找到此收銀員!");
        }

        bool m_FocusID = true;
        private void textBoxCashierID_Enter(object sender, EventArgs e)
        {
            m_FocusID = true;
        }
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            m_FocusID = false;
        }

        private void btnNumberX_Click(object sender, EventArgs e)
        {
            TextBox current;
            if (m_FocusID)
                current = textBoxCashierID;
            else
                current = textBoxPassword;
            Button btn = sender as Button;
            string str = btn.Text;
            if (current.Text.Length < 6)
                current.Text = current.Text + str;
            current.Focus();
            current.SelectionStart = current.Text.Length;
            current.SelectionLength = 0;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TextBox current;
            if (m_FocusID)
                current = textBoxCashierID;
            else
                current = textBoxPassword;
            int len = current.Text.Length;
            if (len > 0)
            {
                current.Text = current.Text.Substring(0, len - 1);
                current.SelectionStart = len - 1;
                current.SelectionLength = 0;
            }
            current.Focus();
        }

        private void btnTestLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        void MarkButton(RadioButton btn)
        {
            btn.FlatAppearance.BorderSize = 0;
            if (btn.Checked)
            {
                btn.BackColor = Color.SeaShell;

            }
            else
                btn.BackColor = Color.FromArgb(216, 228, 248);
        }

        private void rbtnCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            MarkButton(sender as RadioButton);
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            MarkButton(sender as RadioButton);
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string str = btn.Text.Trim();
            List<string> compare = new List<string>();
            foreach (string s in DicPayBy.Values) compare.Add(s);
            int count = compare.Count;
            for (int i = 0; i < count; i++)
            {
                if (compare[i] == str)
                {
                    i++;
                    if (i >= count) btn.Text = compare[0];
                    else btn.Text = compare[i];
                    return;
                }
            }
            btn.Text = compare[0];
        }


        //char PayByFromBtn()
        //{
        //    string str = btnClass.Text.Trim();
        //    foreach (KeyValuePair<char, string> pair in DicPayBy)
        //    {
        //        if (pair.Value == str) return pair.Key;
        //    }
        //    return DicPayBy.First().Key;
        //}

        Dictionary<char, string> DicPayBy = new Dictionary<char, string> { { 'A', "现金" }, { 'B', "刷卡" }, { 'C', "支付宝" }};
        string PayByChinese(char payBy)
        {
            string str;
            if (DicPayBy.TryGetValue(payBy, out str)) return str;
            return DicPayBy.First().Value;
        }

        //private void btnDoCashier_Click(object sender, EventArgs e)
        //{
        //    if (m_DataSealed)
        //    {
        //        MessageBoxShow("今日資料己封印! 無法打單");
        //        return;
        //    }
        //    if (lvItems.Items.Count == 0)
        //        return;
        //    if (m_CurrentOrder == null)
        //    {
        //        CreateOrder(out m_CurrentOrder, m_MaxOrderID);
        //        if (m_CurrentOrder == null) return;
        //    }
        //    if (m_CurrentOrder.RowState != DataRowState.Detached)
        //    {
        //        MessageBoxShow("己經打印過的單子,無法再印! 請按<新單>");
        //        return;
        //    }
        //    decimal moneyGot = 0;
        //    Form form = new FormCheckout(tabControl1.Left + 8, 8, m_CurrentOrder, (decimal)CalcTotal());
        //    if (form.ShowDialog(this) == DialogResult.OK)
        //    {
        //        if (form.Tag.GetType() == typeof(decimal))
        //            moneyGot = (decimal)(form.Tag);
        //        else
        //            moneyGot = 0m;
        //        if (m_CurrentOrder.IsIncomeNull())
        //        {
        //            MessageBox.Show("沒有應收數字! 無法打單");
        //            return;
        //        }
        //        if ((!m_CurrentOrder.IsDeductNull()) && m_CurrentOrder.Deduct != 0)
        //        {
        //            labelDeduct.Text = m_CurrentOrder.Deduct.ToString();
        //            labelDeduct.Visible = labelDeductTitle.Visible = true;
        //            labelTotal.Text = m_CurrentOrder.Income.ToString();
        //        }
        //        labelClass.Text = PayByChinese(m_CurrentOrder.PayBy[0]);
        //        Print(m_CurrentOrder, (double)moneyGot);
        //        if (!this.checkBoxTest.Checked)
        //            RawPrint.SendManagedBytes(m_Printer.PrinterName, m_CashDrawer);   // 彈出錢箱
        //        CreateUpdateDrawerRecord(ref m_MaxDrawerRecordID, m_CurrentOrder.ID % 10000);
        //    }
        //}

        private void btnTest_Click(object sender, EventArgs e)
        {
            ByteBuilder Buf;
            byte[] Begin = new byte[] { 27, 51, 16 };
            byte[] BitmapMode = new byte[] { 27, (byte)'*', 0 };
            byte[] PrintAndScroll = new byte[] { 27, 74, 24 };   // 走24點
            Bitmap bitmap = new Bitmap("maidaren.bmp");
            int n = bitmap.Width;
            for (int i = 0; i < bitmap.Height; i += 8)
            {
                Buf = new ByteBuilder(2048);
                Buf.Append(BitmapMode);
                Buf.Append((byte)(n % 256));
                Buf.Append((byte)(n / 256));
                for (int x = 0; x < n; x++)
                {
                    byte y0 = 0;
                    for (int y = 0; y < 8; y++)
                    {
                        y0 *= 2;
                        Color c = bitmap.GetPixel(x, y + i);
                        if (c.GetBrightness() < 0.4) y0 += 1;
                    }
                    Buf.Append(y0);
                }
                Buf.Append("\n");
                RawPrint.SendManagedBytes(m_Printer.PrinterName, Buf.ToBytes());
            }
            //RawPrint.SendManagedBytes(m_Printer.PrinterName, PrintAndScroll);

        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            if (m_CurrentOrder != null && m_CurrentOrder.RowState != DataRowState.Detached)    // 打印過的單子先清,再加
            {
                MessageBox.Show("打印過的單子,無法刪除!");
                return;
            }
            ListView lv = sender as ListView;
            if (lv.SelectedIndices.Count >0)
            {
                MenuItemForTag lvItemTag = lv.Items[lv.SelectedIndices[0]].Tag as MenuItemForTag;
                Item2List(lvItemTag, MouseButtons.Right);
                lvItemTag.LabelNo.BorderStyle = BorderStyle.Fixed3D;
                lvItemTag.LabelNo.Text = lvItemTag.name;
                //v.Items.RemoveAt(SelectedIndex);
                // CalcTotal();
                if (lv.Items.Count > 0)
                {
                    MenuItemForTag tag = lv.Items[lv.Items.Count - 1].Tag as MenuItemForTag;
                    string idStr = tag.id.ToString();
                    string small = m_SmallDir + "\\" + idStr + ".jpg";
                    if (!File.Exists(small))
                    {
                        string big = m_ProductDir + "\\" + idStr + ".jpg";
                        CreateSmallImage(big, pictureBoxOrdered.Width, pictureBoxOrdered.Height, small);
                    }
                    Image img = Bitmap.FromFile(small);
                    pictureBoxOrdered.Image = img;
                    if (m_FormCustomer != null)
                        m_FormCustomer.SetPicture(img);
                }

            }
        }

        private void btnRClear_Click(object sender, EventArgs e)
        {
            TextBox current;
            if (m_FocusID)
                current = textBoxCashierID;
            else
                current = textBoxPassword;
            int len = current.Text.Length;
            if (len > 0)
            {
                current.Text = current.Text.Substring(0, len - 1);
                current.SelectionStart = len - 1;
                current.SelectionLength = 0;
            }
            current.Focus();
        }

        private void btnRLogin_Click(object sender, EventArgs e)
        {
            ReLoadAllData();
            if (m_FormStatics != null)
            {
                m_FormStatics.Close();
                m_FormStatics = null;
            }
            string sID = textBoxCashierID.Text.Trim();
            string sPass = textBoxPassword.Text.Trim();
            if (sPass.Length < 2)
            {
                MessageBoxShow("密碼太短!");
                return;
            }
            if (sID.Length < 1)
            {
                MessageBoxShow("請輸入收銀員号!");
                return;
            }
            int id;
            if (!int.TryParse(sID, out id))
            {
                MessageBoxShow("ID只能是數字!");
                return;
            }
            foreach (BakeryOrderSet.CashierRow cashier in bakeryOrderSet.Cashier)
            {
                if (cashier.CashierID == id)
                {
                    if (cashier.IsInPositionNull() || (!cashier.InPosition))
                    {
                        MessageBoxShow("此收銀員己封印! 阿彌陀佛!");
                        return;
                    }
                    if (cashier.CashierPassword.CompareTo(sPass) == 0)
                    {
                        if (cashier.Return == false)//判断是否具有退货权限
                        {
                            MessageBoxShow("没有权限!");
                        }
                        else
                        {
                            if (cashier.IsCashierNameNull()) m_CashierName = "收银" + cashier.CashierID.ToString();
                            else m_CashierName = cashier.CashierName;
                            m_CashierID1 = cashier.CashierID;
                            MessageBoxShow("歡迎 <" + m_CashierName + "> \r\n今天是" + DateTime.Now.ToShortDateString());
                            SetLoginStatus(true);
                            ClearOrderInfoOnScreen();
                            lvItems.Items.Clear();
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxShow("密碼不符!");
                        return;
                    }
                }
            }
            MessageBoxShow("沒有找到此收銀員!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
