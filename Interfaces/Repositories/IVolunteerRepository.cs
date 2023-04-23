using CMSApplication.Entities;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IVolunteerRepository : IRepository<Volunteer>
    {
        Task<IList<Volunteer>> GetAll();
        Task<Volunteer> GetVolunteerByName(string Name);
    }
}