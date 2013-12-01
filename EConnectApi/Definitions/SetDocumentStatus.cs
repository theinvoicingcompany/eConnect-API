using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/1.0", ElementName = "SetDocumentStatus", IsNullable = false)]
    public class SetDocumentStatus : GetDocumentBase
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
    }
}
