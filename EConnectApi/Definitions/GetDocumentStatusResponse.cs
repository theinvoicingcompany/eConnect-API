using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetDocumentStatusResponse
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusSetByUserId { get; set; }
        public string StatusSetByUserName { get; set; }
        public string StatusSetByAccountId { get; set; }
        public string StatusSetByAccountName { get; set; }
        public long StatusDate { get; set; }
    }
}