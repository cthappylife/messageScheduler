using System;

namespace MessageScheduler.Models.Schedules
{
    public class MonthlySchedule : Schedule
    {
        public ushort MonthDay { get; set; }

        protected override DateTime GetNextExecutionDay()
        {
            var today = DateTime.Today;
            var executionDayThisMonth = new DateTime(today.Year, today.Month, MonthDay);

            return DateTime.Today > executionDayThisMonth
                ? executionDayThisMonth.AddMonths(1)
                : executionDayThisMonth;
        }
    }
}
