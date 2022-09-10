using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class WorkSchedulesResponse
    {
        [JsonProperty("data")]
        public List<WorkSchedule> WorkSchedules { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
