using CMSApplication.Entities;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IList<Event>> GetAll();
        Task<Event> GetEventByDate(DateTime date);
        Task<Event> GetEventById(int Id);
    }
}