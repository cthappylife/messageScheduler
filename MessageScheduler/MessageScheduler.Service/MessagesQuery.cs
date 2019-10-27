using System;
using System.Collections.Generic;
using System.Text;
using MessageScheduler.Persistence;
using MessageScheduler.Persistence.Models;

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
            throw new NotImplementedException();
        }
    }
}
