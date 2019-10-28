using System;

namespace MessageScheduler.Models.Schedules
{
    public class MonthlySchedule : Schedule
    {
        public ushort MonthDay { get; set; }

        protected override DateTime GetNextExecutionTime()
        {
            var executionTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, MonthDay)
                .AddHours(Time.Hour)
                .AddMinutes(Time.Minute);

            return DateTime.Now > executionTime
                ? executionTime.AddMonths(1)
                : executionTime;
        }
    }
}
