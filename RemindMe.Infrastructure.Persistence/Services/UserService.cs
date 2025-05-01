using Mapster;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task RegisterUserAsync(RegisterUserRequest registerUserRequest)
        {
            if(registerUserRequest == null)
            {
                return;
            }

            /*var user = registerUserRequest.Adapt<User>();

            _repositoryManager.User.Create(user);
            await _repositoryManager.SaveAsync();*/
        }
    }
}
