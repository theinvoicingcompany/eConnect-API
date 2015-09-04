using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class SearchCompanyTests
    {
        [TestMethod]
        public void SearchCompanyEConnect()
        {
            // http://help.everbinding.nl/content/api-search-company

            var search = EConnect.Client.SearchCompany(new SearchCompany()
                {
                      CompanyName = "eVerbinding"
                });

            var company = search.Companies[0];
            Assert.AreEqual("eConnect International B.V.", company.CompanyName);
            Assert.AreEqual("NL:KVK:54441587", company.TemporaryId);
            Assert.AreEqual("Herenweg", company.StreetName);
            Assert.AreEqual("115", company.HouseNumber);
            //Assert.AreEqual(string.Empty, company.HouseNumberSupplement);
            Assert.AreEqual("2402ND", company.PostalCode);
            //Assert.AreEqual(string.Empty, company.Url);
            //Assert.AreEqual(string.Empty, company.EmailAddress);
        }

        [TestMethod]
        public void SearchCompanyPagingTest()
        {
            byte pagesize = 2;

            var search = EConnect.Client.SearchCompany(new SearchCompany()
                {
                    CountryCode = "NL",
                    CompanyName = "lat",
                    City = "UTRECHT",
                    KvkNumber = "",
                    TemporaryId = "",
                    Limit = pagesize
                });

            Assert.AreEqual(pagesize, search.Companies.Length);

            var search2 = EConnect.Client.SearchCompany(new SearchCompany() {SearchKey = search.SearchKey, Limit = pagesize});

            Assert.AreEqual(pagesize, search2.Companies.Length);

            Assert.AreNotEqual(search.Companies[0].TemporaryId, search2.Companies[0].TemporaryId);

            var search3 = EConnect.Client.SearchCompany(new SearchCompany()
                {
                    CountryCode = "NL",
                    CompanyName = "lat",
                    City = "UTRECHT",
                    KvkNumber = "",
                    TemporaryId = "",
                    Limit = 4
                });

            Assert.AreEqual(search3.Companies[2].TemporaryId, search2.Companies[0].TemporaryId);
        }

        [TestMethod]
        public void SearchCompany_ByTemporaryId()
        {
            var search = EConnect.Client.SearchCompany(new SearchCompany()
                {
                    TemporaryId = "897301048"
                });

            Assert.AreEqual(1, search.Companies.Length);
            Assert.AreEqual("L.A.T. WARD", search.Companies[0].CompanyName);
        }

        [TestMethod]
        public void SearchCompany_ByKvk()
        {
            var search = EConnect.Client.SearchCompany(new SearchCompany()
                {
                    KvkNumber = "50560190"
                });

            Assert.AreEqual(1, search.Companies.Length);
            Assert.AreEqual("SelmIT", search.Companies[0].CompanyName);
        }       
    }
}