using RemindMe.Contracts.Requests;

namespace RemindMe.Application.IServices
{
    public interface IReminderService
    {
        Task CreateReminderAsync(CreateReminderRequest createReminderRequest);
    }
}
