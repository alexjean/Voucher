using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WxPayAPI;

namespace VoucherExpense
{
    public partial class FormWxPay1 : Form
    {
        string m_RefundAmount ;
        string m_TradeNoStr;    // 這裏使用交易號, 在BakeryOrder使用的是OutTradeNo
        string m_OutTradeNoStr; // 萬一交易號為null, 就使用OutTradeNo
        bool m_Canceled = false;

        public FormWxPay1(string TradeNoStr, string OutTradeNoStr,string refund_amount)
        {
            m_TradeNoStr    = TradeNoStr;
            m_OutTradeNoStr = OutTradeNoStr;
            m_RefundAmount=refund_amount;
            InitializeComponent();
        }

        void Message(string msg)
        {
            listBoxMsg.Items.Add(msg);
        }

        bool ObjectValid(object obj, Type type)
        {
            if (obj == null) return false;
            if (obj.GetType() == type) return true;
            return false;
        }
        
        int m_CancelRetryCount = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Canceled)
                MessageBox.Show("本单已五次撤消没有成功, 将不印单无记录直接离开!  请记录客户手机帐单截屏含微信交易号,人工退款");
            else
            {
                WxPayData cancelData = new WxPayData();
                WxPayData outData;
                if (m_OutTradeNoStr != null && m_OutTradeNoStr != "")   // POS端只用out_trade_no
                {
                    Message("撤消本支付请求中... 内部交易号<" + m_OutTradeNoStr + ">");
                    cancelData.SetValue("out_trade_no", m_OutTradeNoStr);
                }
                else if (m_TradeNoStr != null && m_TradeNoStr != "")
                {
                    Message("撤消本支付请求中... 微信交易号<" + m_TradeNoStr + ">");
                    cancelData.SetValue("transaction_id", m_TradeNoStr);
                }
                else
                {
                    MessageBox.Show("无法取得 内部交易号 或 微信交易号,进行不了撤销！");
                    goto Cancel;
                }
                try
                {
                    outData=WxPayApi.Reverse(cancelData);
                }
                catch (System.Net.WebException wex)
                {
                    Message(wex.Message);
                    MessageBox.Show("发生网络错误, 无法连至微信支付服务器!");
                    goto Cancel;
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                    MessageBox.Show("发生错误!");
                    goto Cancel;
                }
                m_CancelRetryCount++;
                if (outData != null)
                {
                    string Code = "";
                    object objCode= outData.GetValue("return_code");
                    object objMsg = outData.GetValue("return_msg");
                    object objResult = outData.GetValue("result_code");
                    if (ObjectValid(objCode, typeof(string))) Code = (string)objCode;
                    switch (Code)
                    {
                        case "SUCCESS":
                            if (ObjectValid(objResult,typeof(string)))
                            {
                                string result=(string)objResult;
                                object objErrCode = outData.GetValue("err_code");
                                object objErrCodeDes = outData.GetValue("err_code_des");
                                if (result != "SUCCESS")
                                {
                                    if (ObjectValid(objErrCode, typeof(string)))    Message("撤销失敗!代码:" + (string)objErrCode);
                                    if (ObjectValid(objErrCodeDes, typeof(string))) Message("撤销失敗!原因:" + (string)objErrCodeDes);
                                    if (ObjectValid(objMsg, typeof(string)))
                                        MessageBox.Show("撤销失敗!讯息:" + (string)objMsg);
                                    else
                                        MessageBox.Show("支付失敗!讯息不明.");
                                }
                                else
                                {
                                    Message("支付撤消成功!");
                                    MessageBox.Show("本單撤消成功!");
                                    m_Canceled = true;
                                    goto Cancel;
                                }
                            }
                            else
                                MessageBox.Show("結果字串沒有值,原因不明, 交易可能失敗! 若此單計入癈單, 仍需人工查驗微信支付狀態!");
                            return;


                        case "FAIL":
                            if (ObjectValid(objMsg, typeof(string)))
                                Message("支付撤消失敗! <" + (string)objMsg + ">");
                            else
                                Message("支付撤消失敗! 讯息不明");
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
                return;
            }
        Cancel:
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            WxPayData queryData = new WxPayData();
            WxPayData outData;
            if (m_OutTradeNoStr!=null && m_OutTradeNoStr != "")   // POS端只用out_trade_no
            {
                Message("查询本支付请求中... 内部交易号<" + m_OutTradeNoStr + ">");
                queryData.SetValue("out_trade_no", m_OutTradeNoStr);
            }
            else if (m_TradeNoStr != null && m_TradeNoStr != "")
            {
                Message("查询本支付请求中... 微信交易号<" + m_TradeNoStr + ">");
                queryData.SetValue("transaction_id", m_TradeNoStr);
            }
            else
            {
                Message("无法取得 内部交易号 或 微信交易号,进行不了查询！");
                return;
            }
            try
            {
                outData = WxPayApi.OrderQuery(queryData);
            }
            catch (System.Net.WebException wex)
            {
                Message(wex.Message);
                MessageBox.Show("发生网络错误, 无法连至微信支付服务器!");
                return;
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                MessageBox.Show("发生错误!");
                return;
            }
            if (outData != null)
            {
                string Code = "";
                object objCode = outData.GetValue("return_code");
                object objMsg = outData.GetValue("return_msg");
                object objResult = outData.GetValue("result_code");
                if (ObjectValid(objCode, typeof(string))) Code = (string)objCode;
                switch (Code)
                {
                    case "SUCCESS":
                        if (ObjectValid(objResult, typeof(string)))
                        {
                            string result = (string)objResult;
                            object objErrCode = outData.GetValue("err_code");
                            object objErrCodeDes = outData.GetValue("err_code_des");
                            if (result != "SUCCESS")
                            {
                                if (ObjectValid(objErrCode   , typeof(string))) Message("查询失敗!代码:" + (string)objErrCode);
                                if (ObjectValid(objErrCodeDes, typeof(string))) Message("查询失敗!原因:" + (string)objErrCodeDes);
                                if (ObjectValid(objMsg, typeof(string)))
                                    Message("查询失敗!讯息:" + (string)objMsg);
                                else
                                    Message("查询失敗!讯息不明.");
                            }
                            else
                            {
                                object objTradeState = outData.GetValue("trade_state");
                                object obTotalFee    = outData.GetValue("total_fee");
                                string tradeState    = "";
                                if (ObjectValid(objTradeState, typeof(string)))
                                {
                                    switch((string)objTradeState)
                                    {
                                        case "SUCCESS": tradeState="支付成功"; break;
                                        case "REFUND":  tradeState="转入退款"; break;
                                        case "NOTPAY":  tradeState="未支付";   break;
                                        case "CLOSED":  tradeState="已关闭";   break;
                                        case "REVOKED": tradeState="刷卡支付已撤销"; break;
                                        case "USERPAYING": tradeState="用户支付中";  break;
                                        case "PAYERROR": tradeState="支付失败"; break;
                                    }
                                }
                                Message("支付查询成功! 结果："+tradeState);
                                if (ObjectValid(obTotalFee,typeof(string)))
                                {
                                    string str = obTotalFee.ToString();
                                    int n = str.Length;
                                    string strFee;
                                    if (n < 3) // 不到一元
                                        strFee = str;
                                    else strFee = str.Substring(0, n - 2) + "." + str.Substring(n - 2, 2);
                                    Message("金額 " + strFee);
                                }
                            }
                        }
                        else
                            MessageBox.Show("結果字串沒有值,原因不明, 交易可能失敗! 若此單計入癈單, 仍需人工查驗微信支付狀態!");
                        return;
                    case "FAIL":
                        if (ObjectValid(objMsg, typeof(string)))
                            Message("查询失敗! <" + (string)objMsg + ">");
                        else
                            Message("查询失敗! 讯息不明");
                        return;
                    default:
                        Message("不明原因, 查询可能沒有成功!");
                        return;
                }
            }
            return;
        }

        private void FormWxPay1_Shown(object sender, EventArgs e)
        {
            btnQuery_Click(null,null);
        }
    }
}
