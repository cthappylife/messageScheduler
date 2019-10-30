namespace MessageScheduler.Models.Schedules
{
    public class DailySchedule : Schedule
    {
        public override bool IsTodayScheduled() => true;
    }
}
