using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Infrastructure;

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
            var user = MappingFunctions.MapUserDTOToUser(createUserRequest);

            _repositoryManager.User.Create(user);
            await _repositoryManager.SaveAsyn();
        }
    }
}
