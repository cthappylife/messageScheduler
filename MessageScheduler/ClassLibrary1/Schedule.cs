using System;
using System.Collections.Generic;
using System.Text;

namespace MessageScheduler.Models
{
    public class Schedule
    {
        public RecurrenceType RecurrenceType { get; set; }
        public string Time { get; set; }
        public int Date { get; set; }
        public WeekDays WeekDays { get; set; }
    }
}
