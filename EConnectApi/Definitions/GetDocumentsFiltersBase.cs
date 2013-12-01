using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "filters", IsNullable = false)]
    public class GetDocumentsFiltersBase
    {
        [XmlElement(ElementName = "IsRead")]
        public bool IsRead { get; set; }
        [XmlElement(ElementName = "SenderEntityId")]
        public string SenderEntityId { get; set; }
        [XmlElement(ElementName = "CreatedDateTime")]
        public TimeSpanFilter CreatedDateTime { get; set; }
        [XmlElement(ElementName = "ModifiedDateTime")]
        public TimeSpanFilter ModifiedDateTime { get; set; }
    }
}