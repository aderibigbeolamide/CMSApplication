using Microsoft.EntityFrameworkCore;
using CMSApplication.Contexts;
using CMSApplication.Identity;
using CMSApplication.Interfaces.Repositories;
using System.Linq.Expressions;

namespace CMSApplication.Implementations.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> expression)
        {
            var ans = await _context.Users.Include(x => x.CharityHome).Include(x => x.Donor).Include(x => x.Admin).FirstOrDefaultAsync(expression);
            return ans;
        }
    }
}
