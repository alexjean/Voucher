using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.ecard.edu.recharged.card.del
    /// </summary>
    public class AlipayEcardEduRechargedCardDelRequest : IAopRequest<AlipayEcardEduRechargedCardDelResponse>
    {
        /// <summary>
        /// 机构code
        /// </summary>
        public string AgentCode { get; set; }

        /// <summary>
        /// 支付宝userid
        /// </summary>
        public string AlipayUserId { get; set; }

        /// <summary>
        /// 校园一卡通卡号
        /// </summary>
        public string CardNo { get; set; }

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
            return "alipay.ecard.edu.recharged.card.del";
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
            parameters.Add("agent_code", this.AgentCode);
            parameters.Add("alipay_user_id", this.AlipayUserId);
            parameters.Add("card_no", this.CardNo);
            return parameters;
        }

        #endregion
    }
}
