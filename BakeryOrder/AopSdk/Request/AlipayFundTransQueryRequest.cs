using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.fund.trans.query
    /// </summary>
    public class AlipayFundTransQueryRequest : IAopRequest<AlipayFundTransQueryResponse>
    {
        /// <summary>
        /// 支付宝转账单据号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商户转账唯一订单号
        /// </summary>
        public string OutBizNo { get; set; }

        #region IAopRequest Members
        private string apiVersion = "1.0";
		private string terminalType;
		private string terminalInfo;
        private string prodCode;


        public void SetTerminalType(String terminalType){
			this.terminalType=terminalType;
		}

    	public string GetTerminalType(){
    		return this.terminalType;
    	}

    	public void SetTerminalInfo(String terminalInfo){
    		this.terminalInfo=terminalInfo;
    	}

    	public string GetTerminalInfo(){
    		return this.terminalInfo;
    	}

        public void SetProdCode(String prodCode){
            this.prodCode=prodCode;
        }

        public string GetProdCode(){
            return this.prodCode;
        }

        public string GetApiName()
        {
            return "alipay.fund.trans.query";
        }

        public void SetApiVersion(string apiVersion){
            this.apiVersion=apiVersion;
        }

        public string GetApiVersion(){
            return this.apiVersion;
        }

        public IDictionary<string, string> GetParameters()
        {
            AopDictionary parameters = new AopDictionary();
            parameters.Add("order_id", this.OrderId);
            parameters.Add("out_biz_no", this.OutBizNo);
            return parameters;
        }

        #endregion
    }
}
