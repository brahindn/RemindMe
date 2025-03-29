using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;

namespace RemindMe.Application.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task CreateUserAsync(CreateUserRequest createUserRequest)
        {
            
        }
    }
}
