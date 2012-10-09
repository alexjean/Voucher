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
        public FormCashier()
        {
            InitializeComponent();
        }

        FormCustomer m_FormCustomer=null;
        private void FormCashier_Load(object sender, EventArgs e)
        {
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
    }
}
