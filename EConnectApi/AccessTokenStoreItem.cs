using System;
using EConnectApi.OAuth;

namespace EConnectApi
{
    internal class AccessTokenStoreItem
    {
        public string Scope { get; set; }
        public AccessToken Token { get; set; }
        public DateTime ExpiratedOn { get; set; }
    }
}