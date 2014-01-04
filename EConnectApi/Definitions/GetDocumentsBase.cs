using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class GetDocumentsBase
    {
        protected byte PagerLimit = 10;

        [XmlElement(ElementName = "limit")]
        public byte Limit
        {
            get { return PagerLimit; }
            set
            {
                if (value > 0)
                    PagerLimit = value;
            }
        }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }

        [XmlElement(ElementName = "filters")]
        public GetDocumentsFiltersBase Filters { get; set; }
    }
}