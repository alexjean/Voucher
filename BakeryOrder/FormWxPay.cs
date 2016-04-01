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

        private void FormWxPay_Shown(object sender, EventArgs e)
        {
            Message("訂單<" + m_OutTradeNoStr + "> 支付請求发起中...");
            Application.DoEvents();
            WxPayData OutData;
            try
            {
                OutData=WxPayApi.Micropay(m_PayData);
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

            if (OutData != null)
            {
                string Code = (string)OutData.GetValue("return_code");
                object objMsg = OutData.GetValue("return_msg");
                object objResult=OutData.GetValue("result_code");

                switch (Code)
                {
                    case "SUCCESS":
                        if (objResult != null && objResult != DBNull.Value)
                        {
                            string result=(string)objResult;
                            if (result!="SUCCESS")
                            {

                                if (objMsg.GetType() == typeof(string))
                                    MessageBox.Show("支付失敗!原因不明.");
                                else
                                    MessageBox.Show("支付失敗!原因:"+(string)objMsg);
                            }
                            else
                            {
                                object objFee=OutData.GetValue("total_fee");
                                object objTranscationId=OutData.GetValue("transcation_id");
                                object objOpenID=OutData.GetValue("openid");
                                string Id="";
                                if (objFee.GetType()==typeof(int))
                                {
                                    decimal fee=((int)objFee)/100;
                                    Message("支付成功!!! 金額 " + fee.ToString());
                                }
                                if (objTranscationId.GetType()==typeof(string))
                                {
                                    Id=(string)objTranscationId;
                                    Message("微信交易號<" + Id + ">");
                                }
                                string openId="00000";
                                if (objOpenID.GetType()==typeof(string))
                                {
                                    openId=(string)objOpenID;
                                    if (openId.Length>32)   // 數據庫NVARCHAR(32)
                                        openId=openId.Substring(0,32);
                                }
                                SaveToDB(Id, openId, "00000");  // 微信支付沒有返回UserLogonID
                                btnSuccess.Enabled = true;
                                return;
                            }
                        }
                        else
                            MessageBox.Show("結果字串沒有值,原因不明, 交易可能失敗! 此單計入癈單, 仍需人工查驗微信支付狀態!");
                        goto CancelClose;

                    case "FAIL":
                        if (objMsg != null && objMsg != DBNull.Value)
                        {
                            string msg = (string)objMsg;
                            Message("支付请求失败<" + msg + ">,撤消交易中..");
                        }
                        else
                            Message("支付請求失敗! 原因不明,撤消交易中...");
                        Message("");
                        btnCancel_Click(null, null);     // Cancel_Click中有存檔 
                        goto CancelClose;
                }
            }
            return;

        CancelClose:
            SaveToDB(m_OutTradeNoStr, "00000", "00000");     // 不明失敗均記錄存檔為刪單
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
