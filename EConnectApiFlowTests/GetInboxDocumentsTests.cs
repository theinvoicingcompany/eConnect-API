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
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
                {
                    Limit = 1
                });
            Assert.AreEqual(1, docs.Documents.Length);
        }

        [TestMethod]
        public void GetInboxDocuments_FilterIsRead()
        {
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                    {
                        IsRead = false
                    }
            });
            Assert.AreEqual(0, docs.Documents.Count(a => a.IsRead), "Is Read should be false");

            var docs2 = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    IsRead = true
                }
            });
            Assert.AreEqual(0, docs2.Documents.Count(a => !a.IsRead), "Is Read should be true");
            Assert.AreNotEqual(docs.Documents.First().ConsignmentId, docs2.Documents.First().ConsignmentId);
        }

        [TestMethod]
        public void GetInboxDocuments_FilterCreatedDateTimeFrom()
        {
            var form = DateTime.Now.AddDays(-3);
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    CreatedDateTime = new TimeSpanFilter() { From = form}
                }
            });
            Assert.AreEqual(0, docs.Documents.Count(a => a.CreatedDateTime < form), "Filter is not applied");
        }

        [TestMethod]
        public void GetInboxDocuments_FilterCreatedDateTimeTo()
        {
            var to = DateTime.Now.AddDays(-3);
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    CreatedDateTime = new TimeSpanFilter() { To = to }
                }
            });
            Assert.AreEqual(0, docs.Documents.Count(a => a.CreatedDateTime > to), "Filter is not applied");
        }

        [TestMethod]
        public void GetInboxDocuments_FilterCreatedDateTimeToAndFrom()
        {
            var to = DateTime.Now.AddDays(-3);
            var from = DateTime.Now.AddDays(-8);
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    CreatedDateTime = new TimeSpanFilter() { To = to, From = from}
                }
            });
            Assert.AreEqual(0, docs.Documents.Count(a => a.CreatedDateTime > to && a.CreatedDateTime < from), "Filter is not applied");
        }

        [TestMethod]
        public void GetInboxDocuments_FilterModifiedDateTimeToAndFrom()
        {
            var to = DateTime.Now.AddDays(-3);
            var from = DateTime.Now.AddDays(-8);
            var docs = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    ModifiedDateTime = new TimeSpanFilter() { To = to, From = from }
                },
                Limit = 1
            });

            if(!docs.Documents.Any())
                return;

            var doc = EConnect.Client.GetInboxDocument(new GetInboxDocument()
                {
                    ConsignmentId = docs.Documents.First().ConsignmentId
                });
            }
    }
}
