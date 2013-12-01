using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetDocumentsResponse
    {
        [XmlElement(ElementName = "tuple")]
        public DocumentBase[] Documents { get; set; }
    }
}