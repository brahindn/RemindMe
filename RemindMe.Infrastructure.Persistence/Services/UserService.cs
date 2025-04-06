using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;

namespace RemindMe.Infrastructure.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
