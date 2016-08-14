using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocumentstatus", ElementName = "GetOutboxDocumentStatusResponse", IsNullable = false)]
    public class GetOutboxDocumentStatusResponse : GetDocumentStatusResponse
    {

    }
}