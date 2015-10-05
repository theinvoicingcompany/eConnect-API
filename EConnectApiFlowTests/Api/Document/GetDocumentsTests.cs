using System.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class GetDocumentsTests
    {
        #region Helpers
        public GetDocumentsResponse GetDocuments(IDocumentsRequest parameters)
        {
            var get = (parameters as GetDocumentsBase);
            Assert.IsNotNull(get);
            if (get.Limit == 10)
                get.Limit = 1;

            var page1 = EConnect.Client.GetDocuments(parameters);
            if (page1.Documents == null)
                Assert.Inconclusive("No documents returned");

            Assert.AreEqual(page1.Documents.Length, get.Limit);
            return page1;
        }

        protected GetDocumentsResponse TestFilter(GetDocumentsFiltersBase filter)
        {
            var page1 = GetDocuments(new GetDocumentsOfAnUser()
            {
                Filters = filter
            });

            DocumentsRequesterFilters.Validate(filter, page1.Documents.Select(d => d as DocumentShared).ToArray());

            return page1;
        }
        #endregion

        [TestMethod]
        public void GetDocuments_FromEntity()
        {
            GetDocuments(new GetDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId
            });
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException))]
        public void GetDocuments_WrongEntity()
        {
            GetDocuments(new GetDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId2,
            });
        }

        [TestMethod]
        public void GetDocuments_Paging()
        {
            const byte limit = 2;
            var page1 = GetDocuments(new GetDocumentsOfAnUser()
            {
                Limit = limit
            });
            Assert.AreEqual(limit, page1.Documents.Length);

            var page2 = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser()
            {
                Limit = limit,
                StartRowRange = page1.StartRowRange
            });
            Assert.AreEqual(limit, page2.Documents.Length);
            Assert.AreNotEqual(page1.Documents[0], page2.Documents[0]);
            Assert.AreNotEqual(page1.StartRowRange, page2.StartRowRange);
        }

        [TestMethod]
        public void GetDocuments_FilterCreatedDateTime1()
        {
            TestFilter(DocumentsRequesterFilters.CreatedDateTime1);
        }

        [TestMethod]
        public void GetDocuments_FilterCreatedDateTime2()
        {
            TestFilter(DocumentsRequesterFilters.CreatedDateTime2);
        }

        [TestMethod]
        public void GetDocuments_FilterModifiedDateTime1()
        {
            TestFilter(DocumentsRequesterFilters.ModifiedDateTime1);
        }

        [TestMethod]
        public void GetDocuments_FilterExternalId()
        {
            TestFilter(new GetDocumentsFiltersBase() { ExternalId = "XDFR1442214082161" });
        }

        [TestMethod]
        public void GetDocuments_FilterDocumentId()
        {
            var doc = TestFilter(new GetDocumentsFiltersBase() { DocumentId = "RA000000218DMP1000215" }).Documents.First();
            Assert.AreEqual("RA000000218DTL1000001", doc.DocumentTemplateId);
            Assert.AreEqual("User", doc.TemplateSource);
        }

        [TestMethod]
        public void GetDocuments_FilterDocumentTemplateId()
        {
            TestFilter(new GetDocumentsFiltersBase() { DocumentTemplateId = "RA000000218DTL1000001" });
        }
    }
}
