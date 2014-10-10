using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class SendDocumentBaseResponse
    {
        public string ConsignmentId { get; set; }
        public string ExternalId { get; set; }
    }

    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SendDocumentResponse : SendDocumentBaseResponse
    {
    }

    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SendDocumentForResponse : SendDocumentBaseResponse
    {
    }
}
