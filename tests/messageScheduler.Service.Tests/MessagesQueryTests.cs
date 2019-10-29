using System;
using System.Collections.Generic;
using System.Linq;
using MessageScheduler.Models;
using MessageScheduler.Models.Schedules;
using MessageScheduler.Persistence;
using MessageScheduler.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace messageScheduler.Service.Tests
{
    public class MessagesQueryTests
    {
        private readonly Receiver _receiver; 
        private readonly Mock<IMessageSchedulerContext> _context;
        private MessagesQuery _target;

        public MessagesQueryTests()
        {
            _receiver = new Receiver {Id = 1, Name = "superman", PhoneNumber = "1234567890"};
            _context = new Mock<IMessageSchedulerContext>();
        }

        [Fact]
        public void GetMessagesToSend_InactiveMessage_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = false,
                Message = "hello I am inactive",
                Receiver = _receiver,
                Schedule = new DailySchedule()
            };
            StubDbContext(new [] {message});
            _target = new MessagesQuery(_context.Object);

            Assert.Empty(_target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessageWithoutSchedule_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I do not have schedule",
                Receiver = _receiver,
                Schedule = null
            };
            StubDbContext(new[] { message });
            _target = new MessagesQuery(_context.Object);

            Assert.Empty(_target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessageNotScheduledToToday_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am not scheduled to today",
                Receiver = _receiver,
                Schedule = new FakeSchedule(false)
            };
            StubDbContext(new[] { message });
            _target = new MessagesQuery(_context.Object);

            Assert.Empty(_target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessagesScheduledToToday_ButAlreadySent_DoesNotGet()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am scheduled to today but already sent",
                Receiver = _receiver,
                Schedule = new FakeSchedule(true),
                LastSentDate = DateTime.Today
            };
            StubDbContext(new[] { message });
            _target = new MessagesQuery(_context.Object);

            Assert.Empty(_target.GetMessagesToSend());
        }

        [Fact]
        public void GetMessagesToSend_MessagesScheduledToToday_NotSentYet_Get()
        {
            var message = new ScheduledMessage
            {
                IsActive = true,
                Message = "hello I am scheduled to today and not sent yet",
                Receiver = _receiver,
                Schedule = new FakeSchedule(true),
                LastSentDate = null
            };
            StubDbContext(new[] { message });
            _target = new MessagesQuery(_context.Object);

            Assert.Single(_target.GetMessagesToSend());
        }

        private void StubDbContext(IEnumerable<ScheduledMessage> messages)
        {
            var messagesQueryable = messages.AsQueryable();

            var mockSet = new Mock<DbSet<ScheduledMessage>>();
            mockSet.As<IQueryable<ScheduledMessage>>()
                .Setup(x => x.GetEnumerator())
                .Returns(messagesQueryable.GetEnumerator());

            _context.Setup(c => c.ScheduledMessages).Returns(mockSet.Object);
        }

        private class FakeSchedule : Schedule
        {
            private readonly bool _isTodayScheduled;

            public FakeSchedule(bool isTodayScheduled)
            {
                _isTodayScheduled = isTodayScheduled;
            }

            public override bool IsTodayScheduled()
            {
                return _isTodayScheduled;
            }
        }
    }
}
