using System;
using System.Runtime.Serialization.Formatters;
using EConnectApi.Helpers;
using EConnectApi.OAuth;

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
        private RequestToken _getRequestToken()
        {
            return _oAuthConsumer.GetOAuthRequestToken(
                Config.RequestTokenEndpoint,
                Config.Realm,
                Config.ConsumerKey,
                Config.ConsumerSecret,
                Config.Verifier,
                string.Empty);
        }

        /// <summary>
        ///  Requesting request token, 1st Leg of OAuth
        /// </summary>
        /// <returns></returns>
        public RequestToken GetRequestToken()
        {
            return SafeExecutor(_getRequestToken);
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
                Config.Verifier,
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
        protected string Send(AccessToken accessToken, string scope, string xml)
        {
            var xmlResponse = _oAuthConsumer.send(
                                Config.AccessResourceEndpoint,
                                Config.Realm,
                                Config.ConsumerKey,
                                Config.ConsumerSecret,
                                accessToken.Token,
                                Config.Verifier,
                                accessToken.TokenSecret,
                                scope,
                                xml,
                                Config.RequesterId);

            return xmlResponse;
        }

        public T SendRequest<T>(string scope, object body, object header = null) where T : class
        {
            return SafeExecutor(() =>
            {
                var accessToken = Manager.GetTokenOrNull(scope);

                // if token is null we must request new access token
                if (accessToken == null)
                {
                    // Obtain the Request Token - 1st Leg of OAuth
                    var requestToken = _getRequestToken();
                    // Trade the Request Token and Verfier for the Access Token - 2nd Leg of OAuth
                    accessToken = GetAccessToken(requestToken, scope);
                    // Store access token so we can reuse it for future calls
                    Manager.Store(scope, accessToken);
                }

                string headerxml = string.Empty;
                if (header != null)
                {
                    headerxml = string.Format("<SOAP:Header>{0}</SOAP:Header>", GenericXml.Serialize(header));
                }
                // Convert object to string
                var bodyxml = GenericXml.Serialize(body);

                // Wrap soap message object
                string soap = string.Format("<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\">{0}<SOAP:Body>{1}</SOAP:Body></SOAP:Envelope>", headerxml, bodyxml);

                // Send request
                var result = Send(accessToken, scope, soap);

                // Convert string to object
                return GenericXml.Deserialize<T>(result);

                //XDocument xDoc = XDocument.Load(new StringReader(result));
                //var unwrappedResponse = xDoc.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body")
                //    .First()
                //    .FirstNode.ToString();

                // Convert string to object
                //return GenericXml.Deserialize<T>(unwrappedResponse);
            });
        }

        public void Dispose()
        {
            // Nothing yet. Would be nice to clean up the http connections
        }

        /// <summary>
        /// try to parse exception to SoapFault to reuse EConnect API error message
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fault"></param>
        /// <returns></returns>
        private bool TryParseSoapFault(Exception ex, out SoapFault fault)
        {
            try
            {
                fault = GenericXml.DeserializeSoap<SoapFault>(ex.Message);
                return true;
            }
            catch
            {
                fault = null;
                return false;
            }
        }

        private T SafeExecutor<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (OAuthProtocolException ex)
            {
                SoapFault fault;
                if (TryParseSoapFault(ex, out fault))
                {
                    if (fault.FaultString == "Invalid signature.  Check OAuth credentials." || fault.FaultString == "Invalid consumer key or no such app available in registry")
                    {
                        throw new UnauthorizedException(fault);
                    }
                    throw new EConnectClientException(fault);
                }
                // Exceptions like error 500
                throw;
            }
            catch (Exception ex)
            {
                throw new EConnectClientException("Unknow EConnectClientException", ex);
            }
        }
    }
}