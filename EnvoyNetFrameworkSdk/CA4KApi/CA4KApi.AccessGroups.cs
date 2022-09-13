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

        public int GetAccessGroupNoByName(string name)
        {
            DataTable dt = caAccess.GetAccessGroups();

            return dt.AsEnumerable()
                  .Where(dr => dr["DisplayMember"]?.ToString().ToLower() == name.ToLower())
                  .Select(dr => Convert.ToInt32(dr["ValueMember"]))
                  .FirstOrDefault();
        }

        //private int GetNextAccessGroupNo()
        //{
        //    var dt = caAccess.GetAccessGroups();

        //    if (dt != null)
        //    {
        //        return dt.AsEnumerable()
        //            .Select(dr => Convert.ToInt32(dr["ValueMember"]))
        //            .Max() + 1;
        //    }

        //    return 1;
        //}

        //private bool CreateAccessGroup(string name, int no)
        //{
        //    bool result = caAccess.AccessGroupOperation(name, no, 0) == 0;
        //    DateTime now = DateTime.Now;

        //    return result && CreateTimeScheduleTimeBlock(no, 0, (int)now.DayOfWeek, (int)now.DayOfWeek, now, now.AddSeconds(60 * 2));
        //}
    }
}

