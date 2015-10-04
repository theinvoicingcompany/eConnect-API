using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class CreateDocumentTests
    {
        public void ValidateDocuments(CreateDocument doc, GetDocumentResponse doc2)
        {
            Assert.AreEqual(doc.Payload, doc.Payload);
            Assert.AreEqual(doc.DocumentDescription, doc2.Description);
            Assert.AreEqual(doc.DocumentName, doc2.DocumentName);
            Assert.AreEqual(doc.DocumentTemplateId, doc2.DocumentTemplateId);
            Assert.IsNotNull(doc2.ExternalId);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\UBLWITHATTACHEMENT.txt", "OutputDir")]
        public void CreateDocument()
        {
            var doc = new CreateDocument()
                                           {
                                               DocumentName = "test name",
                                               DocumentDescription = "doc descr",
                                               DocumentTemplateId = "RA000000218DTL1000001",
                                               Payload = TestResources.Document1
                                           };
            var res = EConnect.Client.CreateDocument(doc);

            var doc2 = EConnect.Client.GetDocument(new GetDocument()
                                        {
                                            DocumentId = res.DocumentId
                                        });
            ValidateDocuments(doc, doc2);
        }
    }
}