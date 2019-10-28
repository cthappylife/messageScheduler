using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
