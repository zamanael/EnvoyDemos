using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.Core
{
    public class Company
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locationIds")]
        public List<string> LocationIds { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
