using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/getdocuments", ElementName = "GetDocuments", IsNullable = false)]
    public class GetDocuments : GetDocumentsFromEntityBase, IDocumentsRequest
    {
        /// <summary>
        /// Get documents from Entity
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Get documents from Group
        /// </summary>
        public string GroupId { get; set; }
    }
}