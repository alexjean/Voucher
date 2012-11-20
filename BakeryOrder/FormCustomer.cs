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
        string m_Path = "SlideShow";
        int m_Count = 0;
        const int m_DefaultInterval = 4000;
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
            timer1.Interval = m_DefaultInterval;
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_Count++;
            if (m_Count >= m_Files.Count()) m_Count = 0;
            timer1.Interval = m_DefaultInterval;
            pictureBoxPhoto.BringToFront();
            pictureBoxPhoto.ImageLocation = m_Files[m_Count];
            if (pictureBoxPhoto.Dock!=DockStyle.Fill)
                pictureBoxPhoto.Dock = DockStyle.Fill;
        }

        public void SetTimer(int tick)
        {
            timer1.Interval = tick;
            if (pictureBoxPhoto.Dock != DockStyle.Right) 
                pictureBoxPhoto.Dock = DockStyle.Right;
        }

        public void ShowTotal(double total)
        {
            labelTotal.Text = total.ToString();
        }

        private ListViewItem FindByProductIDFromList(int productID)
        {
            foreach (ListViewItem lvItem in lvCustomer.Items)
            {
                if (productID == (int)lvItem.Tag) return lvItem;
            }
            return null;
        }

        public void Item2List(int productID,string name, double No, double money)
        {
            ListViewItem lvItem=FindByProductIDFromList(productID);
            if (lvItem==null)
            {
                if (No==0) return;
                lvItem = lvCustomer.Items.Add(name);
                lvItem.SubItems.Add(No.ToString());
                lvItem.SubItems.Add(money.ToString());
                lvItem.Tag = productID;
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

        public void SetPicture(Image img)
        {
            pictureBoxOrdered.Image = img;
        }


    }
}
