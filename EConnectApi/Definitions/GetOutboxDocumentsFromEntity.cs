using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/1.0", ElementName = "GetOutboxDocument", IsNullable = false)]
    public class GetOutboxDocumentsFromEntity : GetDocumentsFromEntityBase, IOutboxDocumentsRequest
    {
    }
}