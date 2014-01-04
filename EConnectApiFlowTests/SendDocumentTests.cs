using System;
using System.IO;
using System.Xml.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class SendDocumentTests
    {
        [TestMethod]
        [DeploymentItem(@"TestData\UBLWITHATTACHEMENT.txt", "OutputDir")]
        public void SendDocumentAndGetDocument()
        {
            const string fileName = @"OutputDir\UBLWITHATTACHEMENT.txt";
            Assert.IsNotNull(fileName);
            Assert.IsTrue(File.Exists(fileName), "deployment not successfull");

            string ubltext = File.ReadAllText(fileName);
            Assert.IsFalse(string.IsNullOrEmpty(ubltext), "test file seems to be empty");

            var ubl = XElement.Parse(ubltext);
            Assert.IsNotNull(ubl);

            var doc = new SendDocument()
            {
                DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                Subject = "Afas test factuur "+Guid.NewGuid(),
                Recipient = "thieme@selmit.nl",
                RecipientEmailId = "thieme@selmit.nl",
                Payload = ubl,
                DocumentAsFile = new DocumentAsFile() { FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=", FileName = "order.txt" }
            };

            var result = EConnect.Client.SendDocument(doc);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ConsignmentId);
            Assert.IsNotNull(result.ExternalId);


            var outboxdoc =
                EConnect.Client.GetOutboxDocument(new GetOutboxDocument() {ConsignmentId = result.ConsignmentId});

            Assert.AreEqual(doc.Subject, outboxdoc.Subject);
            Assert.AreEqual(doc.DocumentTemplateId, outboxdoc.StandardTemplateId);
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
    }
}
