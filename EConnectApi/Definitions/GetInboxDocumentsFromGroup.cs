using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/1.0", ElementName = "GetInboxDocuments", IsNullable = false)]
    public class GetInboxDocumentsFromGroup : GetDocumentsFromGroupBase, IInboxDocumentsRequest
    {
        // Nothing extra
    }
}