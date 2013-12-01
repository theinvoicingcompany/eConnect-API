using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class SearchAndEnquireCompanyFlowTests
    {
        [TestMethod]
        public void SearchAndEnquire()
        {
            using (var client = new EConnectClient(new EConnectClientConfigBase()
                                                       {
                                                           ConsumerKey = Properties.Settings.Default.ConsumerKey,
                                                           ConsumerSecret = Properties.Settings.Default.ConsumerSecret,
                                                           RequesterId = Properties.Settings.Default.RequesterId
                                                       }))
            {
                var search = client.SearchCompany(new SearchCompany()
                    {
                        CountryCode = "NL",
                        CompanyName = "lat",
                        KvkNo = "",
                        TemporaryIdentifier = "",
                        Limit = 2
                    });
                var search2 = client.SearchCompany(new SearchCompany()
                    {
                        TemporaryIdentifier = "920582389"
                    });

                //var enquire = client.EnquireCompany(new EnquireCompany()
                //    {
                //        TemporaryIdentifier = "920582389"
                //    });

            }
        }
    }
}
