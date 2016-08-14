using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocumentstatus", ElementName = "GetOutboxDocumentStatus", IsNullable = false)]
    public class GetOutboxDocumentStatus
    {
        public string ConsignmentId { get; set; }
        [XmlIgnore]
        public string ExternalId { get { return ConsignmentId; } set { ConsignmentId = value; } }
    }
}