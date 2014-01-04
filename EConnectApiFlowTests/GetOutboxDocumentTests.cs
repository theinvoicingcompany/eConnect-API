using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetOutboxDocumentTests
    {
        protected DocumentBase OutboxDocument;

         public GetOutboxDocumentTests()
        {
            var result = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 1});
            Assert.IsNotNull(result);
            OutboxDocument = result.Documents.Single();
        }

        [TestMethod]
        public void GetOutboxDocument_ByConsignmentId()
        {
            var result = EConnect.Client.GetOutboxDocument(new GetOutboxDocument()
                {
                    ConsignmentId = OutboxDocument.ConsignmentId
                });

            Assert.AreEqual(result.CreatedDateTime, OutboxDocument.CreatedDateTime);
            Assert.AreEqual(result.DocumentId, OutboxDocument.DocumentId);
        }

        [TestMethod]
        public void GetOutboxDocument_ByExternalId()
        {
            var result = EConnect.Client.GetOutboxDocument(new GetOutboxDocument()
            {
                ConsignmentId = OutboxDocument.ExternalId
            });

            Assert.AreEqual(result.CreatedDateTime, OutboxDocument.CreatedDateTime);
            Assert.AreEqual(result.DocumentId, OutboxDocument.DocumentId);
        }
    }
}
