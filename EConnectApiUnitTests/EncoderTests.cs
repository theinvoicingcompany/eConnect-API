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
    }
}