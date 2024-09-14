using System.Linq.Expressions;

namespace Project_management_system.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void SaveChanges();
    }
}
