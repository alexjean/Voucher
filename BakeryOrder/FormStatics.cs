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
    public partial class FormStatics : Form
    {
        public FormStatics()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            Close();
        }

        private void btnExitProgram_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            Close();
        }

        private void FormStatics_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen;
            Location = new Point(scr.Bounds.X, scr.Bounds.Y);
            TopMost = true;
        }

    }
}
