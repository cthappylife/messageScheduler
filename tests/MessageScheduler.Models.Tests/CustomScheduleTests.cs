using System;
using MessageScheduler.Models.Schedules;
using Xunit;

namespace MessageScheduler.Models.Tests
{
    public class CustomScheduleTests
    {
        [Fact]
        public void IsTodayScheduled_ScheduledDateIsToday_ReturnsTrue()
        {
            var schedule = new CustomSchedule { Date = DateTime.Today };
            Assert.True(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledDateNotToday_ReturnsFalse()
        {
            var schedule = new CustomSchedule {Date = DateTime.Today.AddDays(1)};
            Assert.False(schedule.IsTodayScheduled());
        }

        [Fact]
        public void IsTodayScheduled_ScheduledDateIsSometimeToday_ReturnsTrue()
        {
            var schedule = new CustomSchedule { Date = DateTime.Today.AddHours(2) };
            Assert.True(schedule.IsTodayScheduled());
        }
    }
}
