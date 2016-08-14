using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/requestintegrationcredentials", ElementName = "RequestIntegrationCredentials", IsNullable = false)]
    public class RequestIntegrationCredentials
    {
        /// <summary>
        /// Id of the app integration request received as response while firing the Request for App Integration API
        /// </summary>
        public string IntegrationRequestId { get; set; }
    }
}