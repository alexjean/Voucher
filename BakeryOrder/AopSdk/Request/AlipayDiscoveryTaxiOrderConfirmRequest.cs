using System;
using System.Collections.Generic;
using Aop.Api.Response;

namespace Aop.Api.Request
{
    /// <summary>
    /// AOP API: alipay.discovery.taxi.order.confirm
    /// </summary>
    public class AlipayDiscoveryTaxiOrderConfirmRequest : IAopRequest<AlipayDiscoveryTaxiOrderConfirmResponse>
    {
        /// <summary>
        /// 司机纬度
        /// </summary>
        public string DriverLat { get; set; }

        /// <summary>
        /// 司机车牌
        /// </summary>
        public string DriverLicense { get; set; }

        /// <summary>
        /// 司机经度
        /// </summary>
        public string DriverLng { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 司机手机号
        /// </summary>
        public string DriverPhone { get; set; }

        /// <summary>
        /// 是否支持支付宝付款
        /// </summary>
        public Nullable<bool> IsAlipaySupport { get; set; }

        /// <summary>
        /// 打车订单ID
        /// </summary>
        public string OutBizNo { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string Seller { get; set; }

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
            return "alipay.discovery.taxi.order.confirm";
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
            parameters.Add("driver_lat", this.DriverLat);
            parameters.Add("driver_license", this.DriverLicense);
            parameters.Add("driver_lng", this.DriverLng);
            parameters.Add("driver_name", this.DriverName);
            parameters.Add("driver_phone", this.DriverPhone);
            parameters.Add("is_alipay_support", this.IsAlipaySupport);
            parameters.Add("out_biz_no", this.OutBizNo);
            parameters.Add("partner_id", this.PartnerId);
            parameters.Add("seller", this.Seller);
            return parameters;
        }

        #endregion
    }
}
