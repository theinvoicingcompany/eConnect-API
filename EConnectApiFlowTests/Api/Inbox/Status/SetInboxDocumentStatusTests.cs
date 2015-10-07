using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Inbox.Status
{
    [TestClass]
    public class SetInboxDocumentStatusTests
    {
        protected DocumentInOrOutboxMetaData InboxDocument;

        public SetInboxDocumentStatusTests()
        {
            var result = EConnect.Client2.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                                                           {
                                                               EntityId = Properties.Settings.Default.EntityId2,
                                                               Limit = 1
                                                           });
            Assert.IsNotNull(result);
            InboxDocument = result.Documents.Single().DocumentInbox;
        }
        
        [TestMethod]
        public void SetInboxDocumentStatus()
        {
            var doc = EConnect.Client2.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });
            var statuses = doc.PossibleStatuses;

            //if (statuses.PreviousStatus != null)
            //{
            //    // Go step back, so there will be a step head
            //    EConnect.Client2.SetInboxDocumentStatus(new SetInboxDocumentStatus()
            //        {
            //            ConsignmentId = InboxDocument.ConsignmentId,
            //            StatusCode = statuses.PreviousStatus.Code
            //        });
            //}

            //doc = EConnect.Client2.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });
            //statuses = doc.PossibleStatuses;

            var result = EConnect.Client2.SetInboxDocumentStatus(new SetInboxDocumentStatus()
                {
                    ConsignmentId = InboxDocument.ExternalId,
                    StatusCode = statuses.PossibleStatuses[5].Code
                });

            Assert.IsNotNull(result);

            var result2 =
                EConnect.Client2.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });

            var statuses2 = result2.PossibleStatuses;
            Assert.AreEqual(statuses.NextStatus, statuses2.LatestStatus);
            Assert.AreEqual(statuses.LatestStatus, statuses2.PreviousStatus);
        }
    }
}