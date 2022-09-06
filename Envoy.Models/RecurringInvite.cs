using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Envoy.Models
{
    public class RecurringInvite
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("recurrenceRule")]
        public string RecurrenceRule { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("secretToken")]
        public string SecretToken { get; set; }

        [JsonProperty("flowId")]
        public string FlowId { get; set; }

        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("inviteIds")]
        public List<string> InviteIds { get; set; }

        [JsonProperty("sendEmailToInvitee")]
        public bool SendEmailToInvitee { get; set; }

        [JsonProperty("customFields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonProperty("invitee")]
        public Invitee Invitee { get; set; }

        [JsonProperty("host")]
        public Host Host { get; set; }
    }
}
