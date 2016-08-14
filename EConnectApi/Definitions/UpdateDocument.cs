using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/updatedocument", ElementName = "UpdateDocument", IsNullable = false)]
    public class UpdateDocument
    {
        public string DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentDescription { get; set; }

        public XElement Payload { get; set; }
    }
}