using Newtonsoft.Json;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class Meta
    {
        [JsonProperty("relationships")]
        public List<string> Relationships { get; set; }
    }
}
