using Microsoft.EntityFrameworkCore;
using RemindMe.Application.IRepositories;
using System.Linq.Expressions;

namespace RemindMe.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repositoryContext.Set<T>().Where(expression);
        }


        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }
    }
}
