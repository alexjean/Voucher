using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMobilePublicMockListprimApiResponse.
    /// </summary>
    public class AlipayMobilePublicMockListprimApiResponse : AopResponse
    {
        /// <summary>
        /// 2088xxx
        /// </summary>
        [XmlArray("user_id_list")]
        [XmlArrayItem("string")]
        public List<string> UserIdList { get; set; }
    }
}
