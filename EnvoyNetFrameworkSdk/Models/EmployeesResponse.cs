using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models
{
    public class EmployeesResponse
    {
        [JsonProperty("data")]
        public List<Employee> Employees { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
