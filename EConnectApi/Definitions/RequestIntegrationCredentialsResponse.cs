using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/requestintegrationcredentials", ElementName = "RequestIntegrationCredentialsResponse", IsNullable = false)]
    public class RequestIntegrationCredentialsResponse
    {
        [XmlElement(ElementName = "ERRORCODE")]
        public string ErrorCode { get; set; }
        [XmlElement(ElementName = "ERRORMESSAGE")]
        public string ErrorMessage { get; set; }
        
        public string AppIntegrationKey { get; set; }
        public string AppIntegrationSecret { get; set; }
        public string ApproverId { get; set; }
        public string ApplicationName { get; set; }
    }
}