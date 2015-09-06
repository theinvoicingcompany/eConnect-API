using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Account
{
    [TestClass]
    public class GetAccountDetailsTests
    {
        [TestMethod]
        public void GetAccountDetails()
        {
            var account = EConnect.Client.GetAccountDetails();
            Assert.IsNotNull(account);
            Assert.AreEqual("eLien", account.AccountName);
            Assert.AreEqual("Business", account.AcccountType);
            Assert.AreEqual("A000000218", account.AccountId);
            Assert.AreEqual(true, account.CanSendAppIntegrationRequests);
            Assert.AreEqual(1394791538722, account.RawCreatedDateTime);
            Assert.AreEqual(new DateTime(2014, 3, 14, 10, 5, 38, 722, DateTimeKind.Utc), account.CreatedDateTime);
            Assert.AreEqual("Accounting", account.Category);
            Assert.AreEqual("everbinding.elien@gmail.com", account.Email);
            Assert.AreEqual("Pilot Pricing Plan", account.PricingPlanName);
            Assert.IsTrue(account.TotalUsersCount > 0);
            Assert.AreEqual("UA000000218000026", account.UserId);
            Assert.AreEqual("Wim Kok", account.UserName);
            Assert.IsTrue(account.FinancialInfo!=null);
        }
    }
}