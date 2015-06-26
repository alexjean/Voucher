using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.mobile.bksigntoken.verify
    /// </summary>
    public class AlipayMobileBksigntokenVerifyRequest : IAopRequest<AlipayMobileBksigntokenVerifyResponse>
    {
        /// <summary>
        /// 设备标识
        /// </summary>
        public string Deviceid { get; set; }

        /// <summary>
        /// 调用来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 查询token
        /// </summary>
        public string Token { get; set; }

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
            return "alipay.mobile.bksigntoken.verify";
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
            parameters.Add("deviceid", this.Deviceid);
            parameters.Add("source", this.Source);
            parameters.Add("token", this.Token);
            return parameters;
        }

        #endregion
    }
}
