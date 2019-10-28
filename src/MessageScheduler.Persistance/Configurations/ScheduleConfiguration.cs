using MessageScheduler.Models;
using MessageScheduler.Models.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageScheduler.Persistence.Configurations
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(nameof(Schedule))
                .HasDiscriminator<int>("RecurrenceType")
                .HasValue<DailySchedule>((int)RecurrenceType.Daily)
                .HasValue<WeeklySchedule>((int)RecurrenceType.Weekly)
                .HasValue<MonthlySchedule>((int)RecurrenceType.Monthly)
                .HasValue<CustomSchedule>((int)RecurrenceType.Custom);
        }
    }
}
