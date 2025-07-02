using RemindMe.Domain.Entities;

namespace RemindMe.Application.IRepositories
{
    public interface IReminderRepository
    {
        Task<Reminder> GetReminderAsync(Guid reminderId);
        void Create(Reminder reminder);
        void Delete(Reminder reminder);
    }
}
