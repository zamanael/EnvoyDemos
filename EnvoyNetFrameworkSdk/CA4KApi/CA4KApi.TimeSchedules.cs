using System;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        private bool CreateTimeSchedule(string name, int no)
        {
            bool result = caAccess.TimeScheduleOperation(name, no, 0) == 0;
            DateTime now = DateTime.Now;

            return result && CreateTimeScheduleTimeBlock(no, 0, (int)now.DayOfWeek, (int)now.DayOfWeek, now, now.AddSeconds(60 * 2));
        }

        private bool CreateTimeScheduleTimeBlock(int no, int index, int dayFrom, int dayTo, DateTime timeFrom, DateTime timeTo) =>
           caAccess.TimeScheduleTimeBlockOperation(no, index, dayFrom, dayTo, timeFrom, timeTo, 0) == 0;

        private bool DeleteTimeSchedule(string name, int no) =>
            caAccess.TimeScheduleOperation(name, no, 1) == 0;

        private int GetNextTimeScheduleNo()
        {
            var dt = caAccess.GetTimeSchedules();

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

