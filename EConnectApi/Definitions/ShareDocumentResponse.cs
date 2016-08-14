using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/sharedocument", ElementName = "ShareDocumentResponse", IsNullable = false)]
    public class ShareDocumentResponse
    {
        public string DocumentId { get; set; }
    }
}