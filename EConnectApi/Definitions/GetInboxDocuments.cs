using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getinboxdocuments", ElementName = "GetInboxDocuments", IsNullable = false)]
    public class GetInboxDocuments : GetDocumentsBase, IInboxDocumentsRequest
    {
        /// <summary>
        /// Get documents from Group
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// Get documents from Entity
        /// </summary>
        public string EntityId { get; set; }
    }
}