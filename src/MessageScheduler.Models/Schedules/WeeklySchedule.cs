using System;

namespace MessageScheduler.Models.Schedules
{
    public class WeeklySchedule : Schedule
    {
        public WeekDays WeekDays { get; set; }

        protected override DateTime GetNextExecutionDay()
        {
            var executionDay = DateTime.Today;
            while (!ContainsDayOfWeek(WeekDays, executionDay.DayOfWeek)) // DayOfWeek is 0 to 6, sunday 0
            {
                executionDay = executionDay.AddDays(1);
            }

            return executionDay;
        }

        private static bool ContainsDayOfWeek(WeekDays weekDays, DayOfWeek dayOfWeek)
        {
            return IsBitSet((byte)weekDays, (int)dayOfWeek);
        }

        private static bool IsBitSet(byte b, int pos) => (b & (1 << pos)) != 0;
    }
}
