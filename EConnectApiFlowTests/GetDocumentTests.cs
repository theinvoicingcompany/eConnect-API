using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetDocumentTests
    {
        [TestMethod]
        public void GetDocument_ByDocumentId()
        {
            var doc = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1}).Documents.First();

            var result = EConnect.Client.GetDocument(new GetDocument() { DocumentId = doc.DocumentId });
            // DateTime can be different because of sending and leaving the document outbox
            // Assert.AreEqual(result.CreatedDateTime, doc.CreatedDateTime);
            Assert.AreEqual(result.DocumentId, doc.DocumentId);
            Assert.AreEqual(doc.Subject, result.Subject);
        }
    }
}
