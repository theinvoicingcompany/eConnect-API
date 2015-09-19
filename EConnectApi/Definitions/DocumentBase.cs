using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    public class DocumentDetails : Document
    {
        public string Subject { get; set; }
        public XElement Payload { get; set; }

        public string CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }
        [XmlIgnore]
        public Uri UserImageUrl { get; set; }

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                return _possibleStatuses ?? (_possibleStatuses = new Statuses(RawPossibleConsignmentStatuses, LatestStatusCode));
            }
        }
        
        #region Proxied properties

        private string _rawPossibleConsignmentStatuses;
        private Statuses _possibleStatuses;

        [XmlElement(ElementName = "PossibleConsignmentStatuses")]
        public string RawPossibleConsignmentStatuses
        {
            get { return _rawPossibleConsignmentStatuses; }
            set
            {

                _rawPossibleConsignmentStatuses = value;
                _possibleStatuses = null;
            }
        }

        [XmlElement(ElementName = "PossibleDocumentStatuses")]
        public string RawPossibleDocumentStatuses
        {
            get { return RawPossibleConsignmentStatuses; }
            set { RawPossibleConsignmentStatuses = value; }
        }

        [XmlElement(ElementName = "UserImageUrl")]
        public string RawUserImageUrl
        {
            get { return UserImageUrl == null ? null : UserImageUrl.ToString(); }
            set
            {
                try
                {
                    UserImageUrl = value == null ? null : new Uri(value);
                }
                catch
                {
                    UserImageUrl = null;
                }
            }
        }

        [XmlElement(ElementName = "tsrc")]
        public string VirtualTemplateSource
        {
            get
            {
                return TemplateSource;
            }
            set
            {
                TemplateSource = value;
            }
        }


        #endregion
    }

    public class Document : IEquatable<Document>
    {
        public string ExternalId { get; set; }

        public string DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }

        public string DocumentTemplateId { get; set; }
        public string DocumentTemplateName { get; set; }
        public string StandardTemplateId { get; set; }
        public string StandardTemplateName { get; set; }
        public string MasterTemplateId { get; set; }
        public string MasterTemplateName { get; set; }
        public string TemplateSource { get; set; }
        public string FolderId { get; set; }
        public string FolderName { get; set; }

        public string LatestStatus { get; set; }
        public string LatestStatusInfo { get; set; }
        public string LatestStatusCode { get; set; } // no int, because it can contains text
        public string IsDocumentSent { get; set; } // Sometimes contains values like: 'UA000000219000001,UA000000219000015' so is not always a valid Boolean value.

        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public string OwnerUserId { get; set; }
        public string OwnerUserName { get; set; }

        public string ModifiedByUserName { get; set; }
        public string ModifiedByUserId { get; set; }

        public string DocumentViewerId { get; set; }
        public string DocumentViewerName { get; set; }
        [XmlIgnore]
        public Uri DocumentViewerImageUrl { get; set; }

        [XmlIgnore]
        public Uri DocExUri { get; set; }

        [XmlIgnore]
        public DateTime ModifiedDateTime { get; set; }

        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }

        #region Proxied properties
        [XmlElement(ElementName = "DocExURI")]
        public string RawDocEx
        {
            get { return DocExUri == null ? null : DocExUri.ToString(); }
            set
            {
                try
                {
                    DocExUri = value == null ? null : new Uri(value);
                }
                catch
                {
                    DocExUri = null;
                }
            }
        }


        [XmlElement(ElementName = "DocumentViewerImageURL")]
        public string RawDocumentViewerImageUrl
        {
            get { return DocumentViewerImageUrl == null ? null : DocumentViewerImageUrl.ToString(); }
            set
            {
                try
                {
                    DocumentViewerImageUrl = value == null ? null : new Uri(value);
                }
                catch
                {
                    DocumentViewerImageUrl = null;
                }
            }
        }

        [XmlElement(ElementName = "ModifiedDateTime")]
        public long RawModifiedDateTime
        {
            get { return ModifiedDateTime.ToJavaTimestamp(); }
            set { ModifiedDateTime = value.ToDateTime(); }
        }

        [XmlElement(ElementName = "CreatedDateTime")]
        public long RawCreatedDateTime
        {
            get { return CreatedDateTime.ToJavaTimestamp(); }
            set { CreatedDateTime = value.ToDateTime(); }
        }
        #endregion

        #region equality

        public bool Equals(Document other)
        {
            if (other == null)
                return false;

            return ExternalId == other.ExternalId &&
                   DocumentId == other.DocumentId &&
                   DocumentName == other.DocumentName &&
                   Description == other.Description &&
                   DocumentTemplateId == other.DocumentTemplateId &&
                   DocumentTemplateName == other.DocumentTemplateName &&
                   MasterTemplateId == other.MasterTemplateId &&
                   MasterTemplateName == other.MasterTemplateName &&
                   TemplateSource == other.TemplateSource &&
                   FolderId == other.FolderId &&
                   FolderName == other.FolderName &&
                   LatestStatus == other.LatestStatus &&
                   LatestStatusInfo == other.LatestStatusInfo &&
                   LatestStatusCode == other.LatestStatusCode &&
                   IsDocumentSent == other.IsDocumentSent &&
                   AccountId == other.AccountId &&
                   AccountName == other.AccountName &&
                   OwnerUserId == other.OwnerUserId &&
                   OwnerUserName == other.OwnerUserName &&
                   ModifiedByUserName == other.ModifiedByUserName &&
                   //ModifiedDateTime == other.ModifiedDateTime &&
                   CreatedDateTime == other.CreatedDateTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Document);
        }
        #endregion
    }


    public class DocumentBase : DocumentDetails
    {
        public string ConsignmentId { get; set; }
        public string ConsignmentName { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public string SenderAccountId { get; set; }
        public string SenderAccountName { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public string SenderEntityId { get; set; }
        public string SenderEntityName { get; set; }






        public string TrackingMessage { get; set; }




        public bool IsRead { get; set; }
        // TODO: Check IsTask is not bool?
        public int IsTask { get; set; }


        public string ReceiverEntityId { get; set; }
        public string ReceiverEntityName { get; set; }


        public string TemplateSchemaId { get; set; }

        //[XmlTextAttribute()]
        //[XmlElement(ElementName = "text")]
        //public string[] Text { get; set; }

    }
}