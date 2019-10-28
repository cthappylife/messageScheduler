namespace MessageScheduler.Models
{
    public class ScheduledMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ReceiverId { get; set; }
        public int ScheduleId { get; set; }
        public bool IsActive { get; set; }

        public Receiver Receiver { get; set; }
        public Schedule Schedule { get; set; }
    }
}
