using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models
{
    public class Invitee
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
