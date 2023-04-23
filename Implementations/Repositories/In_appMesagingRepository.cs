using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CMSApplication.Implementations.Repositories
{
    public class In_appMesagingRepository : BaseRepository<In_appMessaging>, IIn_appMessagingRepository
    {
        public In_appMesagingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<In_appMessaging>> GetAll()
        {
            var in_appMessaging = await _context.In_AppMessagings.Where(x => x.IsDeleted == false).ToListAsync();
            return in_appMessaging;
        }

        public Task<In_appMessaging> GetIn_AppMessagingByCharityHome(string Name)
        {
            throw new NotImplementedException();
        }
    }
}