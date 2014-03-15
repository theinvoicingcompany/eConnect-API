using System;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class RequestAppIntegrationTests
    {
        //[TestMethod]
        //public void RequestAppIntegration()
        //{
        //    using (var client = new EConnectClient(new EConnectClientConfigBase()
        //        {
        //            ConsumerKey = "",
        //            ConsumerSecret = "",
        //            RequesterId = ""
        //        }
        //        ))
        //    {
        //        var integration = client.RequestAppIntegration(new RequestAppIntegration()
        //            {
        //                To = ""
        //            });

        //        Assert.IsNotNull(integration.IntegrationRequestId);
        //        Assert.AreNotEqual(string.Empty, integration.IntegrationRequestId);

        //        var credentials = client.RequestIntegrationCredentials(new RequestIntegrationCredentials()
        //            {
        //                IntegrationRequestId = integration.IntegrationRequestId
        //            });

        //        Assert.IsNotNull(credentials.AppIntegrationKey);

        //         using (var client2 = new EConnectClient(new EConnectClientConfigBase()
        //        {
        //            ConsumerKey = credentials.AppIntegrationKey,
        //            ConsumerSecret = credentials.AppIntegrationSecret,
        //            RequesterId = credentials.ApproverId // ?
        //        }
        //        ))
        //         {
        //             client2.Ping();
        //         }
        //    }
        //}
    }
}
