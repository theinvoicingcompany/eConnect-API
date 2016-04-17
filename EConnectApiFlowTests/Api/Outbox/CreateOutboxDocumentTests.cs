using System;
using EConnectApi.Definitions;
using EConnectApiFlowTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Outbox
{
    [TestClass]
    public class CreateOutboxDocumentTests
    {
        [TestMethod]
        [DeploymentItem(TestResources.InvoiceNoAttachmentForRecipient2Path)]
        public void CreateOutboxDocument()
        {
            var create = new CreateOutboxDocument()
            {
                DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                Subject = "Unit test CreateOutboxDocument " + Guid.NewGuid(),
                Recipient = Properties.Settings.Default.EntityId2,
                Payload = TestResources.InvoiceNoAttachmentForRecipient2,
            };

            var res = EConnect.Client.CreateOutboxDocument(Properties.Settings.Default.EntityId, create);
            Assert.IsNotNull(res.ConsignmentId);
            Assert.IsNotNull(res.ExternalId);
        }
    }
}
