using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Dto.OAuth;

namespace Api.Services.Auth
{
    public class AuthorizationService : AuthServiceBase
    {
        private readonly OAuthClientSettings _oAuthClientSettings;
        private readonly OAuthToken _token;

        public AuthorizationService(
            OAuthClientSettings oAuthClientSettings,
            OAuthToken token,
            HttpClient httpClient
        ) : base(httpClient)
        {
            _oAuthClientSettings = oAuthClientSettings;
            _token = token;
        }

        public async Task<OAuthToken> GetRefreshTokenAsync()
        {
            var postObject = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", _token.RefreshToken)
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

        public async Task<string> GetClusterUrlAsync()
        {
            var response = await GetApiResult<ClusterUriResponse>(
                HttpMethod.Get,
                $"https://login.twinfield.com/auth/authentication/connect/accesstokenvalidation?token={_token.Accesstoken}"
            );

            return response.ClusterUrl;
        }
    }
}
