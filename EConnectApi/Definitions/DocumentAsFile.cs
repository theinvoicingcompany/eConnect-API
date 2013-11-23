using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    public class DocumentAsFile
    {
        [XmlAttribute(AttributeName = "fileName")]
        public string FileName { get; set; }
        /// <summary>
        /// Base 64 encoded content
        /// </summary>
        [XmlText]
        public string FileContents { get; set; }
    }
}