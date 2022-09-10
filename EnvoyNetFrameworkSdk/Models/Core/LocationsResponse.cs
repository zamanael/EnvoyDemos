using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.Core
{
    public class LocationsResponse
    {
        [JsonProperty("data")]
        public List<Location> Locations { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
