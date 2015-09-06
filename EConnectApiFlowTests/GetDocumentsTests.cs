using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetDocumentsTests
    {
        [TestMethod]
        public void GetDocuments_Paging()
        {
            var document = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = 1 }).Documents.First();

            var result = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = 2 });
            Assert.IsNotNull(result);
            var doc = result.Documents.First();
            Assert.AreEqual(document.Rowkey, doc.Rowkey);
            Assert.AreEqual(document.CreatedDateTime, doc.CreatedDateTime);
            Assert.AreEqual(document.DocumentId, doc.DocumentId);

            var result2 = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser() { Limit = 2, StartRowRange = result.StartRowRange });
            Assert.IsNotNull(result2);
            var doc2 = result2.Documents.First();
            Assert.AreEqual(result.StartRowRange, doc2.Rowkey, "RowStartRowRange and RowKey are not equal");
            Assert.AreNotEqual(document.CreatedDateTime, doc2.CreatedDateTime);
            Assert.AreNotEqual(document.DocumentId, doc2.DocumentId);
        }

        // TODO implement filter test for GetDocuments
    }
}
