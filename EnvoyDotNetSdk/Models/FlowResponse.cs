using Newtonsoft.Json;

namespace Envoy.Models
{
    public class FlowResponse
    {
        [JsonProperty("data")]
        public Flow Flow { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
