using RemindMe.Domain.Entities;

namespace RemindMe.Application.IRepositories
{
    public interface IUserRepository
    {
        void Create(User user);
    }
}
