using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class SendDocumentTests
    {
        public void Validate(SendDocumentResponse sendRes, GetOutboxDocumentResponse outbox)
        {
            Assert.AreEqual(sendRes.ExternalId, outbox.ExternalId);
            Assert.AreEqual(sendRes.ConsignmentId, outbox.ConsignmentId);
        }

        public void Validate(SendDocument send, GetOutboxDocumentResponse outbox)
        {
            Assert.AreEqual(send.Subject, outbox.Subject);
            Assert.AreEqual(send.DocumentTemplateId, outbox.DocumentTemplateId);
            Assert.AreEqual(Properties.Settings.Default.EntityId, outbox.SenderEntityId);
        }

        [TestMethod]
        [DeploymentItem(TestResources.InvoiceNoAttachmentForRecipient2Path)]
        public void SendDocument()
        {
            // Prepare
            var send = new SendDocument()
            {
                DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                Subject = "Unit test " + Guid.NewGuid(),
                Recipient = Properties.Settings.Default.RequesterId2,
                RecipientEmailId = Properties.Settings.Default.RequesterId2,
                Payload = TestResources.InvoiceNoAttachmentForRecipient2,
                SendViaGroup = Properties.Settings.Default.EntityId
            };

            // Send
            var sendRes = EConnect.Client.SendDocument(send);

            // Check outbox
            var outbox = EConnect.Client.GetOutboxDocument(new GetOutboxDocument()
                                                              {
                                                                  ConsignmentId = sendRes.ConsignmentId
                                                              });

            Validate(sendRes, outbox);
            Validate(send, outbox);

            //// Check inbox
            //var inboxdocs = EConnect.Client2.GetInboxDocuments(new GetInboxDocumentsFromEntity()
            //                                   {
            //                                       EntityId = Properties.Settings.Default.EntityId2,
            //                                       Limit = 1
            //                                   });
            //var inbox = inboxdocs.Documents.Single();

            //Assert.AreEqual(outbox.Subject, inbox.Subject);
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException), "Het document-ID bestaat niet")]
        public void SendDocument_WithUnkownDocumentId()
        {
            var doc = new SendDocument()
            {
                DocumentId = Guid.NewGuid().ToString(),
                Subject = "Afas test factuur " + Guid.NewGuid(),
                Recipient = "thieme@selmit.nl",
                RecipientEmailId = "thieme@selmit.nl",
                DocumentAsFile = new DocumentAsFile() { FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=", FileName = "order.txt" }
            };

            EConnect.Client.SendDocument(doc);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\UBLWITHATTACHEMENT.txt", "OutputDir")]
        public void SendDocumentFor()
        {
            const string fileName = @"OutputDir\UBLWITHATTACHEMENT.txt";
            Assert.IsNotNull(fileName);
            Assert.IsTrue(File.Exists(fileName), "deployment not successfull");

            string ubltext = File.ReadAllText(fileName);
            Assert.IsFalse(string.IsNullOrEmpty(ubltext), "test file seems to be empty");

            var ubl = XElement.Parse(ubltext);
            Assert.IsNotNull(ubl);

            var doc = new SendDocumentFor()
            {
                DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                Subject = "Test factuur " + Guid.NewGuid(),
                Recipient = "NL:KVK:00006661",
                Payload = ubl,
            };

            EConnect.Client.SendDocumentFor("NL:KVK:00006663", doc);
        }
    }
}
