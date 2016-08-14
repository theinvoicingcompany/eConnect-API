using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/requestappintegration", ElementName = "RequestAppIntegrationResponse", IsNullable = false)]
    public class RequestAppIntegrationResponse
    {
        /// <summary>
        /// Id of the app integration request sent, used to fetch status for the same
        /// </summary>
        public string IntegrationRequestId { get; set; }
    }
}