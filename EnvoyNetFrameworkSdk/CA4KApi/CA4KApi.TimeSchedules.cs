using System;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        private int GetOrCreateTimeSchedule(long badgeNo)
        {
            string name = GenerateTimeScheduleName(badgeNo);
            int no = GetTimeScheduleNoByName(name);
            if (no > 0)
            {
                CreateDefaultTimeScheduleTimeBlock(no);
                return no;
            }

            no = GetNextTimeScheduleNo();
            CreateTimeSchedule(name, no);
            CreateDefaultTimeScheduleTimeBlock(no);

            return no;
        }
        private string GenerateTimeScheduleName(long badgeNo) => $"Envoy Time Schedule For Badge {badgeNo}";
        private int GetTimeScheduleNoByName(string name)
        {
            DataTable dt = caAccess.GetTimeSchedule();

            return dt.AsEnumerable()
                  .Where(dr => dr["DisplayMember"]?.ToString().ToLower() == name.ToLower())
                  .Select(dr => Convert.ToInt32(dr["ValueMember"]))
                  .FirstOrDefault();
        }
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
        private void CreateTimeSchedule(string name, int no)
        {
            bool result = caAccess.TimeScheduleOperation(name, no, 0) == 0;
            if (!result)
            {
                throw new Exception("Couldn't create time schedule");
            }
            //DateTime now = DateTime.Now;

            //return result && CreateTimeScheduleTimeBlock(no, 0, (int)now.DayOfWeek, (int)now.DayOfWeek, now, now.AddSeconds(60 * 2));
        }
        private void CreateDefaultTimeScheduleTimeBlock(int no)
        {
            ClearTimeScheduleTimeBlocks(no);

            DateTime now = DateTime.Now;
            CreateTimeScheduleTimeBlock(
                no,
                0,
                (int)now.DayOfWeek,
                (int)now.DayOfWeek,
                now,
                now.AddSeconds(60 * 2)
            );
        }
        private void ClearTimeScheduleTimeBlocks(int no)
        {
            var dt = caAccess.GetTimeBlockIndexByTimeSchedule(no);

            dt.AsEnumerable().Select(dr => dr["ValueMember"])
                .OfType<int>()
                .ToList()
                .ForEach(index =>
                {
                    DateTime now = DateTime.Now;

                    DeleteTimeScheduleTimeBlock(
                       no,
                       index,
                       (int)now.DayOfWeek,
                       (int)now.DayOfWeek,
                       now,
                       now.AddSeconds(60 * 2)
                   );
                });
        }
        private bool CreateTimeScheduleTimeBlock(int no, int index, int dayFrom, int dayTo, DateTime timeFrom, DateTime timeTo) =>
           caAccess.TimeScheduleTimeBlockOperation(no, index, dayFrom, dayTo, timeFrom, timeTo, 0) == 0;
        private bool DeleteTimeScheduleTimeBlock(int no, int index, int dayFrom, int dayTo, DateTime timeFrom, DateTime timeTo) =>
          caAccess.TimeScheduleTimeBlockOperation(no, index, dayFrom, dayTo, timeFrom, timeTo, 1) == 0;
        private bool DeleteTimeSchedule(string name, int no) =>
            caAccess.TimeScheduleOperation(name, no, 1) == 0;
    }
}

