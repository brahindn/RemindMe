using Microsoft.EntityFrameworkCore;
using RemindMe.Domain.Entities;
using RemindMe.Infrastructure.Persistence.ReminderConfigurations;

namespace RemindMe.Infrastructure.Persistence
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReminderConfiguration());
        }
    }
}
