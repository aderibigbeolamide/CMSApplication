using CMSApp.Contexts;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class In_appMesagingRepository : BaseRepository<In_appMessaging>, IIn_appMessagingRepository
    {
        public In_appMesagingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<IList<In_appMessaging>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<In_appMessaging> GetIn_AppMessagingByCharityHome(string Name)
        {
            throw new NotImplementedException();
        }
    }
}