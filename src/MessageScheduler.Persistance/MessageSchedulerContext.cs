using MessageScheduler.Models;
using MessageScheduler.Models.Schedules;
using MessageScheduler.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MessageScheduler.Persistence
{
    public interface IMessageSchedulerContext
    {
        DbSet<Receiver> Receivers { get; set; }

        DbSet<CustomSchedule> CustomSchedules { get; set; }
        DbSet<DailySchedule> DailySchedules { get; set; }
        DbSet<WeeklySchedule> WeeklySchedules { get; set; }
        DbSet<MonthlySchedule> MonthlySchedules { get; set; }

        DbSet<ScheduledMessage> ScheduledMessages { get; set; }
    }

    public class MessageSchedulerContext : DbContext, IMessageSchedulerContext
    {
        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<CustomSchedule> CustomSchedules { get; set; }
        public DbSet<DailySchedule> DailySchedules { get; set; }
        public DbSet<WeeklySchedule> WeeklySchedules { get; set; }
        public DbSet<MonthlySchedule> MonthlySchedules { get; set; }

        public DbSet<ScheduledMessage> ScheduledMessages { get; set; }

        public MessageSchedulerContext(DbContextOptions<MessageSchedulerContext> options) 
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReceiverConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduledMessageConfiguration());
        }
    }
}
