using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/searchcompany", ElementName = "SearchCompanyResponse", IsNullable = false)]
    public class SearchCompanyResponse
    {
        [XmlElement(ElementName = "tuple")]
        public Company[] Companies { get; set; }

        /// <summary>
        /// This parameter gives the searchKey parameter from the previous batch of search results.
        /// </summary>
        [XmlElement(ElementName = "searchKey")]
        public string SearchKey { get; set; }
    }
}
