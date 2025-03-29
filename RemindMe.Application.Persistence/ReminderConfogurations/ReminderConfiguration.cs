using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.Persistence.ReminderConfogurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.Property(m => m.Message)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(ct => ct.CreationTime)
                .IsRequired();

            builder.Property(st => st.ShippingTime)
                .IsRequired();

            builder.Property(d => d.UserDestination)
                .IsRequired();

            builder.Property(u => u.UserId)
                .IsRequired();
        }
    }
}
