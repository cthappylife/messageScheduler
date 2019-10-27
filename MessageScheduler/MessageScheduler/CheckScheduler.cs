using System;
using System.Linq;
using MessageScheduler.Persistence;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MessageScheduler.Functions
{
    public class CheckScheduler
    {
        private readonly MessageSchedulerContext _dbContext;

        public CheckScheduler(MessageSchedulerContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.Migrate();
        }

        [FunctionName("CheckScheduler")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Function CheckScheduler starts running at: {DateTime.Now}");

            
        }
    }
}
