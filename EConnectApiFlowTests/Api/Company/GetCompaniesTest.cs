using System.Linq;
using EConnectApi;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Api.Company
{
    [TestClass]
    public class GetCompaniesTest
    {
        public void ValidateAccountDetails(GetCompaniesResponse.CompanyDetails[] companies, string accountId, string accountName)
        {
            foreach (var company in companies)
            {
                Assert.AreEqual(accountId, company.AccountId);
                Assert.AreEqual(accountName, company.AccountName);
            }
        }

        public void ValidateCompanies(GetCompaniesResponse res)
        {
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Companies);
            Assert.IsTrue(res.Companies.Length > 0);
            ValidateAccountDetails(res.Companies, "A000000218", "eLien");
        }

        [TestMethod]
        public void GetCompanies()
        {
            var res = EConnect.Client.GetCompanies();
            ValidateCompanies(res);
            
            var comp = res.Companies[0];
            Assert.AreEqual(comp.Description, "Koninklijke Ahold N.V.");
        }

        [TestMethod]
        public void GetCompanies_Paging()
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies() { Limit = 1 });
            ValidateCompanies(res);
            var res2 = EConnect.Client.GetCompanies(new GetCompanies() { Limit = 1, Cursor = res.Cursor });
            ValidateCompanies(res2);
            Assert.AreNotEqual(res.Companies[0].CompanyId, res2.Companies[0].CompanyId);
        }

        [TestMethod]
        public void GetCompanies_PagingStartRowRange()
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies() { Limit = 1 });
            ValidateCompanies(res);
            var res2 = EConnect.Client.GetCompanies(new GetCompanies() { Limit = 1, StartRowRange = res.StartRowRange });
            ValidateCompanies(res2);
            Assert.AreNotEqual(res.Companies[0].CompanyId, res2.Companies[0].CompanyId);
        }

        [TestMethod]
        public void GetCompanies_Administrator()
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies() { Filters = new GetCompanies.GetCompaniesFilters()
                                                                                             {
                                                                                                 Administrator = "UA000000218000001"
                                                                                             }});
            ValidateCompanies(res);
            Assert.IsNull(res.Companies.FirstOrDefault(c=>c.AdministratorUserId != "UA000000218000001"));
        }

        [TestMethod]
        [ExpectedException(typeof(EConnectClientException), "Het bedrijf beheerder Id opgegeven in de aanvraag is ongeldig")]
        public void GetCompanies_AdministratorNoRights()
        {
            EConnect.Client.GetCompanies(new GetCompanies() {  Filters = new GetCompanies.GetCompaniesFilters()
                                                                                             {
                                                                                                 Administrator = "UA000000072000001"
                                                                                             }});
        }

        public void ValidateIsVerified(bool isVerified)
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies()
            {
                Filters = new GetCompanies.GetCompaniesFilters()
                {
                    VerifiedOnly = isVerified
                }
            });
            ValidateCompanies(res);
            Assert.IsNull(res.Companies.FirstOrDefault(c => c.IsVerified != isVerified));
        }

        [TestMethod]
        public void GetCompanies_VerifiedOnlyTrue()
        {
            ValidateIsVerified(true);
        }
        
        [TestMethod]
        public void GetCompanies_VerifiedOnlyFalse()
        {
            ValidateIsVerified(false);
        }

        public void ValidateIsRegisteredToPeppol(bool isRegisteredToPeppol)
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies()
            {
                Filters = new GetCompanies.GetCompaniesFilters()
                {
                    SimplerInvoicingRegisteredOnly = isRegisteredToPeppol
                }
            });
            ValidateCompanies(res);
            Assert.IsNull(res.Companies.FirstOrDefault(c => c.IsRegisteredToPeppol != isRegisteredToPeppol));
        }

        [TestMethod]
        public void GetCompanies_ValidateIsRegisteredToPeppolTrue()
        {
            ValidateIsRegisteredToPeppol(true);
        }

        [TestMethod]
        public void GetCompanies_ValidateIsRegisteredToPeppolFalse()
        {
            ValidateIsRegisteredToPeppol(false);
        }

        [TestMethod]
        public void GetCompanies_ComplexFilters()
        {
            var res = EConnect.Client.GetCompanies(new GetCompanies()
            {
                Filters = new GetCompanies.GetCompaniesFilters()
                {
                    SimplerInvoicingRegisteredOnly = true,
                    Administrator = "UA000000218000001",
                    VerifiedOnly = true
                }
            });
            ValidateCompanies(res);
            Assert.IsNull(res.Companies.FirstOrDefault(c => !c.IsRegisteredToPeppol));
            Assert.IsNull(res.Companies.FirstOrDefault(c => !c.IsVerified));
            Assert.IsNull(res.Companies.FirstOrDefault(c => c.AdministratorUserId != "UA000000218000001"));
        }
    }
}