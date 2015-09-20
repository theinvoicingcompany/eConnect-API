using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Outbox.Status
{
    [TestClass]
    public class GetOutboxDocumentStatusTests
    {
        protected DocumentBaseExtensions OutboxDocument;

        public GetOutboxDocumentStatusTests()
        {
            var result = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 1 });
            Assert.IsNotNull(result);
            OutboxDocument = result.Documents.Single();
        }
        
        [TestMethod]
        public void GetOutboxDocumentStatus_ByConsignmentId()
        {
            var result = EConnect.Client.GetOutboxDocumentStatus(new GetOutboxDocumentStatus()
                {
                    ConsignmentId = OutboxDocument.ConsignmentId
                });

            Assert.AreEqual(result.Status, OutboxDocument.LatestStatus);
            Assert.AreEqual(result.StatusCode, OutboxDocument.LatestStatusCode);
        }


        [TestMethod]
        public void GetOutboxDocumentStatus_ByExternalId()
        {
            var result = EConnect.Client.GetOutboxDocumentStatus(new GetOutboxDocumentStatus()
                {
                    ConsignmentId = OutboxDocument.ExternalId
                });

            Assert.AreEqual(result.Status, OutboxDocument.LatestStatus);
            Assert.AreEqual(result.StatusCode, OutboxDocument.LatestStatusCode);
        }
    }
}