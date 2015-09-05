using System;
using System.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
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
                Limit = 1
            });

            var req = res.IntegrationRequests.Single();

            var res2 = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
            {
                Limit = 1,
                StartRowRange = res.StartRowRange
            });

            var req2 = res.IntegrationRequests.Single();

            Assert.AreNotEqual(res.StartRowRange, res2.StartRowRange);
            Assert.AreNotEqual(req.IntegrationId, req2.IntegrationId);
        }

        [TestMethod]
        public void GetIntegrationRequests_RequestIntegrationCredentials_GetInboxDocuments()
        {
            var res = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
            {
                Limit = 1,
                Filters = new GetIntegrationRequests.GetIntegrationRequestsFilters()
                          {
                              Status = IntegrationRequestStatus.Accepted
                          }
            });

            var req = res.IntegrationRequests.Single();
            var cred = EConnect.Client.RequestIntegrationCredentials(new RequestIntegrationCredentials()
                                                          {
                                                              IntegrationRequestId = req.RequestTrackingId
                                                          });

            Assert.IsNotNull(cred.AppIntegrationKey);
            Assert.IsNotNull(cred.AppIntegrationSecret);
            Assert.IsNotNull(cred.ApproverId);

            using (var client = new EConnectClient(new EConnectClientConfigBase()
                                                   {
                                                       ConsumerKey = cred.AppIntegrationKey,
                                                       ConsumerSecret = cred.AppIntegrationSecret,
                                                       RequesterId = cred.ApproverId
                                                   }))
            {
                var inbox = client.GetInboxDocuments(new GetInboxDocumentsFromEntity()
                                                     {
                                                         EntityId = req.RecipientCompanyEntityId,
                                                         Limit = 1
                                                     });
                Assert.IsNotNull(inbox);
            }
        }



        [TestMethod]
        public void RequestAppIntegration_GetIntegrationRequests_RequestIntegrationCredentials()
        {
            var email = Properties.Settings.Default.RequesterId2;
            var start = DateTime.Now;

            // Send integration request
            var req = EConnect.Client.RequestAppIntegration(new RequestAppIntegration()
                                                  {
                                                      To = email,
                                                      EmailAddress = email,
                                                      PayByRequester = true
                                                  });
            // Get integration details
            var res = EConnect.Client.GetIntegrationRequests(new GetIntegrationRequests()
                                                   {
                                                       Filters = new GetIntegrationRequests.GetIntegrationRequestsFilters()
                                                                 {
                                                                     TrackingId = req.IntegrationRequestId
                                                                 }
                                                   });

            var req2 = res.IntegrationRequests.Single();

            // Validate integration details
            Assert.AreEqual(req.IntegrationRequestId, req2.RequestTrackingId);
            Assert.AreEqual(true, req2.PayByRequester);
            Assert.AreEqual(email, req2.RecipientEmail);
            Assert.AreEqual("A000000218", req2.SenderAccountId);
            Assert.AreEqual("eLien", req2.SenderAccountName);
            Assert.AreEqual("Unit Test User Een", req2.SenderUserName);
            Assert.AreEqual("UA000000218000027", req2.SenderUserId);
            Assert.AreEqual("Unit Test Koppeling", req2.AppName);
            Assert.AreEqual(IntegrationRequestStatus.Pending, req2.Status);
            // Validate time. Time between 3min is oke
            DateUtils.ValidateDateTimeBetween(start, req2.RequestedDateTime, new TimeSpan(0, 0, 3));

            // Get crededntials (should be empty because Status = Pending
            var cred = EConnect.Client.RequestIntegrationCredentials(new RequestIntegrationCredentials()
                                                          {
                                                              IntegrationRequestId = req.IntegrationRequestId
                                                          });

            Assert.IsNull(cred.AppIntegrationKey);
            Assert.IsNull(cred.AppIntegrationSecret);
            Assert.IsNotNull(cred.ErrorMessage);
        }
    }
}
