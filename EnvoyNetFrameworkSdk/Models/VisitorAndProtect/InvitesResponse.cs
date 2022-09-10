using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class InvitesResponse
    {
        [JsonProperty("data")]
        public List<Invite> Invites { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
