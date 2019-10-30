using System.Collections.Generic;
using MessageScheduler.Models;

namespace MessageScheduler.Service
{
    public interface IMessagesQuery
    {
        IEnumerable<ScheduledMessage> GetMessagesToSend();
    }
}