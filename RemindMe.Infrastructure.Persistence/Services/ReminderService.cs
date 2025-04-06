using Mapster;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Persistence.Services
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
            if(createReminderRequest == null)
            {
                return;
            }

            var reminder = createReminderRequest.Adapt<Reminder>();

            _repositoryManager.Reminder.Create(reminder);

            try
            {
                await _repositoryManager.SaveAsyn();
            }
            catch(Exception ex)
            {
                throw new ArgumentException();
            }
            
        }
    }
}
