using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetCompaniesResponse
    {
        public class CompanyDetails
        {
            public string AccountId { get; set; }
            public string AccountName { get; set; }
            [XmlIgnore]
            public DateTime CreatedDateTime { get; set; }
            // Proxied property
            [XmlElement(ElementName = "CreatedDate")]
            public long RawCreatedDateTime
            {
                get { return CreatedDateTime.ToJavaTimestamp(); }
                set { CreatedDateTime = value.ToDateTime(); }
            }
            public string Country { get; set; }
            public string Residence { get; set; }
            public string Description { get; set; }
            /// <summary>
            /// Entity id
            /// </summary>
            public string CompanyId { get; set; }
            public string AdministratorUserId { get; set; }
            public string AdministratorUserName { get; set; }
            public string CompanyName { get; set; }

            [XmlElement(ElementName = "URL")]
            public string Url { get; set; }
            public string HouseNumber { get; set; }
            public bool IsRegisteredToPeppol { get; set; }
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
                get { return ActivatedDate.ToJavaTimestamp(); }
                set { ActivatedDate = value.ToDateTime(); }
            }

        }

        [XmlElement(ElementName = "tuple")]
        public CompanyDetails[] Companies { get; set; }


        [XmlElement(ElementName = "cursor")]
        public string Cursor { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}