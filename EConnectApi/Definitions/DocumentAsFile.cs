using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
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