using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document.Status
{
    [TestClass]
    public class GetDocumentStatusTests
    {
        protected DocumentBase Document;

        public GetDocumentStatusTests()
        {
            var result = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = 1 });
            Assert.IsNotNull(result);
            Document = EConnect.Client.GetDocument(new GetDocument() { DocumentId = result.Documents.Single().DocumentId });
        }

        [TestMethod]
        public void GetDocumentStatus()
        {
            var result = EConnect.Client.GetDocumentStatus(new GetDocumentStatus()
                {
                    DocumentId = Document.DocumentId
                });

            Assert.AreEqual(result.Status, Document.LatestStatus);
            Assert.AreEqual(result.StatusCode, Document.LatestStatusCode);
            Assert.IsNotNull(result.StatusSetByAccountId);
            Assert.IsNotNull(result.StatusSetByUserId);
        }
    }
}