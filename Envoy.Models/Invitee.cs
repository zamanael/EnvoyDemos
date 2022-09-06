using Newtonsoft.Json;

namespace Envoy.Models
{
    public class Invitee
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
