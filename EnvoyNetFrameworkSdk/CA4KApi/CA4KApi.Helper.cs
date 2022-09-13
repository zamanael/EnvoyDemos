﻿using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        private UserData GetUserData(JObject data)
        {
            UserData userData = new UserData();

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
            string fullName = dic["Your Full Name"]?.ToString();

            if (!string.IsNullOrEmpty(fullName))
            {
                string[] arr = fullName.Split(' ');
                firstName = arr.First();
                lastName = arr.Last();
                if (arr.Length > 2)
                    mi = arr[1];
            }

            return new UserData
            {
                AccessGroupName = dic["Access Group"]?.ToString(),
                BadgeNo = badgeNo,
                Email = dic["Your Email Address"]?.ToString(),
                FacilityNo = facilityNo,
                FirstName = firstName,
                Host = dic["Host"]?.ToString(),
                LastName = lastName,
                MI = mi,
                PurposeOfVisit = dic["Purpose of visit"]?.ToString(),
                VisitorFullName = dic["Your Full Name"]?.ToString()
            };
        }
    }
}