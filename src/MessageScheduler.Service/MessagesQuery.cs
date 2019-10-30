using System;
using System.Collections.Generic;
using System.Linq;
using MessageScheduler.Models;
using MessageScheduler.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Service
{
    public class MessagesQuery : IMessagesQuery
    {
        private readonly MessageSchedulerContext _messageSchedulerContext;

        public MessagesQuery(MessageSchedulerContext messageSchedulerContext)
        {
            _messageSchedulerContext = messageSchedulerContext;
        }

        public IEnumerable<ScheduledMessage> GetMessagesToSend()
        {
            var messages = _messageSchedulerContext.ScheduledMessages
                .Include(x => x.Schedule)
                .Include(x => x.Receiver)
                .Where(x => x.IsActive
                            && x.Schedule != null
                            && x.LastSentDate != DateTime.Today)
                .ToArray();

            return messages.Where(x => x.Schedule.IsTodayScheduled());
        }
    }
}
