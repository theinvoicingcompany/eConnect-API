using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocuments", ElementName = "GetOutboxDocumentsResponse", IsNullable = false)]
    public class GetOutboxDocumentsResponse 
    {
        [XmlElement(ElementName = "tuple")]
        public DocumentBase[] Documents { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}