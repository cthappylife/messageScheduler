using MessageScheduler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageScheduler.Persistence.Configurations
{
    internal class ScheduledMessageConfiguration : IEntityTypeConfiguration<ScheduledMessage>
    {
        public void Configure(EntityTypeBuilder<ScheduledMessage> builder)
        {
            builder.ToTable("ScheduledMessage");

            builder.Property(x => x.Message)
                .HasColumnName("Message")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ReceiverId)
                .HasColumnName("ReceiverId")
                .IsRequired();

            builder.Property(x => x.ScheduleId)
                .HasColumnName("ScheduleId")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();
        }
    }
}
