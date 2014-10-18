namespace EConnectApi
{
    public class EConnectClientConfigBase : IEConnectClientConfig
    {
        public EConnectClientConfigBase()
        {
            try
            {
                RequestTokenEndpoint = Properties.Settings.Default.EndPointRequestToken;
                AccessTokenEndpoint = Properties.Settings.Default.EndPointAccessToken;
                AccessResourceEndpoint = Properties.Settings.Default.EndPointAccessResource;
                Realm = Properties.Settings.Default.Realm;
                Verifier = Properties.Settings.Default.Verifier;
            }
            catch
            {
                RequestTokenEndpoint = "https://platform.everbinding.nl/api/requesttoken";
                AccessTokenEndpoint = "https://platform.everbinding.nl/api/accesstoken";
                AccessResourceEndpoint = "https://platform.everbinding.nl/api/accessresource";
                Realm = "platform.everbinding.nl";
                Verifier = "Unused";
            }
        }
        public string RequestTokenEndpoint { get; protected set; }
        public string AccessTokenEndpoint { get; protected set; }
        public string AccessResourceEndpoint { get; protected set; }
        public string Realm { get; protected set; }

        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string RequesterId { get; set; }
        public string Verifier { get; set; }
    }
}