using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class DocumentSharedExtensionsDetails : DocumentSharedExtensions, IDocumentDetails, IEquatable<DocumentSharedExtensionsDetails>
    {
        public string reml { get; set; }
        public XElement Payload { get; set; }

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
        #endregion

        #region equality
        public bool Equals(DocumentSharedExtensionsDetails other)
        {
            if (other == null)
                return false;

            if (!(this as DocumentSharedExtensions).Equals(other))
                return false;

            return Payload == other.Payload &&
                   RawPossibleConsignmentStatuses == other.RawPossibleConsignmentStatuses &&
                   RawPossibleDocumentStatuses == other.RawPossibleDocumentStatuses;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DocumentSharedExtensionsDetails);
        }
        #endregion
    }
}