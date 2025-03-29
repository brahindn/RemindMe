using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.Persistence.ReminderConfogurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(14);
            builder.HasIndex(c => c.PhoneNumber).IsUnique();

            builder.Property(c => c.Email)
                .HasMaxLength(256)
                .HasAnnotation("EmailTemplate", @"^[a-zA-Z0-9.]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
