using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using EConnectApi.Definitions;
using EConnectApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{


    [TestClass]
    public class SerializeAndDeserializeTest
    {


        public static string UblSample =
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

        //        public static string RequestSample =
        //            @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/"">
        //                <SOAP:Body>
        //                    " + UblSample + @"
        //                </SOAP:Body>
        //            </SOAP:Envelope>";

        //[TestMethod]
        //public void TestUBL()
        //{

        //    var ubl = XElement.Parse(UblSample);
            

        //    var name = ubl.Element("pwns:FullNameemp").Value;

        //}

        [TestMethod]
        public void SendDocumentSerializeAndDeserialize()
        {
            var senddoc = new SendDocument()
                             {
                                 Payload = XElement.Parse(UblSample),
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
            
            var xml = GenericXml.Serialize(senddoc);
            var xdoc = XElement.Parse(xml);
            Assert.AreEqual(xdoc.Element("{http://ws.vg.pw.com/external/1.0}DocumentTemplateId").Value, senddoc.DocumentTemplateId);
            Assert.AreEqual(xdoc.Element("{http://ws.vg.pw.com/external/1.0}Subject").Value, senddoc.Subject);
            var senddoc2 = GenericXml.Deserialize<SendDocument>(xml);
            Assert.AreEqual(senddoc.DocumentTemplateId, senddoc2.DocumentTemplateId);
            Assert.AreEqual(senddoc.Subject, senddoc2.Subject);
        }
    }

}
