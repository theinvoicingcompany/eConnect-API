using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class EConnectClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(EConnectClientException), "Invalid consumer key or no such app available in registry")]
        public void WrongConsumerKey()
        {
            var client = new EConnectClient(new EConnectClientConfigBase()
                {
                    ConsumerKey = "wrong",
                    ConsumerSecret = Properties.Settings.Default.ConsumerSecret,
                    RequesterId = Properties.Settings.Default.RequesterId
                });
            client.Ping();
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException), "Invalid signature.  Check OAuth credentials.")]
        public void WrongConsumerSecret()
        {
            var client = new EConnectClient(new EConnectClientConfigBase()
            {
                ConsumerKey = Properties.Settings.Default.ConsumerKey,
                ConsumerSecret = "wrong",
                RequesterId = Properties.Settings.Default.RequesterId
            });

            client.Ping();
        }

        //[TestMethod]
        //[ExpectedException(typeof(EConnectClientException), "Invalid consumer key or no such app available in registry")]
        //public void WrongRequesterId()
        //{
        //    var client = new EConnectClient(new EConnectClientConfigBase()
        //    {
        //        ConsumerKey = Properties.Settings.Default.ConsumerKey,
        //        ConsumerSecret = Properties.Settings.Default.ConsumerSecret,
        //        RequesterId = "wrong"
        //    });
        //    client.Ping();
        //}
    }
}
