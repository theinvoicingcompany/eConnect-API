using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EConnectApiFlowTests
{
    public static class EConnect
    {
        private static EConnectClient _client;
        private static EConnectClient _client2;

        /// <summary>
        /// Client with test user 1 and test company 1
        /// </summary>
        public static EConnectClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new EConnectClient(new EConnectClientConfigBase()
                        {
                            ConsumerKey = Properties.Settings.Default.ConsumerKey,
                            ConsumerSecret = Properties.Settings.Default.ConsumerSecret,
                            RequesterId = Properties.Settings.Default.RequesterId
                        });
                }
                return _client;
            }
        }

        /// <summary>
        /// Client with test user 2 and test company 2
        /// </summary>
        public static EConnectClient Client2
        {
            get
            {
                if (_client2 == null)
                {
                    _client2 = new EConnectClient(new EConnectClientConfigBase()
                    {
                        ConsumerKey = Properties.Settings.Default.ConsumerKey2,
                        ConsumerSecret = Properties.Settings.Default.ConsumerSecret2,
                        RequesterId = Properties.Settings.Default.RequesterId2
                    });
                }
                return _client2;
            }
        }
    }
}