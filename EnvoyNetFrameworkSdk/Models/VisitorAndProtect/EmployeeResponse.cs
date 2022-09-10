using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class EmployeeResponse
    {
        [JsonProperty("data")]
        public Employee Employee { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
