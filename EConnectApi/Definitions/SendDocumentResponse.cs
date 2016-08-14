using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/senddocument/", ElementName = "SendDocumentResponse", IsNullable = false)]
    public class SendDocumentResponse : SendDocumentBaseResponse
    {
    }
}
