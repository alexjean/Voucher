using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Member
{
    public partial class FormCenter : Form
    {
        public FormCenter()
        {
            InitializeComponent();
        }

        private void 会员卡类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FormCardClass();
            f.MdiParent = this;
           f.WindowState = FormWindowState.Maximized;
            f.Show();
           
        }

        private void 会员卡ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new FormCard();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void 门店设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FormStore();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
