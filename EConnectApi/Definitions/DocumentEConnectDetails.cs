using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class DocumentEConnectDetails : DocumentEConnect, IDocumentDetails, IEquatable<DocumentEConnectDetails>
    {
        public DocumentEConnectDetails() : this(null)
        {
            
        }

        private DocumentDetails _details;
        public DocumentEConnectDetails(DocumentDetails details = null)
        {
            _details = details ?? new DocumentDetails();
        }

        public XElement Payload
        {
            get
            {
                return _details.Payload;
            }
            set
            {
                _details.Payload = value;
            }
        }

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                return _details.PossibleStatuses;
            }
        }

        [XmlIgnore]
        public Uri UserImageUrl { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }

        #region Proxied properties

        [XmlElement(ElementName = "PossibleConsignmentStatuses")]
        public string RawPossibleConsignmentStatuses
        {
            get { return _details.RawPossibleConsignmentStatuses; }
            set { _details.RawPossibleConsignmentStatuses = value; }
        }

        [XmlElement(ElementName = "PossibleDocumentStatuses")]
        public string RawPossibleDocumentStatuses
        {
            get { return _details.RawPossibleDocumentStatuses; }
            set { _details.RawPossibleDocumentStatuses = value; }
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

        #region equality
        public bool Equals(DocumentEConnectDetails other)
        {
            if (other == null)
                return false;

            if (!(this as DocumentEConnect).Equals(other))
                return false;

            return Payload == other.Payload &&
                   RawPossibleConsignmentStatuses == other.RawPossibleConsignmentStatuses &&
                   RawPossibleDocumentStatuses == other.RawPossibleDocumentStatuses &&
                   RawUserImageUrl == other.RawUserImageUrl &&
                   CreatorUserId == other.CreatorUserId &&
                   CreatorUserName == other.CreatorUserName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DocumentEConnectDetails);
        }
        #endregion
    }
}