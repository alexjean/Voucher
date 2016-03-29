using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WxPayAPI;
namespace BakeryOrder
{
    public partial class FormWxPay : Form
    {
        WxPayData m_PayData ;
        string m_OutTradeNoStr;
        bool m_Canceled = false;
        int m_X = 0;
        int m_Y = 0;
        public FormWxPay(int x, int y, string out_trade_no_str,WxPayAPI.WxPayData payData)
        {
            m_X = x;
            m_Y = y;
            m_OutTradeNoStr = out_trade_no_str;
            m_PayData = payData;
            InitializeComponent();
        }

        private void FormWxPay_Load(object sender, EventArgs e)
        {
            Location = new Point(m_X, m_Y);
        }
    }
}
