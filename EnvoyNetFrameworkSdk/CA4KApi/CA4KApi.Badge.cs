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
            ushort accessGroupNo = (ushort)GetAccessGroupNoByName(userData.AccessGroupName);
            ushort operation = 0; //insert;

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
            //ushort accessGroupNo = (ushort)GetAccessGroupNoByName(userData.AccessGroupName);
            ushort[] agNos = Enumerable.Empty<ushort>().ToArray();
            ushort operation = 1; //delete;

            bool badgeExists = caAccess.BadgeExists((long)badge, facility, pivi);

            if (badgeExists)
                caAccess.BadgeOperation(
                    facility,
                    badge,
                    firstName,
                    lastName,
                    mi,
                    agNos,
                    operation
                );
        }
    }
}

