using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocuments", ElementName = "GetInboxDocumentsResponse", IsNullable = false)]
    public class GetInboxDocumentsResponse
    {
        [XmlElement(ElementName = "tuple")]
        public DocumentBase[] Documents { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}