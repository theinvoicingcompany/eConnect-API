using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocuments", ElementName = "GetDocuments", IsNullable = false)]
    public class GetDocumentsOfAnUser : GetDocumentsBase, IDocumentsRequest
    {
        // Nothing extra
    }
}