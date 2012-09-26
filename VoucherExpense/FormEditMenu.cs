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
    public partial class FormEditMenu : Form
    {
        private static class MyLayout
        {
            public static int NoX = 4;
            public static int NoY = 26;
            public static int OffsetX = 10;
            public static int OffsetY = 20;
            public static int NoWidth = 40;
        }

/*
        class MenuItem
        {
            public int code;
            public string name;
            public double No;
            public double Price;
            public short classcode;
            public System.Windows.Forms.Label LabelNo;
            public double Money() { return Price * No; }
            public void SetZero() { No = 0; }
            public string NoToString() { return No.ToString(); }
        }
*/

        public FormEditMenu()
        {
            InitializeComponent();
        }

        bool m_Modified = false;
        int m_CurrentMenu = -1;
        private void cbSelectMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (m_Modified) UpdateDataSet(m_CurrentMenu);
            groupBox1.Controls.Clear();
            groupBox1.Text=box.SelectedItem.ToString();
            m_CurrentMenu=box.SelectedIndex;
            InitFoodMenu(groupBox1,m_CurrentMenu, out m_FoodName);
        }

        private void FormEditMenu_Load(object sender, EventArgs e)
        {
            try
            {
                productTableAdapter1.Connection = MapPath.BasicConnection;
                productTableAdapter1.Fill(basicDataSet1.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("產品表載入失敗:" + ex.Message);
            }

            cbSelectMenu.SelectedIndex = 0;    // 必需在 .Fill之後,因為中間有叫InitFoodMenu

            foreach (BasicDataSet.ProductRow row in basicDataSet1.Product)
            {
                listBoxProduct.Items.Add(new DragItem(null,row));
            }
        }

        private Label[,] m_FoodName;
        private BasicDataSet.ProductRow GetFoodMenuItem(int id,int x, int y)
        {
            int x1 = x + id * 10;  // x最多不到10行,所以用x編碼菜單id
            foreach (BasicDataSet.ProductRow Row in basicDataSet1.Product.Rows)
            {
                if (Row.MenuX == x1 && Row.MenuY == y ) return Row;
            }
            return null;
        }

        #region ====== DragDrop Function ======
        class DragItem
        {
            public Label label;
            public BasicDataSet.ProductRow row;
            public int X;
            public int Y;
            public DragItem(Label l, BasicDataSet.ProductRow r)
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
            DoDragDrop(box.SelectedItem, DragDropEffects.Copy);
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            Label label=sender as Label;
            DoDragDrop(new DragItem(label,label.Tag as BasicDataSet.ProductRow), DragDropEffects.Move);
        }

        private void LabelDragEnter(object sender, DragEventArgs e)
        {
            Label label = sender as Label;
            e.Effect = DragDropEffects.All;
            label.BorderStyle = BorderStyle.FixedSingle;
        }

        private void LabelDragLeave(object sender,EventArgs e)
        {
            Label label = sender as Label;
            label.BorderStyle = BorderStyle.None;
        }

        private void LabelDragDrop(object sender, DragEventArgs e)
        {
            Label label = sender as Label;
            label.BorderStyle = BorderStyle.None;
            DragItem item=e.Data.GetData(typeof(DragItem)) as DragItem;
            BasicDataSet.ProductRow row = item.row;
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
            if (row==null) return; 
            // Check duplicate
            int code=row.Code;
            foreach (Label l in m_FoodName)
            {
                BasicDataSet.ProductRow ro = l.Tag as BasicDataSet.ProductRow;
                if (ro == null) continue;
                if (l  ==label) continue;
                if (ro.Code == code)
                {
                    l.Text = "";
                    l.BackColor = Color.SeaShell;
                    l.Tag = null;
                }
            }
        }
        #endregion

        private void InitFoodMenu(GroupBox grBox,int menuId,out Label [,] FoodName)
        {
            SuspendLayout();
            string mark = "F" + menuId.ToString() + DateTime.Now.Ticks.ToString();  //避免多次進入,label重名了
            int WidthX  = (grBox.Width - MyLayout.OffsetX) / MyLayout.NoX;
            int HeightY = (grBox.Height - MyLayout.OffsetY) / MyLayout.NoY;
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
                    l.Name = mark+"X" + x.ToString() + "Y" + y.ToString();
                    l.Size = new System.Drawing.Size(WidthX - MyLayout.NoWidth - 2, HeightY - 2);
                    l.TabIndex = 0;
                    BasicDataSet.ProductRow Row = GetFoodMenuItem(menuId,x, y);
                    if (Row != null)
                    {
                        l.Tag = Row;
                        if (Row.IsNameNull()) l.Text = "";
                        else                  l.Text = Row.Name.ToString();
                    }
                    else
                    {
                        l.Tag = null;
                        l.Text = "";
                    }
                    l.DragEnter += new DragEventHandler(this.LabelDragEnter);
                    l.DragLeave += new EventHandler(this.LabelDragLeave);
                    l.DragDrop +=new DragEventHandler(LabelDragDrop);
                    l.MouseDown +=new MouseEventHandler(LabelMouseDown);
                    l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    l.BorderStyle = BorderStyle.None;
                    l.AllowDrop = true;
                    grBox.Controls.Add(l);
                }

            ResumeLayout();
            PerformLayout();
        }

        private void UpdateDataSet(int menuId)
        {
            if (menuId < 0) return;
            int xLen=m_FoodName.GetLength(0);
            int yLen=m_FoodName.GetLength(1);
            for (int x = 0; x < xLen; x++)
            {
                int x1 = x + menuId * 10;
                for (int y = 0; y < yLen; y++)
                {
                    Label l=m_FoodName[x,y];
                    if (l.BackColor!=Color.SeaShell) continue;  // nochange
                    if (l.Tag == null)
                    {
                        var rows = from row in basicDataSet1.Product
                                   where row.MenuX == x1 && row.MenuY == y
                                   select row;
                        foreach (var row in rows) row.MenuX = -1;
                    }
                    else
                    {
                        var ro=l.Tag as BasicDataSet.ProductRow;
                        if (ro.IsCodeNull()) continue;
                        var rows = from row in basicDataSet1.Product
                                   where row.Code==ro.Code
                                   select row;
                        foreach (var row in rows)
                        {
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
                UpdateDataSet(m_CurrentMenu);
            try
            {
                productTableAdapter1.Update(basicDataSet1.Product);
                MessageBox.Show("存檔成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void FormEditMenu_Shown(object sender, EventArgs e)
        {
            listBoxProduct.Focus();
        }

     

    }
}
