using System;
using System.Linq;
using MessageScheduler.Persistence;
using MessageScheduler.Service;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageScheduler.Functions
{
    public class CheckSchedule
    {
        private readonly IMessagesQuery _messagesQuery;

        public CheckSchedule(MessageSchedulerContext dbContext, IMessagesQuery messagesQuery)
        {
            _messagesQuery = messagesQuery;
            dbContext.Database.Migrate();
        }

        [FunctionName("CheckSchedule")]
        public void Run(
            [TimerTrigger("%CheckScheduleTimer%")]TimerInfo myTimer, 
            [TwilioSms(AccountSidSetting = "TwilioAccountSid", AuthTokenSetting = "TwilioAuthToken", From = "+14058966282")] ICollector<CreateMessageOptions> twilioMessageOptions,
            ILogger log)
        {
            log.LogInformation($"Function CheckSchedule starts running at: {DateTime.Now}");

            var messages = _messagesQuery.GetMessagesToSend().ToArray();

            if (!messages.Any())
            {
                log.LogInformation("No message to sent today");
                return;
            }

            log.LogInformation($"Will send {messages.Length} messages.");

            foreach (var message in messages)
            {
                twilioMessageOptions.Add(
                    new CreateMessageOptions(new PhoneNumber(message.Receiver.PhoneNumber))
                    {
                        Body = message.Message
                    });
                log.LogInformation($"Message \"{message.Message}\" to {message.Receiver.Name} {message.Receiver.PhoneNumber}");
            }

            log.LogInformation("All messages scheduled to today have been sent.");
            log.LogInformation($"Function CheckSchedule ends running at: {DateTime.Now}.");
        }
    }
}