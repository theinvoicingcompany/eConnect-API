using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetInboxDocumentTests
    {
        protected DocumentBase InboxDocument;

        public GetInboxDocumentTests()
        {
            var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1 });
            Assert.IsNotNull(result);
            InboxDocument = result.Documents.Single();
        }

        [TestMethod]
        public void GetInboxDocument_ByConsignmentId()
        {
            var result = EConnect.Client.GetInboxDocument(new GetInboxDocument()
                {
                    ConsignmentId = InboxDocument.ConsignmentId
                });

            Assert.AreEqual(result.CreatedDateTime, InboxDocument.CreatedDateTime);
            Assert.AreEqual(result.DocumentId, InboxDocument.DocumentId);
        }

        [TestMethod]
        public void GetInboxDocument_ByExternalId()
        {
            var result = EConnect.Client.GetInboxDocument(new GetInboxDocument()
            {
                ExternalId = InboxDocument.ExternalId
            });

            Assert.AreEqual(result.CreatedDateTime, InboxDocument.CreatedDateTime);
            Assert.AreEqual(result.DocumentId, InboxDocument.DocumentId);
        }
    }
}
