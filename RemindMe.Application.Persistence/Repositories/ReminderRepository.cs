using RemindMe.Application.IRepositories;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.Persistence.Repositories
{
    public class ReminderRepository : RepositoryBase<Reminder>, IReminderRepository
    {
        public ReminderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
