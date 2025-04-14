namespace RemindMe.Application.IServices
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IReminderService ReminderService { get; }
        IMongoService MongoService { get; }
    }
}
