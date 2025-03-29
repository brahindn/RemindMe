namespace RemindMe.Application.IRepositories
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IReminderRepository Reminder { get; }
        Task SaveAsyn();
    }
}
