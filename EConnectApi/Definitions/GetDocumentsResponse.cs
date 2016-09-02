using System;
using System.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocuments", ElementName = "GetDocumentsResponse", IsNullable = false)]
    public class GetDocumentsResponse
    {
        [XmlElement(ElementName = "tuple", Namespace = "http://api.everbinding.nl/v3/getdocuments")]
        public DocumentBase[] Documents { get; set; }

        [XmlElement(ElementName = "startrowrange")]
        public string StartRowRange { get; set; }
    }
}