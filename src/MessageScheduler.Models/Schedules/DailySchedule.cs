using System;
using System.Collections.Generic;
using System.Text;

namespace MessageScheduler.Models.Schedules
{
    public class DailySchedule : Schedule
    {
        protected override DateTime GetNextExecutionTime()
        {
            var executionTime = DateTime.Today
                .AddHours(Time.Hour)
                .AddMinutes(Time.Minute);

            return DateTime.Now > executionTime
                ? executionTime.AddDays(1)
                : executionTime;
        }
    }
}
