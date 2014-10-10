using System.Xml.Linq;

namespace EConnectApi.Definitions
{
    public class SendDocumentBase
    {
        /// <summary>
        /// UBL
        /// </summary>
        public XElement Payload { get; set; }

        /// <summary>
        /// This parameter gives the id of the document that should be sent. 
        /// This parameter should not be entered if the DocumentTemplateId is provided. 
        /// You can find the DocumentId of a document by selecting the document from the 
        /// DocumentBase List section under Documents & Data, and clicking the ​Properties button.
        /// </summary>
        public string DocumentId { get; set; }

        public string DocumentTemplateId { get; set; }

        public string Recipient { get; set; }


        public string Subject { get; set; }

    }
}