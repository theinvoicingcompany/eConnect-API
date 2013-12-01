using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string TemporaryIdentifier { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string HouseNumberSupplement { get; set; }
        public string PostalCode { get; set; }
        public string Residence { get; set; }
        public string IsoCountryCode { get; set; }
        [XmlElement(ElementName = "URL")]
        public string Url { get; set; }
        [XmlElement(ElementName = "EMailAddress")]
        public string EmailAddress { get; set; }
    }
}