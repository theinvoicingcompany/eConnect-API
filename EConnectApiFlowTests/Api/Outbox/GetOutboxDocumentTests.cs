using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Outbox
{
    [TestClass]
    public class GetOutboxDocumentTests
    {
        protected DocumentBaseExtensions OutboxDocument;

        public GetOutboxDocumentTests()
        {
            var page1 = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 1 });
            if(page1 == null || page1.Documents == null)
                Assert.Inconclusive("No documents returned");
            OutboxDocument = page1.Documents.Single();
        }

        public void GetDocument(GetOutboxDocument parameters)
        {
            var details = EConnect.Client.GetOutboxDocument(parameters);

            Assert.IsTrue(OutboxDocument.Equals(details));
            Assert.IsNotNull(details.Payload);
            Assert.IsNotNull(details.PossibleStatuses);
        }

        [TestMethod]
        public void GetOutboxDocument_ByConsignmentId()
        {
            GetDocument(new GetOutboxDocument()
            {
                ConsignmentId = OutboxDocument.ConsignmentId
            });
        }

        [TestMethod]
        public void GetOutboxDocument_ByExternalId()
        {
            GetDocument(new GetOutboxDocument()
            {
                ConsignmentId = OutboxDocument.ExternalId
            });
        }
    }
}
