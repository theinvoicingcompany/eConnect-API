using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlRoot("SenderId")]
    [XmlType(AnonymousType = true, Namespace = "")]
    public class SenderIdHeader
    {
        [XmlText]
        public string SenderId { get; set; }
    }
}
