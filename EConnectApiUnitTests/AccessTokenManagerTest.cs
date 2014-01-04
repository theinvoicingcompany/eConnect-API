using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi;
using EConnectApi.OAuth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class AccessTokenManagerTest
    {
        internal AccessTokenManager AccessTokenManager = new AccessTokenManager();

        private AccessToken SampleAccessToken
        {
            get
            {
                var token = new AccessToken();
                token.Init("oauth_token=4cHvGr9a75ezXRb98lafmbXFG82dLDYM&oauth_token_secret=s80VcgU9IjsfkwEuFJsf2nFchKl4GLXo");
                return token;
            }
        }

        private AccessToken SampleAccessToken2
        {
            get
            {
                var token = new AccessToken();
                token.Init("oauth_token=5cHvGr9a75ezXRb98lafmbXFG82dLDYM&oauth_token_secret=s90VcgU9IjsfkwEuFJsf2nFchKl4GLXo");
                return token;
            }
        }

        private void AssertAreEqualAccessToken(AccessToken token1, AccessToken token2)
        {
            Assert.AreEqual(token1.Token, token2.Token);
            Assert.AreEqual(token1.TokenSecret, token2.TokenSecret);
        }

        [TestMethod]
        public void Insert_Valid()
        {
            const string scope = "scope1";
            AccessTokenManager.Store(scope, SampleAccessToken, DateTime.Now.AddMinutes(1));
            var token = AccessTokenManager.GetTokenOrNull(scope);
            AssertAreEqualAccessToken(SampleAccessToken, token);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_TokenNull()
        {
            const string scope = "scope_token_null";
            AccessTokenManager.Store(scope, null, DateTime.Now.AddMinutes(1));
            var token = AccessTokenManager.GetTokenOrNull(scope);
            Assert.IsNull(token);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_ScopeNull()
        {
            const string scope = null;
            AccessTokenManager.Store(scope, SampleAccessToken, DateTime.Now.AddMinutes(1));
            var token = AccessTokenManager.GetTokenOrNull(scope);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void Insert_AndOverwrite()
        {
            const string scope = "scope_overwrite";
            AccessTokenManager.Store(scope, SampleAccessToken, DateTime.Now.AddMinutes(10));
            AccessTokenManager.Store(scope, SampleAccessToken2, DateTime.Now.AddMinutes(10));
            var token = AccessTokenManager.GetTokenOrNull(scope);
            AssertAreEqualAccessToken(SampleAccessToken2, token);
        }

        [TestMethod]
        public void GetExpiratedToken()
        {
            const string scope = "scope_expiration";
            AccessTokenManager.Store(scope, SampleAccessToken, DateTime.Now.AddMinutes(-1));
            var token = AccessTokenManager.GetTokenOrNull(scope);
            Assert.IsNull(token);
        }
    }
}
