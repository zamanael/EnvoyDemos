using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class Invite
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("expectedArrivalAt")]
        public DateTime ExpectedArrivalAt { get; set; }

        [JsonProperty("expectedDepartureAt")]
        public DateTime ExpectedDepartureAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("flowId")]
        public string FlowId { get; set; }

        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("approvalStatus")]
        public string ApprovalStatus { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("secretToken")]
        public string SecretToken { get; set; }

        [JsonProperty("sendEmailToInvitee")]
        public bool SendEmailToInvitee { get; set; }

        [JsonProperty("customFields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("invitee")]
        public Invitee Invitee { get; set; }

        [JsonProperty("host")]
        public object Host { get; set; }
    }
}
