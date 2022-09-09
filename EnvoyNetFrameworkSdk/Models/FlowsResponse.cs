using Newtonsoft.Json;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class FlowsResponse
    {
        [JsonProperty("data")]
        public List<Flow> Flows { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
