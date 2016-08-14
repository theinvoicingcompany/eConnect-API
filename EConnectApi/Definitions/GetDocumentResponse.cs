using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocument", ElementName = "GetDocumentResponse", IsNullable = false)]
    public class GetDocumentResponse : DocumentBase
    {
        [Obsolete]
        public XElement DocumentXML { get; set; }

        [Obsolete]
        // TODO: Investigate use of this property
        public RuleApplicable RuleXML { get; set; }
    }
}