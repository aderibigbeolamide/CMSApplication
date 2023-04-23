using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;

namespace CMSApplication.Implementations.Repositories
{
    public class CreateUserRepository : BaseRepository<CreateUser>, ICreateUserRepository
    {
        public CreateUserRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
