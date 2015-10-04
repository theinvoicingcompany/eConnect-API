using System;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    /// <summary>
    /// Used by Inbox or Outbox documents
    /// </summary>
    public class DocumentBaseExtensions : DocumentBase, IEquatable<DocumentBaseExtensions>
    {
        public string ConsignmentId { get; set; }
        public string ConsignmentName { get; set; }
        
        public string Subject { get; set; }
        public string Type { get; set; }

        public string SenderId { get; set; } // only inbox?
        public string SenderAccountId { get; set; }
        public string SenderAccountName { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public string SenderEntityId { get; set; }
        public string SenderEntityName { get; set; }

        public string OriginalSender { get; set; }  // only inbox?
        public string DocumentAsFile { get; set; }  // only inbox?

        public string ReceiverEntityId { get; set; }
        public string ReceiverEntityName { get; set; }
        public string RecipientEmailId { get; set; }
        [XmlElement(ElementName = "TrustedReceiver")]
        public bool IsTrustedReceiver { get; set; }

        public string TrackingMessage { get; set; }
        public bool IsRead { get; set; }       
        // TODO: Check IsTask is not bool?
        public int IsTask { get; set; }

        #region equality

        public bool Equals(DocumentBaseExtensions other)
        {
            if (other == null)
                return false;

            if (!(this as DocumentBase).Equals(other))
                return false;

            return ConsignmentId == other.ConsignmentId &&
                   ConsignmentName == other.ConsignmentName &&
                   Subject == other.Subject &&
                   Type == other.Type &&
                   SenderId == other.SenderId &&
                   SenderAccountId == other.SenderAccountId &&
                   SenderAccountName == other.SenderAccountName &&
                   SenderUserId == other.SenderUserId &&
                   SenderUserName == other.SenderUserName &&
                   SenderEntityId == other.SenderEntityId &&
                   SenderEntityName == other.SenderEntityName &&
                   OriginalSender == other.OriginalSender &&
                   DocumentAsFile == other.DocumentAsFile &&
                   ReceiverEntityId == other.ReceiverEntityId &&
                   ReceiverEntityName == other.ReceiverEntityName &&
                   IsTrustedReceiver == other.IsTrustedReceiver &&
                   TrackingMessage == other.TrackingMessage &&
                   IsRead == other.IsRead &&
                   IsTask == other.IsTask;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as DocumentBaseExtensions);
        }
        #endregion
    }
}