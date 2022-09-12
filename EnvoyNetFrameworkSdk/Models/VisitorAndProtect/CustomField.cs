using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class CustomField
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
