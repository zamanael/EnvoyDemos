using Newtonsoft.Json;

namespace Envoy.Models
{
    public class LocationResponse
    {
        [JsonProperty("data")]
        public Location Locations { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
