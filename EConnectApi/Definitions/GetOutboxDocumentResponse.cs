using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getoutboxdocument", ElementName = "GetOutboxDocumentResponse", IsNullable = false)]
    public class GetOutboxDocumentResponse : DocumentBase
    {
        [Obsolete]
        public RuleApplicable RuleApplicable { get; set; }
    }
}