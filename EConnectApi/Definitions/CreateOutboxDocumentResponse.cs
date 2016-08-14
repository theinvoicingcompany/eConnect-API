using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createoutboxdocument", ElementName = "CreateOutboxDocumentResponse", IsNullable = false)]
    public class CreateOutboxDocumentResponse : SendDocumentBaseResponse
    {
        public string AppEventResponses { get; set; }
    }
}