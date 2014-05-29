using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.com/pw/PWDataDx/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.com/pw/PWDataDx/1.0", IsNullable = false)]
    public class RequestAppIntegration
    {
        /// <summary>
        /// Company Id or Login Id to whom the app integration request has to be sent.
        /// </summary>
        [XmlElement(ElementName = "to")]
        public string To { get; set; }

        /// <summary>
        /// Login Id or Email Id to whom the integration / on-boarding request has to be sent. Compulsory parameter if 'to' field is a KvK value.
        /// </summary>
        [XmlElement(ElementName = "Email")]
        public string EmailAdress { get; set; }

        /// <summary>
        /// It should be set to "true" if the requester company pays for all the transactions of the integration.
        /// </summary>
        public bool PayByRequester { get; set; }

    }
}