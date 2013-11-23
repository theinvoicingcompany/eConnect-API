using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using EConnectApi.OAuth;

// See Matlus.FederatedIdentity
namespace EConnectApi.OAuth
{
  // Reference page on Google: http://code.google.com/apis/accounts/docs/OAuth_ref.html
  // Reference page on Twitter: http://dev.twitter.com/pages/auth#at-twitter
  // Reference page on Yahoo: http://developer.yahoo.com/oauth/guide/oauth-auth-flow.html
  // Reference page on Vimeo: http://vimeo.com/api/docs/oauth

  
  internal class OAuthUtils
  {
    #region Private Nested Classes
    
    private class ProtocolParameter
    {
      public string Name { get; private set; }
      public string Value { get; private set; }

      public ProtocolParameter(string name, string value)
      {
        Name = name;
        Value = value;
      }
    }

    private class LexicographicComparer : IComparer<ProtocolParameter>
    {
      public int Compare(ProtocolParameter x, ProtocolParameter y)
      {
        if (x.Name == y.Name)
          return string.Compare(x.Value, y.Value);
        else
          return string.Compare(x.Name, y.Name);
      }
    }

    #endregion Private Nested Classes

    //http://en.wikipedia.org/wiki/Percent-encoding
    private readonly static string reservedCharacters = "!*'();:@&=+$,/?%#[]";
    private const string OAuthVersion = "1.0";
    private const string OAuthProtocolParameterPrefix = "oauth_";

    private static Random random = new Random();

    #region Private static methods

    private static string GenerateTimeStamp()
    {
      TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1);
      return Math.Truncate(ts.TotalSeconds).ToString();
    }

    private static string GenerateNonce(string timestamp)
    {
      var buffer = new byte[256];
      random.NextBytes(buffer);
      var hmacsha1 = new HMACSHA1();
      hmacsha1.Key = Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(buffer));      
      return ComputeHash(hmacsha1, timestamp);
    }

    private static string ComputeHash(HashAlgorithm hashAlgorithm, string data)
    {
      if (hashAlgorithm == null)
        throw new ArgumentNullException("hashAlgorithm");
      if (string.IsNullOrEmpty(data))
        throw new ArgumentNullException("data");

      byte[] buffer = System.Text.Encoding.ASCII.GetBytes(data);
      byte[] bytes = hashAlgorithm.ComputeHash(buffer);

      return Convert.ToBase64String(bytes);
    }

    private static string NormalizeProtocolParameters(IList<ProtocolParameter> parameters)
    {
      var sb = new StringBuilder();
      ProtocolParameter p = null;
      for (int i = 0; i < parameters.Count; i++)
      {
        p = parameters[i];
        sb.AppendFormat("{0}={1}", p.Name, UrlEncode(p.Value));

        if (i < parameters.Count - 1)
        {
          sb.Append("&");
        }
      }

      return sb.ToString();
    }

    private static List<ProtocolParameter> ExtractQueryStrings(string url)
    {
      int questionIndex = url.IndexOf('?');
      if (questionIndex == -1)
        return new List<ProtocolParameter>();

      var parameters = url.Substring(questionIndex + 1);
      var result = new List<ProtocolParameter>();

      if (!String.IsNullOrEmpty(parameters))
      {
        string[] parts = parameters.Split('&');
        foreach (var part in parts)
        {
          if (!string.IsNullOrEmpty(part) && !part.StartsWith(OAuthProtocolParameterPrefix))
          {
            if (part.IndexOf('=') != -1)
            {
              string[] nameValue = part.Split('=');
              result.Add(new ProtocolParameter(nameValue[0], nameValue[1]));
            }
            else
              result.Add(new ProtocolParameter(part, String.Empty));
          }
        }
      }
      return result;
    }

    private string GenerateSignatureBaseString(string url, string httpMethod, List<ProtocolParameter> protocolParameters)
    {
      protocolParameters.Sort(new LexicographicComparer());

      var uri = new Uri(url);
      var normalizedUrl = string.Format("{0}://{1}", uri.Scheme, uri.Host);

      if (!((uri.Scheme == "http" && uri.Port == 80) || (uri.Scheme == "https" && uri.Port == 443)))
        normalizedUrl += ":" + uri.Port;
      normalizedUrl += uri.AbsolutePath;

      var normalizedRequestParameters = NormalizeProtocolParameters(protocolParameters);

      StringBuilder signatureBaseSb = new StringBuilder();
      signatureBaseSb.AppendFormat("{0}&", httpMethod);
      signatureBaseSb.AppendFormat("{0}&", UrlEncode(normalizedUrl));
      signatureBaseSb.AppendFormat("{0}", UrlEncode(normalizedRequestParameters));
      return signatureBaseSb.ToString();
    }

    private static string GenerateSignature(string consumerSecret, SignatureMethod signatureMethod, string signatureBaseString, string tokenSecret = null)
    {
      switch (signatureMethod)
      {
        case SignatureMethod.HMACSHA1:
          var hmacsha1 = new HMACSHA1();
          var beforeEncoding = String.Format("{0}&{1}", UrlEncode(consumerSecret), String.IsNullOrEmpty(tokenSecret) ? "" : UrlEncode(tokenSecret));
          var beforeComputeHash = Encoding.ASCII.GetBytes(beforeEncoding);
          hmacsha1.Key = Encoding.ASCII.GetBytes(beforeEncoding);
          return ComputeHash(hmacsha1, signatureBaseString);
        case SignatureMethod.PLAINTEXT:
          throw new NotImplementedException("PLAINTEXT Signature Method type is not yet implemented");
        case SignatureMethod.RSASHA1:
          throw new NotImplementedException("RSA-SHA1 Signature Method type is not yet implemented");
        default:
          throw new ArgumentException("Unknown Signature Method", "signatureMethod");
      }
    }

    #endregion Private static methods

    #region Public Static Methods
    
    public static string UrlEncode(string value)
    {
      if (String.IsNullOrEmpty(value))
        return String.Empty;

      var sb = new StringBuilder();

      foreach (char @char in value)
      {
        if (reservedCharacters.IndexOf(@char) == -1)
          sb.Append(@char);
        else
          sb.AppendFormat("%{0:X2}", (int)@char);
      }
      return sb.ToString();
    }

    #endregion Public Static Methods

    public AuthorizeHeader GetRequestTokenAuthorizationHeader(string url, string realm, string consumerKey, string consumerSecret, string callbackUrl, string scope, SignatureMethod signatureMethod = SignatureMethod.HMACSHA1, string httpMethod = "POST")
    {
      var urlEncodedCallback = UrlEncode(callbackUrl);
      var timestamp = GenerateTimeStamp();
      var nounce = GenerateNonce(timestamp);

      var protocolParameters = ExtractQueryStrings(url);
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.ConsumerKey.GetStringValue(), consumerKey));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.SignatureMethod.GetStringValue(), signatureMethod.GetStringValue()));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Timestamp.GetStringValue(), timestamp));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Nounce.GetStringValue(), nounce));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Version.GetStringValue(), OAuthVersion));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Callback.GetStringValue(), callbackUrl));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Scope.GetStringValue(), scope));

      string signatureBaseString = GenerateSignatureBaseString(url, httpMethod, protocolParameters);
      var signature = GenerateSignature(consumerSecret, signatureMethod, signatureBaseString);
      return new AuthorizeHeader(realm, consumerKey, signatureMethod.GetStringValue(), signature, timestamp, nounce, OAuthVersion, callbackUrl, scope);
    }

    public AuthorizeHeader GetAccessTokenAuthorizationHeader(string url, string realm, string consumerKey, string consumerSecret, string token, string verifier, string tokenSecret, string scope, SignatureMethod signatureMethod = SignatureMethod.HMACSHA1, string httpMethod = "POST")
    {
      var timestamp = GenerateTimeStamp();
      var nounce = GenerateNonce(timestamp);

      var protocolParameters = ExtractQueryStrings(url);
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.ConsumerKey.GetStringValue(), consumerKey));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.SignatureMethod.GetStringValue(), signatureMethod.GetStringValue()));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Timestamp.GetStringValue(), timestamp));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Nounce.GetStringValue(), nounce));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Version.GetStringValue(), OAuthVersion));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Token.GetStringValue(), token));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Verifier.GetStringValue(), verifier));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Scope.GetStringValue(), scope));

      string signatureBaseString = GenerateSignatureBaseString(url, httpMethod, protocolParameters);
      System.Diagnostics.Debug.WriteLine(signatureBaseString);

      var signature = GenerateSignature(consumerSecret, signatureMethod, signatureBaseString, tokenSecret);
      return new AuthorizeHeader(realm, consumerKey, signatureMethod.GetStringValue(), signature, timestamp, nounce, OAuthVersion, token, verifier, scope);
    }


    public AuthorizeHeader send(string url, string realm, string consumerKey, string consumerSecret, string token, string tokenSecret, string scope, SignatureMethod signatureMethod = SignatureMethod.HMACSHA1, string httpMethod = "POST")
    {
      System.Diagnostics.Debug.WriteLine("");
      System.Diagnostics.Debug.WriteLine(token);
      System.Diagnostics.Debug.WriteLine(tokenSecret);
      System.Diagnostics.Debug.WriteLine("----");
      var timestamp = GenerateTimeStamp();
      var nounce = GenerateNonce(timestamp);

      var protocolParameters = ExtractQueryStrings(url);
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.ConsumerKey.GetStringValue(), consumerKey));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.SignatureMethod.GetStringValue(), signatureMethod.GetStringValue()));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Timestamp.GetStringValue(), timestamp));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Nounce.GetStringValue(), nounce));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Version.GetStringValue(), OAuthVersion));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Token.GetStringValue(), token));
      protocolParameters.Add(new ProtocolParameter(OAuthProtocolParameter.Scope.GetStringValue(), scope));

      string signatureBaseString = GenerateSignatureBaseString(url, httpMethod, protocolParameters);
      System.Diagnostics.Debug.WriteLine(signatureBaseString);

      var signature = GenerateSignature(consumerSecret, signatureMethod, signatureBaseString, tokenSecret);
      return new AuthorizeHeader(realm, consumerKey, signatureMethod.GetStringValue(), signature, timestamp, nounce, OAuthVersion, token, "DUMMY VERIFIER", scope);
    }
  
  }

  public enum SignatureMethod
  {
    [EnumStringValueAttribute("HMAC-SHA1")]
    HMACSHA1,
    [EnumStringValueAttribute("RSA-SHA1")]
    RSASHA1,
    [EnumStringValueAttribute("PLAINTEXT")]
    PLAINTEXT
  }

  internal enum OAuthProtocolParameter
  {
    [EnumStringValueAttribute("oauth_consumer_key")]
    ConsumerKey,
    [EnumStringValueAttribute("oauth_signature_method")]
    SignatureMethod,
    [EnumStringValueAttribute("oauth_signature")]
    Signature,
    [EnumStringValueAttribute("oauth_timestamp")]
    Timestamp,
    [EnumStringValueAttribute("oauth_nonce")]
    Nounce,
    [EnumStringValueAttribute("oauth_version")]
    Version,
    [EnumStringValueAttribute("oauth_callback")]
    Callback,
    [EnumStringValueAttribute("oauth_verifier")]
    Verifier,
    [EnumStringValueAttribute("oauth_token")]
    Token,
    [EnumStringValueAttribute("oauth_token_secret")]
    TokenSecret,
    [EnumStringValueAttribute("scope")]
    Scope
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class EnumStringValueAttribute : Attribute
  {
    public string Value { get; private set; }

    public EnumStringValueAttribute(string value)
    {
      Value = value;
    }
  }

  public static class EnumStringValueExtension
  {
    public static string GetStringValue(this Enum value)
    {
      string output = null;
      Type type = value.GetType();
      FieldInfo fieldInfo = type.GetField(value.ToString());
      EnumStringValueAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(EnumStringValueAttribute), false) as EnumStringValueAttribute[];
      if (attributes.Length > 0)
        output = attributes[0].Value;
      return output;
    }
  }
}
