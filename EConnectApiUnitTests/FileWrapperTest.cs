using System;
using System.IO;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class FileWrapperTest
    {
        const string _TestTextFile = @"OutputDir\small_base64.txt";
        const string _TestPdfFile = @"OutputDir\small.pdf";

        [TestMethod]
        [DeploymentItem(@"TestData\small.pdf", "OutputDir")]
        public void ReadFile()
        {
            var file = new GetDocumentPdfResponse();
            var bytes = File.ReadAllBytes(_TestPdfFile);
            file.Load(_TestPdfFile);
            
            Assert.AreEqual(bytes.Length, file.Contents.Length);
            Assert.AreEqual(bytes[10], file.Contents[10]);
            Assert.AreEqual(Convert.ToBase64String(bytes), file.PdfVersionFile);
        }

        [TestMethod]
        [DeploymentItem(@"TestData\small_base64.txt", "OutputDir")]
        [DeploymentItem(@"TestData\small.pdf", "OutputDir")]
        public void WriteFile()
        {
            var base64 = File.ReadAllText(_TestTextFile);
            var file = new FileWrapper("small_frombase64.pdf", base64);
            file.Store(@"OutputDir\");
            var pdffile = File.ReadAllBytes(@"OutputDir\small_frombase64.pdf");
            var bytes = File.ReadAllBytes(_TestPdfFile);
            Assert.AreEqual(bytes.Length, pdffile.Length);
        }
    }
}