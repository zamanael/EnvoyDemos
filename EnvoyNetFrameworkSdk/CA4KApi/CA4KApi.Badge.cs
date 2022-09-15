using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
                string.IsNullOrEmpty(userData.Room))
                return;


            ulong badge = (ulong)userData.BadgeNo;
            ushort facility = (ushort)userData.FacilityNo.Value;
            string pivi = "0";
            string firstName = userData.FirstName;
            string lastName = userData.LastName;
            string mi = userData.MI ?? "";
            string room = userData.Room;
            Dictionary<string, int> roomToAccessGroupMapping = GetRoomToAccessGroupMapping(data);
            ushort accessGroupNo = (ushort)roomToAccessGroupMapping[room];
            ushort[] agNos = new ushort[] { accessGroupNo };
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
                agNos,
                operation
            );

            //var now = GetRoundedNow(userData.ExpectedArrivalTime);
            bool isInvited = IsInvited(data);
            DateTime? actDate1 = null, deactDate1 = DateTime.Now.AddHours(2);
            if (isInvited)
            {
                var dt = caAccess.GetBadgeInfo((long)badge, facility);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var date = dt.Rows[0]["ActvDate"];
                    actDate1 = date == DBNull.Value ? null : (DateTime?)((DateTime)date).ToLocalTime();
                    date = dt.Rows[0]["ExprDate"];
                    deactDate1 = date == DBNull.Value ? null : (DateTime?)((DateTime)date).ToLocalTime();
                }
            }


            int enable = 1;
            caAccess.UpdateBadgeParams(
                facility,
                badge,
                actDate1,
                deactDate1,
                enable
            );
        }

        public void DeactivateBadge(JObject data)
        {
            UserData userData = GetUserData(data);

            if (!userData.BadgeNo.HasValue || !userData.FacilityNo.HasValue)
                return;

            ulong badge = (ulong)userData.BadgeNo;
            ushort facility = (ushort)userData.FacilityNo.Value;

            caAccess.UpdateBadgeParams(
                Facility: facility,
                Badge: badge,
                actDate1: null,
                deactDate1: null,
                enable: 0
            );
        }

        public void CreateBadgeForInvitation(JObject data)
        {
            UserData userData = GetUserData(data);

            if (!userData.BadgeNo.HasValue ||
                !userData.FacilityNo.HasValue ||
                string.IsNullOrEmpty(userData.FirstName) ||
                string.IsNullOrEmpty(userData.LastName) ||
                string.IsNullOrEmpty(userData.Room))
                return;


            ulong badge = (ulong)userData.BadgeNo;
            ushort facility = (ushort)userData.FacilityNo.Value;
            string pivi = "0";
            string firstName = userData.FirstName;
            string lastName = userData.LastName;
            string mi = userData.MI ?? "";
            string room = userData.Room;
            //Dictionary<string, int> roomToAccessGroupMapping = GetRoomToAccessGroupMapping(data);
            //ushort accessGroupNo = (ushort)roomToAccessGroupMapping[room];
            ushort accessGroupNo = (ushort)0;
            ushort[] agNos = new ushort[] { accessGroupNo };
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
                agNos,
                operation
            );

            var now = GetRoundedNow(userData.ExpectedArrivalTime);
            int enable = 1;
            caAccess.UpdateBadgeParams(
                facility,
                badge,
                now,
                now.AddHours(2),
                enable
            );
        }

        private DateTime GetRoundedNow(DateTime? n)
        {
            var now = n.HasValue ? n.Value : DateTime.Now;

            int minute = now.Minute % 15;

            if (minute > 0)
            {
                now = now.AddMinutes(-minute);
            }

            return now;
        }
    }
}
