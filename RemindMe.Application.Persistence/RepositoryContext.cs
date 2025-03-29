using Microsoft.EntityFrameworkCore;
using RemindMe.Application.Persistence.ReminderConfogurations;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.Persistence
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
