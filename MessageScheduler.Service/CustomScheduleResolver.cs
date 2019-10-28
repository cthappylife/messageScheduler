using System;
using MessageScheduler.Persistence.Models;

namespace MessageScheduler.Service
{
    public class CustomSchedule : IExecutionTimeResolver
    {
        public DateTime Get(Schedule schedule)
        {
            return DateTime.Now > schedule.Time
                ? DateTime.MinValue
                : schedule.Time;
        }
    }
}
