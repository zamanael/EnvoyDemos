using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models
{
    public class Meta
    {
        [JsonProperty("relationships")]
        public List<string> Relationships { get; set; }
    }
}
