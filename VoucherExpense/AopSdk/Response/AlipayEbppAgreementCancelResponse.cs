using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayEbppAgreementCancelResponse.
    /// </summary>
    public class AlipayEbppAgreementCancelResponse : AopResponse
    {
        /// <summary>
        /// 返回码  0:成功 1:支付宝侧不存在订阅关系 111:其他错误
        /// </summary>
        [XmlElement("retcode")]
        public string Retcode { get; set; }

        /// <summary>
        /// 返回描述
        /// </summary>
        [XmlElement("retmsg")]
        public string Retmsg { get; set; }

        /// <summary>
        /// 返回结果,0:成功 600:支付宝侧不存在订阅关系/其他错误
        /// </summary>
        [XmlElement("retype")]
        public long Retype { get; set; }
    }
}
