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


namespace VoucherExpense
{
    public partial class FormAlipay1 : Form
    {
        DoAlipay m_Alipay;
        string m_RefundAmount ;
        string m_TradeNoStr;   // 這裏使用支付宝交易號, 在BakeryOrder使用的是OutTradeNo
        bool m_Canceled = false;

        public FormAlipay1(DoAlipay alipay, string trade_no_str, string refund_amount)
        {
            m_TradeNoStr = trade_no_str;
            m_Alipay = alipay;
            m_RefundAmount=refund_amount;
            InitializeComponent();
        }

        private void FormAlipay_Load(object sender, EventArgs e)
        {
        }


        void Message(string msg)
        {
            listBoxMsg.Items.Add(msg);
        }

        int m_CancelRetryCount = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Canceled)
                MessageBox.Show("本单已五次撤消没有成功, 将直接离开!  请记录客户手机帐单截屏含支付宝交易号,人工退款");
            else
            {
                Message("撤消本支付请求中... 單號<"+m_TradeNoStr+">");
                AlipayTradeCancelResponse cancelResponse = null;
                try
                {
                    cancelResponse = m_Alipay.CancelByTradeNo(m_TradeNoStr);
                    m_CancelRetryCount++;
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
                switch (cancelResponse.Code)
                {
                    case ResultCode.SUCCESS:
                            Message("支付撤消成功! 交易号<" + cancelResponse.TradeNo + ">");
                            m_Alipay.RefundedOrCanceled = true;
                            m_Canceled = true;
                            MessageBox.Show("本單撤消成功!");
                            break;
                    case ResultCode.FAIL: Message("支付撤消失敗! <" + cancelResponse.Msg+">");
                            Message("");
                            Message(cancelResponse.SubMsg);
                            Message("");
                            if (m_CancelRetryCount >= 5)
                                m_Canceled = true;
                            return;   // 按五次,因m_Canceled=true;就直接離開
                    default:
                            Message("不明原因, 撤消可能沒有成功!");
                            if (m_CancelRetryCount > 5)
                                m_Canceled = true;
                            return;
                }
            }
            this.DialogResult=DialogResult.Cancel;
            Close();
        }

     
        private void FormAlipay_Shown(object sender, EventArgs e)
        {
            if (m_Alipay == null)
                MessageBox.Show("無法使用支付宝服務, 支付宝組件啟動失敗或未安裝所需組件!");
            Application.DoEvents();
            m_Alipay.RefundedOrCanceled = false; // 要傳回狀態給上一層用的
            btnQuery_Click(null, null);
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            AlipayTradeRefundResponse refundResponse=null;
            try
            {
                refundResponse = m_Alipay.Refund(m_TradeNoStr, m_RefundAmount,"原麦山丘退款");
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
            switch (refundResponse.Code)
            {
                case ResultCode.SUCCESS:
                    Message("退款成功! 交易号<" + refundResponse.TradeNo + ">");
                    m_Alipay.RefundedOrCanceled = true;
                    MessageBox.Show("本單退款成功!");
                    break;
                case ResultCode.FAIL: Message("本單退款失敗! <" + refundResponse.Msg + ">");
                    Message("");
                    Message(refundResponse.SubMsg);
                    Message("");
                    return;   
            }


            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            AlipayTradeQueryResponse queryResponse = null;
            try
            {
                queryResponse = m_Alipay.QueryByTradeNo(m_TradeNoStr);
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
                                                btnRefund.Enabled = true;
                                                // SaveToDB(queryResponse.TradeNo, queryResponse.OpenId);
                                                return;
                        case "TRADE_FINISHED":  Message("==>交易结束，不可退款");
                                                btnCancel.Enabled = false;
                                                return;
                        case "TRADE_CLOSED":    Message("==>交易己关闭或已全额退款!");
                                                btnCancel.Enabled = false;
                                                return;
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
