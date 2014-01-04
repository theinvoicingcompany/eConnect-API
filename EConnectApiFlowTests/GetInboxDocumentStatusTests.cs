using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetInboxDocumentStatusTests
    {
        protected DocumentBase InboxDocument;

        public GetInboxDocumentStatusTests()
        {
            var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1 });
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
        }
    }
}