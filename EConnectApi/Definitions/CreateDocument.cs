using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createdocument", ElementName = "CreateDocument", IsNullable = false)]
    public class CreateDocument
    {
        public string DocumentTemplateId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentDescription { get; set; }

        public XElement Payload { get; set; }
    }
}