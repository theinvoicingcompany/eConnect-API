using EConnectApi.Helpers;
using EConnectApi.OAuth;
using EConnectApi.Properties;

namespace EConnectApi
{
    internal class BaseClient
    {
        private readonly OAuthConsumer _oAuthConsumer;
        private readonly string _requesterId;
        private RequestToken _requestToken;

        public BaseClient(string requesterId)
        {

            _requesterId = requesterId;
            _oAuthConsumer = new OAuthConsumer(); 
        }

        /// <summary>
        ///  Requesting request token
        /// </summary>
        /// <returns></returns>
        public RequestToken GetRequestToken() { 
            return _oAuthConsumer.GetOAuthRequestToken(
                Settings.Default.EndPointRequestToken,
                Settings.Default.Realm,
                Settings.Default.OAUThAppKey,
                Settings.Default.OAUThSecret,
                "Unused",
                string.Empty); // Empty scope
        }

        /// <summary>
        /// Requesting access token using request token
        /// </summary>
        /// <param name="requestToken"></param>
        /// <returns></returns>
        public AccessToken GetAccessToken(RequestToken requestToken, string scope)
        {
            return _oAuthConsumer.GetOAuthAccessToken(
                Settings.Default.EndPointAccessToken,
                Settings.Default.Realm,
                Settings.Default.OAUThAppKey,
                Settings.Default.OAUThSecret,
                requestToken.Token,
                "Unused",
                requestToken.TokenSecret,
                scope);  
        }

        /// <summary>
        /// Send request
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="scope"></param>
        /// <param name="xml"></param>
        /// <param name="requesterId"></param>
        /// <returns></returns>
        public string Send(AccessToken accessToken, string scope, string xml, string requesterId)
        {
            var xmlResponse = _oAuthConsumer.send(Settings.Default.EndPointAccessResource,
                                            Settings.Default.Realm,
                                            Settings.Default.OAUThAppKey,
                                            Settings.Default.OAUThSecret,
                                            accessToken.Token,
                                            accessToken.TokenSecret,
                                            scope,
                                            xml,
                                            requesterId);

            return xmlResponse; 
        }

        public T SendRequest<T>(string scope, object body) where T : class
        {
            // Convert object to string
            var xml = GenericXml.Serialize(body);

            //var soep2 = new Envelope()
            //                {
            //                    Body = xml
            //                };
            //string ssoep2 = GenericXml.SerializeSoap(soep2);

            // TODO REFACTOR, remove strings
            string soap = string.Format("<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP:Body>{0}</SOAP:Body></SOAP:Envelope>", xml);

            if (_requestToken == null)
                _requestToken = GetRequestToken();

            AccessToken accessToken;
            try
            {
                // Get access token and reuse request token
                accessToken = GetAccessToken(_requestToken, scope);
            }
            catch
            {
                // if fails, get new toke and try it again
                _requestToken = GetRequestToken();
                accessToken = GetAccessToken(_requestToken, scope);
            }

            // Send request
            var result = Send(accessToken, scope, soap, _requesterId);
            
            // Convert string to object
            return GenericXml.Deserialize<T>(result);
        }

    }
}