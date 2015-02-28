using EConnectApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class EncoderTests
    {
        [TestMethod]
        public void MailAddressForUrl()
        {
            Assert.AreEqual("tester%2bencode@gmail.com", Encoder.MailAddressForUrl("tester+encode@gmail.com"));
            Assert.AreEqual("tester.encode@gmail.com", Encoder.MailAddressForUrl("tester.encode@gmail.com"));
        }

        [TestMethod]
        public void MailAddressForUrl_NullAndEmpty()
        {
            Assert.AreEqual(null, Encoder.MailAddressForUrl(null));
            Assert.AreEqual(string.Empty, Encoder.MailAddressForUrl(string.Empty));
        }

        [TestMethod]
        public void WrongMailAddress()
        {
            Assert.AreEqual("XCNL10019", Encoder.MailAddressForUrl("XCNL10019"));
            Assert.AreEqual("XCNL%2b10019", Encoder.MailAddressForUrl("XCNL+10019"));
        }
    }
}