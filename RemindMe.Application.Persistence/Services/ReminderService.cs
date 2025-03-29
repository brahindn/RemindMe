using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;

namespace RemindMe.Application.Persistence.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IRepositoryManager _repositoryManager;
        
        public ReminderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task CreateReminderAsync(CreateReminderRequest createReminderRequest)
        {
            
        }
    }
}
