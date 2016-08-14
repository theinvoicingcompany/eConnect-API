using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/enquirecompany", ElementName = "EnquireCompanyResponse", IsNullable = false)]
    public class EnquireCompanyResponse : Company
    {
        [Obsolete]
        public string Country { get; set; }
        [Obsolete]
        public string ExternalIdSource { get; set; }
    }
}