using System.Threading.Tasks;

namespace Api.Dto.OAuth
{
    public class OAuthSoapHeader : ISoapHeader
    {
        private readonly OAuthToken _oauthToken;
        public string ClusterUri { get; set; } = "https://api.accounting.twinfield.com";
        public string Company { get; set; }

        public OAuthSoapHeader(OAuthToken oauthToken)
        {
            _oauthToken = oauthToken;
        }

        public async Task<TwinfieldFinderService.Header> GetHeaderAsync(TwinfieldFinderService.Header header)
        {
            header.AccessToken = _oauthToken.Accesstoken;

            if (!string.IsNullOrEmpty(Company))
                header.CompanyCode = Company;

            return header;
        }

        public async Task<TwinfieldProcessXmlService.Header> GetHeaderAsync(TwinfieldProcessXmlService.Header header)
        {
            header.AccessToken = _oauthToken.Accesstoken;

            if (!string.IsNullOrEmpty(Company))
                header.CompanyCode = Company;

            return header;
        }
    }
}
