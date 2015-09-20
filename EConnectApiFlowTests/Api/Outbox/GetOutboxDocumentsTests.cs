using System;
using System.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Outbox
{
    [TestClass]
    public class GetOutboxDocumentsTests
    {
        #region Helpers
        public GetOutboxDocumentsResponse GetDocuments(IOutboxDocumentsRequest parameters)
        {
            var get = (parameters as GetDocumentsBase);
            Assert.IsNotNull(get);
            if (get.Limit == 10)
                get.Limit = 1;

            var page1 = EConnect.Client.GetOutboxDocuments(parameters);
            if (page1.Documents == null)
                Assert.Inconclusive("No documents returned");

            Assert.AreEqual(page1.Documents.Length, get.Limit);
            Assert.IsNotNull(page1.StartRowRange);
            return page1;
        }

        public void TestFilter(GetDocumentsFiltersBase filter)
        {
            var page1 = GetDocuments(new GetOutboxDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId,
                Filters = filter
            });

            DocumentsRequesterFilters.Validate(filter, page1.Documents.Select(d=> d as DocumentBase).ToArray());
        }
        #endregion

        [TestMethod]
        public void GetOutboxDocuments_FromEntity()
        {
            GetDocuments(new GetOutboxDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId
            });
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException))]
        public void GetOutboxDocuments_WrongFromEntity()
        {
            GetDocuments(new GetOutboxDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId2
            });
        }

        [TestMethod]
        public void GetOutboxDocuments_Paging()
        {
            const byte limit = 2;
            var page1 = GetDocuments(new GetOutboxDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId,
                Limit = limit
            });
            Assert.AreEqual(limit, page1.Documents.Length);

            var page2 = GetDocuments(new GetOutboxDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId,
                Limit = limit,
                StartRowRange = page1.StartRowRange
            });
            Assert.AreEqual(limit, page2.Documents.Length);
            Assert.AreNotEqual(page1.Documents[0], page2.Documents[0]);
            Assert.AreNotEqual(page1.StartRowRange, page2.StartRowRange);
        }

        [TestMethod]
        public void GetOutboxDocuments_FromGroup()
        {
            GetDocuments(new GetOutboxDocumentsFromGroup()
            {
                GroupId = "XGI214007441664201365"
            });
        }

        [TestMethod]
        public void GetOutboxDocuments_OfAnUser()
        {
            GetDocuments(new GetOutboxDocumentsOfAnUser());
        }

        [TestMethod]
        public void GetOutboxDocuments_FilterIsReadFalse()
        {
            TestFilter(DocumentsRequesterFilters.IsReadFalse);
        }

        [TestMethod]
        public void GetOutboxDocuments_FilterIsReadTrue()
        {
            TestFilter(DocumentsRequesterFilters.IsReadTrue);
        }

        [TestMethod]
        public void GetOutboxDocuments_FilterCreatedDateTime1()
        {
            TestFilter(DocumentsRequesterFilters.CreatedDateTime1);
        }

        [TestMethod]
        public void GetOutboxDocuments_FilterCreatedDateTime2()
        {
            TestFilter(DocumentsRequesterFilters.CreatedDateTime2);
        }

        [TestMethod]
        public void GetOutboxDocuments_FilterModifiedDateTime1()
        {
            TestFilter(DocumentsRequesterFilters.ModifiedDateTime1);
        }
    }
}