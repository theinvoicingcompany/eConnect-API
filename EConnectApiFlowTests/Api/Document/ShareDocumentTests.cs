using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class ShareDocumentTests
    {
        [TestMethod]
        public void ShareDocument_FromEntity()
        {
            var inbox = EConnect.Client2.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                                                          {
                                                              EntityId = Properties.Settings.Default.EntityId2,
                                                              Limit = 1
                                                          });
            var doc = inbox.Documents.Single();

            EConnect.Client2.ShareDocument(new ShareDocument()
                             {
                                 DocumentId = doc.DocumentId,
                                 DocumentType = DocumentType.Inbox,
                                 ShareToUsers = new[]
                                                {
                                                    new ShareDocument.User()
                                                    {
                                                        Id = Properties.Settings.Default.RequesterId,
                                                        Permission = Permission.Read
                                                    }
                                                }
                             });

            var doc2 = EConnect.Client.GetDocument(new GetDocument()
                                         {
                                             DocumentId = doc.DocumentId
                                         });

            Assert.AreEqual(doc2, doc);
        }

        [TestMethod]
        public void ShareDocument_OfAnUser()
        {
            var docs = EConnect.Client.GetDocuments(new GetDocumentsOfAnUser()
                                                   {
                                                       Limit = 1
                                                   });
            var doc = docs.Documents.Single();

            var res = EConnect.Client.ShareDocument(new ShareDocument()
            {
                DocumentId = doc.DocumentId,
                DocumentType = DocumentType.Document,
                ShareToUsers = new[]
                                                {
                                                    new ShareDocument.User()
                                                    {
                                                        Id = Properties.Settings.Default.RequesterId2,
                                                        Permission = Permission.Edit
                                                    }
                                                }
            });

            Assert.AreEqual(doc.DocumentId, res.DocumentId);
            
            var doc2 = EConnect.Client2.GetDocument(new GetDocument()
            {
                DocumentId = doc.DocumentId
            });

            Assert.IsTrue((doc as EConnectApi.Definitions.EConnectDocument).Equals(doc2), "documents are not the same");
        }
    }
}