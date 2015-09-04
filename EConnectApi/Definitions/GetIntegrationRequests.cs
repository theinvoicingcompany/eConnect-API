using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetIntegrationRequests : PageAble
    {
        public class GetIntegrationRequestsFilters
        {
            public bool ShouldSerializeStatus() { return Status.HasValue; }
            public IntegrationRequestStatus? Status { get; set; }

            public string SentBy { get; set; }

            public string SentFor { get; set; }

            public string PayByRequester { get; set; }

            public string AppId { get; set; }

            public string TrackingId { get; set; }

        }

        [XmlElement(ElementName = "filters")]
        public GetIntegrationRequestsFilters Filters { get; set; }
    }

    public enum IntegrationRequestStatus
    {
        Accepted,
        Pending,
        Rejected,
        Withdrawn,
        Cancelled
    }
}