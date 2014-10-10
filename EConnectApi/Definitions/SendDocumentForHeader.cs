using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlRoot("SenderId")]
    [XmlType(AnonymousType = true, Namespace = "")]
    public class SendDocumentForHeader
    {
        [XmlText]
        public string SenderId { get; set; }
    }
}