using EConnectApi.Definitions;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class GetInboxDocumentsTests
    {
        [TestMethod]
        public void GetInboxDocumentsFromEntity()
        {
            var xml = @"<GetInboxDocuments xmlns=""http://ws.vg.pw.com/external/1.0"">
                <EntityId>XCNL10027</EntityId>
                <limit>25</limit>
                <startrowrange/>
            </GetInboxDocuments>";
            var request = new GetInboxDocumentsFromEntity()
                            {
                                EntityId = "XCNL10027",
                                Limit = 25,
                                StartRowRange = string.Empty
                            };

            Compare.IsObjectSameAsXml<GetInboxDocumentsFromEntity>(request, xml);
        }

        [TestMethod]
        public void GetInboxDocumentsFromGroup()
        {
            string xml = @"<GetInboxDocuments xmlns=""http://ws.vg.pw.com/external/1.0"">
               <GroupId>XGP3137087487318464</GroupId>
                <limit>25</limit>
                <startrowrange/>
            </GetInboxDocuments>";

            var request = new GetInboxDocumentsFromGroup()
            {
                GroupId = "XGP3137087487318464",
                Limit = 25,
                StartRowRange = string.Empty
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentsFromGroup>(request, xml);
        }

        [TestMethod]
        public void GetInboxDocumentsOfAnUser()
        {
            string xml = @"<GetInboxDocuments xmlns=""http://ws.vg.pw.com/external/1.0"">
                <limit>25</limit>
                <startrowrange/>
            </GetInboxDocuments>";

            var request = new GetInboxDocumentsOfAnUser()
            {
                Limit = 25,
                StartRowRange = string.Empty
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentsOfAnUser>(request, xml);
        }


        [TestMethod]
        public void GetUnreadInboxDocumentsOfAnUser()
        {
            string xml = @"<GetInboxDocuments xmlns=""http://ws.vg.pw.com/external/1.0"">
                <filters>
                    <IsRead>false</IsRead>
                </filters>                
                <limit>25</limit>
                <startrowrange/>
            </GetInboxDocuments>";

            var request = new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                              {
                                  IsRead = false
                              },
                Limit = 25,
                StartRowRange = string.Empty
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentsOfAnUser>(request, xml);
        }

        [TestMethod]
        public void GetUnreadInboxDocumentsOfAnUserSentFormAnEntity()
        {
            string xml = @"<GetInboxDocuments xmlns=""http://ws.vg.pw.com/external/1.0"">
                <filters>
                    <IsRead>false</IsRead>
                    <SenderEntityId>XCNL10027</SenderEntityId> 
                </filters>                
                <limit>25</limit>
                <startrowrange/>
            </GetInboxDocuments>";

            var request = new GetInboxDocumentsOfAnUser()
            {
                Filters = new GetDocumentsFiltersBase()
                {
                    IsRead = false,
                    SenderEntityId = "XCNL10027"
                },
                Limit = 25,
                StartRowRange = string.Empty
            };

            Compare.IsObjectSameAsXml<GetInboxDocumentsOfAnUser>(request, xml);
        }

        [TestMethod]
        public void GetInboxDocumentsReponse()
        {
            string xml =
                @"<GetInboxDocumentsResponse>
                    <tuple>
                        <rowkey>CUA000000191000001INCC9223370651617362923UA000000191000001</rowkey>
                        <SenderAccountId>A000000191</SenderAccountId>
                        <SenderAccountName>selmit.nl</SenderAccountName>
                        <CreatedDateTime>1385237412946</CreatedDateTime>
                        <ConsignmentId>CUA000000191000001INCC9223370651617362923UA000000191000001</ConsignmentId>
                        <ConsignmentName>Afas test factuur</ConsignmentName>
                        <DocumentId>RA000000191DMP2000009</DocumentId>
                        <ExternalId>XCNIN10280</ExternalId>
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
                    </tuple></GetInboxDocumentsResponse>";

            var response = new GetInboxDocumentsResponse()
                               {
                                   Documents = new[]
                                                   {
                                                       new DocumentBase() 
                                                           {
                                                               SenderAccountId = "A000000191",
                                                               SenderAccountName = "selmit.nl",
                                                               RawCreatedDateTime = 1385237412946,
                                                               ConsignmentId = "CUA000000191000001INCC9223370651617362923UA000000191000001",
                                                               ConsignmentName = "Afas test factuur",
                                                               DocumentId = "RA000000191DMP2000009",
                                                               ExternalId = "XCNIN10280",
                                                               IsRead = false,
                                                               IsTask = 0,
                                                               LatestStatus = " ",
                                                               LatestStatusCode = "10",
                                                               LatestStatusInfo = " ",
                                                               Subject = "Afas test factuur",
                                                               StandardTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                                                               StandardTemplateName = "SimplerInvoicing Factuur - UBL2.0 Standard",
                                                               Type = "Inbox",
                                                               SenderUserId = "UA000000191000001",
                                                               SenderUserName = "Thieme",
                                                               DocumentViewerId = "GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3",
                                                               DocumentViewerName = "SimplerInvoicing Factuur - UBL2.0 Standard"   
                                                           }
                                                   }
                               };

            Compare.IsObjectSameAsXml<GetInboxDocumentsResponse>(response, xml);
        }
    }
}
