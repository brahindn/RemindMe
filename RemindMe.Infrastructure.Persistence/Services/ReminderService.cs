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

            createReminderRequest.UserDestination = new Guid("0195fcb3-191a-7051-8d9b-88d23c189f8b"); //Test User Destination

            var reminder = createReminderRequest.Adapt<Reminder>();

            reminder.CreatedAt = DateTime.UtcNow;
            reminder.UserId = "0195fcb2-1a3a-7920-918d-fcced7f13d2a"; //Test UserId

            _repositoryManager.Reminder.Create(reminder);
             await _repositoryManager.SaveAsync();
        }
    }   
}
