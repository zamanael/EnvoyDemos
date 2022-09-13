using EnvoyNetFrameworkSdk.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        public IEnumerable<Option> GetAccessGroupsOptions()
        {
            try
            {
                var dt = caAccess.GetAccessGroups();

                if (dt != null)
                {
                    return dt.AsEnumerable()
                        .Select(dr => new Option
                        {
                            Label = dr["DisplayMember"].ToString(),
                            Value = dr["ValueMember"].ToString()
                        })
                        .ToArray();
                }

                return Enumerable.Empty<Option>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        private int GetOrCreateAccessGroup(string name, long badgeNo)
        {
            int no = GetAccessGroupNoByName(name);
            if (no > 0)
                return no;

            name = GenerateAccessGroupName(badgeNo);
            no = GetAccessGroupNoByName(name);
            if (no > 0)
            {
                GetOrCreateTimeSchedule(badgeNo);
                //CreateDefaultTimeScheduleTimeBlock(no);
                return no;
            }

            no = GetNextAccessGroupNo();
            bool success = caAccess.AccessGroupOperation(name, no, 0) == 0;
            if (!success)
                throw new Exception("Couldn't create access group.");

           

            return no;
        }

        private int GetAccessGroupNoByName(string name)
        {
            DataTable dt = caAccess.GetAccessGroups();

            return dt.AsEnumerable()
                  .Where(dr => dr["DisplayMember"]?.ToString().ToLower() == name.ToLower())
                  .Select(dr => Convert.ToInt32(dr["ValueMember"]))
                  .FirstOrDefault();
        }

        private string GenerateAccessGroupName(long badgeNo) => $"Envoy Access Group For Badge {badgeNo}";

        private int GetNextAccessGroupNo()
        {
            var dt = caAccess.GetAccessGroups();

            if (dt != null)
            {
                return dt.AsEnumerable()
                     .Select(dr => Convert.ToInt32(dr["ValueMember"]))
                     .Max() + 1;
            }

            return 1;
        }
    }
}

