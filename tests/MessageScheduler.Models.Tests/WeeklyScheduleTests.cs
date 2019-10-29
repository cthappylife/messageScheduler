using System;
using MessageScheduler.Models.Schedules;
using Xunit;

namespace MessageScheduler.Models.Tests
{
    public class WeeklyScheduleTests
    {
        [Fact]
        public void IsTodayScheduled_ScheduledWeekDayIsToday_ReturnsTrue()
        {
            var weekDayOfToday = ConvertToWeekDay(DateTime.Today);
            var schedule = new WeeklySchedule { WeekDays = weekDayOfToday };

            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledWeekDayIsNotToday_ReturnsFalse()
        {
            var weekDayOfTomorrow = ConvertToWeekDay(DateTime.Today.AddDays(1));
            var schedule = new WeeklySchedule { WeekDays = weekDayOfTomorrow };

            Assert.False(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledWeekDaysContainsToday_ReturnsTrue()
        {
            var weekDayOfToday = ConvertToWeekDay(DateTime.Today);
            var weekDayOfTomorrow = ConvertToWeekDay(DateTime.Today.AddDays(1));
            var schedule = new WeeklySchedule
            {
                WeekDays = weekDayOfToday | weekDayOfTomorrow
            };

            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledWeekDaysDoesNotContainToday_ReturnsFalse()
        {
            var weekDayOfTomorrow = ConvertToWeekDay(DateTime.Today.AddDays(1));
            var weekDayOfDayAfterTomorrow = ConvertToWeekDay(DateTime.Today.AddDays(2));
            var schedule = new WeeklySchedule
            {
                WeekDays = weekDayOfTomorrow | weekDayOfDayAfterTomorrow
            };

            Assert.False(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledWeekDayIsEveryDay_ReturnsTrue()
        {
            var schedule = new WeeklySchedule { WeekDays = WeekDays.EveryDay };
            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledContainsToday_WeekDaysOrWeekends_ReturnsTrue()
        {
            var schedule = new WeeklySchedule
            {
                WeekDays = IsTodayWeekend() ? WeekDays.WeekEnds : WeekDays.WeekDays
            };

            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledDoesNotContainToday_WeekDaysOrWeekends_ReturnsFalse()
        {
            var schedule = new WeeklySchedule
            {
                WeekDays = IsTodayWeekend() ? WeekDays.WeekDays : WeekDays.WeekEnds
            };

            Assert.False(schedule.IsTodayScheduled());
        }

        private static WeekDays ConvertToWeekDay(DateTime date)
        {
            var dayOfWeek = (int)date.DayOfWeek;
            return (WeekDays)(1 << dayOfWeek);
        }

        private static bool IsTodayWeekend()
        {
            var today = DateTime.Today.DayOfWeek;
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}
