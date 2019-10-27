using MessageScheduler.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageScheduler.Persistence.Configurations
{
    internal class SentMessageConfiguration : IEntityTypeConfiguration<SentMessage>
    {
        public void Configure(EntityTypeBuilder<SentMessage> builder)
        {
            builder.ToTable("SentMessage");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id)
            //    .UseSqlServerIdentityColumn();

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
