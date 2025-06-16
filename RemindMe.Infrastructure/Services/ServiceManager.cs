using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RemindMe.Application.IRepositories;
using RemindMe.Application.IServices;
using RemindMe.Domain.Entities;

namespace RemindMe.Infrastructure.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IReminderService> _reminderService;
        private readonly Lazy<IMongoService> _mongoService;

        public ServiceManager(IRepositoryManager repositoryManager, UserManager<User> userManager, IConfiguration configuration, Serilog.ILogger logger)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repositoryManager, userManager, configuration, logger));
            _reminderService = new Lazy<IReminderService>(() => new ReminderService(repositoryManager));
            _mongoService = new Lazy<IMongoService>(() => new MongoService());
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IReminderService ReminderService => _reminderService.Value;
        public IMongoService MongoService => _mongoService.Value;
    }
}
