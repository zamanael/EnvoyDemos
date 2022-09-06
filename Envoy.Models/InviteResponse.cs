using Newtonsoft.Json;

namespace Envoy.Models
{
    public class InviteResponse
    {
        [JsonProperty("data")]
        public Invite Invite { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
