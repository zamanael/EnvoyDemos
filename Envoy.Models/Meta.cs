using Newtonsoft.Json;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class Meta
    {
        [JsonProperty("relationships")]
        public List<object> Relationships { get; set; }
    }
}
