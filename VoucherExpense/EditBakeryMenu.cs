﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyDataSet = VoucherExpense.DamaiDataSet;
using MyProductRow = VoucherExpense.DamaiDataSet.ProductRow;
using MyProductAdapter = VoucherExpense.DamaiDataSetTableAdapters.ProductTableAdapter;
namespace VoucherExpense
{
    public partial class EditBakeryMenu : Form
    {

        #region ======== Shared function with FormCashier.cs ======
        private static class MyLayout
        {
            public static int NoX = 4;
            public static int NoY = 6;
            public static int OffsetX = 10;
            public static int OffsetY = 10;
            public static int NoWidth = 10;
        }

        const int SpeicalRowCodeForMenu = 0;

        MyDataSet m_DataSet = new MyDataSet();
        MyProductAdapter productAdapter = new MyProductAdapter();
        private void EditBakeryMenu_Load(object sender, EventArgs e)
        {
            try
            {
                productAdapter.Connection.ConnectionString = DB.SqlConnectString(MyFunction.HardwareCfg);
                productAdapter.Fill(m_DataSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("產品表載入失敗:" + ex.Message);
            }
            foreach (var row in m_DataSet.Product)
            {
                if (row.Code <= SpeicalRowCodeForMenu) continue;   // 系統保留用
                listBoxProduct.Items.Add(new DragItem(null, row));
            }

            // 程式保留row.Code 0做為菜單的寬高,這行不是產品
            var rows = from row in m_DataSet.Product
                       where row.Code == SpeicalRowCodeForMenu
                       select row;
            foreach (var row in rows)
            {
                MyLayout.NoX = -row.MenuX;
                MyLayout.NoY = -row.MenuY;
            }

            LoadTabControlItem();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            UpdateAllFoodMenu();

            comboBoxWidth.Text = MyLayout.NoX.ToString();
            comboBoxHeight.Text = MyLayout.NoY.ToString();
            comboBoxHeight.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            comboBoxWidth.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
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
                bshBack = new SolidBrush(Color.Azure);
                bshFore = Brushes.Black;
                // 把標簽後的Control色填成背景色
                int count = tabControl1.TabPages.Count - 1;
                if (count < 0) return;
                Rectangle endRect = tabControl1.GetTabRect(count);
                Point pt=new Point(endRect.X + endRect.Width, endRect.Y);
                Size  sz=new Size(tabControl1.Width-endRect.X-endRect.Width,endRect.Height);
                Rectangle headerRect = new Rectangle(pt, sz);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(216, 228, 248)), headerRect);
            }
            else
            {
                fntTab = e.Font;
                bshBack = new SolidBrush(Color.FromArgb(216,228,248));
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X+3, recTab.Y + 3, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        void UpdateAllFoodMenu()
        {
            int i = 0;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tp.Controls.Clear();
                Label[,] l;
                InitFoodMenu(tp, i++,out l);
                tp.Tag = l;
            }
        }

        private MyProductRow GetFoodMenuItem(int id, int x, int y)
        {
            int x1 = x + id * 10;  // x最多不到10行,所以用x編碼菜單id
            foreach (MyProductRow Row in m_DataSet.Product)
            {
                if (Row.MenuX == x1 && Row.MenuY == y) return Row;
            }
            return null;
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
                    MyProductRow Row = GetFoodMenuItem(menuId, x, y);
                    if (Row != null)
                    {
                        l.Tag = Row;
                        if (Row.IsNameNull()) l.Text = "";
                        else l.Text = Row.Name.ToString();
                    }
                    else
                    {
                        l.Tag = null;
                        l.Text = "";
                    }
                    l.DragEnter += new DragEventHandler(this.LabelDragEnter);
                    l.DragLeave += new EventHandler(this.LabelDragLeave);
                    l.DragDrop += new DragEventHandler(LabelDragDrop);
                    l.MouseDown += new MouseEventHandler(LabelMouseDown);
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    l.BorderStyle = BorderStyle.Fixed3D;
                    l.AllowDrop = true;
                    tabPage.Controls.Add(l);
                }

            ResumeLayout();
            PerformLayout();
        }

        private void LoadTabControlItem()
        {

            // 小於0的是菜單名負一排最前面
            var rows = from row in m_DataSet.Product
                   where row.Code < SpeicalRowCodeForMenu
                   orderby row.Code descending
                   select row;
            tabControl1.TabPages.Clear();
            if (rows.Count() == 0)   // 都沒有的話留下預設的
            {
                tabControl1.TabPages.Add("面包");

                int maxID = (from ro in m_DataSet.Product
                             select ro.ProductID).Max();
                MyProductRow row = m_DataSet.Product.NewProductRow();
                row.ProductID = ++maxID;
                row.Name = SystemMenuName("面包", 1);
                row.Code = -1;
                row.MenuX = -1;
                row.MenuY = -1;
                m_DataSet.Product.AddProductRow(row);
                SaveProduct();
            }
            else
            {
                String str;
                int i;
                foreach (var row in rows)
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

        public EditBakeryMenu()
        {
            InitializeComponent();
        }


        bool m_Modified = false;
        #region ====== DragDrop Function ======
        class DragItem
        {
            public Label label;                
            public MyProductRow row;
            public int X;
            public int Y;
            public DragItem(Label l, MyProductRow r)
            {
                label = l;
                row = r;
                X = Y = -1;
            }
            public override string ToString()
            {
                if (row == null) return "";
                if (row.IsNameNull()) return "";
                return row.Name;
            }
        }

        private void listBoxProduct_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box.SelectedItem == null) return;
            DoDragDrop(box.SelectedItem, DragDropEffects.Copy);
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            DoDragDrop(new DragItem(label, label.Tag as MyProductRow), DragDropEffects.Move);
        }

        private void LabelDragEnter(object sender, DragEventArgs e)
        {
            Label label = sender as Label;
            e.Effect = DragDropEffects.All;
            label.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LabelDragLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.BorderStyle = BorderStyle.Fixed3D;
        }

        private void LabelDragDrop(object sender, DragEventArgs e)
        {
            Label label = sender as Label;
            label.BorderStyle = BorderStyle.Fixed3D;
            DragItem item = e.Data.GetData(typeof(DragItem)) as DragItem;
            MyProductRow row = item.row;
            if (label.Tag == row) return;
            label.Text = item.ToString();
            label.BackColor = Color.SeaShell;
            label.Tag = row;
            m_Modified = true;
            if (item.label != null)
            {
                item.label.Text = "";
                item.label.BackColor = Color.SeaShell;
                item.label.Tag = null;
            }
            if (row == null) return;
            // Check duplicate
            int code = row.Code;
            Label[,] currentFoodTable = tabControl1.SelectedTab.Tag as Label[,];    // FoodTable放到TabPage.Tag去
            foreach (Label l in currentFoodTable)
            {
                var ro = l.Tag as MyProductRow;      // Label[,]內的label.Tag放著ProductRow
                if (ro == null) continue;
                if (l == label) continue;
                if (ro.Code == code)
                {
                    l.Text = "";
                    l.BackColor = Color.SeaShell;
                    l.Tag = null;
                }
            }
        }
        #endregion

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = comboBoxWidth.SelectedItem.ToString();
                int w=Convert.ToInt32(str);
                str = comboBoxHeight.SelectedItem.ToString();
                int h = Convert.ToInt32(str);
                MyLayout.NoX = w;
                MyLayout.NoY = h;
                UpdateAllFoodMenu();
            }
            catch { }
        }

        private void UpdateDataSet(int menuId,Label [,] FoodName)
        {
            if (menuId < 0) return;
            int xLen = FoodName.GetLength(0);
            int yLen = FoodName.GetLength(1);
            for (int x = 0; x < xLen; x++)
            {
                int x1 = x + menuId * 10;
                for (int y = 0; y < yLen; y++)
                {
                    Label l = FoodName[x, y];
                    if (l.BackColor != Color.SeaShell) continue;  // nochange
                    // Mark SeaShell的先清掉
                    var ros = from row in m_DataSet.Product
                                where row.MenuX == x1 && row.MenuY == y
                                select row;
                    foreach (var row in ros) row.MenuX = -1;
                    if (l.Tag != null)  // 改成 ProductID比對 2313.06.09
                    {  
                        var ro = l.Tag as MyProductRow;
                        int productID = ro.ProductID;
                        var rows = from row in m_DataSet.Product
                                   where row.ProductID == productID    
                                   select row;
                        if (rows.Count() > 0)
                        {
                            var row = rows.First();
                            row.MenuX = (short)x1;
                            row.MenuY = (short)y;
                        }
                    }
                }
            }
            m_Modified = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_Modified)
                UpdateDataSet(tabControl1.SelectedIndex,tabControl1.SelectedTab.Tag as Label[,]);
            // <0的程式內用的,以Code比對
            var rows = from row in m_DataSet.Product
                       where row.Code == SpeicalRowCodeForMenu
                       select row;
            string reserved = "菜單寬高_勿動_程式用";
            if (rows.Count() == 0)
            {
                MyProductRow row=m_DataSet.Product.NewProductRow();
                row.MenuX = (short)-MyLayout.NoX;
                row.MenuY = (short)-MyLayout.NoY;
                row.Code = SpeicalRowCodeForMenu;
                row.Name = reserved;
                m_DataSet.Product.AddProductRow(row);
            }
            else
            {
                MyProductRow row=rows.First();
                short x = (short)-MyLayout.NoX; 
                short y = (short)-MyLayout.NoY;
                if ((x != row.MenuX) || (y != row.MenuY))
                {
                    row.Name = reserved;
                    row.MenuX = x;
                    row.MenuY = y;
                }
            }
            try
            {
                int i=productAdapter.Update(m_DataSet.Product);
                MessageBox.Show("存檔成功! 共更新 "+i.ToString()+"筆");
                UpdateAllFoodMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        void SaveProduct()
        {
            try
            {
                productAdapter.Update(m_DataSet.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        string SystemMenuName(string name, int index)
        {
            return name + "_菜單名" + index.ToString() + "_勿動";
        }

        void RenewMenuSaveInProduct()
        {
            var rows = from row in m_DataSet.Product
                       where (row.RowState!=DataRowState.Deleted) && (row.Code < SpeicalRowCodeForMenu)
                       select row;
            int i = 0;
            foreach (MyProductRow row in rows)
            {
                if (i >= tabControl1.TabCount)
                {
                    row.Delete();
                    continue;
                }
                TabPage page = tabControl1.TabPages[i];
                i++;
                row.Name = SystemMenuName(page.Text, i);
                row.Code = -i;
                row.MenuX = -1;
                row.MenuY = -1;
            }
            if (i < tabControl1.TabCount)
            {
                int maxID = (from row in m_DataSet.Product
                             where row.RowState != DataRowState.Deleted
                             select row.ProductID).Max();
                for (; i < tabControl1.TabCount; )
                {
                    MyProductRow row = m_DataSet.Product.NewProductRow();
                    TabPage page = tabControl1.TabPages[i];
                    row.ProductID = ++maxID;
                    i++;
                    row.Name = SystemMenuName(page.Text, i);
                    row.Code = -i;
                    row.MenuX = -1;
                    row.MenuY = -1;
                    m_DataSet.Product.AddProductRow(row);
                }
            }
            SaveProduct();
            LoadTabControlItem();
            UpdateAllFoodMenu();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    TabPage tp = this.tabControl1.TabPages[i];
                    if (this.tabControl1.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        this.tabControl1.SelectedTab = tp;
                        tabControl1.ContextMenuStrip = this.contextMenuStripForTabControl;
                        break;
                    }
                }
            }
        }

        private void tabControl1_MouseLeave(object sender, EventArgs e)
        {
            tabControl1.ContextMenuStrip = null;
        }

        private void 插入toolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            tabControl1.TabPages.Insert(i, "菜單" + i.ToString());
            RenewMenuSaveInProduct();
        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl1.SelectedIndex;
            string name = tabControl1.TabPages[i].Text;
            if (MessageBox.Show("刪除第"+(i+1).ToString()+" 標簽頁<" + name + ">?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tabControl1.TabPages.RemoveAt(i);
                RenewMenuSaveInProduct();
            }
        }

        private void 改名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = textBoxRename.Text.Trim();
            if (str.Length < 2)
            {
                MessageBox.Show("名稱請至少輸入二個字!");
                return;
            }
            if (str.Contains('_'))
            {
                MessageBox.Show("名稱中不可以有底線 _");
                return;
            }
            int i = tabControl1.SelectedIndex;
            if (i < 0 || i >= tabControl1.TabCount) return;
            string name = tabControl1.TabPages[i].Text;
            if (MessageBox.Show("將第" + (i + 1).ToString() + "標簽<"+name+">改名成<" + str + ">?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            tabControl1.TabPages[i].Text = str;    // 在SaveProduct會重Load
            RenewMenuSaveInProduct();
        }
    }
}
