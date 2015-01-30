using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetOutboxDocumentsTests
    {
        protected DocumentBase OutboxDocument;

        public GetOutboxDocumentsTests()
        {
            //var result = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 2 });
            //Assert.IsNotNull(result);
            //OutboxDocument = result.Documents.Single();
        }

        [TestMethod]
        public void GetOutboxDocuments_Paging()
        {
            var result = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 2, Filters = new GetDocumentsFiltersBase()
            {
                ModifiedDateTime = new TimeSpanFilter() { From = new DateTime(2014, 7, 1, 1, 1, 1) }
            }});
            Assert.IsNotNull(result);
            var doc = result.Documents.First();
            Assert.AreEqual(OutboxDocument.Rowkey, doc.Rowkey);
            Assert.AreEqual(OutboxDocument.CreatedDateTime, doc.CreatedDateTime);
            Assert.AreEqual(OutboxDocument.DocumentId, doc.DocumentId);

            var result2 = EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsOfAnUser() { Limit = 2, StartRowRange = result.StartRowRange });
            Assert.IsNotNull(result2);
            var doc2 = result2.Documents.First();
            Assert.AreEqual(result.StartRowRange, doc2.Rowkey);
            Assert.AreNotEqual(OutboxDocument.CreatedDateTime, doc2.CreatedDateTime);
            Assert.AreNotEqual(OutboxDocument.DocumentId, doc2.DocumentId);
        }

        [TestMethod]
        public void GetOutboxDocuments_ByEntityId()
        {
            EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsFromEntity()
                {
                    EntityId = "XCNL10199"
                });

            //throw new NotImplementedException();
        }

        [TestMethod]
        public void GetOutboxDocuments_ByGroupId()
        {
            EConnect.Client.GetOutboxDocuments(new GetOutboxDocumentsFromGroup()
                {
                    GroupId = "XGL1138485213468291",
                    Limit = 1
                });
            //throw new NotImplementedException();
        }

        [TestMethod]
        public void GetOutboxDocuments_OfAnUser()
        {
            Assert.IsNotNull(OutboxDocument);
        }
    }
}