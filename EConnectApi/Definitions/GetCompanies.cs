using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetCompanies
    {
        public class GetCompaniesFilters
        {
            public bool ShouldSerializeMyCompaniesOnly() { return MyCompaniesOnly.HasValue; }
            public bool? MyCompaniesOnly { get; set; }

            public bool ShouldSerializeVerifiedOnly() { return VerifiedOnly.HasValue; }
            public bool? VerifiedOnly { get; set; }

            public bool ShouldSerializeSimplerInvoicingRegisteredOnly() { return SimplerInvoicingRegisteredOnly.HasValue; }
            /// <summary>
            /// Only peppol registered companies
            /// </summary>
            public bool? SimplerInvoicingRegisteredOnly { get; set; }
            public string Administrator { get; set; }
        }

        [XmlElement(ElementName = "filters")]
        public GetCompaniesFilters Filters { get; set; }

        protected byte PagerLimit = 20;

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


        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}