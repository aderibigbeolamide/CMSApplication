using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface IIn_appMessagingRepository : IRepository<In_appMessaging>
    {
        Task<IList<In_appMessaging>> GetAll();
        Task<In_appMessaging> GetIn_AppMessagingByCharityHome(string Name);
        
    }
}