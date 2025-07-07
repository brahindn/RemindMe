using Microsoft.EntityFrameworkCore;
using RemindMe.Application.IRepositories;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Persistence.Repositories
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        public ReminderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task<Reminder> GetReminderAsync(Guid reminderId)
        {
            return await FindByCondition(c => c.Id.Equals(reminderId)).SingleOrDefaultAsync();
        }
    }
}
