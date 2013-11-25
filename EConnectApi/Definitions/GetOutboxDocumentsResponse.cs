using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetOutboxDocumentsResponse
    {
        [XmlElement(ElementName = "tuple")]
        public DocumentBase[] DocumentsBase { get; set; }
    }
}