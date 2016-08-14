using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/setinboxdocumentstatus", ElementName = "SetInboxDocumentStatus", IsNullable = false)]
    public class SetInboxDocumentStatus : SetDocumentStatusBase
    {
        public string ConsignmentId { get; set; }
        [XmlIgnore]
        public string ExternalId { get { return ConsignmentId; } set { ConsignmentId = value; } }
    }
}