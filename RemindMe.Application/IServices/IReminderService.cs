using RemindMe.Contracts.Requests;
using RemindMe.Domain.Entities;

namespace RemindMe.Application.IServices
{
    public interface IReminderService
    {
        Task CreateReminderAsync(CreateReminderRequest createReminderRequest);
    }
}
