using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetIntegrationRequestsResponse : PageAbleResponse
    {
        public class IntegrationRequestDetails
        {
            public string SenderAccountId { get; set; }

            public string SenderAccountName { get; set; }

            public string AppId { get; set; }

            public string AppName { get; set; }

            [XmlIgnore]
            public DateTime RequestedDateTime { get; set; }

            // Proxied property
            [XmlElement(ElementName = "RequestedDate")]
            public long RawRequestedDateTime
            {
                get
                {
                    return RequestedDateTime.ToJavaTimestamp();
                }
                set
                {
                    RequestedDateTime = value.ToDateTime();
                }
            }

            public string RecipientCompanyEntityId { get; set; }

            [XmlIgnore]
            public string RecipientCompanyId
            {
                get
                {
                    return RecipientCompanyEntityId;
                }
                set
                {
                    RecipientCompanyEntityId = value;
                }
            }


            [XmlElement(ElementName = "RecipientCompanyKVK")]
            public string RecipientCompanyKvk { get; set; }

            public string RecipientCompanyName { get; set; }

            public string RecipientEmail { get; set; }

            public string RequestTrackingId { get; set; }

            public string IntegrationId { get; set; }

            public bool PayByRequester { get; set; }

            public string RequestorAccountId { get; set; }

            public IntegrationRequestStatus Status { get; set; }

            public string SenderUserId { get; set; }

            public string SenderUserName { get; set; }
        }

        [XmlElement(ElementName = "tuple")]
        public IntegrationRequestDetails[] IntegrationRequests { get; set; }
    }
}