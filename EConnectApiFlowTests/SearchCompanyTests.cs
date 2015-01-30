using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class SearchCompanyTests
    {
        [TestMethod]
        public void SearchCompanyFromExample()
        {
            // http://help.everbinding.nl/content/api-search-company

            var search = EConnect.Client.SearchCompany(new SearchCompany()
                {
                    CountryCode = "NL",
                    CompanyName = "L.A.T. WARD",
                    City = "UTRECHT",
                    KvkNumber = "",
                    TemporaryId = "",
                    Limit = 2
                });

            Assert.IsNotNull(search.SearchKey);
            Assert.AreNotEqual(string.Empty, search.SearchKey);
            Assert.AreEqual(2, search.Companies.Length);

            var company = search.Companies[0];
            Assert.AreEqual("L.A.T. WARD", company.CompanyName);
            Assert.AreEqual("897301048", company.TemporaryId);
            Assert.AreEqual("BETHLEHEMWEG", company.StreetName);
            Assert.AreEqual("11", company.HouseNumber);
            Assert.AreEqual(string.Empty, company.HouseNumberSupplement);
            Assert.AreEqual("3513 CV", company.PostalCode);
            Assert.AreEqual(string.Empty, company.Url);
            Assert.AreEqual(string.Empty, company.EmailAddress);
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
            Assert.AreEqual("SELMIT", search.Companies[0].CompanyName);
        }       
    }
}