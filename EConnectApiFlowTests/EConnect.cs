using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EConnectApiFlowTests
{
    public class EConnect
    {
        private static EConnectClient _client;

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
    }
}