using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetDocumentResponse : DocumentBase
    {
        public XElement DocumentXML { get; set; }

        // TODO: Investigate use of this property
        public RuleApplicable RuleXML { get; set; }
    }
}