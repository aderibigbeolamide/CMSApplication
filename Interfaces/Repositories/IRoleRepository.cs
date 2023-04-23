using CMSApplication.Identity;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IList<Role> GetRolesByUserId(int id);
    }
}
