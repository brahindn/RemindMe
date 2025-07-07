using Mapster;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Contracts.Requests;
using RemindMe.Contracts.Responses;
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
                throw new ArgumentNullException(nameof(createReminderRequest));
            }

            var newReminder = createReminderRequest.Adapt<Reminder>();

            _repositoryManager.Reminder.Create(newReminder);
            await _repositoryManager.SaveAsync();
        }

        public async Task<GetReminderResponse> GetReminderAsync(Guid id)
        {
            var reminder = await _repositoryManager.Reminder.GetReminderAsync(id);

            if (reminder == null)
            {
                throw new NullReferenceException($"Reminder not found with Id: {id}");
            }

            var getReminderResponse = reminder.Adapt<GetReminderResponse>();

            return getReminderResponse;
        }

        public async Task DeleteReminderAsync(Guid id)
        {
            var reminder = await _repositoryManager.Reminder.GetReminderAsync(id);

            if(reminder == null)
            {
                throw new NullReferenceException($"Reminder not found with Id: {id}");
            }

            _repositoryManager.Reminder.Delete(reminder);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateReminderAsync(UpdateReminderRequest updateReminderRequest)
        {
            if(updateReminderRequest == null)
            {
                throw new ArgumentNullException(nameof(updateReminderRequest));
            }

            var existingReminder = await _repositoryManager.Reminder.GetReminderAsync(updateReminderRequest.Id);

            if(existingReminder == null)
            {
                throw new InvalidOperationException("Reminder not found");
            }

            updateReminderRequest.Adapt(existingReminder);

            _repositoryManager.Reminder.Update(existingReminder);
            await _repositoryManager.SaveAsync();
        }
    }   
}
