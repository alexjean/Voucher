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
    public partial class FormMessage : Form
    {
        string m_Msg="";
        bool m_ReturnResult = false;
        bool m_showAdd = false;
        int m_max = 0;

        public FormMessage(string msg)
        {
            m_Msg = msg;
            InitializeComponent();
        }

        public FormMessage(string msg,bool returnResult)
        {
            m_ReturnResult = returnResult;
            m_Msg = msg;
            InitializeComponent();
        }
        public FormMessage(string msg,int max)
        {
            m_showAdd = true;
            m_Msg = msg;
            m_max = max;
            InitializeComponent();
        }
        private void FormMessage_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            textBoxMessage.Text = m_Msg;
            btnConfirm.Visible = !m_ReturnResult;
            btnYes.Visible = btnNo.Visible = m_ReturnResult;
            btAdd.Visible = btMinus.Visible = m_showAdd;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void FormMessage_Shown(object sender, EventArgs e)
        {
            if (m_ReturnResult) btnYes.Focus();
            else btnConfirm.Focus();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int num=Convert.ToInt32(textBoxMessage.Text);
                if (num<m_max)
                {
                     num++;
                }

                textBoxMessage.Text = num.ToString();
                FormCheckout.ExchangeNo = num;
            }
            catch (Exception)
            {
                if (m_max <= 0)
                {
                    textBoxMessage.Text = "0";
                    FormCheckout.ExchangeNo = 0;
                }
                else
                {
                    textBoxMessage.Text = "1";
                    FormCheckout.ExchangeNo = 1;
                }
                
            }
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBoxMessage.Text);
                if (num >0)
                {
                    num--;
                }
                textBoxMessage.Text = num.ToString();
                FormCheckout.ExchangeNo = num;
            }
            catch 
            {
                if (m_max <= 0)
                {
                    textBoxMessage.Text = "0";
                    FormCheckout.ExchangeNo = 0;
                }
                else
                {
                    textBoxMessage.Text = "1";
                    FormCheckout.ExchangeNo = 1;
                }
            }
        }
    }
}
