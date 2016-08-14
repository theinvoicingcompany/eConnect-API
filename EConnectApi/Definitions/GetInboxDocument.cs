using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocument", ElementName = "GetInboxDocument", IsNullable = false)]
    public class GetInboxDocument : GetDocumentBase, IInboxDocumentRequest
    {

    }
}
