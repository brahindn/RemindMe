namespace RemindMe.Application.IRepositories
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
    }
}
