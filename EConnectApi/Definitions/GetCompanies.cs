using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetCompanies
    {
        public class GetCompaniesFilters
        {
            public bool MyCompaniesOnly { get; set; }
            public bool VerfiedOnly { get; set; }
            /// <summary>
            /// Only peppol registered companies
            /// </summary>
            public bool SimplerInvoicingRegisteredOnly { get; set; }
            public string Administrator { get; set; }
        }

        [XmlElement(ElementName = "filters")]
        public GetCompaniesFilters Filters { get; set; }

        protected byte PagerLimit = 20;

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

        [XmlElement(ElementName = "cursor")]
        public string Cursor { get; set; }
    }
}