using System;

namespace MessageScheduler.Models
{
    public abstract class Schedule
    {
        public int Id { get; set; }

        public DateTime NextExecutionDay => GetNextExecutionDay();

        protected abstract DateTime GetNextExecutionDay();
    }
}
