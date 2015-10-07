using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class DocumentEConnect : DocumentMetaData, IEquatable<DocumentEConnect>
    {
        public string DocumentName { get; set; }
        public string Description { get; set; }

        public string TemplateSource { get; set; }
        public string FolderId { get; set; }
        public string FolderName { get; set; }

        public string IsDocumentSent { get; set; } // Sometimes contains values like: 'UA000000219000001,UA000000219000015' so is not always a valid Boolean value.

        public string AccountId { get; set; }
        public string AccountName { get; set; }

        public string OwnerUserId { get; set; }
        public string OwnerUserName { get; set; }

        public string ModifiedByUserName { get; set; }
        public string ModifiedByUserId { get; set; }

        [XmlIgnore]
        public Uri DocumentViewerImageUrl { get; set; }

        [XmlIgnore]
        public Uri DocExUri { get; set; }

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

        #endregion

        #region equality
        public bool Equals(DocumentEConnect other)
        {
            if (other == null)
                return false;

            if (!(this as DocumentMetaData).Equals(other))
                return false;

            return DocumentName == other.DocumentName &&
                   Description == other.Description &&
                   TemplateSource == other.TemplateSource &&
                   FolderId == other.FolderId &&
                   FolderName == other.FolderName &&
                   IsDocumentSent == other.IsDocumentSent &&
                   AccountId == other.AccountId &&
                   AccountName == other.AccountName &&
                   OwnerUserId == other.OwnerUserId &&
                   OwnerUserName == other.OwnerUserName &&
                   ModifiedByUserName == other.ModifiedByUserName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DocumentEConnect);
        }
        #endregion
    }
}