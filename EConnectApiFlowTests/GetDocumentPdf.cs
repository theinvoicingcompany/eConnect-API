using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetDocumentPdfTest
    {
        private void ValidatePdf(GetDocumentPdfResponse test)
        {
            // Save it
            var targetdir = Directory.GetCurrentDirectory();

            test.Store(targetdir, test.DocumentId + "test.pdf");

            // Test it
            Assert.IsNotNull(test.DocumentFileName);
            var filepath = Path.Combine(targetdir, test.DocumentId + "test.pdf");
            Assert.IsTrue(File.Exists(filepath));

            // Cleanup
            File.Delete(filepath);
        }

        [TestMethod]
        public void DownloadAndStorePdf()
        {
            // Download PDF form first inbox doc
            var doc1 = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1 }).Documents.First();
            var test = EConnect.Client.GetDocumentPdf(new GetDocumentPdf() { ConsignmentId = doc1.ConsignmentId });

            ValidatePdf(test);
        }

        [TestMethod]
        public void TestNormalPdf()
        {
            var externalId = "XCNIN44018";
            var result = EConnect.Client.GetOutboxDocument(new GetOutboxDocument()
            {
                ExternalId = externalId
            });

            var pdfbase64 = result.Payload.Descendants("{urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2}EmbeddedDocumentBinaryObject").FirstOrDefault();
            Assert.AreEqual(null, pdfbase64);

            var test = EConnect.Client.GetDocumentPdf(new GetDocumentPdf() { ExternalId = externalId });
            ValidatePdf(test);
        }
    }
}