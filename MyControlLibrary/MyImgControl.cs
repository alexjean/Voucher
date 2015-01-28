using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyControlLibrary
{
    public partial class MyImgControl : UserControl
    {
        public Color MyColor;
        public Color MyStrColor;
        public int Myalpha;
        public string MyStr{get;set;}

        public MyImgControl()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
               this.panel1.BackColor = Color.FromArgb(Myalpha, MyColor);
               this.label1.BackColor = Color.FromArgb(1, MyColor);
               this.label1.ForeColor = MyStrColor;
               this.label1.Text = MyStr;
               this.label1.Refresh();
        }
        public void changetext(string str)
        {
            this.label1.ForeColor = MyStrColor;
            this.label1.Text = str;
        }
    }
}
