using CardAccess.API;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed class CA4KApi
    {
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
        private static volatile CA4KApi _instance;
        private static readonly object SyncLock = new object();

        private ca4Knet caAccess;
        bool apiInitialized = false;

        private CA4KApi()
        {
            try
            {
                caAccess = new ca4Knet();
                caAccess.LogIn("admin", "");
                if (caAccess.ConnectStr != "")
                {
                    apiInitialized = true;
                }
            }
            catch (Exception ex)
            {
                if (caAccess != null) caAccess = null;
            }
        }

        //uses a pattern known as double check locking
        public static CA4KApi Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CA4KApi();
                    }
                }

                return _instance;
            }
        }

        public IEnumerable<(string DisplayMember, string ValueMember)> GetAccessGrous()
        {
            var dt = caAccess.GetAccessGroups();

            if (dt != null)
            {
                return dt.AsEnumerable()
                    .Select(dr => (dr["DisplayMember"].ToString(), dr["ValueMember"].ToString()))
                    .ToArray();
            }

            return Enumerable.Empty<(string, string)>();
        }

        public void ActivateBadge(JObject data)
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
            ushort operation = 0; //insert;
            bool badgeExists = caAccess.BadgeExists((long)badge, facility, pivi);

            if (badgeExists)
            {
                operation = 2; // update
            }

            caAccess.BadgeOperation(facility, badge, firstName, lastName, mi, new ushort[] { accessGroup }, operation);
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
