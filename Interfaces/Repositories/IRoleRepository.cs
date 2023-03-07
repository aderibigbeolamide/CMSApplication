using CMSApp.Identity;

namespace CMSApp.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IList<Role> GetRolesByUserId(int id);
    }
}
