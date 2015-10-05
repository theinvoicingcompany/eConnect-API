using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetInboxDocumentResponse : DocumentSharedExtensionsDetails
    {
        [Obsolete]
        public RuleApplicable RuleApplicable { get; set; }
    }


}