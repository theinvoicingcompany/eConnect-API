using System;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class EnquireCompanyTests
    {
        [TestMethod]
        public void EnquireCompany_ByEntityId()
        {
            var result = EConnect.Client.EnquireCompany(new EnquireCompany()
                {
                    EntityId = "XCNL10199"
                });

            Assert.AreEqual("SELMIT", result.CompanyName);
            Assert.AreEqual("Nederland", result.Country);
            Assert.AreEqual("920582389", result.TemporaryId);
            Assert.AreEqual("50560190", result.KvkNumber);
        }

        [TestMethod]
        public void EnquireCompany_ByTemporaryId()
        {
            var result = EConnect.Client.EnquireCompany(new EnquireCompany()
            {
                TemporaryId = "920582389"
            });

            Assert.AreEqual("SELMIT", result.CompanyName);
            Assert.AreEqual("Nederland", result.Country);
            Assert.AreEqual("920582389", result.TemporaryId);
            Assert.AreEqual("50560190", result.KvkNumber);
        }
    }
}
