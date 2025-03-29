using RemindMe.Application.IRepositories;

namespace RemindMe.Application.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IReminderRepository> _reminderRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _reminderRepository = new Lazy<IReminderRepository>(() => new ReminderRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        }

        public IReminderRepository Reminder => _reminderRepository.Value;
        public IUserRepository User => _userRepository.Value;

        public async Task SaveAsyn()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
