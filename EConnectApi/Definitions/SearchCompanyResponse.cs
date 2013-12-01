using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
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
