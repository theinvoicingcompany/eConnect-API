using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class SetDocumentStatusResponse : GetDocument
    {
        [XmlElement(ElementName = "dnm")]
        public string DocumentName { get; set; }

        [XmlElement(ElementName = "dsc")]
        public string Description { get; set; }
    
        [XmlIgnore]
        public DateTime ReverseDateTime { get; set; }

        #region Proxied properties
        [XmlElement(ElementName = "ReverseTimeStamp")]
        public long RawReverseDateTime
        {
            get { return ReverseDateTime.ToJavaTimestamp(); }
            set { ReverseDateTime = value.ToDateTime(); }
        }

        #endregion
    }
}