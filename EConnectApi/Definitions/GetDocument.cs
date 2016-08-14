using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocument", ElementName = "GetDocument", IsNullable = false)]
    public class GetDocument
    {
        public string DocumentId { get; set; }
    }
}