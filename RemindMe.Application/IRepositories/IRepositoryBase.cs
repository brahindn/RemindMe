using System.Linq.Expressions;

namespace RemindMe.Application.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
