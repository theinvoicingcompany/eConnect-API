using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/senddocument", ElementName = "SendDocument", IsNullable = false)]
    public class SendDocument : SendDocumentBase
    {
        public DocumentAsFile DocumentAsFile { get; set; }
        public string RecipientEmailId { get; set; }
        public string SendViaGroup { get; set; }

    }
}
