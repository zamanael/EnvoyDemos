using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        public void ActivateBadge(JObject data)
        {
            UserData userData = GetUserData(data);

            if (!userData.BadgeNo.HasValue ||
                !userData.FacilityNo.HasValue ||
                string.IsNullOrEmpty(userData.FirstName) ||
                string.IsNullOrEmpty(userData.LastName) ||
                string.IsNullOrEmpty(userData.AccessGroupName))
                return;

            ulong badge = (ulong)userData.BadgeNo;
            ushort facility = userData.FacilityNo.Value;
            string pivi = "0";
            string firstName = userData.FirstName;
            string lastName = userData.LastName;
            string mi = userData.MI ?? "";
            ushort operation = 0; //insert;
            ushort accessGroupNo = (ushort)GetAccessGroupNoByName(userData.AccessGroupName);


            bool badgeExists = caAccess.BadgeExists((long)badge, facility, pivi);
            if (badgeExists)
                operation = 2; // update

            caAccess.BadgeOperation(
                facility,
                badge,
                firstName,
                lastName,
                mi,
                new ushort[] { accessGroupNo },
                operation
            );
        }

        public void DeactivateBadge(JObject data)
        {
            JArray userData = data["payload"]["attributes"]["user-data"] as JArray;

            ulong badge = userData.OfType<JObject>()
                .Where(e => e.GetValue("field").ToString() == "Badge No")
                .Select(e => ulong.Parse(e.GetValue("value")?.ToString() ?? "0"))
                .FirstOrDefault();

            ushort facility = userData.OfType<JObject>()
                .Where(e => e.GetValue("field").ToString() == "Facility No")
                .Select(e => ushort.Parse(e.GetValue("value")?.ToString() ?? "0"))
                .FirstOrDefault();

            string[] nameArray = userData.OfType<JObject>()
               .Where(e => e.GetValue("field").ToString() == "Your Full Name")
               .Select(e => e.GetValue("value")?.ToString() ?? "0")
               .FirstOrDefault()
               .Split(' ');

            string firstName = nameArray.FirstOrDefault();
            string lastName = nameArray.LastOrDefault();
            string mi = nameArray.Length > 2 ? nameArray[1] : "";
            ushort accessGroup = 1;
            string pivi = "0";
            ushort operation = 1; //delete;
            bool badgeExists = caAccess.BadgeExists((long)badge, facility, pivi);


            if (badgeExists)
            {
                caAccess.BadgeOperation(facility, badge, firstName, lastName, mi, new ushort[] { accessGroup }, operation);
            }
        }
    }
}

