using System;
using System.IO;
using EConnectApi.Definitions;
using EConnectApi.Helpers;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class GetDocumentPdfTest
    {
        [TestMethod]
        public void GetDocumentPdfResponse()
        {
            const string base64 = @"MjAxNC8wNi8yNCAxNDoyODowOSBTdGFydGluZyBjeWd3aW
                        oyODowOSBVc2VyIGhhcyBiYWNrdXAvcmVzdG9yZSByaWdodHMN
                        CjIwMTQvMDYvMjQgMTQ6Mjg6MDkgaW9fc3RyZWFtX2N5Z2ZpbGU6
                        IGZvcGVuKC9ldGMvc2V0dXAvc2V0dXAucmMpIGZhaWxlZCAyIE5vIHN1
                        Y2ggZmlsZSBvciBkaXJlY3Rvcg==";
            var xml = string.Format(@"<GetDocumentPDFResponse><DocumentId/><DocumentFileName>Test.pdf</DocumentFileName><PDFVersionFile>{0}</PDFVersionFile></GetDocumentPDFResponse>", base64);

            var obj = new GetDocumentPdfResponse()
            {
                DocumentFileName = "Test.pdf",
                PdfVersionFile = base64,
                DocumentId = ""
            };

            Compare.IsObjectSameAsXml<GetDocumentPdfResponse>(obj, xml);
        }
    }
}