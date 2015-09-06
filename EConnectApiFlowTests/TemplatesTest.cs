using System;
using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class TemplatesTest
    {
        [TestMethod]
        public void GetTemplates()
        {
            var res = EConnect.Client.GetTemplates();
            Assert.IsNotNull(res.Templates);
            var template = res.Templates.Single(a => a.DocumentTemplateId == "RA000000218DTL1000004");
            Assert.AreEqual("A000000218", template.OwnerAccountId);
            Assert.AreEqual("eLien", template.OwnerAccountName);
            Assert.AreEqual(1438603173089, template.RawCreatedDateTime);
            Assert.AreEqual("UA000000218000001", template.CreatorUserId);
            Assert.AreEqual("test elien", template.CreatorUserName);
            Assert.AreEqual("Deze factuur is gebaseerd op de UBL2.0 Standard en voldoet aan de specificaties van Simplerinvoicing 1.0.", template.Description);
            Assert.AreEqual(false, template.IsMasterTemplate);
            Assert.AreEqual("nl", template.Language);
            Assert.AreEqual(null, template.ParentTemplateId);
            Assert.AreEqual("GLDT9223370666504283001RA000000006DTP2000001", template.MasterTemplateId);
            Assert.IsTrue(template.CreatedDateTime <= template.LastModifiedDateTime);
            Assert.AreEqual("Factuur", template.MasterTemplateName);
            Assert.AreEqual("RA000000218DTL1000004", template.DocumentTemplateId);
            Assert.AreEqual("Factuur", template.DocumentTemplateName);
            Assert.AreEqual("UA000000218000001", template.OwnerUserId);
            Assert.AreEqual("test elien", template.OwnerUserName);
            Assert.AreEqual(new Uri("http://fs.everbinding.nl/snapshots/2014/61438603173010.png"), template.Url);
        }

        [TestMethod]
        public void GetTemplates_Partner()
        {
            var res = EConnect.Client.GetTemplates(new GetTemplates()
                                                   {
                                                       Type = TemplateType.Partner
                                                   });

            var template = res.Templates.Single(t => t.DocumentTemplateId == "RA000000006DTP2000109");
            Assert.AreEqual("Task to convert a document to a eVerbinding document", template.Description);
            Assert.AreEqual("Conversietaak", template.DocumentTemplateName);
            Assert.AreEqual(null, template.ParentTemplateId);
        }


        [TestMethod]
        public void GetTemplates_MasterTemplateId()
        {
            var masterId = "GLDT9223370666504283001RA000000006DTP2000001";
            var res = EConnect.Client.GetTemplates(new GetTemplates()
            {
                Filters = new GetTemplates.GetTemplatesFilters()
                          {
                              MasterTemplateId = masterId
                          }
            });

            Assert.IsTrue(res.Templates.Count(t => t.MasterTemplateId != masterId) == 0);
        }

        [TestMethod]
        public void GetTemplates_ParentTemplateId()
        {
            var res = EConnect.Client.GetTemplates();
            var template = res.Templates.Single(t => t.DocumentTemplateId == "RA000000218DTL1000002");
            Assert.AreEqual("GLDT9223370610890560363RA000000006DTP2000111", template.ParentTemplateId);
        }
    }
}