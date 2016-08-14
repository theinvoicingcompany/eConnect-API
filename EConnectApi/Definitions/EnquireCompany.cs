using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/enquirecompany", ElementName = "EnquireCompany", IsNullable = false)]
    public class EnquireCompany
    {
        [Obsolete]
        [XmlElement(ElementName = "TemporaryIdentifier")]
        public string TemporaryId { get; set; }
        public string EntityId { get; set; }
    }
}
