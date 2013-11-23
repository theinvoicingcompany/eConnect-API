using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRootAttribute(Namespace = "http://ws.vg.pw.com/external/1.0", IsNullable = false)]
    public class SendDocument
    {
        /// <summary>
        /// UBL
        /// </summary>
        public XElement Payload { get; set; }

        /// <summary>
        /// This parameter gives the id of the document that should be sent. 
        /// This parameter should not be entered if the DocumentTemplateId is provided. 
        /// You can find the DocumentId of a document by selecting the document from the 
        /// Document List section under Documents & Data, and clicking the ​Properties button.
        /// </summary>
        public string DocumentId { get; set; }

        public string DocumentTemplateId { get; set; }
        public string Subject { get; set; }
        public DocumentAsFile DocumentAsFile { get; set; }
        public string Recipient { get; set; }
        //public MailAddress RecipientEmailId { get; set; }
        public string RecipientEmailId { get; set; }
        public string SendViaGroup { get; set; }

    }


}
