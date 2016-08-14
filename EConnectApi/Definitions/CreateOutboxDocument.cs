using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createoutboxdocument", ElementName = "CreateOutboxDocument", IsNullable = false)]
    public class CreateOutboxDocument : SendDocumentBase
    {
        public string SenderId { get; set; }
    }
}