using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class SetDocumentStatusResponse
    {
        public string DocumentId { get; set; }
       
        [XmlElement(ElementName = "dnm")]
        public string DocumentName { get; set; }

        [XmlElement(ElementName = "dsc")]
        public string Description { get; set; }

        public string AppEventResponses { get; set; }
    
        [XmlIgnore]
        public DateTime DateTime { get; set; }

        #region Proxied properties
        [XmlElement(ElementName = "ReverseTimeStamp")]
        public long RawReverseDateTime
        {
            get { return DateTime.ToReverseTimestamp(); }
            set { DateTime = value.ToDateTimeFromReverseTimestamp(); }
        }

        #endregion
    }
}