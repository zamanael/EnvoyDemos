using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class WorkScheduleResponse
    {
        [JsonProperty("data")]
        public WorkSchedule WorkSchedule { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
