using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "filters", IsNullable = false)]
    public class GetDocumentsFiltersBase
    {
        // XmlSerializer supports the ShouldSerialize{Foo}() pattern,
        public bool ShouldSerializeIsRead() { return IsRead.HasValue; }
        [XmlElement(ElementName = "IsRead")]
        public bool? IsRead { get; set; }

        public bool ShouldSerializeIsTask() { return IsTask.HasValue; }
        public int? IsTask { get; set; }

        [XmlElement(ElementName = "CreatedDateTime")]
        public TimeSpanFilter CreatedDateTime { get; set; }
        [XmlElement(ElementName = "ModifiedDateTime")]
        public TimeSpanFilter ModifiedDateTime { get; set; }


        public string DocumentId { get; set; }
        public string ExternalId { get; set; }
        public string ConsignmentId { get; set; }
        public string ConsignmentName { get; set; }
        public string Subject { get; set; }
        //public string Type { get; set; } // Not usefull, because we have GetInbox, GetOutbox and GetDoc

        public string SenderAccountId { get; set; }
        public string SenderAccountName { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public string SenderEntityId { get; set; }
        public string SenderEntityName { get; set; }
        public string LatestStatus { get; set; }
        public string LatestStatusInfo { get; set; }
        public string LatestStatusCode { get; set; } // no int, because it can contains text

        public string MasterTemplateId { get; set; }
        public string MasterTemplateName { get; set; }

        public string ReceiverEntityId { get; set; }
        public string ReceiverEntityName { get; set; }

        public string StandardTemplateId { get; set; }
        public string StandardTemplateName { get; set; }

        public string DocumentViewerId { get; set; }
        public string DocumentViewerName { get; set; }

        public string TrackingMessage { get; set; }

        public string DocumentTemplateId { get; set; }
        public string DocumentTemplateName { get; set; }
        public string TemplateSchemaId { get; set; }
    }
}