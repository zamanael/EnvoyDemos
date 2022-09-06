using Newtonsoft.Json;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class LocationResponse
    {
        [JsonProperty("data")]
        public List<Location> Locations { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
