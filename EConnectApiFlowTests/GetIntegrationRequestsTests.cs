using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetIntegrationRequestsTests
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
            Assert.AreEqual("AIA0000002189223370595751039742000122", req.IntegrationId);
            Assert.AreEqual("everbinding.elien+notexist@gmail.com", req.RecipientEmail);
            Assert.AreEqual(IntegrationRequestStatus.Pending, req.Status);
            Assert.AreEqual("UA000000218000001", req.SenderUserId);
        }

        [TestMethod]
        public void GetIntegrationRequests_Paging()
        {
            var res = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
            {
                Limit = 2
            });

            //var req = res.IntegrationRequests.Single();

            var res2 = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
            {
                Limit = 2,
                StartRowRange = res.StartRowRange
            });

            //var req2 = res.IntegrationRequests.Single();

            Assert.AreNotEqual(res.StartRowRange, res2.StartRowRange);
            //Assert.AreNotEqual(req.IntegrationId, req2.IntegrationId);
        }
    }
}
