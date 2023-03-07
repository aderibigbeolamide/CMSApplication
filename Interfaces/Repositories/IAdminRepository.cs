using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> GetAdminInfo(int id);
        Task<IList<Admin>> GetAllAdmins();
        Task<IList<Admin>> GetAllDeletedAdmin();
        Task<IList<Admin>> GetAllSuperAdmin();
        Task<IList<Admin>> GetNonSuperAdmins();
    }
}
