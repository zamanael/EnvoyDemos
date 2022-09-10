using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.Core
{
    public class LocationResponse
    {
        [JsonProperty("data")]
        public Location Locations { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
