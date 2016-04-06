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

        void SaveToDB(string AliTradeNo, string OpenId, string BuyerLogonId)
        {
            m_PayData.SetValue("LastTradeNo"     , AliTradeNo);
            m_PayData.SetValue("LastOpenID"      , OpenId);
            m_PayData.SetValue("LastBuyerLogonID", BuyerLogonId);
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
                MessageBox.Show("发生错误!");
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
                                //if (ObjectValid(objMsg, typeof(string)))
                                //    MessageBox.Show("撤销失敗!讯息:" + (string)objMsg);
                                //else
                                //    MessageBox.Show("支付失敗!讯息不明.");

                                //if (ObjectValid(objMsg, typeof(string)))
                                //    MessageBox.Show("支付失敗!原因:" + (string)objMsg);
                                //else
                                //    MessageBox.Show("支付失敗!原因不明.");
                            }
                            else
                            {
                                object objFee=outData.GetValue("total_fee");
                                object objTranscationId=outData.GetValue("transaction_id");
                                object objOpenID=outData.GetValue("openid");
                                string Id="";
                                if (ObjectValid(objFee,typeof(string)))
                                {
                                    //decimal fee=((int)objFee)/100;
                                    Message("支付成功!!! 金額 " + objFee.ToString());
                                }
                                if (ObjectValid(objTranscationId,typeof(string)))
                                {
                                    Id=(string)objTranscationId;
                                    Message("微信交易號<" + Id + ">");
                                }
                                string openId="00000";
                                if (ObjectValid(objOpenID,typeof(string)))
                                {
                                    openId=(string)objOpenID;
                                    if (openId.Length>32)   // 數據庫NVARCHAR(32)
                                        openId=openId.Substring(0,32);
                                }
                                if (openId=="00000" || Id=="")
                                    SaveToDB(m_OutTradeNoStr, "00000", "00000");   // 沒有OpenID就存OutTradeNo, 在大麥店長端退款以OpenID判斷要給那一個
                                else
                                    SaveToDB(Id, openId, "00000");  // 微信支付沒有返回UserLogonID
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
            SaveToDB(m_OutTradeNoStr, "00000", "00000");     // 不明失敗均記錄存檔為刪單
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
            SaveToDB(m_OutTradeNoStr, "00000", "00000");   // 取消失敗,可能只有OutTradeNo,沒有TradeNo及OpenID等等, OpenID="00000"代表TradeNo存的是OutTradeNo
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
