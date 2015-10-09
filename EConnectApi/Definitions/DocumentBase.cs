using System;
using System.CodeDom;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class DocumentBase
    {
        [XmlIgnore]
        public DocumentMetaData Document
        {
            get
            {
                return Details;
            }
        }

        [XmlIgnore]
        public DocumentDetails Details
        {
            get;
            private set;
        }

        [XmlIgnore]
        public DocumentInOrOutboxMetaData DocumentInbox
        {
            get
            {
                return Type == "Inbox" ? Details : null;
            }
        }

        [XmlIgnore]
        public DocumentInOrOutboxMetaData DocumentOutbox
        {
            get
            {
                return Type == "Outbox" ? Details : null;
            }
        }
        
        [XmlIgnore]
        public DocumentEConnect DocumentEConnect
        {
            get
            {
                return string.IsNullOrEmpty(Type) ? _ecDoc : null;
            }
        }

        [XmlIgnore]
        public DocumentEConnectDetails DocumentEConnectDetails
        {
            get
            {
                return string.IsNullOrEmpty(Type) ? _ecDetails : null;
            }
        }

        private readonly DocumentEConnect _ecDoc;
        private readonly DocumentEConnectDetails _ecDetails;

        public DocumentBase()
        {
            Details = new DocumentDetails();
            _ecDoc = new DocumentEConnect();
            _ecDetails = new DocumentEConnectDetails(Details);
        }

        #region backwards compatibility

        #region doc only
        public string DocumentName
        {
            get
            {
                return _ecDoc.DocumentName;
            }
            set
            {
                _ecDoc.DocumentName = value;
            }
        }
        public string Description
        {
            get
            {
                return _ecDoc.Description;
            }
            set
            {
                _ecDoc.Description = value;
            }
        }
        public string TemplateSource
        {
            get
            {
                return _ecDoc.TemplateSource;
            }
            set
            {
                _ecDoc.TemplateSource = value;
            }
        }
        public string FolderId
        {
            get
            {
                return _ecDoc.FolderId;
            }
            set
            {
                _ecDoc.FolderId = value;
            }
        }
        public string FolderName
        {
            get
            {
                return _ecDoc.FolderName;
            }
            set
            {
                _ecDoc.FolderName = value;
            }
        }
        public string IsDocumentSent
        {
            get
            {
                return _ecDoc.IsDocumentSent;
            }
            set
            {
                _ecDoc.IsDocumentSent = value;
            }
        }
        public string AccountId
        {
            get
            {
                return _ecDoc.AccountId;
            }
            set
            {
                _ecDoc.AccountId = value;
            }
        }
        public string AccountName
        {
            get
            {
                return _ecDoc.AccountName;
            }
            set
            {
                _ecDoc.AccountName = value;
            }
        }
        public string OwnerUserId
        {
            get
            {
                return _ecDoc.OwnerUserId;
            }
            set
            {
                _ecDoc.OwnerUserId = value;
            }
        }
        public string OwnerUserName
        {
            get
            {
                return _ecDoc.OwnerUserName;
            }
            set
            {
                _ecDoc.OwnerUserName = value;
            }
        }
        public string ModifiedByUserName
        {
            get
            {
                return _ecDoc.ModifiedByUserName;
            }
            set
            {
                _ecDoc.ModifiedByUserName = value;
            }
        }
        public string ModifiedByUserId
        {
            get
            {
                return _ecDoc.ModifiedByUserId;
            }
            set
            {
                _ecDoc.ModifiedByUserId = value;
            }
        }
        [XmlIgnore]
        public Uri DocExUri
        {
            get
            {
                return _ecDoc.DocExUri;
            }
            set
            {
                _ecDoc.DocExUri = value;
            }
        }
        [XmlElement(ElementName = "DocExURI")]
        public string RawDocEx
        {
            get
            {
                return _ecDoc.RawDocEx;
            }
            set
            {
                _ecDoc.RawDocEx = value;
            }
        }
        [XmlIgnore]
        public Uri DocumentViewerImageUrl
        {
            get
            {
                return _ecDoc.DocumentViewerImageUrl;
            }
            set
            {
                _ecDoc.DocumentViewerImageUrl = value;
            }
        }
        [XmlElement(ElementName = "DocumentViewerImageURL")]
        public string RawDocumentViewerImageUrl
        {
            get
            {
                return _ecDoc.RawDocumentViewerImageUrl;
            }
            set
            {
                _ecDoc.RawDocumentViewerImageUrl = value;
            }
        }
        #endregion

        #region doc-details only
        [XmlIgnore]
        public Uri UserImageUrl
        {
            get
            {
                return _ecDetails.UserImageUrl;
            }
            set
            {
                _ecDetails.UserImageUrl = value;
            }
        }
        public string CreatorUserId
        {
            get
            {
                return _ecDetails.CreatorUserId;
            }
            set
            {
                _ecDetails.CreatorUserId = value;
            }
        }
        public string CreatorUserName
        {
            get
            {
                return _ecDetails.CreatorUserName;
            }
            set
            {
                _ecDetails.CreatorUserName = value;
            }
        }


        [XmlElement(ElementName = "UserImageUrl")]
        public string RawUserImageUrl
        {
            get
            {
                return _ecDetails.RawUserImageUrl;
            }
            set
            {
                _ecDetails.RawUserImageUrl = value;
            }
        }

        [XmlElement(ElementName = "tsrc")]
        public string VirtualTemplateSource
        {
            get
            {
                return _ecDetails.TemplateSource;
            }
            set
            {
                _ecDetails.TemplateSource = value;
            }
        }
        #endregion

        #region Shared between inbox, outbox and document

        public string ExternalId
        {
            get
            {
                return Details.ExternalId;
            }
            set
            {
                Details.ExternalId = value;
            }
        }

        public string DocumentId
        {
            get
            {
                return Details.DocumentId;
            }
            set
            {
                Details.DocumentId = value;
            }
        }

        public string DocumentTemplateId
        {
            get
            {
                return Details.DocumentTemplateId;
            }
            set
            {
                Details.DocumentTemplateId = value;
            }
        }

        public string DocumentTemplateName
        {
            get
            {
                return Details.DocumentTemplateName;
            }
            set
            {
                Details.DocumentTemplateName = value;
            }
        }

        public string MasterTemplateId
        {
            get
            {
                return Details.MasterTemplateId;
            }
            set
            {
                Details.MasterTemplateId = value;
            }
        }
        public string MasterTemplateName
        {
            get
            {
                return Details.MasterTemplateName;
            }
            set
            {
                Details.MasterTemplateName = value;
            }
        }

        public string StandardTemplateId
        {
            get
            {
                return Details.StandardTemplateId;
            }
            set
            {
                Details.StandardTemplateId = value;
            }
        }
        public string StandardTemplateName
        {
            get
            {
                return Details.StandardTemplateName;
            }
            set
            {
                Details.StandardTemplateName = value;
            }
        }

        public string LatestStatus
        {
            get
            {
                return Details.LatestStatus;
            }
            set
            {
                Details.LatestStatus = value;
            }
        }
        public string LatestStatusInfo
        {
            get
            {
                return Details.LatestStatusInfo;
            }
            set
            {
                Details.LatestStatusInfo = value;
            }
        }
        public string LatestStatusCode
        {
            get
            {
                return Details.LatestStatusCode;
            }
            set
            {
                Details.LatestStatusCode = value;
            }
        }

        public string DocumentViewerId
        {
            get
            {
                return Details.DocumentViewerId;
            }
            set
            {
                Details.DocumentViewerId = value;
            }
        }
        public string DocumentViewerName
        {
            get
            {
                return Details.DocumentViewerName;
            }
            set
            {
                Details.DocumentViewerName = value;
            }
        }

        [XmlIgnore]
        public DateTime ModifiedDateTime
        {
            get
            {
                return Details.ModifiedDateTime;
            }
            set
            {
                Details.ModifiedDateTime = value;
            }
        }

        [XmlIgnore]
        public DateTime CreatedDateTime
        {
            get
            {
                return Details.CreatedDateTime;
            }
            set
            {
                Details.CreatedDateTime = value;
            }
        }

        #region Proxied properties
        [XmlElement(ElementName = "ModifiedDateTime")]
        public long RawModifiedDateTime
        {
            get
            {
                return Details.RawModifiedDateTime;
            }
            set
            {
                Details.RawModifiedDateTime = value;
            }
        }

        [XmlElement(ElementName = "CreatedDateTime")]
        public long RawCreatedDateTime
        {
            get
            {
                return Details.RawCreatedDateTime;
            }
            set
            {
                Details.RawCreatedDateTime = value;
            }
        }
        #endregion

        #endregion

        #region Shared between inbox and outbox

        public string ConsignmentId
        {
            get { return Details.ConsignmentId; }
            set { Details.ConsignmentId = value; }
        }

        public string ConsignmentName
        {
            get
            {
                return Details.ConsignmentName;
            }
            set
            {
                Details.ConsignmentName = value;
            }
        }

        public string Subject
        {
            get
            {
                return Details.Subject;
            }
            set
            {
                Details.Subject = value;
            }
        }

        public string Type
        {
            get
            {
                return Details.Type;
            }
            set
            {
                Details.Type = value;
            }
        }

        public string SenderId
        {
            get
            {
                return Details.SenderId;
            }
            set
            {
                Details.SenderId = value;
            }
        }

        public string SenderAccountId
        {
            get
            {
                return Details.SenderAccountId;
            }
            set
            {
                Details.SenderAccountId = value;
            }
        }

        public string SenderAccountName
        {
            get
            {
                return Details.SenderAccountName;
            }
            set
            {
                Details.SenderAccountName = value;
            }
        }

        public string SenderUserId
        {
            get
            {
                return Details.SenderUserId;
            }
            set
            {
                Details.SenderUserId = value;
            }
        }

        public string SenderUserName
        {
            get
            {
                return Details.SenderUserName;
            }
            set
            {
                Details.SenderUserName = value;
            }
        }

        public string SenderEntityId
        {
            get
            {
                return Details.SenderEntityId;
            }
            set
            {
                Details.SenderEntityId = value;
            }
        }

        public string SenderEntityName
        {
            get
            {
                return Details.SenderEntityName;
            }
            set
            {
                Details.SenderEntityName = value;
            }
        }

        public string OriginalSender
        {
            get
            {
                return Details.OriginalSender;
            }
            set
            {
                Details.OriginalSender = value;
            }
        }

        public string DocumentAsFile
        {
            get
            {
                return Details.ConsignmentId;
            }
            set
            {
                Details.DocumentAsFile = value;
            }
        }

        public string ReceiverEntityId
        {
            get
            {
                return Details.ReceiverEntityId;
            }
            set
            {
                Details.ReceiverEntityId = value;
            }
        }

        public string ReceiverEntityName
        {
            get
            {
                return Details.ReceiverEntityName;
            }
            set
            {
                Details.ReceiverEntityName = value;
            }
        }

        public string RecipientEmailId
        {
            get
            {
                return Details.RecipientEmailId;
            }
            set
            {
                Details.RecipientEmailId = value;
            }
        }

        [XmlElement(ElementName = "TrustedReceiver")]
        public bool IsTrustedReceiver
        {
            get
            {
                return Details.IsTrustedReceiver;
            }
            set
            {
                Details.IsTrustedReceiver = value;
            }
        }

        public string TrackingMessage
        {
            get
            {
                return Details.TrackingMessage;
            }
            set
            {
                Details.TrackingMessage = value;
            }
        }

        public bool IsRead
        {
            get
            {
                return Details.IsRead;
            }
            set
            {
                Details.IsRead = value;
            }
        }

        public int IsTask
        {
            get
            {
                return Details.IsTask;
            }
            set
            {
                Details.IsTask = value;
            }
        }

        #endregion

        #region Shared between doc-details, inbox-details, outbox-details

        public XElement Payload
        {
            get
            {
                return Details.Payload;
            }
            set
            {
                Details.Payload = value;
            }
        }

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                return Details.PossibleStatuses;
            }
        }

        [XmlElement(ElementName = "PossibleConsignmentStatuses")]
        public string RawPossibleConsignmentStatuses
        {
            get { return Details.RawPossibleConsignmentStatuses; }
            set { Details.RawPossibleConsignmentStatuses = value; }
        }

        [XmlElement(ElementName = "PossibleDocumentStatuses")]
        public string RawPossibleDocumentStatuses
        {
            get { return Details.RawPossibleDocumentStatuses; }
            set { Details.RawPossibleDocumentStatuses = value; }
        }

        #endregion

        #endregion backwards compatibility
    }
}