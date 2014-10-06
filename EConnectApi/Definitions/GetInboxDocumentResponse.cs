using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetInboxDocumentResponse : DocumentBase
    {
        // TODO: Investigate use of this property
        public RuleApplicable RuleApplicable { get; set; }
    }


}