using System.Runtime.Serialization.Formatters;

namespace EConnectApi
{
    public class UnauthorizedException : EConnectClientException
    {
        public UnauthorizedException(SoapFault fault) : base(fault)
        {
            
        }
    }
}