using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class TimeSpanFilter
    {
        [XmlElement(ElementName = "form")]
        public long From { get; set; }
        [XmlElement(ElementName = "to")]
        public long  To { get; set; }
    }
}