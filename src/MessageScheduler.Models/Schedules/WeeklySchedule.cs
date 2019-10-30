using System;

namespace MessageScheduler.Models.Schedules
{
    public class WeeklySchedule : Schedule
    {
        public WeekDays WeekDays { get; set; }

        public override bool IsTodayScheduled()
            => IsDayOfWeekScheduled(WeekDays, DateTime.Today.DayOfWeek);

        private static bool IsDayOfWeekScheduled(WeekDays weekDays, DayOfWeek dayOfWeek)
            => IsBitSet((byte)weekDays, (int)dayOfWeek);

        private static bool IsBitSet(byte b, int pos) => (b & (1 << pos)) != 0;
    }
}
