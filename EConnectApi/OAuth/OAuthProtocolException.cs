using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

// See Matlus.FederatedIdentity
namespace EConnectApi.OAuth
{
    internal class OAuthProtocolException : Exception
  {
    public OAuthProtocolException(string message)
      : base(message)
    {
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