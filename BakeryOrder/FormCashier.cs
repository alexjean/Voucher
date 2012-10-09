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
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (m_FormCustomer!=null)
                m_FormCustomer.Close();
            Close();
        }
    }
}
