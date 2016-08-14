using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/updatedocument", ElementName = "UpdateDocumentResponse", IsNullable = false)]
    public class UpdateDocumentResponse
    {
        public string DocumentId { get; set; }
    }
}