using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CMSApplication.Implementations.Repositories
{
    public class VolunteerRepository : BaseRepository<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Volunteer>> GetAll()
        {
            var volunteers = await _context.Volunteers.Include(x => x.Categorys).ToListAsync();
            return volunteers;
        }

        public async Task<Volunteer> GetVolunteerByName(string Name)
        {
            var volunteer = await _context.Volunteers.Where(x => x.voluntryName == Name).FirstOrDefaultAsync();
            return volunteer;
        }
    }
}