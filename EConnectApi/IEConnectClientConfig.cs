namespace EConnectApi
{
    public interface IEConnectClientConfig
    {
        /// <summary>
        /// To get request token
        /// </summary>
        string RequestTokenEndpoint { get; }

        /// <summary>
        /// To get access token
        /// </summary>
        string AccessTokenEndpoint { get; }

        /// <summary>
        /// To fire the service
        /// </summary>
        string AccessResourceEndpoint { get; }

        /// <summary>
        /// Realm
        /// </summary>
        string Realm { get; }

        /// <summary>
        /// OAuth App key
        /// </summary>
        string ConsumerKey { get; set; }
        
        /// <summary>
        /// OAuth secret
        /// </summary>
        string ConsumerSecret { get; set; }
        
        /// <summary>
        /// The user that an app wishes to act on behalf of
        /// </summary>
        string RequesterId { get; set; }
    }
}
