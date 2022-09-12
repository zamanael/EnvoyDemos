using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models
{
    public class Option
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
