using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class SetDocumentStatusTests
    {
        protected DocumentBase Document;

        public SetDocumentStatusTests()
        {
            var result = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = 1 });
            Assert.IsNotNull(result);
            Document = result.Documents.Single();
        }

        [TestMethod]
        public void SetDocumentStatus()
        {
            var doc = EConnect.Client.GetDocument(new GetDocument() { DocumentId = Document.DocumentId });
            var statuses = doc.PossibleStatuses;

            if (statuses.PreviousStatus != null)
            {
                // Go step back, so there will be a step head
                EConnect.Client.SetDocumentStatus(new SetDocumentStatus()
                    {
                        DocumentId = doc.DocumentId,
                        StatusCode = statuses.PreviousStatus.Code
                    });

                doc = EConnect.Client.GetDocument(new GetDocument() { DocumentId = Document.DocumentId });
                statuses = doc.PossibleStatuses;

                Assert.IsNotNull(statuses, "PossibleStatuses is null");
                Assert.IsNotNull(statuses.NextStatus, "NextStatus is null");
            }
            
            var result = EConnect.Client.SetDocumentStatus(new SetDocumentStatus()
                {
                    DocumentId = Document.DocumentId,
                    StatusCode = statuses.NextStatus.Code
                });

            Assert.IsNotNull(result);

            var result2 =
                EConnect.Client.GetDocument(new GetDocument() { DocumentId = Document.DocumentId });

            var statuses2 = result2.PossibleStatuses;
            Assert.AreEqual(statuses.NextStatus, statuses2.LatestStatus);
            Assert.AreEqual(statuses.LatestStatus, statuses2.PreviousStatus);
        }
    }
}