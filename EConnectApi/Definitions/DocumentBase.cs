using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    public class DocumentBase
    {
        [XmlElement(ElementName = "rowkey")]
        public string Rowkey { get; set; }

        public string DocumentId { get; set; } // doc
        public string ExternalId { get; set; } // doc
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

        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }
        // Proxied property
        [XmlElement(ElementName = "CreatedDateTime")]
        public long RawCreatedDateTime
        {
            get { return CreatedDateTime.ToJavaTimestamp(); }
            set { CreatedDateTime = value.ToDateTime(); }
        }


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

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                if (_possibleStatuses == null)
                    _possibleStatuses = new Statuses(RawPossibleConsignmentStatuses, LatestStatusCode);
                return _possibleStatuses;
            }
        }

        public bool IsRead { get; set; }
        // TODO: Check IsTask is not bool?
        public int IsTask { get; set; }
        public string LatestStatus { get; set; } // doc
        public string LatestStatusInfo { get; set; } // doc
        public string LatestStatusCode { get; set; } // doc, no int, because it can contains text

        public string MasterTemplateId { get; set; }
        public string MasterTemplateName { get; set; }

        public string ReceiverEntityId { get; set; }
        public string ReceiverEntityName { get; set; }

        public string StandardTemplateId { get; set; } // doc   
        public string StandardTemplateName { get; set; } // doc

        public string DocumentViewerId { get; set; } // doc
        public string DocumentViewerName { get; set; } // doc

        public string TrackingMessage { get; set; }

        public string DocumentTemplateId { get; set; } // doc 
        public string DocumentTemplateName { get; set; } // doc
        public string TemplateSchemaId { get; set; }
        
        //[XmlTextAttribute()]
        //[XmlElement(ElementName = "text")]
        //public string[] Text { get; set; }

        /// <summary>
        /// UBL
        /// </summary>
        public XElement Payload { get; set; }



        #region NEW_IN_DOC
        public string AccountId { get; set; }

        public string AccountName { get; set; }

        public string DocumentName { get; set; }

        public string Description { get; set; }

        [XmlElement(ElementName = "DocExURI")]
        public string RawDocEx
        {
            get { return DocEx == null ? null : DocEx.ToString(); }
            set
            {
                try
                {
                    DocEx = value == null ? null : new Uri(value);
                }
                catch
                {
                    DocEx = null;
                }
            }
        }

        [XmlIgnore]
        public Uri DocEx { get; set; }

        public string OwnerUserId { get; set; }
        public string OwnerUserName { get; set; }

        public string FolderId { get; set; }

        public string FolderName { get; set; }

        public string IsDocumentSent { get; set; } // No bool


        [XmlIgnore]
        public DateTime ModifiedDateTime { get; set; }
        // Proxied property
        [XmlElement(ElementName = "ModifiedDateTime")]
        public long RawModifiedDateTime
        {
            get { return ModifiedDateTime.ToJavaTimestamp(); }
            set { ModifiedDateTime = value.ToDateTime(); }
        }

        public string ModifiedByUserName { get; set; }
        public string ModifiedByUserId { get; set; }


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

        [XmlIgnore]
        public Uri DocumentViewerImageUrl { get; set; }

        public string TemplateSource { get; set; }

        #endregion

    }
}