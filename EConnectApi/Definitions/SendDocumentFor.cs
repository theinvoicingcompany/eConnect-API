using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/senddocumentfor", ElementName = "SendDocumentFor", IsNullable = false)]
    public class SendDocumentFor : SendDocumentBase
    {

    }
}