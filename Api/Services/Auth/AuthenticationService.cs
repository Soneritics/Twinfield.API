using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Dto.OAuth;

namespace Api.Services.Auth
{
    public class AuthenticationService : AuthServiceBase
    {
        private readonly OAuthClientSettings _oAuthClientSettings;

        public AuthenticationService(OAuthClientSettings oAuthClientSettings, HttpClient httpClient)
            : base(httpClient)
        {
            _oAuthClientSettings = oAuthClientSettings;
        }

        public string GetAuthorizationUrl(string redirectUrl, string state, string nonce)
        {
            return "https://login.twinfield.com/auth/authentication/connect/authorize" +
                $"?client_id={_oAuthClientSettings.Id}" +
                "&response_type=code&scope=openid+twf.organisationUser+twf.user+twf.organisation+offline_access" +
                $"&redirect_uri={redirectUrl}&state={state}&nonce={nonce}";
        }

        public string GetAuthorizationUrl(string redirectUrl)
        {
            return GetAuthorizationUrl(
                redirectUrl,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            );
        }

        public async Task<OAuthToken> GetAccessTokenByAuthorizationCodeAsync(string authorizationCode, string redirectUrl)
        {
            var postObject = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("redirect_uri", redirectUrl)
            };

            var rawToken = await GetApiResult<RawToken>(
                HttpMethod.Post,
                "https://login.twinfield.com/auth/authentication/connect/token",
                _oAuthClientSettings,
                postObject
            );

            return new OAuthToken()
            {
                Accesstoken = rawToken.Accesstoken,
                RefreshToken = rawToken.RefreshToken,
                ExpiresIn = rawToken.ExpiresIn
            };
        }
    }
}
