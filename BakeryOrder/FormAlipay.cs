using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Alipay;
using System.Threading;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;


namespace BakeryOrder
{
    public partial class FormAlipay : Form
    {
        DoAlipay m_Alipay;
        string m_Content ;
        string m_TradeNoStr;
        bool m_Canceled = false;
        int m_X = 0;
        int m_Y = 0;

        public FormAlipay(int x,int y,string trade_no_str,DoAlipay alipay,string content)
        {
            m_X = x;
            m_Y = y;
            m_TradeNoStr = trade_no_str;
            m_Alipay = alipay;
            m_Content = content;
            InitializeComponent();
        }

        private void FormAlipay_Load(object sender, EventArgs e)
        {
            Location = new Point(m_X, m_Y);
        }


        void Message(string msg)
        {
            listBoxMsg.Items.Add(msg);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Canceled)
                Message("本单已撤消!");
            else
            {
                Message("撤消本支付请求中... 單號<"+m_TradeNoStr+">");
                AlipayTradeCancelResponse cancelResponse = null;
                try
                {
                    cancelResponse = m_Alipay.Cancel(m_TradeNoStr);
                }
                catch (System.Net.WebException wex)
                {
                    Message(wex.Message);
                    MessageBox.Show("发生网络错误, 无法连至支付宝服务器!");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                    MessageBox.Show("发生错误!");
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                m_Canceled = true;
                switch (cancelResponse.Code)
                {
                    case ResultCode.SUCCESS:
                            Message("支付撤消成功! 交易号<" + cancelResponse.TradeNo + ">");
                            MessageBox.Show("本單撤消成功!");
                            break;
                    case ResultCode.FAIL: Message("支付撤消失敗! <" + cancelResponse.Msg+">");
                            Message("");
                            Message(cancelResponse.SubMsg);
                            Message("");
                            return;   // 再按一次,因m_Canceled=true;就直接離開
                }
            }
            this.DialogResult=DialogResult.Cancel;
            Close();
        }

        void SaveToDB(string OutTradeNo,string OpenId)
        {
            // 存支付宝 OutTradeNo , OpenID, 帳號?
            m_Alipay.LastOutTradeNo = OutTradeNo;
            m_Alipay.LastOpenID = OpenId;
        }

        private void FormAlipay_Shown(object sender, EventArgs e)
        {
            Message("訂單<" + m_TradeNoStr + "> 支付請求发起中...");
            Application.DoEvents();
            AlipayTradePayResponse payResponse=null;
            try
            {
                payResponse = m_Alipay.Pay(m_Content.ToString());
            }
            catch (System.Net.WebException wex)
            {
                Message(wex.Message);
                MessageBox.Show("发生网络错误, 无法连至支付宝服务器!");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                MessageBox.Show("发生错误!");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            string result = payResponse.Body;
            if (payResponse != null)
            {
                switch (payResponse.Code)
                {
                    case ResultCode.SUCCESS:
                        Message("支付成功!!! 金額 " + payResponse.TotalAmount);
                        Message("交易號<"+payResponse.TradeNo+">");
                        Message(payResponse.Msg);
                        SaveToDB(payResponse.OutTradeNo,payResponse.OpenId);
                        btnSuccess.Enabled = true;
                        break;
                    case ResultCode.INRROCESS:
                        Message("支付处理中，查询状态...");
                        btnQuery_Click(null, null);
                        break;

                    case ResultCode.FAIL:
                        Message("支付请求失败<"+payResponse.Msg+">,撤消交易中..");
                        Message("");
                        Message(payResponse.SubMsg);
                        Message("");
                        btnCancel_Click(null, null);    
                        break;
                }
            }
            
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            AlipayTradeQueryResponse queryResponse = null;
            try
            {
                queryResponse = m_Alipay.Query(m_TradeNoStr);
            }
            catch (System.Net.WebException wex)
            {
                Message(wex.Message);
                MessageBox.Show("发生网络错误, 无法连至支付宝服务器!");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                MessageBox.Show("发生错误!");
                this.DialogResult = DialogResult.Cancel;
                Close();
                return;
            }


            if (queryResponse != null)
            {
                if (queryResponse.Code== ResultCode.SUCCESS)
                {
                    switch(queryResponse.TradeStatus)
                    {
                        case "TRADE_SUCCESS":   Message("==>交易支付成功"); 
                                                btnSuccess.Enabled = true;
                                                SaveToDB(queryResponse.OutTradeNo, queryResponse.OpenId);
                                                return;
                        case "TRADE_FINISHED":  Message("==>交易结束，不可退款"); return;
                        case "TRADE_CLOSED":    Message("==>" + queryResponse.Msg + ":" + queryResponse.SubMsg);   return;
                        case "WAIT_BUYER_PAY":  Message("==>交易创建，等待买家付款..."); return;
                     }
                }
                else if (queryResponse.Code == ResultCode.FAIL)
                {
                    Message("查询<" + queryResponse.Msg + ">" + queryResponse.SubMsg);
                }
            }
            else Message("沒有傳回訊息!...");
        }

    }
}
