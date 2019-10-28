using System;

namespace MessageScheduler.Models.Schedules
{
    public class WeeklySchedule : Schedule
    {
        public WeekDays WeekDays { get; set; }

        protected override DateTime GetNextExecutionTime()
        {
            var executionTime = DateTime.Today
                .AddHours(Time.Hour)
                .AddMinutes(Time.Minute);

            executionTime = DateTime.Now > executionTime
                ? executionTime.AddDays(1)
                : executionTime;

            while (!ContainsDayOfWeek(WeekDays, executionTime.DayOfWeek)) // DayOfWeek is 0 to 6, sunday 0
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
