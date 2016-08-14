using System.Collections.Generic;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://api.everbinding.nl/v3/sharedocument", ElementName = "ShareDocument", IsNullable = false)]
    public class ShareDocument
    {
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }

        public bool ShouldSerializePermission()
        {
            return Permission.HasValue;
        }

        /// <summary>
        /// Specify a global permission for all recipients
        /// </summary>
        public Permission? Permission { get; set; }

        public User[] ShareToUsers { get; set; }

        public Group[] ShareToGroups { get; set; }

        public Company[] ShareToCompanies { get; set; }

        public class ShareEntity
        {
            public string Id { get; set; }
            public Permission Permission { get; set; }
        }

        public class User : ShareEntity
        {

        }

        public class Group : ShareEntity
        {

        }

        public class Company : ShareEntity
        {

        }

    }

    public enum DocumentType
    {
        Document,
        Inbox,
        Outbox
    }

    public enum Permission
    {
        Read,
        Edit,
        FullAccess
    }
}