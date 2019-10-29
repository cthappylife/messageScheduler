using System;
using MessageScheduler.Models.Schedules;
using Xunit;

namespace MessageScheduler.Models.Tests
{
    public class MonthlyScheduleTests
    {
        [Fact]
        public void IsTodayScheduled_ScheduledMonthDayIsToday_ReturnsTrue()
        {
            var schedule = new MonthlySchedule() { MonthDay = DateTime.Today.Day };
            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledMonthDayNotToday_ReturnsFalse()
        {
            var schedule = new MonthlySchedule() { MonthDay = DateTime.Today.AddDays(1).Day };
            Assert.False(schedule.IsTodayScheduled());
        }
    }
}
