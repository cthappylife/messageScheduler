using System;
using System.Collections.Generic;
using System.Linq;
using MessageScheduler.Models;
using MessageScheduler.Persistence;

namespace MessageScheduler.Service
{
    public interface IMessagesQuery
    {
        IEnumerable<ScheduledMessage> GetMessagesToSend();
    }

    public class MessagesQuery : IMessagesQuery
    {
        private readonly IMessageSchedulerContext _messageSchedulerContext;

        public MessagesQuery(IMessageSchedulerContext messageSchedulerContext)
        {
            _messageSchedulerContext = messageSchedulerContext;
        }

        public IEnumerable<ScheduledMessage> GetMessagesToSend()
        {
            var messages = _messageSchedulerContext.ScheduledMessages.ToArray();
            return  messages.Where(x => x.IsActive
                            && x.Schedule != null
                            && x.Schedule.IsTodayScheduled()
                            && x.LastSentDate != DateTime.Today);
        }
    }
}
