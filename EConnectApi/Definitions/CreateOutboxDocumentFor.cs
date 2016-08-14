using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/createoutboxdocument", ElementName = "CreateOutboxDocumentFor", IsNullable = false)]
    public class CreateOutboxDocumentFor : SendDocumentBase
    {

    }
}
