using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class GetDocumentsResponseBase
    {
        [XmlElement(ElementName = "tuple")]
        public EConnectDocument[] Documents { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}