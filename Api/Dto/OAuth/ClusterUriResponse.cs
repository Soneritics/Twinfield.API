using Newtonsoft.Json;

namespace Api.Dto.OAuth
{
    public class ClusterUriResponse
    {
        [JsonProperty("twf.clusterUrl")]
        public string ClusterUrl { get; set; }
    }
}