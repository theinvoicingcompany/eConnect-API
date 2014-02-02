using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.com/pw/PWDataDx/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.com/pw/PWDataDx/1.0", IsNullable = false)]
    public class RequestIntegrationCredentials
    {
        /// <summary>
        /// Id of the app integration request received as response while firing the Request for App Integration API
        /// </summary>
        public string IntegrationRequestId { get; set; }
    }
}