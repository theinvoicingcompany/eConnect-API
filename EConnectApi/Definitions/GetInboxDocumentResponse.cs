using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetInboxDocumentResponse : DocumentBase
    {
        /// <summary>
        /// UBL
        /// </summary>
        public XElement Payload { get; set; }

        // TODO: Investigate use of this property
        public RuleApplicable RuleApplicable { get; set; }
    }
}