using System;

namespace MessageScheduler.Persistence.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public DateTime Time { get; set; }
        public ushort Day { get; set; }
        public WeekDays WeekDays { get; set; }
    }
}
