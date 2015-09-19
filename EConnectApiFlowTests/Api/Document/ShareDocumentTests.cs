using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Document
{
    [TestClass]
    public class ShareDocumentTests
    {
        public void AreSameDocuments(DocumentBase target, DocumentDetails actual)
        {
            Assert.AreEqual(target.DocumentId, actual.DocumentId);
            Assert.AreEqual(target.Subject, actual.Subject);
            Assert.AreEqual(target.OwnerUserId, actual.OwnerUserId);
            Assert.AreEqual(target.ExternalId, actual.ExternalId);
        }

        [TestMethod]
        public void ShareDocument()
        {
            var inbox = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                                                          {
                                                              EntityId = Properties.Settings.Default.EntityId,
                                                              Limit = 1
                                                          });
            var doc = inbox.Documents.Single();

            EConnect.Client.ShareDocument(new ShareDocument()
                             {
                                 DocumentId = doc.DocumentId,
                                 DocumentType = DocumentType.Inbox,
                                 ShareToUsers = new[]
                                                {
                                                    new ShareDocument.User()
                                                    {
                                                        Id = Properties.Settings.Default.RequesterId2,
                                                        Permission = Permission.Read
                                                    }
                                                }
                             });

            var doc2 = EConnect.Client2.GetDocument(new GetDocument()
                                         {
                                             DocumentId = doc.DocumentId
                                         });

            AreSameDocuments(doc, doc2);
        }

        [TestMethod]
        public void ShareDocument2()
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

            //var res2d = EConnect.Client2.GetDocuments(new GetDocumentsOfAnUser()
            //                              {
            //                                  Limit = 1
            //                              });

            //var doc2d = res2d.Documents.Single();
            var doc2 = EConnect.Client2.GetDocument(new GetDocument()
            {
                DocumentId = doc.DocumentId
            });

            AreSameDocuments(doc as DocumentBase, doc2);
        }
    }
}