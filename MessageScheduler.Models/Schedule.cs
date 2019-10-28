using System;

namespace MessageScheduler.Models
{
    public abstract class Schedule
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public DateTime NextExecutionTime => GetNextExecutionTime();

        protected abstract DateTime GetNextExecutionTime();
    }
}
