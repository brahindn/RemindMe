using RemindMe.Contracts.Requests;
using RemindMe.Contracts.Responses;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.IServices
{
    public interface IReminderService
    {
        Task<GetReminderResponse> GetReminderAsync(Guid id);
        Task CreateReminderAsync(CreateReminderRequest createReminderRequest);
        Task DeleteReminderAsync(Guid reminderId);
    }
}
