using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models
{
    public class RecurringInviteResponse
    {
        [JsonProperty("data")]
        public RecurringInvite RecurringInvite { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
