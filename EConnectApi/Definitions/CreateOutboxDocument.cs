using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/2.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/2.0", IsNullable = false)]
    public class CreateOutboxDocument : SendDocumentBase
    {

    }
}