using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.com/pw/PWDataDx/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.com/pw/PWDataDx/1.0", IsNullable = false)]
    public class RequestAppIntegration
    {
        private string _to;
        /// <summary>
        /// Company Id or Login Id to whom the app integration request has to be sent.
        /// </summary>
        [XmlElement(ElementName = "to")]
        public string To
        {
            get { return Encoder.MailAddressForUrl(_to); }
            set { _to = value; }
        }

        private string _emailAddress;
        /// <summary>
        /// Login Id or Email Id to whom the integration / on-boarding request has to be sent. Compulsory parameter if 'to' field is a KvK value.
        /// </summary>
        [XmlElement(ElementName = "Email")]
        public string EmailAddress
        {
            get { return Encoder.MailAddressForUrl(_emailAddress); }
            set { _emailAddress = value; }
        }

        [XmlIgnore]
        [Obsolete("Use EmailAddress")]
        public string EmailAdress
        {
            get { return EmailAddress; }
            set { EmailAddress = value; }
        }

        /// <summary>
        /// It should be set to "true" if the requester company pays for all the transactions of the integration.
        /// </summary>
        public bool PayByRequester { get; set; }

    }
}