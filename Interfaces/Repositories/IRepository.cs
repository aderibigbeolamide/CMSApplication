using System.Linq.Expressions;

namespace CMSApp.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Register(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> Get(Expression<Func<T, bool>> expression);
    }
}
