using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createoutboxdocument", ElementName = "CreateOutboxDocumentForResponse", IsNullable = false)]
    public class CreateOutboxDocumentForResponse : SendDocumentBaseResponse
    {
        public string AppEventResponses { get; set; }
    }
}
