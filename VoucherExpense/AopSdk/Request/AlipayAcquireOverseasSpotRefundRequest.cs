using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.acquire.overseas.spot.refund
    /// </summary>
    public class AlipayAcquireOverseasSpotRefundRequest : IAopRequest<AlipayAcquireOverseasSpotRefundResponse>
    {
        /// <summary>
        /// refund currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The refund order id on partner system.    partner_refund_id together with partner identify a refund transaction
        /// </summary>
        public string PartnerRefundId { get; set; }

        /// <summary>
        /// The original partner transaction id given in the payment request
        /// </summary>
        public string PartnerTransId { get; set; }

        /// <summary>
        /// Less than or equal to the original transaction amont and the left transaction amount if ever refunded.
        /// </summary>
        public string RefundAmount { get; set; }

        /// <summary>
        /// The reason of refund
        /// </summary>
        public string RefundReason { get; set; }

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
            return "alipay.acquire.overseas.spot.refund";
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
            parameters.Add("currency", this.Currency);
            parameters.Add("partner_refund_id", this.PartnerRefundId);
            parameters.Add("partner_trans_id", this.PartnerTransId);
            parameters.Add("refund_amount", this.RefundAmount);
            parameters.Add("refund_reason", this.RefundReason);
            return parameters;
        }

        #endregion
    }
}
