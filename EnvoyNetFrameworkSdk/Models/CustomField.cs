using Newtonsoft.Json;

namespace Envoy.Models
{
    public class CustomField
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
