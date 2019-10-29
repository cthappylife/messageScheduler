using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageScheduler.Models;
using MessageScheduler.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;

namespace MessageScheduler.Service.Tests
{
    internal static class MessageSchedulerContextExtensions
    {
        public static MessageSchedulerContext StubScheduledMessages(
            this MessageSchedulerContext context, 
            IEnumerable<ScheduledMessage> messages)
        {
            context.ScheduledMessages.AddRange(messages.ToList());
            context.SaveChanges();
            return context;
        }
    }
}
