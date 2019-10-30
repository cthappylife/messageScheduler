using System;
using MessageScheduler.Models.Schedules;
using MessageScheduler.Persistence;
using MessageScheduler.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MessageScheduler.Models;
using MessageScheduler.Service.Tests;

namespace messageScheduler.Service.Tests
{
    public class MessagesQueryTests
    {
        [Fact]
        public void GetMessagesToSend_InactiveMessage_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = false,
                Message = "hello I am inactive",
                Receiver = new Receiver { Name = "superman", PhoneNumber = "00358999999999" },
                Schedule = new DailySchedule()
            };
            var context = CreateDbContext(nameof(GetMessagesToSend_InactiveMessage_DoesNotGet))
                .StubScheduledMessages(new[] {message});
            var target = new MessagesQuery(context);

            Assert.Empty(target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessageWithoutSchedule_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I do not have schedule",
                Receiver = new Receiver { Name = "superman", PhoneNumber = "00358999999999" },
                Schedule = null
            };
            var context = CreateDbContext(nameof(GetMessagesToSend_MessageWithoutSchedule_DoesNotGet))
                .StubScheduledMessages(new[] { message });
            var target = new MessagesQuery(context);

            Assert.Empty(target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessageNotScheduledToToday_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am not scheduled to today",
                Receiver = new Receiver { Name = "superman", PhoneNumber = "00358999999999" },
                Schedule = new FakeCustomSchedule(false)
            };
            var context = CreateDbContext(nameof(GetMessagesToSend_MessageNotScheduledToToday_DoesNotGet))
                .StubScheduledMessages(new[] { message });
            var target = new MessagesQuery(context);

            Assert.Empty(target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessagesScheduledToToday_ButAlreadySent_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am scheduled to today but already sent",
                Receiver = new Receiver { Name = "superman", PhoneNumber = "00358999999999" },
                Schedule = new FakeCustomSchedule(true),
                LastSentDate = DateTime.Today
            };
            var context = CreateDbContext(nameof(GetMessagesToSend_MessagesScheduledToToday_ButAlreadySent_DoesNotGet))
                .StubScheduledMessages(new[] { message });
            var target = new MessagesQuery(context);

            Assert.Empty(target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessagesScheduledToToday_NotSentYet_Get()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am scheduled to today and not sent yet",
                Receiver = new Receiver { Name = "superman", PhoneNumber = "00358999999999" },
                Schedule = new FakeCustomSchedule(true),
                LastSentDate = null
            };
            var context = CreateDbContext(nameof(GetMessagesToSend_MessagesScheduledToToday_NotSentYet_Get))
                .StubScheduledMessages(new[] { message });
            var target = new MessagesQuery(context);

            Assert.Single(target.GetMessagesToSend());
        }

        private static MessageSchedulerContext CreateDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<MessageSchedulerContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
            var dbContext = new MessageSchedulerContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
