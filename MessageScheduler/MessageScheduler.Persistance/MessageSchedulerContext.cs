using System;
using MessageScheduler.Persistence.Configurations;
using MessageScheduler.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Persistence
{
    public class MessageSchedulerContext : DbContext
    {
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduledMessage> ScheduledMessages { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }

        public MessageSchedulerContext()
        {
        }

        public MessageSchedulerContext(DbContextOptions<MessageSchedulerContext> options) 
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReceiverConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduledMessageConfiguration());
            modelBuilder.ApplyConfiguration(new SentMessageConfiguration());
        }
    }
}
