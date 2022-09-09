using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class InvitesResponse
    {
        [JsonProperty("data")]
        public List<Invite> Invites { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
