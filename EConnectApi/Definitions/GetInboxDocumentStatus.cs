using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/1.0", ElementName = "GetInboxDocumentStatus", IsNullable = false)]
    public class GetInboxDocumentStatus 
    {
        public string ConsignmentId { get; set; }
    }
}