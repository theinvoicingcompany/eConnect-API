using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SendDocumentResponse
    {
        public string ConsignmentId { get; set; }
        public string ExternalId { get; set; }
    }
}
