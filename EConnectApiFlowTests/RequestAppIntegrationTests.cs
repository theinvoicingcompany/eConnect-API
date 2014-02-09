using System;
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
            var result = EConnect.Client.RequestAppIntegration(new RequestAppIntegration()
                {
                    To = "A000000202"
                });

            throw new NotImplementedException();
        }

        [TestMethod]
        public void RequestIntegrationCredentials()
        {
            var result = EConnect.Client.RequestIntegrationCredentials(new RequestIntegrationCredentials()
            {
                IntegrationRequestId = "A000000202"
            });
            
            throw new NotImplementedException();
        }
    }
}
