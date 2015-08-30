using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class GetAccountDetailsTest
    {
        [TestMethod]
        public void GetAccountDetails()
        {
            var account = EConnect.Client.GetAccountDetails();
            Assert.AreEqual("Test elien", account.AccountName);
        }
    }
}