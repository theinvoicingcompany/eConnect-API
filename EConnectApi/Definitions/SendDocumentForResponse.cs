using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/senddocumentfor/", ElementName = "SendDocumentForResponse", IsNullable = false)]
    public class SendDocumentForResponse : SendDocumentBaseResponse
    {
    }
}