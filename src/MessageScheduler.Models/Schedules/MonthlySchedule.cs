using System;

namespace MessageScheduler.Models.Schedules
{
    public class MonthlySchedule : Schedule
    {
        public ushort MonthDay { get; set; }

        public override bool ShouldExecuteToday()
        {
            var today = DateTime.Today;
            var executionDayThisMonth = new DateTime(today.Year, today.Month, MonthDay);

            return today == executionDayThisMonth;
        }
    }
}
