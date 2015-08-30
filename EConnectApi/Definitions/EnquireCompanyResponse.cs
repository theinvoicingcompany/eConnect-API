using System;

namespace EConnectApi.Definitions
{
    public class EnquireCompanyResponse : Company
    {
        [Obsolete]
        public string Country { get; set; }
        [Obsolete]
        public string ExternalIdSource { get; set; }
    }
}