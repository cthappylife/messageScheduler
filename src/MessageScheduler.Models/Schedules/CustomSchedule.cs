using System;

namespace MessageScheduler.Models.Schedules
{
    public class CustomSchedule : Schedule
    {
        public DateTime Date { get; set; }

        public override bool IsTodayScheduled()
        {
            return DateTime.Today == Date.Date;
        }
    }
}
