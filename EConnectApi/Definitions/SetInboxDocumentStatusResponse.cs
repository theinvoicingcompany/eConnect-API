using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/setinboxdocumentstatus", ElementName = "SetInboxDocumentStatusResponse", IsNullable = false)]
    public class SetInboxDocumentStatusResponse
    {
        public string ConsignmentId { get; set; }
    }
}