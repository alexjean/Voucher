using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using Com.Alipay;
using System.Threading;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using System.Text;


namespace Com.Alipay
{
    public class ResultCode
    {
        public const string SUCCESS = "10000";
        public const string INRROCESS = "10003";
        public const string FAIL = "40004";
    }

    public class StrPair
    {
        public string Key;
        public string Value;
        public StrPair(string key, string val) { Key = key; Value = val; }
    }

    public class DoAlipay
    {
        public string serverUrl ="https://openapi.alipay.com/gateway.do";
        public string appId = "2015051300073986";
        public string merchant_private_key = KeyFilePath()+"rsa_private_key.pem";
        public string version   ="0.92";
        public string sign_type ="RSA";
        public string alipay_public_key = KeyFilePath()+"alipay_rsa_public_key.pem";
        public string charset="utf-8";
        public static string KeyFilePath() { return @"D:\HotZones\Restaurant10\VoucherExpense10\BakeryOrder\RSA_KeyFile\"; }
        //{
        //    string debugPath = Application.ExecutablePath;   //   ..\bin\Debug\BakeryOrder.Exe 要退三個 \
        //    int i;
        //    i=debugPath.LastIndexOf('\\');
        //    if (i>0)
        //    {
        //        debugPath = debugPath.Substring(0, i);
        //        i = debugPath.LastIndexOf('\\');
        //        if (i > 0)
        //        {
        //            debugPath = debugPath.Substring(0, i);
        //            i = debugPath.LastIndexOf('\\');
        //            if (i>0)
        //                debugPath = debugPath.Substring(0, i);
        //        }
        //    }
        //    return debugPath+"\\RSA_KeyFile\\";
        //}
        IAopClient m_Client;

        public void Setup()
        {
            m_Client = new DefaultAopClient(serverUrl, appId, merchant_private_key , "", version,
                                            sign_type       , alipay_public_key        , charset);
        }

        public static string List2Jason(List<StrPair> cmd)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (StrPair pair in cmd)
                sb.Append("\"" + pair.Key + "\":\"" + pair.Value + "\",");
            if (sb.Length>1) sb.Remove(sb.Length - 1, 1);  // 去掉結尾 ,号
            sb.Append("}");
            return sb.ToString();
        }

            public AlipayTradePayResponse Pay(string biz_content)
        {
            AlipayTradePayRequest payRequst = new AlipayTradePayRequest();
            payRequst.BizContent = biz_content;

            Dictionary<string, string> paramsDict = (Dictionary<string, string>)payRequst.GetParameters();
            
            AlipayTradePayResponse payResponse = m_Client.Execute(payRequst);
            return payResponse;
        }

        public AlipayTradeCancelResponse Cancel(string biz_content)
        {
            AlipayTradeCancelRequest cancelRequest = new AlipayTradeCancelRequest();
            cancelRequest.BizContent = biz_content;
            AlipayTradeCancelResponse cancelResponse = m_Client.Execute(cancelRequest);


            if (null != cancelResponse)
            {
                if (cancelResponse.Code == ResultCode.FAIL && cancelResponse.RetryFlag == "Y")
                {
                    //if (cancelResponse.Body.Contains("\"retry_flag\":\"Y\""))		
                    //cancelOrderRetry(biz_content);
                    // 新开一个线程重试撤销
                    ParameterizedThreadStart ParStart = new ParameterizedThreadStart(cancelOrderRetry);
                    Thread myThread = new Thread(ParStart);
                    object o = biz_content;
                    myThread.Start(o);
                }
            }

            return cancelResponse;

        }


        public void cancelOrderRetry(object o)
        {
            int retryCount = 10;

            for (int i = 0; i < retryCount; ++i)
            {

                Thread.Sleep(5000);
                AlipayTradeCancelRequest cancelRequest = new AlipayTradeCancelRequest();
                cancelRequest.BizContent = o.ToString();
                // Dictionary<string, string> paramsDict = (Dictionary<string, string>)cancelRequest.GetParameters();
                AlipayTradeCancelResponse cancelResponse = m_Client.Execute(cancelRequest);

                if (null != cancelResponse)
                {
                    if (cancelResponse.Code == ResultCode.FAIL)
                    {
                        //if (cancelResponse.Body.Contains("\"retry_flag\":\"N\""))		
                        if (cancelResponse.RetryFlag == "N")
                        {
                            break;
                        }
                    }
                    if ((cancelResponse.Code == ResultCode.SUCCESS))
                    {
                        break;
                    }
                }

                if (i == retryCount - 1)
                {
                    // 处理到最后一次，还是未撤销成功，需要在商户数据库中对此单最标记，人工介入处理

                }

            }
        }


        public AlipayTradeQueryResponse LoopQuery(string biz_content)
        {
            AlipayTradeQueryRequest payRequst = new AlipayTradeQueryRequest();
            payRequst.BizContent = biz_content;
            Dictionary<string, string> paramsDict = (Dictionary<string, string>)payRequst.GetParameters();
            AlipayTradeQueryResponse payResponse = null;
            for (int i = 1; i <= 6; i++)
            {
                Thread.Sleep(5000);
                payResponse = m_Client.Execute(payRequst);
                if (string.Compare(payResponse.Code, ResultCode.SUCCESS, false) == 0)
                {
                    if (payResponse.TradeStatus == "TRADE_FINISHED"
                        || payResponse.TradeStatus == "TRADE_SUCCESS"
                        || payResponse.TradeStatus == "TRADE_CLOSED")
                        break;
                }

            }
            List<StrPair> list = new List<StrPair>() { new StrPair("out_trade_no", payResponse.OutTradeNo) };
            biz_content = List2Jason(list);
            Cancel(biz_content);
            return payResponse;
        }
    }

}