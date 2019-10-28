using MessageScheduler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageScheduler.Persistence.Configurations
{
    internal class SentMessageConfiguration : IEntityTypeConfiguration<SentMessage>
    {
        public void Configure(EntityTypeBuilder<SentMessage> builder)
        {
            builder.ToTable("SentMessage");

            builder.Property(x => x.SentTime)
                .HasColumnName("SentTime")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(x => x.SentSuccessfully)
                .HasColumnName("SentSuccessfully")
                .IsRequired();
        }
    }
}
