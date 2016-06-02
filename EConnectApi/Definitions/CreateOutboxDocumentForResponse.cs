using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CreateOutboxDocumentForResponse : SendDocumentBaseResponse
    {
        public string AppEventResponses { get; set; }
    }
}
