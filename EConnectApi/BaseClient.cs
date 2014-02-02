using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;
using EConnectApi.Helpers;
using EConnectApi.OAuth;
using EConnectApi.Properties;

namespace EConnectApi
{
    internal class BaseClient : IDisposable
    {
        private readonly OAuthConsumer _oAuthConsumer;
        protected IEConnectClientConfig Config;
        protected AccessTokenManager Manager;

        public BaseClient(IEConnectClientConfig config)
        {
            Config = config;
            // Underlying OAuth client
            _oAuthConsumer = new OAuthConsumer();
            // Helper to store access tokens
            Manager = new AccessTokenManager();
        }

        /// <summary>
        ///  Requesting request token, 1st Leg of OAuth
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
        /// Requesting access token using request token, 2nd Leg of OAuth
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
                var accessToken = Manager.GetTokenOrNull(scope);

                // if token is null we must request new access token
                if (accessToken == null)
                {
                    // Obtain the Request Token - 1st Leg of OAuth
                    var requestToken = GetRequestToken();
                    // Trade the Request Token and Verfier for the Access Token - 2nd Leg of OAuth
                    accessToken = GetAccessToken(requestToken, scope);
                    // Store access token so we can reuse it for future calls
                    Manager.Store(scope, accessToken);
                }

                // Convert object to string
                var xml = GenericXml.Serialize(body);

                // Wrap soap message object
                string soap = string.Format("<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP:Body>{0}</SOAP:Body></SOAP:Envelope>", xml);

                // Send request
                var result = Send(accessToken, scope, soap);

                XDocument xDoc = XDocument.Load(new StringReader(result));
                var unwrappedResponse = xDoc.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body")
                    .First()
                    .FirstNode.ToString();

                // Convert string to object
                return GenericXml.Deserialize<T>(unwrappedResponse);
            }
            catch (OAuthProtocolException ex)
            {
                try
                {
                    // try to parse exception to SoapFault to reuse EConnect API error message
                    var fault = GenericXml.DeserializeSoap<SoapFault>(ex.Message);
                    if (fault != null)
                        throw new EConnectClientException(fault);
                }
                finally
                {
                    // Exceptions like error 500
                    throw new EConnectClientException("Protocol exception", ex);
                }
            }
            catch(Exception ex)
            {
                throw new EConnectClientException("Unknow EConnectClientException", ex);
            }
        }

        public void Dispose()
        {
            // Nothing yet. Would be nice to clean up the http connections
        }
    }
}