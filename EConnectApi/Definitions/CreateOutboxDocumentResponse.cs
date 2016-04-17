using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CreateOutboxDocumentResponse : SendDocumentBaseResponse
    {
        public string AppEventResponses { get; set; }
    }
}