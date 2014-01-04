using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class GetDocumentBase
    {
        public string ConsignmentId { get; set; }
        [XmlIgnore]
        public string ExternalId { get { return ConsignmentId; } set { ConsignmentId = value; } }
    }
}