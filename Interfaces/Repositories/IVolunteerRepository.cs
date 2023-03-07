using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface IVolunteerRepository : IRepository<Volunteer>
    {
        Task<IList<Volunteer>> GetAll();
        Task<Volunteer> GetVolunteerByName(string Name);
    }
}