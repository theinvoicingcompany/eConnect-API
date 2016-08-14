using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/gettemplates", ElementName = "GetTemplates", IsNullable = false)]
    public class GetTemplates
    {
        public GetTemplates()
        {
            Type = TemplateType.Account;
            // StartRowRange is not available at this moment, so use MaxValue. 
            Limit = byte.MaxValue;
        }

        public byte Limit { get; set; }

        public class GetTemplatesFilters
        {
            public string MasterTemplateId { get; set; }
        }
        
        public TemplateType Type { get; set; }

        [XmlElement(ElementName = "filters")]
        public GetTemplatesFilters Filters { get; set; }
    }

    public enum TemplateType
    {
        Account, Partner
    }
}