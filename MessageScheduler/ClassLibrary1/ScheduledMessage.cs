using System;
using System.Collections.Generic;
using System.Text;

namespace MessageScheduler.Models
{
    public class ScheduledMessage
    {
        public string Message { get; set; }
        public Person Receiver { get; set; }
        public Schedule Schedule { get; set; }
        public bool IsActive { get; set; }
    }
}
