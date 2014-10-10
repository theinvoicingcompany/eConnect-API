using System;
using System.IO;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class FileWrapperTest
    {
        private string base64 = @"MjAxNC8wNi8yNCAxNDoyODowOSBTdGFydGluZyBjeWd3aW
                            oyODowOSBVc2VyIGhhcyBiYWNrdXAvcmVzdG9yZSByaWdodHMN
                            CjIwMTQvMDYvMjQgMTQ6Mjg6MDkgaW9fc3RyZWFtX2N5Z2ZpbGU6
                            IGZvcGVuKC9ldGMvc2V0dXAvc2V0dXAucmMpIGZhaWxlZCAyIE5vIHN1
                            Y2ggZmlsZSBvciBkaXJlY3Rvcg==";

        [TestMethod]
        public void WriteFile()
        {
            var file = new FileWrapper("test.pdf", base64);
            file.Store(@"C://Temp/");
        }

        [TestMethod]
        public void ReadFile()
        {
            var testfile = @"C://Temp/econnecttest.pdf";  
            var file = new GetDocumentPdfResponse();
            var bytes = File.ReadAllBytes(testfile);
            file.Load(testfile);
            Assert.AreEqual(bytes, file.Contents);
            Assert.AreEqual(Convert.ToBase64String(bytes), file.PdfVersionFile);
            file.Store(@"C://Temp/", "econnecttestnew.pdf");
        }
    }
}