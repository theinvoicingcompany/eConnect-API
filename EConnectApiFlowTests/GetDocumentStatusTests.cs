using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetDocumentStatusTests
    {
        protected DocumentDetails Document;

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
        }
    }
}