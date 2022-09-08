using Newtonsoft.Json;

namespace Envoy.Models
{
    public class TokenResponse
    {
        [JsonProperty("token_type")]
        public string Token_type { get; set; }

        [JsonProperty("access_token")]
        public string Access_token { get; set; }

        [JsonProperty("expires_in")]
        public int Expires_in { get; set; }

        [JsonProperty("refresh_token")]
        public string Refresh_token { get; set; }

        [JsonProperty("refresh_token_expires_in")]
        public int Refresh_token_expires_in { get; set; }

        [JsonProperty("state")]
        public object State { get; set; }

        [JsonProperty("company_id")]
        public string Company_id { get; set; }
    }
}
