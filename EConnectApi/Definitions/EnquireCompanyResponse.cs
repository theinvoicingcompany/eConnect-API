namespace EConnectApi.Definitions
{
    public class EnquireCompanyResponse : Company
    {
        public string Country { get; set; }
        public string ExternalIdSource { get; set; }
    }
}