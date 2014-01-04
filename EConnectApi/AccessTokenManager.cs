using System;
using System.Collections.Generic;
using System.Linq;
using EConnectApi.OAuth;

namespace EConnectApi
{
    internal class AccessTokenManager
    {
        private readonly List<AccessTokenStoreItem> _scopeAndToken = new List<AccessTokenStoreItem>();
        
        protected AccessTokenStoreItem GetItem(string scope)
        {
            return _scopeAndToken.FirstOrDefault(a => a.Scope.Equals(scope, StringComparison.InvariantCultureIgnoreCase) && a.ExpiratedOn > DateTime.Now);
        }

        /// <summary>
        /// Store access token for scope in memory
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="token"></param>
        /// <param name="expiratedOn">DefaultStatus is 120 min</param>
        public void Store(string scope, AccessToken token, DateTime? expiratedOn = null)
        {
            if(string.IsNullOrEmpty(scope))
                throw new ArgumentNullException("scope");

            if(token == null)
                throw new ArgumentNullException("token");

            var storeItem = GetItem(scope);
            
            if (storeItem != null)
                _scopeAndToken.Remove(storeItem);

            _scopeAndToken.Add(new AccessTokenStoreItem()
                {
                    Scope = scope,
                    Token = token,
                    ExpiratedOn = expiratedOn.GetValueOrDefault(DateTime.Now.AddMinutes(120))
                });
        }

        public AccessToken GetTokenOrNull(string scope)
        {
            var accessTokenEnitity = GetItem(scope);
            if (accessTokenEnitity != null)
                return accessTokenEnitity.Token;
            return null;
        }
    }
}