using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Inbox.Status
{
    [TestClass]
    public class GetInboxDocumentStatusTests
    {
        protected DocumentSharedExtensions InboxDocument;

        public GetInboxDocumentStatusTests()
        {
            var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                                                           {
                                                               EntityId = Properties.Settings.Default.EntityId,
                                                               Limit = 1
                                                           });
            Assert.IsNotNull(result);
            InboxDocument = result.Documents.Single();
        }

        [TestMethod]
        public void GetInboxDocumentStatus_ByConsignmentId()
        {
            var result = EConnect.Client.GetInboxDocumentStatus(new GetInboxDocumentStatus()
                {
                    ConsignmentId = InboxDocument.ConsignmentId
                });

            Assert.AreEqual(result.Status, InboxDocument.LatestStatus);
            Assert.AreEqual(result.StatusCode, InboxDocument.LatestStatusCode);
            Assert.IsNotNull(result.StatusSetByAccountId);
            Assert.IsNotNull(result.StatusSetByUserId);
        }


        [TestMethod]
        public void GetInboxDocumentStatus_ByExternalId()
        {
            var result = EConnect.Client.GetInboxDocumentStatus(new GetInboxDocumentStatus()
                {
                    ConsignmentId = InboxDocument.ExternalId
                });

            Assert.AreEqual(result.Status, InboxDocument.LatestStatus);
            Assert.AreEqual(result.StatusCode, InboxDocument.LatestStatusCode);
            Assert.IsNotNull(result.StatusSetByAccountId);
            Assert.IsNotNull(result.StatusSetByUserId);
        }
    }
}