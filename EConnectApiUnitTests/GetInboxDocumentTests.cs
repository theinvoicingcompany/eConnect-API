using System;
using System.Xml.Linq;
using EConnectApi.Definitions;
using EConnectApi.Helpers;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class GetInboxDocumentTests
    {
        [TestMethod]
        public void GetInboxDocument()
        {
            var xml = @"<GetInboxDocument xmlns=""http://ws.vg.pw.com/external/1.0"">
                        <ConsignmentId>CLEA0000000149223370677397471774EXCNL000002INCC9223370677387815337UA000000014000003</ConsignmentId>
                       </GetInboxDocument>";
            var request = new GetInboxDocument() { ConsignmentId = "CLEA0000000149223370677397471774EXCNL000002INCC9223370677387815337UA000000014000003" };

            Compare.IsObjectSameAsXml<GetInboxDocument>(request, xml);
        }

        [TestMethod]
        public void GetInboxDocumentResponse()
        {
            var payload = @"<urn:Invoice xmlns:urn=""urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"" xmlns:urn1=""urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"" xmlns:urn2=""urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"">
                  <urn1:UBLVersionID xmlns:urn1=""urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"">2.0</urn1:UBLVersionID>
            </urn:Invoice>";

            var xml =
                string.Format(@"<GetInboxDocumentResponse>
                <Payload>{0}</Payload>
                <RuleApplicable><Rules/></RuleApplicable>
                <SenderAccountId>A000000191</SenderAccountId>
                <SenderAccountName>selmit.nl</SenderAccountName>
                <CreatedDateTime>1385244409859</CreatedDateTime>
                <ConsignmentId>CUA000000191000001INCC9223370651610366013UA000000191000001</ConsignmentId>
                <ConsignmentName>Afas test factuur</ConsignmentName>
                <DocumentId>RA000000191DMP1000009</DocumentId>
                <ExternalId>XCNIN10281</ExternalId>
                <IsRead>false</IsRead>
                <IsTask>0</IsTask>
                <LatestStatusCode>10</LatestStatusCode>
                <LatestStatusInfo> </LatestStatusInfo>
                <LatestStatus> </LatestStatus>
                <Subject>Afas test factuur</Subject>
                <StandardTemplateId>GLDT9223370666504283001RA000000006DTP2000001</StandardTemplateId>
                <StandardTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</StandardTemplateName>
                <Type>Inbox</Type>
                <SenderUserId>UA000000191000001</SenderUserId>
                <SenderUserName>Thieme</SenderUserName>
                <DocumentViewerId>GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3</DocumentViewerId>
                <DocumentViewerName>SimplerInvoicing Factuur - UBL2.0 Standard</DocumentViewerName>
                <PossibleConsignmentStatuses>consignmentstatus1:Afgeleverd:10,consignmentstatus2:Gelezen:20,consignmentstatus3:Verwerkt:30,consignmentstatus4:Goedgekeurd:40,consignmentstatus5:Afgewezen:50,defaultstatus:Afgeleverd:10</PossibleConsignmentStatuses>
                </GetInboxDocumentResponse>", payload);

            var response = new GetInboxDocumentResponse()
            {
                Payload = XElement.Parse(payload),
                RuleApplicable = new RuleApplicable() { Rules = string.Empty },
                SenderAccountId = "A000000191",
                SenderAccountName = "selmit.nl",
                RawCreatedDateTime = 1385244409859,
                ConsignmentId = "CUA000000191000001INCC9223370651610366013UA000000191000001",
                ConsignmentName = "Afas test factuur",
                DocumentId = "RA000000191DMP1000009",
                ExternalId = "XCNIN10281",
                IsRead = false,
                IsTask = 0,
                LatestStatusCode = 10,
                LatestStatusInfo = " ",
                LatestStatus = " ",
                Subject = "Afas test factuur",
                StandardTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                StandardTemplateName = "SimplerInvoicing Factuur - UBL2.0 Standard",
                Type = "Inbox",
                SenderUserId = "UA000000191000001",
                SenderUserName = "Thieme",
                DocumentViewerId =
                    "GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3",
                DocumentViewerName = "SimplerInvoicing Factuur - UBL2.0 Standard",
                RawPossibleConsignmentStatuses =
                    "consignmentstatus1:Afgeleverd:10,consignmentstatus2:Gelezen:20,consignmentstatus3:Verwerkt:30,consignmentstatus4:Goedgekeurd:40,consignmentstatus5:Afgewezen:50,defaultstatus:Afgeleverd:10"
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentResponse>(response, xml);
        }


        //[TestMethod]
        public void GetInboxDocumentResponse2()
        {
            var payload = @"<urn:Invoice xmlns:urn=""urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"" xmlns:urn1=""urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"" xmlns:urn2=""urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"">
                  <urn1:UBLVersionID xmlns:urn1=""urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"">2.0</urn1:UBLVersionID>
            </urn:Invoice>";

            var xml =
                string.Format(@"<GetInboxDocumentResponse xmlns="""">
      <Payload>{0}</Payload>
      <RuleApplicable>
        <Rules/>
      </RuleApplicable>
      <SenderAccountId>A000000191</SenderAccountId>
      <SenderAccountName>selmit.nl</SenderAccountName>
      <CreatedDateTime>1391346404385</CreatedDateTime>
      <ConsignmentId>CUA000000191000001INCC9223370645588146187UA000000191000001</ConsignmentId>
      <ConsignmentName>Afas test factuur a2ff6d37-d8e6-475a-a11b-1b372a5fdc63</ConsignmentName>
      <DocumentId>RA000000191DMP1000014</DocumentId>
      <ExternalId>XCNIN10639</ExternalId>
      <IsRead>false</IsRead>
      <IsTask>0</IsTask>
      <LatestStatusCode>10</LatestStatusCode>
      <LatestStatusInfo>UA000000191000001:Thieme:A000000191:selmit.nl:1391346403251</LatestStatusInfo>
      <LatestStatus>Afgeleverd:UA000000191000001:Thieme:A000000191:selmit.nl:1391346403249</LatestStatus>
      <MasterTemplateId>RA000000006DTP2000001</MasterTemplateId>
      <MasterTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</MasterTemplateName>
      <Subject>Afas test factuur a2ff6d37-d8e6-475a-a11b-1b372a5fdc63</Subject>
      <StandardTemplateId>GLDT9223370666504283001RA000000006DTP2000001</StandardTemplateId>
      <StandardTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</StandardTemplateName>
      <DocumentTemplateId>GLDT9223370666504283001RA000000006DTP2000001</DocumentTemplateId>
      <TrackingMessage>EM0001</TrackingMessage>
      <DocumentTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</DocumentTemplateName>
      <TemplateSchemaId>RTSP2000003</TemplateSchemaId>
      <Type>Inbox</Type>
      <SenderUserId>UA000000191000001</SenderUserId>
      <SenderUserName>Thieme</SenderUserName>
      <DocumentViewerId>GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3</DocumentViewerId>
      <DocumentViewerName>SimplerInvoicing Factuur - UBL2.0 Standard</DocumentViewerName>
      <PossibleConsignmentStatuses>
        <ConsignmentStatus>
          <consignmentstatus1 StatusCode=""10"">Afgeleverd</consignmentstatus1>
          <consignmentstatus2 StatusCode=""20"">Gelezen</consignmentstatus2>
          <consignmentstatus3 StatusCode=""30"">Verwerkt</consignmentstatus3>
          <consignmentstatus4 StatusCode=""40"">Goedgekeurd</consignmentstatus4>
          <consignmentstatus5 StatusCode=""50"">Afgewezen</consignmentstatus5>
          <defaultstatus StatusCode=""10"">Afgeleverd</defaultstatus>
        </ConsignmentStatus>
      </PossibleConsignmentStatuses>
    </GetInboxDocumentResponse>", payload);

            var response = new GetInboxDocumentResponse()
            {
                Payload = XElement.Parse(payload),
                RuleApplicable = new RuleApplicable() { Rules = string.Empty },
                SenderAccountId = "A000000191",
                SenderAccountName = "selmit.nl",
                RawCreatedDateTime = 1385244409859,
                ConsignmentId = "CUA000000191000001INCC9223370651610366013UA000000191000001",
                ConsignmentName = "Afas test factuur",
                DocumentId = "RA000000191DMP1000009",
                ExternalId = "XCNIN10281",
                IsRead = false,
                IsTask = 0,
                LatestStatusCode = 10,
                LatestStatusInfo = " ",
                LatestStatus = " ",
                Subject = "Afas test factuur",
                StandardTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                StandardTemplateName = "SimplerInvoicing Factuur - UBL2.0 Standard",
                Type = "Inbox",
                SenderUserId = "UA000000191000001",
                SenderUserName = "Thieme",
                DocumentViewerId =
                    "GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3",
                DocumentViewerName = "SimplerInvoicing Factuur - UBL2.0 Standard",
                RawPossibleConsignmentStatuses =
                    "consignmentstatus1:Afgeleverd:10,consignmentstatus2:Gelezen:20,consignmentstatus3:Verwerkt:30,consignmentstatus4:Goedgekeurd:40,consignmentstatus5:Afgewezen:50,defaultstatus:Afgeleverd:10"
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentResponse>(response, xml);
        }

    }
}
