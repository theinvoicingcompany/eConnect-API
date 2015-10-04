using System.IO;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Helpers
{
    public static class TestResources
    {
        private static XElement XmlReader(string filename)
        {
            filename = filename.Replace(@"TestData\", "");
            Assert.IsNotNull(filename);
            Assert.IsTrue(File.Exists(filename), "deployment not successfull");

            var ubltext = File.ReadAllText(filename);
            Assert.IsFalse(string.IsNullOrEmpty(ubltext), "test file seems to be empty");

            var xml = XElement.Parse(ubltext);
            Assert.IsNotNull(xml);

            return xml;
        }

        public static XElement Document1
        {
            get
            {
                const string filename = @"OutputDir\UBLWITHATTACHEMENT.txt";
                return XmlReader(filename);
            }
        }

        public const string InvoiceNoAttachmentForRecipient2Path = @"TestData\InvoiceNoAttachmentForRecipient2.xml";
        public static XElement InvoiceNoAttachmentForRecipient2
        {
            get
            {
                return XmlReader(InvoiceNoAttachmentForRecipient2Path);
            }
        }
    }
}
