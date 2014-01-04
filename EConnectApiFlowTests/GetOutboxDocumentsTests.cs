using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetOutboxDocumentsTests
    {
        [TestMethod]
        public void GetOutboxDocuments_Paging()
        {
            var outboxDocument = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 1 }).Documents.First();

            var result = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 2 });
            Assert.IsNotNull(result);
            var doc = result.Documents.First();
            Assert.AreEqual(outboxDocument.Rowkey, doc.Rowkey);
            Assert.AreEqual(outboxDocument.CreatedDateTime, doc.CreatedDateTime);
            Assert.AreEqual(outboxDocument.DocumentId, doc.DocumentId);

            var result2 = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 2, StartRowRange = result.StartRowRange });
            Assert.IsNotNull(result2);
            var doc2 = result2.Documents.First();
            Assert.AreEqual(result.StartRowRange, doc2.Rowkey);
            Assert.AreNotEqual(outboxDocument.CreatedDateTime, doc2.CreatedDateTime);
            Assert.AreNotEqual(outboxDocument.DocumentId, doc2.DocumentId);
        }

        [TestMethod]
        public void GetOutboxDocuments_ByEntityId()
        {
            EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsFromEntity()
                {
                    EntityId = ""
                });

            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetOutboxDocuments_ByGroupId()
        {
            EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsFromGroup()
                {
                    GroupId = "XGL1138485213468291",
                    Limit = 1
                });
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetOutboxDocuments_OfAnUser()
        {
            EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser()
                {
                    Limit = 1
                });
            throw new NotImplementedException();
        }
    }
}