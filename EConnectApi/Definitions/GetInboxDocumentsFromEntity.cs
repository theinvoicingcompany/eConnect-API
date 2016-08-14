using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocuments", ElementName = "GetInboxDocuments", IsNullable = false)]
    public class GetInboxDocumentsFromEntity : GetDocumentsFromEntityBase, IInboxDocumentsRequest
    {
        // Nothing extra
    }
}