using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocumentstatus", ElementName = "GetInboxDocumentStatusResponse", IsNullable = false)]
    public class GetInboxDocumentStatusResponse : GetDocumentStatusResponse
    {

    }
}