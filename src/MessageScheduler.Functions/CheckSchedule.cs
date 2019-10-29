using System;
using System.Linq;
using MessageScheduler.Persistence;
using MessageScheduler.Service;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MessageScheduler.Functions
{
    public class CheckSchedule
    {
        private readonly MessageSchedulerContext _dbContext;
        private readonly IMessagesQuery _messagesQuery;

        public CheckSchedule(
            MessageSchedulerContext dbContext,
            IMessagesQuery messagesQuery)
        {
            _messagesQuery = messagesQuery;
            _dbContext = dbContext;
            _dbContext.Database.Migrate();
        }

        [FunctionName("CheckSchedule")]
        public void Run([TimerTrigger("%CheckScheduleTimer%")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Function CheckSchedule starts running at: {DateTime.Now}");

            var messages = _messagesQuery.GetMessagesToSend();

            if (!messages.Any())
            {
                log.LogInformation("No message to sent today");
                return;
            }

            //TODO send message
        }
    }
}