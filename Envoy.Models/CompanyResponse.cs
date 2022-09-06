using Newtonsoft.Json;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class CompanyResponse
    {
        [JsonProperty("data")]
        public List<Company> Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
