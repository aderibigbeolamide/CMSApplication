using CMSApplication.Entities;

namespace CMSApplication.Interfaces.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IList<Appointment>> GetAll();
        Task<Appointment> GetById(int id);
        Task<IList<Appointment>> GetByDonorId(int id);
        Task<IList<Appointment>> GetByCharityHomeId(int id);
        Task<IList<Appointment>> GetUnapproved();
    }
}
