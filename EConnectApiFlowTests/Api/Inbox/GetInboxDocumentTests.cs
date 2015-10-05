using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Inbox
{
    [TestClass]
    public class GetInboxDocumentTests
    {
        protected DocumentSharedExtensions InboxDocument;

        public GetInboxDocumentTests()
        {
            var page1 = EConnect.Client2.GetInboxDocuments(new GetInboxDocumentsFromEntity()
            {
                Limit = 2,
                EntityId = Properties.Settings.Default.EntityId2
            });
            if (page1 == null || page1.Documents == null)
                Assert.Inconclusive("No documents returned");
            InboxDocument = page1.Documents[1];
        }

        public void GetDocument(GetInboxDocument parameters)
        {
            var details = EConnect.Client2.GetInboxDocument(parameters);

            Assert.IsTrue(InboxDocument.Equals(details));
            Assert.IsNotNull(details.Payload);
            Assert.IsNotNull(details.PossibleStatuses);
        }

        [TestMethod]
        public void GetInboxDocument_ByConsignmentId()
        {
            GetDocument(new GetInboxDocument()
            {
                ConsignmentId = InboxDocument.ConsignmentId
            });
        }

        [TestMethod]
        public void GetInboxDocument_ByExternalId()
        {
            GetDocument(new GetInboxDocument()
            {
                ConsignmentId = InboxDocument.ExternalId
            });
        }
    }
}
