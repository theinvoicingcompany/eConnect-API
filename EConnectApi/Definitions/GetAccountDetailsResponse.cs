using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetAccountDetailsResponse
    {
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }

        public string AcccountType { get; set; }
        public string Address { get; set; }
        public string AccountId { get; set; }

        public bool CanSendAppIntegrationRequests { get; set; }
        public string AccountName { get; set; }
        public string AccountImage { get; set; }

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
        public string Category { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PricingPlanName { get; set; }
        public string TotalUsersCount { get; set; }
        public string Website { get; set; }

        public FinancialDetails FinancialInfo { get; set; }

        public class FinancialDetails
        {
            public double AvailableBalance { get; set; }
            public double LastCreditedAmount { get; set; }

            [XmlIgnore]
            public DateTime LastCreditDoneAt { get; set; }
            // Proxied property
            [XmlElement(ElementName = "LastCreditDoneAt")]
            public long RawLastCreditDoneAt
            {
                get { return LastCreditDoneAt.ToJavaTimestamp(); }
                set { LastCreditDoneAt = value.ToDateTime(); }
            }

            public string LastTransactionProcessedAt { get; set; }

            [XmlIgnore]
            public DateTime BalanceUpdatedAt { get; set; }
            // Proxied property
            [XmlElement(ElementName = "BalanceUpdatedAt")]
            public long RawBalanceUpdatedAt
            {
                get { return BalanceUpdatedAt.ToJavaTimestamp(); }
                set { BalanceUpdatedAt = value.ToDateTime(); }
            }
        }

    }
}