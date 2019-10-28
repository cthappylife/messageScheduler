using System;

namespace MessageScheduler.Models.Schedules
{
    public class CustomSchedule : Schedule
    {
        public DateTime Date { get; set; }

        protected override DateTime GetNextExecutionDay()
        {
            return Date;
        }
    }
}
