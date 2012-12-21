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

        private void FormMessage_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            textBoxMessage.Text = m_Msg;
            btnConfirm.Visible = !m_ReturnResult;
            btnYes.Visible = btnNo.Visible = m_ReturnResult;
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
    }
}
