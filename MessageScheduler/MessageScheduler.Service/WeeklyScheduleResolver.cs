using System;
using MessageScheduler.Persistence.Models;

namespace MessageScheduler.Service
{
    public class WeeklySchedule : IExecutionTimeResolver
    {
        public DateTime Get(Schedule schedule)
        {
            var executionTime = DateTime.Today
                .AddHours(schedule.Time.Hour)
                .AddMinutes(schedule.Time.Minute);

            executionTime = DateTime.Now > executionTime
                ? executionTime.AddDays(1)
                : executionTime;

            while (!ContainsDayOfWeek(schedule.WeekDays, executionTime.DayOfWeek)) // DayOfWeek is 0 to 6, sunday 0
            {
                executionTime = executionTime.AddDays(1);
            }

            return executionTime;
        }

        private bool ContainsDayOfWeek(WeekDays weekDays, DayOfWeek dayOfWeek)
        {
            return IsBitSet((byte)weekDays, (int)dayOfWeek);
        }

        private static bool IsBitSet(byte b, int pos) => (b & (1 << pos)) != 0;
    }
}
