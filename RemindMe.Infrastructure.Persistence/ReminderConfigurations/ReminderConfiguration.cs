using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Persistence.ReminderConfigurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(300)
                .HasDefaultValue(string.Empty);

            builder.Property(m => m.Message)
                .HasMaxLength(300);

            builder.Property(sch => sch.ScheduledAt)
                .IsRequired();

            builder.Property(s => s.IsSent)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.TargetType)
                .IsRequired()
                .HasDefaultValue("email");

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(d => d.UserDestination)
                .IsRequired();

            builder.Property(u => u.UserId)
                .IsRequired();
        }
    }
}
