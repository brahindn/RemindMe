using Mapster;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Services
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
            if (createReminderRequest == null)
            {
                return;
            }

            var newReminder = createReminderRequest.Adapt<Reminder>();

            _repositoryManager.Reminder.Create(newReminder);
            await _repositoryManager.SaveAsync();
        }
    }   
}
