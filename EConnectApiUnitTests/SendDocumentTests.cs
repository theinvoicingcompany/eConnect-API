using System.Xml.Linq;
using EConnectApi.Definitions;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class SendDocumentTests
    {
        [TestMethod]
        public void SendDocument()
        {
            var ublSample =
             @"<pwns:document_instance xmlns:pwns=""http://schemas.pw.vg.com/pwns"">
                <pwns:FullName dx_etyp=""string"">Jacobs</pwns:FullName>
                <pwns:positonAppliedFor dx_etyp=""string"">Technical Support</pwns:positonAppliedFor>
                <pwns:Telephone dx_etyp=""string"">87878778</pwns:Telephone>
                <pwns:Email dx_etyp=""string"">jacobs@jjjjjjxj.com</pwns:Email>
                <pwns:dx_57 dx_etyp=""string"">&lt;![CDATA[&lt;br&gt;]]&gt;</pwns:dx_57>
                <pwns:Pleaseattachyourresumehere dx_etyp=""string""/>
                <pwns:FullNameemp>Karthik Sudar</pwns:FullNameemp>
                <pwns:Title/>
                <pwns:Department/>
                <pwns:PhoneNumber/>
                <pwns:Emailemp>karthik@miui.com</pwns:Emailemp>
                <pwns:attachments1 dx_etyp=""string"">
                    <attachment0 dx_atmt=""true"" filename=""testfile.txt"" isfilecontent=""true"" xmlns=""http://schemas.pw.vg.com/pwns"">
                        <!-- Base 64 encoded content of attachment0 goes here -->
                    </attachment0>
                </pwns:attachments1>
            </pwns:document_instance>";

            var xml = string.Format(@"<SendDocument xmlns=""http://ws.vg.pw.com/external/1.0"">
            <Payload>{0}</Payload>
            <DocumentTemplateId>RA000000014DTNL000007</DocumentTemplateId>
            <Subject>order-re</Subject>
            <DocumentAsFile fileName=""order.txt"">T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=</DocumentAsFile>
            <Recipient>UA000000015000001</Recipient>
            <RecipientEmailId>kkarthik@vanenburgsoftware.com</RecipientEmailId>
            <SendViaGroup>GRA0000000019223370662185881375EXGP3000001</SendViaGroup>
        </SendDocument>", ublSample);


            var request = new SendDocument()
            {
                Payload = XElement.Parse(ublSample),
                DocumentTemplateId = "RA000000014DTNL000007",
                Subject = "order-re",
                DocumentAsFile = new DocumentAsFile()
                                     {
                                         FileName = "order.txt",
                                         FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U="
                                     },
                Recipient = "UA000000015000001",
                RecipientEmailId = "kkarthik@vanenburgsoftware.com",
                SendViaGroup = "GRA0000000019223370662185881375EXGP3000001"

            };

            //var test = GenericXml.Serialize(request);
            //var back = GenericXml.Deserialize<SendDocument>(test);
            Compare.IsObjectSameAsXml<SendDocument>(request, xml);
        }


        [TestMethod]
        public void SendDocumentForHeader()
        {
            string xml = "<SenderId>test</SenderId>";
            var obj = new SendDocumentForHeader() { SenderId = "test" };

            Compare.IsObjectSameAsXml<SendDocumentForHeader>(obj, xml);
        }


    }
}
