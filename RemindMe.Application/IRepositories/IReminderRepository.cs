using RemindMe.Domain.Entities;

namespace RemindMe.Application.IRepositories
{
    public interface IReminderRepository
    {
        void Create(Reminder reminder);
    }
}
