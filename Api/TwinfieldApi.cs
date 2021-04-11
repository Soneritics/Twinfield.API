using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Dto.OAuth;
using Api.Exceptions;
using Api.Services;
using Api.Services.Auth;

namespace Api
{
    public class TwinfieldApi
    {
        private readonly HttpClient _httpClient;
        private readonly OAuthClientSettings _oAuthClientSettings;
        private OAuthSoapHeader _soapHeader;

        #region Field
        private async Task<OAuthSoapHeader> GetSoapHeader()
        {
            return _soapHeader ??= new OAuthSoapHeader(Token)
            {
                ClusterUri = await AuthorizationService.GetClusterUrlAsync()
            };
        }

        private OAuthToken _token;
        public OAuthToken Token
        {
            get => _token;
            set
            {
                _soapHeader = default;
                _token = value;
            }
        }

        protected AuthenticationService AuthenticationService => new AuthenticationService(_oAuthClientSettings, _httpClient);
        protected AuthorizationService AuthorizationService => new AuthorizationService(_oAuthClientSettings, Token, _httpClient);

        public ServiceFactory ServiceFactory
        {
            get
            {
                if (Token == default)
                {
                    throw new MissingFieldException("Field `Token` has not been set");
                }

                if (Token?.IsExpired() == true)
                {
                    throw new TokenExpiredException();
                }

                return new ServiceFactory(GetSoapHeader().GetAwaiter().GetResult());
            }
        }
        #endregion

        public TwinfieldApi(HttpClient httpClient, OAuthClientSettings oAuthClientSettings)
        {
            _httpClient = httpClient;
            _oAuthClientSettings = oAuthClientSettings;
        }

        public TwinfieldApi(OAuthClientSettings oAuthClientSettings)
            : this(new HttpClient(), oAuthClientSettings)
        {
        }

        #region Authentication
        public string GetAuthorizationUrl(string redirectUrl, string state, string nonce)
        {
            return AuthenticationService
                .GetAuthorizationUrl(redirectUrl, state, nonce);
        }

        public string GetAuthorizationUrl(string redirectUrl)
        {
            return AuthenticationService
                .GetAuthorizationUrl(redirectUrl);
        }

        public async Task SetAccessTokenByAuthorizationCodeAsync(string authorizationCode, string redirectUrl)
        {
            Token = await AuthenticationService
                .GetAccessTokenByAuthorizationCodeAsync(authorizationCode, redirectUrl);
        }
        #endregion

        public async Task RefreshTokenAsync()
        {
            Token = await AuthorizationService.GetRefreshTokenAsync();
            await GetSoapHeader();
        }

        public void SetCompany(string companyCode)
        {
            _soapHeader.Company = companyCode;
        }
    }
}
