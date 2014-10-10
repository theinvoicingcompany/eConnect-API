using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRootAttribute(Namespace = "http://ws.vg.pw.com/external/1.0", IsNullable = false)]
    public class SendDocument : SendDocumentBase
    {
        public DocumentAsFile DocumentAsFile { get; set; }
        public string RecipientEmailId { get; set; }
        public string SendViaGroup { get; set; }

    }
}
