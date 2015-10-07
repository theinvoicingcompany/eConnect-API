using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document.Status
{
    [TestClass]
    public class SetDocumentStatusTests
    {
        public DocumentBase GetDocument1()
        {
            return EConnect.Client.GetDocument(new GetDocument() { DocumentId = "RA000000218DML1000031" });
        }

        [TestMethod]
        public void SetDocumentStatus()
        {
            var doc_v1 = GetDocument1();
            var statuses = doc_v1.PossibleStatuses;

            if (statuses.PreviousStatus != null)
            {
                // Go step back, so there will be a step head
                EConnect.Client.SetDocumentStatus(new SetDocumentStatus()
                    {
                        DocumentId = doc_v1.DocumentId,
                        StatusCode = statuses.PreviousStatus.Code
                    });

                var doc_v2 = GetDocument1();
                statuses = doc_v2.PossibleStatuses;

                Assert.IsNotNull(statuses, "PossibleStatuses is null");
                Assert.IsNotNull(statuses.NextStatus, "NextStatus is null");
            }
            
            var result = EConnect.Client.SetDocumentStatus(new SetDocumentStatus()
                {
                    DocumentId = doc_v1.DocumentId,
                    StatusCode = statuses.NextStatus.Code
                });

            Assert.IsNotNull(result);

            var doc_v3 = GetDocument1();

            var statuses2 = doc_v3.PossibleStatuses;
            Assert.AreEqual(statuses.NextStatus, statuses2.LatestStatus);
            Assert.AreEqual(statuses.LatestStatus, statuses2.PreviousStatus);
        }
    }
}