using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocument", ElementName = "GetInboxDocumentResponse", IsNullable = false)]
    public class GetInboxDocumentResponse : DocumentBase
    {
        [Obsolete]
        public RuleApplicable RuleApplicable { get; set; }
    }
}