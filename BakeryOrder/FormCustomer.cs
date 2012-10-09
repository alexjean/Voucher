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
    }
}
