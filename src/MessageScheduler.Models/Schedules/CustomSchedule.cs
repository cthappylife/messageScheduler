using System;

namespace MessageScheduler.Models.Schedules
{
    public class CustomSchedule : Schedule
    {
        public DateTime Date { get; set; }

        protected override DateTime GetNextExecutionTime()
        {
            return Date.AddHours(Time.Hour).AddMinutes(Time.Minute);
        }
    }
}
