using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.databiz.core.payment.ability.get
    /// </summary>
    public class AlipayDatabizCorePaymentAbilityGetRequest : IAopRequest<AlipayDatabizCorePaymentAbilityGetResponse>
    {
        /// <summary>
        /// 外部商户应用名称
        /// </summary>
        public string AppInfo { get; set; }

        /// <summary>
        /// 移动设备唯一标示码，后续版本废弃该参数，手机号码作为唯一查询标示。
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// 手机号码，必选！
        /// </summary>
        public string MobileNum { get; set; }

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
            return "alipay.databiz.core.payment.ability.get";
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
            parameters.Add("app_info", this.AppInfo);
            parameters.Add("imei", this.Imei);
            parameters.Add("mobile_num", this.MobileNum);
            return parameters;
        }

        #endregion
    }
}
