using System;
using MessageScheduler.Persistence.Models;

namespace MessageScheduler.Service
{
    public class DailySchedule : IExecutionTimeResolver
    {
        public DateTime Get(Schedule schedule)
        {
            var executionTime = DateTime.Today
                .AddHours(schedule.Time.Hour)
                .AddMinutes(schedule.Time.Minute);

            return DateTime.Now > executionTime
                ? executionTime.AddDays(1)
                : executionTime;
        }
    }
}
