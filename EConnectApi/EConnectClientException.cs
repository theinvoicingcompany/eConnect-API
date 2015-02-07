using System;
using System.CodeDom;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace EConnectApi
{
    [Serializable]
    public class EConnectClientException : Exception
    {
        public string Details { get; set; }
        public string Code { get; set; }

        public EConnectClientException(SoapFault fault)
            : base(fault.FaultString)
        {
            Details = fault.Detail.ToString();
            Code = fault.FaultCode;
        }

        public EConnectClientException()
        {
        }

        public EConnectClientException(string message)
            : base(message)
        {
        }

        public EConnectClientException(string message, Exception inner)
            : base(message, inner)
        {
            Details = message;
        }

        protected EConnectClientException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}