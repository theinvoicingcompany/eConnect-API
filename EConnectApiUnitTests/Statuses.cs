using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class StatusesTests
    {
        [TestMethod]
        public void DeserializationTest()
        {
            var doc = new EConnectDocumentDetails()
            {
                LatestStatusCode = "20",
                RawPossibleConsignmentStatuses =
                    "consignmentstatus1:Afgeleverd:10,consignmentstatus2:Gelezen:20,consignmentstatus3:Verwerkt:30,consignmentstatus4:Goedgekeurd:40,consignmentstatus5:Afgewezen:50,defaultstatus:Afgeleverd:10"
            }; 

            var statuses = doc.PossibleStatuses.PossibleStatuses;

            Assert.AreEqual(statuses.Length, 5);
            Assert.AreEqual(statuses.Single(a => a.Code == "10").Name, "Afgeleverd");
            Assert.AreEqual(statuses.Single(a => a.Code == "20").Name, "Gelezen");
            Assert.AreEqual(statuses.Single(a => a.Code == "30").Name, "Verwerkt");
            Assert.AreEqual(statuses.Single(a => a.Code == "40").Name, "Goedgekeurd");
            Assert.AreEqual(statuses.Single(a => a.Code == "50").Name, "Afgewezen");
            Assert.AreEqual(doc.PossibleStatuses.DefaultStatus.Name, "Afgeleverd");
            Assert.AreEqual(doc.PossibleStatuses.LatestStatus.Name, "Gelezen");
        }

        [TestMethod]
        public void NextAndBackStatusTest()
        {
            var statuses = new Statuses("documentstatus1:Drafted:10,documentstatus2:processing:20,documentstatus3:Approved:30,documentstatus4:Rejected:40", "20");

            Assert.AreEqual(statuses.NextStatus.Code, "30");
            Assert.AreEqual(statuses.LatestStatus.Code, "20");
            Assert.AreEqual(statuses.PreviousStatus.Code, "10");
        }

        [TestMethod]
        public void NextAndBackStatusTest_Unorderd()
        {
            var statuses = new Statuses("documentstatus4:Rejected:40,documentstatus1:Drafted:10,documentstatus3:Approved:30,documentstatus2:processing:20", "20");

            Assert.AreEqual(statuses.NextStatus.Code, "30");
            Assert.AreEqual(statuses.LatestStatus.Code, "20");
            Assert.AreEqual(statuses.PreviousStatus.Code, "10");
        }

        [TestMethod]
        public void NextAndBackStatusTestWithNextNull()
        {
            var doc = new EConnectDocumentDetails()
            {
                LatestStatusCode = "20",
                RawPossibleConsignmentStatuses =
                    "consignmentstatus1:Afgeleverd:10,consignmentstatus2:Gelezen:20"
            };

            Assert.AreEqual(doc.PossibleStatuses.NextStatus, null);
            Assert.AreEqual(doc.PossibleStatuses.LatestStatus.Code, "20");
            Assert.AreEqual(doc.PossibleStatuses.PreviousStatus.Code, "10");
        }
    }

}
