using System;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class UpdateDocumentTests
    {
        public void ValidateDocuments(UpdateDocument doc, GetDocumentResponse doc2)
        {
            Assert.AreEqual(doc.Payload, doc.Payload);
            Assert.AreEqual(doc.DocumentDescription, doc2.Description);
            Assert.AreEqual(doc.DocumentName, doc2.DocumentName);
            Assert.AreEqual(doc.DocumentId, doc2.DocumentId);
            Assert.IsNotNull(doc2.ExternalId);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\UBLWITHATTACHEMENT.txt", "OutputDir")]
        public void UpdateDocument()
        {
            var doc = new UpdateDocument()
                      {
                          DocumentId = "RA000000218DML1000029",
                          DocumentName = Guid.NewGuid().ToString(),
                          DocumentDescription = DateTime.UtcNow.ToLongDateString(),
                          // TODO change payload to dynamic payload
                          Payload = TestResources.Document1
                      };
            var res = EConnect.Client.UpdateDocument(doc);

            var doc2 = EConnect.Client.GetDocument(new GetDocument()
                                                   {
                                                       DocumentId = res.DocumentId
                                                   });

            ValidateDocuments(doc, doc2);
        }
    }
}