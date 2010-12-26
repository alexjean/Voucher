using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormMessage : Form
    {
        private string Msg;
        public FormMessage(string msg,int timetick)
        {
            Msg = msg;
            InitializeComponent();
            label1.Text = msg;
            timer1.Interval = timetick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}