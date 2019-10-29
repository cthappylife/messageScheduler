using MessageScheduler.Models.Schedules;
using Xunit;

namespace MessageScheduler.Models.Tests
{
    public class DailyScheduleTests
    {
        [Fact]
        public void IsTodayScheduled_ReturnsTrue()
        {
            var schedule = new DailySchedule();
            Assert.True(schedule.IsTodayScheduled());
        }
    }
}
