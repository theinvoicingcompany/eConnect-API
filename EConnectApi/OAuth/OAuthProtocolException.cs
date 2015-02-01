using System;
using System.Net;
using System.Runtime.Serialization;

// See Matlus.FederatedIdentity
namespace EConnectApi.OAuth
{
    internal class OAuthProtocolException : EConnectClientException
  {
    public OAuthProtocolException(string message)
      : base(message)
    {
        Details = "Protocol or network issue";
    }

    public OAuthProtocolException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public OAuthProtocolException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}