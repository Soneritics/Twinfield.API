using Newtonsoft.Json;

namespace Api.Dto.OAuth
{
    public class RawToken
    {
        [JsonProperty("access_token")]
        public string Accesstoken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
