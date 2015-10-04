using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public interface IDocumentDetails
    {
        XElement Payload { get; set; }
        
        [XmlIgnore]
        Statuses PossibleStatuses { get;  }
    }
}