using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RemindMe.Domain.Entities;
using RemindMe.Infrastructure.Persistence.ReminderConfigurations;
using RemindMe.Infrastructure.Persistence.Repositories.Configuration;
using Microsoft.AspNetCore.Identity;

namespace RemindMe.Infrastructure.Persistence
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ReminderConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.HasDefaultSchema("identity");
        }
    }
}
