using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;

namespace RemindMe.Infrastructure.Persistence.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IReminderService> _reminderService;
        private readonly Lazy<IMongoService> _mongoService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager));
            _reminderService = new Lazy<IReminderService>(() => new ReminderService(repositoryManager));
            _mongoService = new Lazy<IMongoService>(() => new MongoService());
        }

        public IUserService UserService => _userService.Value;
        public IReminderService ReminderService => _reminderService.Value;
        public IMongoService MongoService => _mongoService.Value;
    }
}
