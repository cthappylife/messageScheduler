using System;

namespace MessageScheduler.Models.Schedules
{
    public class DailySchedule : Schedule
    {
        protected override DateTime GetNextExecutionDay()
        {
            return DateTime.Today;
        }
    }
}
