﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MessageScheduler.Models
{
    public class SentMessage
    {
        public int Id { get; set; }
        public int ScheduledMessageId { get; set; }
        public DateTime SentTime { get; set; }
        public bool SentSuccessfully { get; set; }

        public ScheduledMessage ScheduledMessage { get; set; }
    }
}
