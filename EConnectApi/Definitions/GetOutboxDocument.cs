using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocument", ElementName = "GetOutboxDocument", IsNullable = false)]
    public class GetOutboxDocument : GetDocumentBase, IOutboxDocumentRequest
    {

    }
}