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
        [TestMethod]
        public void DownloadAndStorePdf()
        {
            // Download PDF form first inbox doc
            var doc1 = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser()).Documents.First();
            var test = EConnect.Client.GetDocumentPdf(new GetDocumentPdf() { ConsignmentId = doc1.ConsignmentId });

            // Save it
            var targetdir = Directory.GetCurrentDirectory();
            test.Store(targetdir, "test.pdf");

            // Test it
            Assert.IsNotNull(test.DocumentFileName);
            var filepath = Path.Combine(targetdir, "test.pdf");
            Assert.IsTrue(File.Exists(filepath));

            // Cleanup
            File.Delete(filepath);
        }
    }
}