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

            Assert.AreEqual("SelmIT", result.CompanyName);
            Assert.AreEqual("NL:KVK:50560190", result.TemporaryId);
            Assert.AreEqual("50560190", result.KvkNumber);
        }
    }
}
