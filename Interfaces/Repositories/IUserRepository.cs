using CMSApp.Identity;
using System.Linq.Expressions;

namespace CMSApp.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(Expression<Func<User, bool>> expression);
    }
}
