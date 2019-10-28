namespace MessageScheduler.Models.Schedules
{
    public class DailySchedule : Schedule
    {
        public override bool ShouldExecuteToday()
        {
            return true;
        }
    }
}
