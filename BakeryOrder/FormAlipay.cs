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
        string m_OutTradeNoStr;
        bool m_Canceled = false;
        int m_X = 0;
        int m_Y = 0;

        public FormAlipay(int x,int y,string out_trade_no_str,DoAlipay alipay,string content)
        {
            m_X = x;
            m_Y = y;
            m_OutTradeNoStr = out_trade_no_str;
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

        int m_CancelRetryCount = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Canceled)
                MessageBox.Show("本单已五次撤消没有成功, 将不印单无记录直接离开!  请记录客户手机帐单截屏含支付宝交易号,人工退款");
            else
            {
                Message("撤消本支付请求中... 單號<"+m_OutTradeNoStr+">");
                AlipayTradeCancelResponse cancelResponse = null;
                try
                {
                    cancelResponse = m_Alipay.Cancel(m_OutTradeNoStr);
                }
                catch (System.Net.WebException wex)
                {
                    Message(wex.Message);
                    MessageBox.Show("发生网络错误, 无法连至支付宝服务器!");
                    goto Cancel;
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                    MessageBox.Show("发生错误!");
                    goto Cancel;
                }
                m_CancelRetryCount++;
                switch (cancelResponse.Code)
                {
                    case ResultCode.SUCCESS:
                            Message("支付撤消成功! 交易号<" + cancelResponse.TradeNo + ">");
                            MessageBox.Show("本單撤消成功!");
                            m_Canceled = true;
                            SaveToDB(m_OutTradeNoStr, "00000", "00000");
                            goto Cancel;
                    case ResultCode.FAIL: Message("支付撤消失敗! <" + cancelResponse.Msg+">");
                            Message("");
                            Message(cancelResponse.SubMsg);
                            Message("");
                            if (m_CancelRetryCount >= 5)
                            {
                                m_Canceled = true;
                                goto Cancel;
                            }
                            return;
                            // 按五次,因m_Canceled=true;就直接離開
                    default:
                            Message("不明原因, 撤消可能沒有成功!");
                            if (m_CancelRetryCount > 5)
                            {
                                m_Canceled = true;
                                goto Cancel;
                            }
                            return;
                }
            }
        Cancel:
            SaveToDB(m_OutTradeNoStr, "00000", "00000");   // 取消失敗,可能只有OutTradeNo,沒有TradeNo及OpenID等等, OpenID="00000"代表TradeNo存的是OutTradeNo
            this.DialogResult=DialogResult.Cancel;
            Close();
        }

        void SaveToDB(string AliTradeNo,string OpenId,string BuyerLogonId)
        {
            // 存支付宝 OutTradeNo , OpenID, 帳號?
            m_Alipay.LastTradeNo = AliTradeNo;
            m_Alipay.LastOpenID = OpenId;
            m_Alipay.LastBuyerLogonID = BuyerLogonId;
        }

        private void FormAlipay_Shown(object sender, EventArgs e)
        {
            if (m_Alipay == null)
                MessageBox.Show("無法使用支付宝服務, 支付宝組件啟動失敗或未安裝所需組件!");
            Message("訂單<" + m_OutTradeNoStr + "> 支付請求发起中...");
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
                goto CancelClose;
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                MessageBox.Show("发生错误!");
                goto CancelClose;
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
                        SaveToDB(payResponse.TradeNo,payResponse.OpenId,payResponse.BuyerLogonId);
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
                        btnCancel_Click(null, null);     // Cancel_Click中有存檔   
                        break;
                }
            }
            return;

        CancelClose:
            SaveToDB(m_OutTradeNoStr, "00000", "00000");     // 不明失敗均記錄存檔為刪單
            this.DialogResult = DialogResult.Cancel;
            Close();
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
                queryResponse = m_Alipay.Query(m_OutTradeNoStr);
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
                                                SaveToDB(queryResponse.TradeNo, queryResponse.OpenId,queryResponse.BuyerLogonId);
                                                return;
                        case "TRADE_FINISHED":  Message("==>交易结束，不可退款"); return;
                        case "TRADE_CLOSED":    Message("==>交易己关闭或已全额退款!"); return;
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
