using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi.Definitions;
using EConnectApiUnitTests.XmlTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
      [TestClass]
    public class SearchCompanyTests
    {
          [TestMethod]
          public void SearchCompanySerializationTest()
          {
              var xml = @"<SearchCompany xmlns=""http://ws.vg.pw.com/external/1.0"">
                            <CountryCode>NL</CountryCode>
                            <CompanyName>lat</CompanyName>
                            <City>UTRECHT</City>
                            <KVKNo/>
                            <TemporaryIdentifier/>
                            <limit>2</limit>
                        </SearchCompany>";

              var request = new SearchCompany()
                            {
                                CountryCode = "NL",
                                CompanyName = "lat",
                                City = "UTRECHT",
                                KvkNumber = string.Empty,
                                TemporaryId = string.Empty,
                                Limit = 2
                            };

              Compare.IsObjectSameAsXml<SearchCompany>(request, xml);

          }

          [TestMethod]
          public void SearchCompanyResponseSerializationTest()
          {
              var xml = @"<SearchCompanyResponse>
                            <tuple>
                                <CompanyName>L.A.T. WARD</CompanyName>
                                <TemporaryIdentifier>897301048</TemporaryIdentifier>
                                <StreetName>BETHLEHEMWEG</StreetName>
                                <HouseNumber>11</HouseNumber>
                                <HouseNumberSupplement/>
                                <PostalCode>3513 CV</PostalCode>
                                <Residence>UTRECHT</Residence>
                                <IsoCountryCode>NL</IsoCountryCode>
                                <URL/>
                                <EMailAddress/>
                            </tuple>
                            <searchKey>00LAT0405400388292960000000000002</searchKey>
                        </SearchCompanyResponse>";

              var request = new SearchCompanyResponse()
              {
                 Companies = new[]
                     {
                        new Company()
                            {
                                CompanyName = "L.A.T. WARD",
                                TemporaryId = "897301048",
                                StreetName = "BETHLEHEMWEG",
                                HouseNumber = "11",
                                HouseNumberSupplement = string.Empty,
                                PostalCode = "3513 CV",
                                Residence = "UTRECHT",
                                IsoCountryCode = "NL",
                                Url = string.Empty,
                                EmailAddress = string.Empty
                            }
                     },
                 SearchKey = "00LAT0405400388292960000000000002"
              };

              Compare.IsObjectSameAsXml<SearchCompanyResponse>(request, xml);

          }
    }
}
