using System;
using MessageScheduler.Persistence.Models;

namespace MessageScheduler.Service
{
    public class MonthlySchedule : IExecutionTimeResolver
    {
        public DateTime Get(Schedule schedule)
        {
            var executionTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, schedule.Day)
                .AddHours(schedule.Time.Hour)
                .AddMinutes(schedule.Time.Minute);

            return DateTime.Now > executionTime
                ? executionTime.AddMonths(1)
                : executionTime;
        }

    }
}
