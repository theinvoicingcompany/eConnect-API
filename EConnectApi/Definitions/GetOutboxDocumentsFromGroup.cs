using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocuments", ElementName = "GetOutboxDocuments", IsNullable = false)]
    public class GetOutboxDocumentsFromGroup : GetDocumentsFromGroupBase, IOutboxDocumentsRequest
    {

    }
}