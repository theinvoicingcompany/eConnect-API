using System;
using EConnectApi.Definitions;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class GetInboxDocumentStatusTest
    {
        [TestMethod]
        public void GetInboxDocumentStatusResponse()
        {
            var xml = @"<GetInboxDocumentStatusResponse>
                            <Status>Gelezen</Status>
                            <StatusCode>20</StatusCode>
                            <StatusSetByUserId>UA000000191000001</StatusSetByUserId>
                            <StatusSetByUserName>Thieme</StatusSetByUserName>
                            <StatusSetByAccountId>A000000191</StatusSetByAccountId>
                            <StatusSetByAccountName>selmit.nl</StatusSetByAccountName>
                            <StatusDate>1388767018104</StatusDate>
                        </GetInboxDocumentStatusResponse>";

            var request = new GetInboxDocumentStatusResponse()
                {
                    Status = "Gelezen",
                    StatusCode = 20,
                    StatusSetByUserId = "UA000000191000001",
                    StatusSetByUserName = "Thieme",
                    StatusSetByAccountId = "A000000191",
                    StatusSetByAccountName = "selmit.nl",
                    StatusDate = 1388767018104
                };

            Compare.IsObjectSameAsXml<GetInboxDocumentStatusResponse>(request, xml);
        }

        [TestMethod]
        public void GetInboxDocumentStatus()
        {
            var xml = @"<GetInboxDocumentStatus xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://ws.vg.pw.com/external/1.0"">
  <ConsignmentId>CUA000000191000001INCC9223370651610366013UA000000191000001</ConsignmentId>
</GetInboxDocumentStatus>";

            var request = new GetInboxDocumentStatus()
            {
                ExternalId = "CUA000000191000001INCC9223370651610366013UA000000191000001"
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentStatus>(request, xml);
        }
    }
}
