using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocumentpdf", ElementName = "GetDocumentPDF", IsNullable = false)]
    public class GetDocumentPdf : GetDocumentBase
    {

    }
}