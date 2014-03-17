using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    public class TimeSpanFilter
    {
        [XmlIgnore]
        public DateTime? From { get; set; }
        // Proxied property
        [XmlElement(ElementName = "from")]
        public long RawFrom
        {
            get { return From.GetValueOrDefault().ToJavaTimestamp(); }
            set { From = value.ToDateTime(); }
        }

        // XmlSerializer supports the ShouldSerialize{Foo}() pattern,
        public bool ShouldSerializeRawFrom() { return From.HasValue; }

        [XmlIgnore]
        public DateTime? To { get; set; }
        // Proxied property
        [XmlElement(ElementName = "to")]
        public long RawTo
        {
            get { return To.GetValueOrDefault().ToJavaTimestamp(); }
            set { To = value.ToDateTime(); }
        }

        // XmlSerializer supports the ShouldSerialize{Foo}() pattern,
        public bool ShouldSerializeRawTo() { return To.HasValue; }
    }
}