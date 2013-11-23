using System;
using System.Xml.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class FlowTests
    {
        [TestMethod]
        public void SendDocumentAndGetInboxDocument()
        {
            using (var client = new EConnectClient("thieme@selmit.nl"))
            {
                var doc = new SendDocument()
                {
                    DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                    Subject = "Afas test factuur",
                    Recipient = "thieme@selmit.nl",
                    RecipientEmailId = "thieme@selmit.nl",
                    Payload = XElement.Parse(System.IO.File.ReadAllText(@"C:\Users\Thieme\Documents\SelmIT\eVerbinding\EConnectApi\Test files\UBLWITHATTACHEMENT.txt")),
                    DocumentAsFile = new DocumentAsFile() { FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=", FileName = "order.txt" }
                };

                //var res = client.SendDocument(doc);
                var docs = client.GetInboxDocuments(new GetInboxDocuments() { Limit = 25});
            }
        }
    }
}
