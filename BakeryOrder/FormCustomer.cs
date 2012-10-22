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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        string[] m_Files = null;
        string m_Path = "Products";
        int m_Count = 0;
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            Screen[] scr = Screen.AllScreens;
            if (scr.Count() > 1)
            {
                int i = 0;
                if (scr[i].Primary) i = 1;
                Location = new Point(scr[i].Bounds.X, scr[i].Bounds.Y);
            }
            if (!Directory.Exists(m_Path))
            {
                MessageBox.Show("照片目錄不存在!");
                return;
            }
            m_Files=Directory.GetFiles(m_Path);
            if (m_Files.Count()==0) return;
            pictureBoxPhoto.ImageLocation =  m_Files[m_Count];
            timer1.Interval = 3000;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_Count++;
            if (m_Count >= m_Files.Count()) m_Count = 0;
            pictureBoxPhoto.ImageLocation = m_Files[m_Count];
        }

        public void SetTimer(int tick)
        {
            timer1.Interval = 30000;
        }

        public void ShowTotal(double total)
        {
            labelTotal.Text = total.ToString();
        }

        private ListViewItem FindByCodeFromList(int code)
        {
            foreach (ListViewItem lvItem in lvCustomer.Items)
            {
                if (code == (int)lvItem.Tag) return lvItem;
            }
            return null;
        }

        public void Item2List(int code,string name, double No, double money)
        {
            ListViewItem lvItem=FindByCodeFromList(code);
            if (lvItem==null)
            {
                if (No==0) return;
                lvItem = lvCustomer.Items.Add(name);
                lvItem.SubItems.Add(No.ToString());
                lvItem.SubItems.Add(money.ToString());
                lvItem.Tag = code;
            }
            else
            {
                if (No==0)
                    lvCustomer.Items.Remove(lvItem);
                else
                {                
                    lvItem.SubItems[1].Text = No.ToString();
                    lvItem.SubItems[2].Text = money.ToString(); ;
                }
            }
        }


    }
}
