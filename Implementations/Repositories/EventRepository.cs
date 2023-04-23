using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CMSApplication.Implementations.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Event>> GetAll()
        {
            var events = await _context.Events.Where(x => x.IsDeleted == false).ToListAsync();
            return events;
        }

        public async Task<Event> GetEventByDate(DateTime date)
        {
            var events = await _context.Events.Where(x => x.EventDate == date.Date).FirstOrDefaultAsync();
            return events;
        }

        public Task<Event> GetEventById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}