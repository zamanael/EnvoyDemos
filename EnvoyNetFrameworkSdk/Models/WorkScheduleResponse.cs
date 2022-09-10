using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models
{
    public class WorkScheduleResponse
    {
        [JsonProperty("data")]
        public WorkSchedule WorkSchedule { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
