using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocumentpdf", ElementName = "GetDocumentPDFResponse", IsNullable = false)]
    public class GetDocumentPdfResponse : FileWrapper
    {
        public string ConsignmentId { get; set; }

        public string DocumentId { get; set; }

        [XmlElement(ElementName = "DocumentFileName")]
        public string DocumentFileName { get { return FileName; } set { FileName = value; } }

        /// <summary>
        /// Base 64 encoded content
        /// </summary>
        [XmlText]
        [XmlElement(ElementName = "PDFVersionFile")]
        public string PdfVersionFile { get { return Base64; } set { Base64 = value; } }
    }
}