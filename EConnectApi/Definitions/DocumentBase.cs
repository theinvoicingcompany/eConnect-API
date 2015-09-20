using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    /// <summary>
    /// Share document class for all document types
    /// </summary>
    public class DocumentBase : IEquatable<DocumentBase>
    {
        public string ExternalId { get; set; }

        public string DocumentId { get; set; }
       
        public string DocumentTemplateId { get; set; }
        public string DocumentTemplateName { get; set; }
 
        public string MasterTemplateId { get; set; }
        public string MasterTemplateName { get; set; }

        public string StandardTemplateId { get; set; }
        public string StandardTemplateName { get; set; }
        
        public string LatestStatus { get; set; }
        public string LatestStatusInfo { get; set; }
        public string LatestStatusCode { get; set; } // no int, because it can contains text
        
        public string DocumentViewerId { get; set; }
        public string DocumentViewerName { get; set; }

        [XmlIgnore]
        public DateTime ModifiedDateTime { get; set; }

        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }

        #region Proxied properties
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

        public bool Equals(DocumentBase other)
        {
            if (other == null)
                return false;

            return ExternalId == other.ExternalId &&
                   DocumentId == other.DocumentId &&
                   DocumentTemplateId == other.DocumentTemplateId &&
                   DocumentTemplateName == other.DocumentTemplateName &&
                   MasterTemplateId == other.MasterTemplateId &&
                   MasterTemplateName == other.MasterTemplateName &&
                   StandardTemplateId == other.StandardTemplateId &&
                   StandardTemplateName == other.StandardTemplateName &&
                   LatestStatus == other.LatestStatus &&
                   LatestStatusInfo == other.LatestStatusInfo &&
                   LatestStatusCode == other.LatestStatusCode &&
                   DocumentViewerId == other.DocumentViewerId &&
                   DocumentViewerName == other.DocumentViewerName &&
                   //ModifiedDateTime == other.ModifiedDateTime &&
                   CreatedDateTime == other.CreatedDateTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DocumentBase);
        }
        #endregion
    }
}