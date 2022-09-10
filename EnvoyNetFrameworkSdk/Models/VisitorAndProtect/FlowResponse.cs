using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class FlowResponse
    {
        [JsonProperty("data")]
        public Flow Flow { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
