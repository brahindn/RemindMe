using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RemindMe.Domain.Entities;
using RemindMe.Infrastructure.Persistence.ReminderConfigurations;

namespace RemindMe.Infrastructure.Persistence
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ReminderConfiguration());

            modelBuilder.HasDefaultSchema("identity");
        }
    }
}
