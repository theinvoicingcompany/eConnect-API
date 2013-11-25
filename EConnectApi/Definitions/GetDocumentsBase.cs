using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class GetDocumentsBase
    {
        // TODO: Limit default value and MIN value
        [XmlElement(ElementName = "limit")]
        public byte Limit { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string Startrowrange { get; set; }

        [XmlElement(ElementName = "filters")]
        public GetDocumentsFiltersBase Filters { get; set; }
    }
}