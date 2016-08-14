using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getcompanies", ElementName = "GetCompanies", IsNullable = false)]
    public class GetCompanies : PageAble
    {
        public class GetCompaniesFilters
        {
            public bool ShouldSerializeMyCompaniesOnly() { return MyCompaniesOnly.HasValue; }
            public bool? MyCompaniesOnly { get; set; }

            public bool ShouldSerializeVerifiedOnly() { return VerifiedOnly.HasValue; }

            [XmlElement(ElementName = "VerfiedOnly")]
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

        [XmlElement(ElementName = "cursor")]
        public string Cursor { get; set; }
    }
}