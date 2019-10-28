using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private readonly MessageSchedulerContext _messageSchedulerContext;

        public MessagesQuery(MessageSchedulerContext messageSchedulerContext)
        {
            _messageSchedulerContext = messageSchedulerContext;
        }

        public IEnumerable<ScheduledMessage> GetMessagesToSend()
        {
            return _messageSchedulerContext.ScheduledMessages
                .Where(x => x.IsActive
                            && x.Schedule.ShouldExecuteToday()
                            && x.LastSentDate != DateTime.Today)
                .ToArray();
        }
    }
}
