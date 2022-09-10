using Newtonsoft.Json;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models
{
    public class CompanyResponse
    {
        [JsonProperty("data")]
        public List<Company> Companies { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
