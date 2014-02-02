using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class RequestAppIntegrationResponse
    {
        /// <summary>
        /// Id of the app integration request sent, used to fetch status for the same
        /// </summary>
        public string IntegrationRequestId { get; set; }
    }
}