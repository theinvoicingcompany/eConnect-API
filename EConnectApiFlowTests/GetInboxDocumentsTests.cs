using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetInboxDocumentsTests
    {
        [TestMethod]
        public void GetInboxDocuments_Paging()
        {
            var inboxDocument = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1 }).Documents.First();

            var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 2 });
            Assert.IsNotNull(result);
            var doc = result.Documents.First();
            Assert.AreEqual(inboxDocument.Rowkey, doc.Rowkey);
            Assert.AreEqual(inboxDocument.CreatedDateTime, doc.CreatedDateTime);
            Assert.AreEqual(inboxDocument.DocumentId, doc.DocumentId);

            var result2 = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 2, StartRowRange = result.StartRowRange });
            Assert.IsNotNull(result2);
            var doc2 = result2.Documents.First();
            Assert.AreEqual(result.StartRowRange, doc2.Rowkey);
            Assert.AreNotEqual(inboxDocument.CreatedDateTime, doc2.CreatedDateTime);
            Assert.AreNotEqual(inboxDocument.DocumentId, doc2.DocumentId);
        }

        [TestMethod]
        public void GetInboxDocuments_ByEntityId()
        {
            EConnect.Client.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                {
                    EntityId = ""
                });

            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetInboxDocuments_ByGroupId()
        {
            EConnect.Client.GetInboxDocuments(new GetInboxDocumentsFromGroup()
                {
                    GroupId = "XGL1138485213468291",
                    Limit = 1
                });
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetInboxDocuments_OfAnUser()
        {
            EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
                {
                    Limit = 1
                });
            throw new NotImplementedException();
        }
    }
}
