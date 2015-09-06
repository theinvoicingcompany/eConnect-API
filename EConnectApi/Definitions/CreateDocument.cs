using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.com/pw/PWDataDx/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.com/pw/PWDataDx/1.0", IsNullable = false)]
    public class CreateDocument
    {
        public string DocumentTemplateId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentDescription { get; set; }

        public XElement Payload { get; set; }
    }
}