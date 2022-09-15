using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        private UserData GetUserData(JObject data)
        {
            JArray userDataArray = data["payload"]["attributes"]["user-data"] as JArray;
            var dic = new Dictionary<string, object>();

            foreach (var customField in JsonConvert
                .DeserializeObject<IEnumerable<CustomField>>(userDataArray.ToString()))
            {
                dic.Add(customField.Field, customField.Value);
            }

            long? badgeNo = null;
            if (dic.ContainsKey("Badge No") && long.TryParse(dic["Badge No"].ToString(), out long b))
            {
                badgeNo = b;
            }

            short? facilityNo = null;
            if (dic.ContainsKey("Facility No") && short.TryParse(dic["Facility No"].ToString(), out short f))
            {
                facilityNo = f;
            }

            string firstName = null;
            string lastName = null;
            string mi = null;
            // string fullName = dic["Your Full Name"]?.ToString();
            string fullName = data["payload"]["attributes"]["full-name"]?.ToString();

            if (!string.IsNullOrEmpty(fullName))
            {
                string[] arr = fullName.Split(' ');
                firstName = arr.First();
                lastName = arr.Last();
                if (arr.Length > 2)
                    mi = arr[1];
            }

            string expectedArrivalTime = data["payload"]["attributes"]["expected-arrival-time"]?.ToString();

            return new UserData
            {
                Room = dic.ContainsKey("Room") ? dic["Room"]?.ToString() : null,
                BadgeNo = badgeNo,
                Email = dic.ContainsKey("Your Email Address") ? dic["Your Email Address"]?.ToString() : null,
                FacilityNo = facilityNo,
                FirstName = firstName,
                Host = dic.ContainsKey("Host") ? dic["Host"]?.ToString() : null,
                LastName = lastName,
                MI = mi,
                PurposeOfVisit = dic.ContainsKey("Purpose of visit") ? dic["Purpose of visit"]?.ToString() : null,
                VisitorFullName = dic.ContainsKey("Your Full Name") ? dic["Your Full Name"]?.ToString() : null,
                ExpectedArrivalTime = string.IsNullOrEmpty(expectedArrivalTime) ? (DateTime?)null : DateTime.Parse(expectedArrivalTime).ToLocalTime()
            };
        }

        private Dictionary<string, int> GetRoomToAccessGroupMapping(JObject data)
        {
            JObject config = data["meta"]["config"]["accessGroups"] as JObject;
            var map = new Dictionary<string, int>();

            foreach (var item in config)
            {
                map.Add(item.Value.ToString(), int.Parse(item.Key));
            }

            return map;
        }

        private bool IsInvited(JObject data)
        {
            return data["payload"]["relationships"]["invite"] != null;
        }
    }
}
