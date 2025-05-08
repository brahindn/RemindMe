namespace RemindMe.Application.IServices
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IReminderService ReminderService { get; }
        IMongoService MongoService { get; }
    }
}
