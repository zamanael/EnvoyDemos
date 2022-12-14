using System;

namespace EnvoyNetFrameworkSdk.Models
{
    public class UserData
    {
        public string Host { get; set; }
        public long? BadgeNo { get; set; }
        public short? FacilityNo { get; set; }
        public string VisitorType { get; set; }
        public string VisitorFullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Email { get; set; }
        public DateTime? ExpectedArrivalTime { get; set; }
    }
}
