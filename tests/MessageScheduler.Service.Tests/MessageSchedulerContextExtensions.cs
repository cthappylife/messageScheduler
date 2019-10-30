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
            var scheduledMessages = messages.ToList();
            context
                .AddReceivers(scheduledMessages.Select(x => x.Receiver))
                .AddSchedules(scheduledMessages.Select(x => x.Schedule))
                .AddScheduledMessages(scheduledMessages);
            context.SaveChanges();

            return context;
        }

        private static MessageSchedulerContext AddScheduledMessages(
            this MessageSchedulerContext context,
            IEnumerable<ScheduledMessage> messages)
        {
            context.ScheduledMessages.AddRange(messages);
            return context;
        }

        private static MessageSchedulerContext AddReceivers(
            this MessageSchedulerContext context,
            IEnumerable<Receiver> receivers)
        {
            context.Receivers.AddRange(receivers);
            return context;
        }

        private static MessageSchedulerContext AddSchedules(
            this MessageSchedulerContext context,
            IEnumerable<Schedule> schedules)
        {
            foreach (var schedule in schedules) AddSchedule(context, schedule);
            return context;
        }

        private static void AddSchedule(MessageSchedulerContext context, Schedule schedule)
        {
            switch (schedule)
            {
                case DailySchedule dailySchedule:
                    context.DailySchedules.Add(dailySchedule);
                    return;
                case WeeklySchedule weeklySchedule:
                    context.WeeklySchedules.Add(weeklySchedule);
                    return;
                case MonthlySchedule monthlySchedule:
                    context.MonthlySchedules.Add(monthlySchedule);
                    return;
                case CustomSchedule customSchedule:
                    context.CustomSchedules.Add(customSchedule);
                    return;
                default:
                    return;
            }
        }
    }
}
