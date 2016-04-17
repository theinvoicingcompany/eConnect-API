using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetCompaniesResponse : PageAbleResponse
    {
        public class CompanyDetails
        {
            public string AccountId { get; set; }
            public string AccountName { get; set; }
            public string EmailAddress { get; set; }

            [XmlIgnore]
            public DateTime CreatedDateTime { get; set; }

            // Proxied property
            [XmlElement(ElementName = "CreatedDate")]
            public long RawCreatedDateTime
            {
                get
                {
                    return CreatedDateTime.ToJavaTimestamp();
                }
                set
                {
                    CreatedDateTime = value.ToDateTime();
                }
            }

            public string Country { get; set; }
            public string Residence { get; set; }
            public string Description { get; set; }

            public string EntityId { get; set; }
            public string CompanyId { get; set; }
            public string TemporaryIdentifier { get; set; }

            public string AdministratorUserId { get; set; }
            public string AdministratorUserName { get; set; }
            public string CompanyName { get; set; }

            [XmlElement(ElementName = "URL")]
            public string Url { get; set; }

            public string HouseNumber { get; set; }

            [XmlElement(ElementName = "PeppolRegisterationRefernceList")]
            public string PeppolRegisterationReferenceList { get; set; }
            public bool IsRegisteredToPeppol { get; set; }

            private string _isVerified;
            [XmlElement(ElementName = "IsVerified")]
            public string IsVerifiedRaw
            {
                get { return _isVerified; }
                set
                {
                    _isVerified = value;
                    IsVerified = value.Equals("true", StringComparison.InvariantCultureIgnoreCase);
                }
            }

            [XmlIgnore]
            public bool IsVerified { get; set; }

            public int MemberCount { get; set; }
            public string PostalCode { get; set; }
            public string StreetName { get; set; }
            public string CompanyCreatorUserId { get; set; }
            public string CompanyCreatorUserName { get; set; }

            [XmlIgnore]
            public DateTime ActivatedDate { get; set; }

            [XmlElement(ElementName = "ActivatedDate")]
            public long RawActivatedDate
            {
                get
                {
                    return ActivatedDate.ToJavaTimestamp();
                }
                set
                {
                    ActivatedDate = value.ToDateTime();
                }
            }

        }

        [XmlElement(ElementName = "tuple")]
        public CompanyDetails[] Companies { get; set; }
    }
}