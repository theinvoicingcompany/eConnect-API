using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createdocument", ElementName = "CreateDocumentResponse", IsNullable = false)]
    public class CreateDocumentResponse
    {
        public string DocumentId { get; set; }

        public string ExternalId { get; set; }
    }
}