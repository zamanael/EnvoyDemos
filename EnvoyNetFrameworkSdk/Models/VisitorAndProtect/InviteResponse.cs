using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class InviteResponse
    {
        [JsonProperty("data")]
        public Invite Invite { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
