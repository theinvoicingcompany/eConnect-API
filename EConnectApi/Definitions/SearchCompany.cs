using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRootAttribute(Namespace = "http://ws.vg.pw.com/external/1.0", IsNullable = false)]
    public class SearchCompany
    {
        /// <summary>
        /// This parameter gives the country code of the company being searched.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// This parameter gives the company name of the company being searched.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// This parameter gives the name of the city where the company being searched is present.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// This parameter gives the KvK no of the company which is being searched. Providing a KVK no will always return a unique result.
        /// </summary>
        [XmlElement(ElementName = "KVKNo")]
        public string KvkNumber { get; set; }

        /// <summary>
        /// This parameter gives the identifier of the company which is being searched. Providing a temporary identifier will always return a unique result.
        /// </summary>
        [XmlElement(ElementName = "TemporaryIdentifier")]
        public string TemporaryId { get; set; }

        /// <summary>
        /// This parameter gives the searchKey parameter from the previous batch of search results.
        /// </summary>
        [XmlElement(ElementName = "searchKey")]
        public string SearchKey { get; set; }

        /// <summary>
        /// This parameter gives the number of company results that has to be fetched.
        /// </summary>
        [XmlElement(ElementName = "limit")]
        public byte Limit { get; set; }
    }
}
