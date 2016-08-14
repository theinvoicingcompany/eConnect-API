using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocumentstatus", ElementName = "GetDocumentStatus", IsNullable = false)]
    public class GetDocumentStatus : GetDocument
    {
        
    }
}