using System;
using System.Runtime.Remoting.Messaging;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class RequestAppIntegrationTests
    {


        [TestMethod]
        public void RequestAppIntegration()
        {

            //using (var client = new EConnectClient(new EConnectClientConfigBase()
            //    {
            //        ConsumerKey = "526a7076596841563941516f7746305",
            //        ConsumerSecret = "4668777978464b32317859337264484",
            //        RequesterId = "development@vismasoftware.nl"
            //    }
            //    ))
            //{
            //    //var integration = client.RequestAppIntegration(new RequestAppIntegration()
            //    //    {
            //    //        To = "thieme.vanselm@gmail.com"
            //    //    });

            //    //Assert.IsNotNull(integration.IntegrationRequestId);
            //    //Assert.AreNotEqual(string.Empty, integration.IntegrationRequestId);

            //    //var credentials = client.RequestIntegrationCredentials(new RequestIntegrationCredentials()
            //    //    {
            //    //        IntegrationRequestId = integration.IntegrationRequestId
            //    //    });

            //    //Assert.IsNotNull(credentials.AppIntegrationKey);

            //    //using (var client2 = new EConnectClient(new EConnectClientConfigBase()
            //    //    {
            //    //        ConsumerKey = credentials.AppIntegrationKey,
            //    //        ConsumerSecret = credentials.AppIntegrationSecret,
            //    //        RequesterId = credentials.ApproverId // ?
            //    //    }
            //    //    ))
            //    //{
            //        client.GetInboxDocuments(new GetInboxDocumentsFromEntity()
            //        {
            //            EntityId = "XCNL10019"
            //        });
            //    //}
            //}

            //using (var client = new EConnectClient(new EConnectClientConfigBase()
            //{
            //    ConsumerKey = "526a7076596841563941516f7746305",
            //    ConsumerSecret = "4668777978464b32317859337264484",
            //    RequesterId = "development@vismasoftware.nl"
            //}
            //    ))
            //{
            //    var form = DateTime.Now.AddDays(-30);
            //    // Load documents with selection
            //    var APIdocs = client.GetOutboxDocuments(new GetOutboxDocumentsFromEntity() 
            //    {

            //        //EntityId = Settings.Default.EntityID,
            //        EntityId = "XCNL10019",
            //        Limit = 10,

            //        Filters = new GetDocumentsFiltersBase()
            //        {
            //            //MasterTemplateId = "",
            //            CreatedDateTime = new TimeSpanFilter() { From = form }
            //        }
            //    });
            //}
        }

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
