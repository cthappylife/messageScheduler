using MessageScheduler.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageScheduler.Persistence.Configurations
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id)
            //    .UseSqlServerIdentityColumn();

            builder.Property(x => x.RecurrenceType)
                .HasColumnName("RecurrenceType")
                .IsRequired();

            builder.Property(x => x.Time)
                .HasColumnName("Time")
                .IsRequired();

            builder.Property(x => x.Day)
                .HasColumnName("Day");

            builder.Property(x => x.WeekDays)
                .HasColumnName("Weekdays");
        }
    }
}
