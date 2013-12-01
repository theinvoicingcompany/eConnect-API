using System;
using System.Runtime.Serialization.Formatters;
using EConnectApi.Helpers;
using EConnectApi.OAuth;
using EConnectApi.Properties;

namespace EConnectApi
{
    internal class BaseClient
    {
        private readonly OAuthConsumer _oAuthConsumer;
        protected IEConnectClientConfig Config;
        private RequestToken _requestToken;

        public BaseClient(IEConnectClientConfig config)
        {
            Config = config;
            _oAuthConsumer = new OAuthConsumer();
        }

        /// <summary>
        ///  Requesting request token
        /// </summary>
        /// <returns></returns>
        public RequestToken GetRequestToken()
        {
            return _oAuthConsumer.GetOAuthRequestToken(
                Config.RequestTokenEndpoint,
                Config.Realm,
                Config.ConsumerKey,
                Config.ConsumerSecret,
                "Unused",
                string.Empty); // Empty scope
        }

        /// <summary>
        /// Requesting access token using request token
        /// </summary>
        /// <param name="requestToken"></param>
        /// <param name="scope">Ex. SEND_DOC</param>
        /// <returns></returns>
        public AccessToken GetAccessToken(RequestToken requestToken, string scope)
        {
            return _oAuthConsumer.GetOAuthAccessToken(
                Config.AccessTokenEndpoint,
                Config.Realm,
                Config.ConsumerKey,
                Config.ConsumerSecret,
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
        /// <returns></returns>
        public string Send(AccessToken accessToken, string scope, string xml)
        {
            var xmlResponse = _oAuthConsumer.send(
                                Config.AccessResourceEndpoint,
                                Config.Realm,
                                Config.ConsumerKey,
                                Config.ConsumerSecret,
                                accessToken.Token,
                                accessToken.TokenSecret,
                                scope,
                                xml,
                                Config.RequesterId);

            return xmlResponse;
        }

        public T SendRequest<T>(string scope, object body) where T : class
        {
            try
            {
                // Convert object to string
                var xml = GenericXml.Serialize(body);

                string soap = string.Format("<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP:Body>{0}</SOAP:Body></SOAP:Envelope>", xml);

                //if (_requestToken == null)
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
                var result = Send(accessToken, scope, soap);

                // Convert string to object
                return GenericXml.Deserialize<T>(result);
            }
            catch (OAuthProtocolException ex)
            {
                SoapFault fault = null;
                try
                {
                    fault = GenericXml.DeserializeSoap<SoapFault>(ex.Message);

                }
                catch
                {
                }
                if (fault != null)
                    throw new EConnectClientException(fault);

                throw new EConnectClientException("Protocol exception", ex);
            }
        }

    }
}