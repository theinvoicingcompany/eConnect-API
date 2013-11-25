using System;
using System.Linq;
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
            using (var client = new EConnectClient(new EConnectClientConfigBase()
                                                       {
                                                           ConsumerKey = Properties.Settings.Default.ConsumerKey,
                                                           ConsumerSecret = Properties.Settings.Default.ConsumerSecret,
                                                           RequesterId = Properties.Settings.Default.RequesterId
                                                       }))
            {
                //var doc = new SendDocument()
                //{
                //    DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                //    Subject = "Afas test factuur",
                //    Recipient = "thieme@selmit.nl",
                //    RecipientEmailId = "thieme@selmit.nl",
                //    Payload = XElement.Parse(System.IO.File.ReadAllText(@"C:\Users\Thieme\Documents\SelmIT\eVerbinding\EConnectApi\Test files\UBLWITHATTACHEMENT.txt")),
                //    DocumentAsFile = new DocumentAsFile() { FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=", FileName = "order.txt" }
                //};

                //var senddocres = client.SendDocument(doc);
                var docs = client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 25 });
                var firstdoc = docs.Documents.First();
                var doc3 = client.GetInboxDocument(new GetInboxDocument()
                                                      {
                                                          //ConsignmentId = "CUA000000191000001INCC9223370651610366013UA000000191000001"
                                                          ConsignmentId = firstdoc.ConsignmentId
                                                      });
                Assert.AreEqual(firstdoc.ConsignmentName, doc3.ConsignmentName);
                Assert.AreEqual(firstdoc.CreatedDateTime, doc3.CreatedDateTime);

                var docsout = client.GetOutboxDocuments(new GetOutboxDocumentsesOfAnUser() {Limit = 1});
                var firstout = docsout.DocumentsBase.First();
                var doc4 = client.GetOutboxDocument(new GetOutboxDocuments() { ConsignmentId = firstdoc.ConsignmentId });

                Assert.AreEqual(firstout.ConsignmentName, doc4.ConsignmentName);
                Assert.AreEqual(firstout.CreatedDateTime, doc4.CreatedDateTime);
                //var doc4 = client.GetInboxDocument(new GetInboxDocument()
                //                                       {
                //                                           ExternalId = senddocres.ExternalId
                //                                       });
                //Assert.AreEqual(doc.DocumentId, doc4.DocumentId);
                //Assert.AreEqual(doc.GetHashCode(), doc4.GetHashCode());

            }
        }
    }
}
