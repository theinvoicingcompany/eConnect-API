using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    /// <summary>
    /// Used by GetDocument
    /// </summary>
    public class EConnectDocumentDetails : EConnectDocument, IDocumentDetails, IEquatable<EConnectDocumentDetails>
    {
        public XElement Payload { get; set; }

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                return _possibleStatuses ?? (_possibleStatuses = new Statuses(RawPossibleConsignmentStatuses, LatestStatusCode));
            }
        }

        [XmlIgnore]
        public Uri UserImageUrl { get; set; }
        public string CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }

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

        #region equality
        public bool Equals(EConnectDocumentDetails other)
        {
            if (other == null)
                return false;

            if (!(this as EConnectDocument).Equals(other))
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
            return Equals(obj as EConnectDocumentDetails);
        }
        #endregion
    }
}