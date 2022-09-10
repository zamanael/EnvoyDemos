using Newtonsoft.Json;
using System;

namespace EnvoyNetFrameworkSdk.Models.VisitorAndProtect
{
    public class WorkSchedule
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("expectedArrivalAt")]
        public DateTime ExpectedArrivalAt { get; set; }

        [JsonProperty("expectedDepartureAt")]
        public DateTime ExpectedDepartureAt { get; set; }

        [JsonProperty("arrivedAt")]
        public object ArrivedAt { get; set; }

        [JsonProperty("departedAt")]
        public object DepartedAt { get; set; }

        [JsonProperty("flowId")]
        public string FlowId { get; set; }

        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("registrationURL")]
        public string RegistrationURL { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("scheduledFor")]
        public ScheduledFor ScheduledFor { get; set; }
    }
}
