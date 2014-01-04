using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class GetDocumentsResponseBase
    {
        [XmlElement(ElementName = "tuple")]
        public DocumentBase[] Documents { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}