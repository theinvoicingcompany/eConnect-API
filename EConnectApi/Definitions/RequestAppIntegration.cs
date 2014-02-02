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
    }
}