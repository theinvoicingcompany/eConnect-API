using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/setdocumentstatus", ElementName = "SetDocumentStatus", IsNullable = false)]
    public class SetDocumentStatus : SetDocumentStatusBase
    {
        public string DocumentId { get; set; }
    }
}
