using System;
using System.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Integration
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void GetIntegrationRequests()
        {
            var res = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
                                                             {
                                                                 Filters = new GetIntegrationRequests.GetIntegrationRequestsFilters()
                                                                           {
                                                                               TrackingId = "AINRwk226bS5cf8qHPXgLTU2vQpQ9WCJBJ6g"
                                                                           }
                                                             });

            var req = res.IntegrationRequests.Single();
            Assert.AreEqual("everbinding.elien+notexist@gmail.com", req.RecipientEmail);
            Assert.AreEqual(IntegrationRequestStatus.Pending, req.Status);
            Assert.AreEqual("UA000000218000001", req.SenderUserId);
        }

        [TestMethod]
        public void GetIntegrationRequests_Paging()
        {
            var res = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
                                                             {
                                                                 Limit = 1
                                                             });

            var req = res.IntegrationRequests.Single();

            var res2 = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
                                                              {
                                                                  Limit = 1,
                                                                  Cursor = res.Cursor
                                                              });

            var req2 = res.IntegrationRequests.Single();

            Assert.AreNotEqual(res.Cursor, res2.Cursor);
            Assert.AreNotEqual(req.RequestedDateTime, req2.RequestedDateTime);
            Assert.AreNotEqual(req.ActivatedDateTime, req2.ActivatedDateTime);
        }
    }
}
