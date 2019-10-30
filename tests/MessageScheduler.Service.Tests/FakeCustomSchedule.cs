using MessageScheduler.Models.Schedules;

namespace MessageScheduler.Service.Tests
{
    internal class FakeCustomSchedule : CustomSchedule
    {
        private readonly bool _isTodayScheduled;

        public FakeCustomSchedule(bool isTodayScheduled)
        {
            _isTodayScheduled = isTodayScheduled;
        }

        public override bool IsTodayScheduled() => _isTodayScheduled;
    }
}
