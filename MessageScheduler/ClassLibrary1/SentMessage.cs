using System;
using System.Collections.Generic;
using System.Text;

namespace MessageScheduler.Models
{
    public class SentMessage
    {
        public ScheduledMessage ScheduledMessage { get; set; }
        public TimeSpan SentTime { get; set; }
        public bool SentSuccessfully { get; set; }
    }
}
