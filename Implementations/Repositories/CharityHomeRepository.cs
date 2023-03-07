using Microsoft.EntityFrameworkCore;
using CMSApp.Contexts;
using CMSApp.DTOs;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class CharityHomeRepository : BaseRepository<CharityHome>, ICharityHomeRepository
    {
        public CharityHomeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<CharityHome>> GetAllWithCategory()
        {
            var charityHomes = await _context.CharityHomes.Include(x => x.User).Include(x => x.Particulars).Where(x => x.IsDeleted == false && x.IsApproved == true).ToListAsync();
            return charityHomes;
        }
        public async Task<IList<CharityHome>> GetAll()
        {
            var charityHomes = await _context.CharityHomes.Include(x => x.User).Include(x => x.Particulars).Where(x => x.IsDeleted == false && x.IsApproved == true).ToListAsync();
            return charityHomes;
        }

        public async Task<HashSet<CharityHome>> GetByDescriptionContent(string content)
        {
            var charityHomes = await _context.CharityHomes.Include(x => x.User).Where(x => x.Description.ToLower().Contains(content.ToLower()) && x.IsDeleted == false && x.IsApproved == true).Include(x => x.Particulars).ToListAsync();
            return charityHomes.ToHashSet();
        }

        public async Task<CharityHome> GetCharityHome(int id)
        {
            var charityHome = await _context.CharityHomes.Include(x => x.User).Include(x => x.Particulars).SingleOrDefaultAsync(x => x.Id == id);
            return charityHome;
        }

        public async Task<CharityHome> GetCharityHomeByEmail(string email)
        {
            var charityHome = await _context.CharityHomes.Include(x => x.User).Include(x => x.Particulars).SingleOrDefaultAsync(x => x.Email == email);
            return charityHome;
        }

        public async Task<HashSet<CharityHome>> GetCharityHomeByName(string name)
        {
            var charityHome = await _context.CharityHomes.Include(x => x.User).Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.IsDeleted == false && x.IsBan == false).Include(x => x.Particulars).ToListAsync();
            
            return charityHome.ToHashSet();
        }

       

        public async Task<IList<CharityHome>> GetUnapprovedCharityHomes()
        {
            var charityHomes = await _context.CharityHomes.Include(x => x.User).Where(x => x.IsApproved == false).Include(x => x.Particulars).ToListAsync();
            return charityHomes;
        }
    }
}
