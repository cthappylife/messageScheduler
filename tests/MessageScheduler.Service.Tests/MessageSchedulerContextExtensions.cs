using System.Collections.Generic;
using System.Linq;
using MessageScheduler.Models;
using MessageScheduler.Models.Schedules;
using MessageScheduler.Persistence;

namespace MessageScheduler.Service.Tests
{
    internal static class MessageSchedulerContextExtensions
    {
        public static MessageSchedulerContext StubScheduledMessages(
            this MessageSchedulerContext context, 
            IEnumerable<ScheduledMessage> messages)
        {
            context.Receivers.AddRange(messages.Select(x => x.Receiver));
            AddSchedules(context, messages);
            context.ScheduledMessages.AddRange(messages.ToList());
            context.SaveChanges();
            return context;
        }

        private static void AddSchedules(
            MessageSchedulerContext context, 
            IEnumerable<ScheduledMessage> messages)
        {
            foreach (var message in messages)
            {
                switch (message.Schedule)
                {
                    case DailySchedule dailySchedule:
                        context.DailySchedules.Add(dailySchedule);
                        break;
                    case WeeklySchedule weeklySchedule:
                        context.WeeklySchedules.Add(weeklySchedule);
                        break;
                    case MonthlySchedule monthlySchedule:
                        context.MonthlySchedules.Add(monthlySchedule);
                        break;
                    case CustomSchedule customSchedule:
                        context.CustomSchedules.Add(customSchedule);
                        break;
                    case null:
                        continue;
                }
            }
        }
    }
}
