using CMSApplication.Identity;
using System.Linq.Expressions;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(Expression<Func<User, bool>> expression);
    }
}
