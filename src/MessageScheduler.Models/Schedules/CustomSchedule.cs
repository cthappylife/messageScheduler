using System;

namespace MessageScheduler.Models.Schedules
{
    public class CustomSchedule : Schedule
    {
        public DateTime Date { get; set; }

        public override bool IsTodayScheduled() => DateTime.Today == Date.Date;
    }
}