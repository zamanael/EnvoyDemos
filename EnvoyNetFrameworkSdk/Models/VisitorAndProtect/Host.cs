using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class Host
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
