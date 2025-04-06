using RemindMe.Application.IRepositories;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
