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

        public FormWxPay(int x, int y, string out_trade_no_str, WxPayAPI.WxPayData payData) // 借用WxPayData payData傳回 outTradeNo transcationId openid
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

        // 借用WxPayData payData傳回 outTradeNo transcationId openid
        void SaveToDB(string TradeNo, string OpenId)
        {
            m_PayData.SetValue("LastTradeNo"     , TradeNo);  //  openid "00000"則存out_trade_no,否則transcation_id
            m_PayData.SetValue("LastOpenID"      , OpenId);
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

        private void FormWxPay_Shown(object sender, EventArgs e)
        {
            Message("訂單<" + m_OutTradeNoStr + "> 支付請求发起中...");
            Application.DoEvents();
            WxPayData outData;
            try
            {
                outData=WxPayApi.Micropay(m_PayData);
            }
            catch (System.Net.WebException wex)
            {
                Message(wex.Message);
                MessageBox.Show("发生网络错误, 无法连至微信服务器!");
                goto CancelClose;
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                MessageBox.Show("发生错误! 是否网络不通？");
                goto CancelClose;
            }

            if (outData != null)
            {
                string Code="";
                object objCode=outData.GetValue("return_code");
                object objMsg = outData.GetValue("return_msg");
                object objResult = outData.GetValue("result_code");
                if (ObjectValid(objCode, typeof(string))) Code = (string)objCode;

                switch (Code)
                {
                    case "SUCCESS":
                        if (ObjectValid(objResult,typeof(string)))
                        {
                            string result=(string)objResult;
                            if (result!="SUCCESS")
                            {
                                object objErrCode = outData.GetValue("err_code");
                                object objErrCodeDes = outData.GetValue("err_code_des");
                                if (ObjectValid(objErrCode, typeof(string)))    Message("交易尚未成功!代码:" + (string)objErrCode);
                                if (ObjectValid(objErrCodeDes, typeof(string))) Message("交易尚未成功!原因:" + (string)objErrCodeDes);
                            }
                            else
                            {
                                object objFee=outData.GetValue("total_fee");
                                object objTranscationId=outData.GetValue("transaction_id");
                                object objOpenID=outData.GetValue("openid");
                                string Id="";
                                if (ObjectValid(objTranscationId,typeof(string)))
                                {
                                    Id=(string)objTranscationId;
                                    Message("微信交易號<" + Id + ">");
                                }
                                if (ObjectValid(objFee, typeof(string)))
                                {
                                    string str = objFee.ToString();
                                    int n = str.Length;
                                    string strFee;
                                    if (n < 3) // 不到一元
                                        strFee = str;
                                    else strFee = str.Substring(0, n - 2) + "." + str.Substring(n - 2, 2);
                                    Message("支付成功!!! 金額 " + strFee);
                                }
                                string openId = "00000";
                                if (ObjectValid(objOpenID,typeof(string)))
                                {
                                    openId=(string)objOpenID;
                                    if (openId.Length>32)   // 數據庫NVARCHAR(32)
                                        openId=openId.Substring(0,32);
                                }
                                if (openId=="00000" || Id=="")
                                    SaveToDB(m_OutTradeNoStr, "00000");   // 沒有OpenID就存OutTradeNo, 在大麥店長端退款以OpenID判斷要給那一個
                                else
                                    SaveToDB(Id, openId);  // 微信支付沒有返回UserLogonID
                                btnSuccess.Enabled = true;
                            }
                            return;
                        }
                        else
                            MessageBox.Show("結果字串沒有值,原因不明, 交易可能失敗! 此單計入癈單, 仍需人工查驗微信支付狀態!");
                        goto CancelClose;

                    case "FAIL":
                    default:
                        btnCancel_Click(null, null);     // Cancel_Click中有存檔 
                        if (ObjectValid(objMsg,typeof(string)))
                        {
                            string msg = (string)objMsg;
                            MessageBox.Show("支付请求失败<" + msg + ">,撤消交易中..");
                        }
                        else
                            MessageBox.Show("支付請求失敗! 原因不明,撤消交易中...");
                        Message("");
                        goto CancelClose;
                }
            }
            return;

        CancelClose:
            SaveToDB(m_OutTradeNoStr, "00000");     // 不明失敗均記錄存檔為刪單
            this.DialogResult = DialogResult.Cancel;
            Close();
        }


        int m_CancelRetryCount = 0;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (m_Canceled)
                MessageBox.Show("本单已五次撤消没有成功, 将不印单无记录直接离开!  请记录客户手机帐单截屏含微信交易号,人工退款");
            else
            {
                Message("撤消本支付请求中... 單號<" + m_OutTradeNoStr + ">");
                WxPayData cancelData=new WxPayData();
                WxPayData outData;
                cancelData.SetValue("out_trade_no",m_OutTradeNoStr);
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
                                    btnSuccess.Enabled = true;
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
            SaveToDB(m_OutTradeNoStr, "00000");   // 取消失敗,可能只有OutTradeNo,沒有TradeNo及OpenID等等, OpenID="00000"代表TradeNo存的是OutTradeNo
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            WxPayData queryData = new WxPayData();
            WxPayData outData;
            if (m_OutTradeNoStr != "")   // POS端只用out_trade_no
            {
                Message("查询本支付请求中... 内部交易号<" + m_OutTradeNoStr + ">");
                queryData.SetValue("out_trade_no", m_OutTradeNoStr);
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
                            if (result != "SUCCESS")
                            {
                                object objErrCode = outData.GetValue("err_code");
                                object objErrCodeDes = outData.GetValue("err_code_des");
                                if (ObjectValid(objErrCode, typeof(string))) Message("查询失敗!代码:" + (string)objErrCode);
                                if (ObjectValid(objErrCodeDes, typeof(string))) Message("查询失敗!原因:" + (string)objErrCodeDes);
                                if (ObjectValid(objMsg, typeof(string)))
                                    Message("查询失敗!讯息:" + (string)objMsg);
                                else
                                    Message("查询失敗!讯息不明.");
                            }
                            else
                            {
                                object objTradeState = outData.GetValue("trade_state");
                                string tradeState = "";
                                if (ObjectValid(objTradeState, typeof(string)))
                                {
                                    switch ((string)objTradeState)
                                    {
                                        case "SUCCESS": tradeState = "支付成功";

                                                        object objFee=outData.GetValue("total_fee");
                                                        object objTranscationId=outData.GetValue("transaction_id");
                                                        object objOpenID=outData.GetValue("openid");
                                                        string Id="";
                                                        if (ObjectValid(objTranscationId,typeof(string)))
                                                        {
                                                            Id=(string)objTranscationId;
                                                            Message("微信交易號<" + Id + ">");
                                                        }
                                                        if (ObjectValid(objFee, typeof(string)))
                                                        {
                                                            string str = objFee.ToString();
                                                            int n = str.Length;
                                                            string strFee;
                                                            if (n < 3) // 不到一元
                                                                strFee = str;
                                                            else strFee = str.Substring(0, n - 2) + "." + str.Substring(n - 2, 2);
                                                            Message("支付成功!!! 金額 " + strFee);
                                                        }
                                                        string openId = "00000";
                                                        if (ObjectValid(objOpenID,typeof(string)))
                                                        {
                                                            openId=(string)objOpenID;
                                                            if (openId.Length>32)   // 數據庫NVARCHAR(32)
                                                                openId=openId.Substring(0,32);
                                                        }
                                                        if (openId=="00000" || Id=="")
                                                            SaveToDB(m_OutTradeNoStr, "00000");   // 沒有OpenID就存OutTradeNo, 在大麥店長端退款以OpenID判斷要給那一個
                                                        else
                                                            SaveToDB(Id, openId);  // 微信支付沒有返回UserLogonID


                                                        btnSuccess.Enabled = true;
                                                        break;
                                        case "REFUND": tradeState = "转入退款"; break;
                                        case "NOTPAY": tradeState = "未支付"; break;
                                        case "CLOSED": tradeState = "已关闭"; break;
                                        case "REVOKED": tradeState = "刷卡支付已撤销"; break;
                                        case "USERPAYING": tradeState = "用户支付中"; break;
                                        case "PAYERROR": tradeState = "支付失败"; break;
                                    }
                                }
                                Message("支付查询成功! 结果：" + tradeState);
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

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
