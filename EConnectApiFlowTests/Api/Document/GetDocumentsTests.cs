using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class GetDocumentsTests
    {
        [TestMethod]
        public void GetDocuments_Entity()
        {
            const byte limit = 1;
            var page1 = EConnect.Client.GetDocuments(new GetDocumentsFromEntity()
                                                     {
                                                         EntityId = Properties.Settings.Default.EntityId,
                                                         Limit = limit
                                                     });
            Assert.IsNotNull(page1.Documents);
            Assert.AreEqual(page1.Documents.Length, limit);
            Assert.IsNotNull(page1.StartRowRange);
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException))]
        public void GetDocuments_WrongEntity()
        {
            EConnect.Client.GetDocuments(new GetDocumentsFromEntity()
            {
                EntityId = Properties.Settings.Default.EntityId2,
                Limit = 1
            });
        }

        [TestMethod]
        public void GetDocuments_Paging()
        {
            const byte limit = 2;
            var page1 = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = limit });
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

        protected void TestFilter(GetDocumentsFiltersBase filter)
        {
            var page1 = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser()
            {
                Filters = filter
            });

            DocumentsRequesterFilters.Validate(filter, page1.Documents);
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
            TestFilter(new GetDocumentsFiltersBase() { DocumentId = "RA000000218DMP1000215" });
        }
        [TestMethod]
        public void GetDocuments_FilterDocumentTemplateId()
        {
            TestFilter(new GetDocumentsFiltersBase() { DocumentTemplateId = "RA000000218DTL1000001" });
        }
    }
}
