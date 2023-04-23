using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CMSApplication.Implementations.Repositories
{
    public class CampaignRepository : BaseRepository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Campaign>> GetAll()
        {
            var campaignies = await _context.Campaigns.Where(x => x.IsActive == true).Include(x => x.In_appMessagings_).ThenInclude(x => x.CharityHomes).ToListAsync();
            return campaignies;
        }

        public async Task<Campaign> GetCampaign(int id)
        {
            var campaign = await _context.Campaigns.Include(x => x.In_appMessagings_).ThenInclude(x => x.CharityHomes).SingleOrDefaultAsync();
            return campaign;
        }

        public async Task<Campaign> GetCampaignByCharityHome(string Name)
        {
            var campaign = await _context.Campaigns.Include(x => x.In_appMessagings_).ThenInclude(x => x.CharityHomes).SingleOrDefaultAsync(x => x.Name == Name);
            return campaign;
        }

        public async Task<Campaign> GetCampaignByDate(DateTime date)
        {
            var campaign = await _context.Campaigns.Where(x => x.StartDate == date).FirstOrDefaultAsync();
            return campaign;
        }
    }
}