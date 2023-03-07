using Microsoft.EntityFrameworkCore;
using CMSApp.Contexts;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IList<Appointment>> GetAll()
        {
            var appointments = await _context.Appointments.Include(x => x.Donor).Include(x => x.CharityHome).Where(x => x.IsDeleted == false).ToListAsync();
            return appointments;
        }

        public async Task<IList<Appointment>> GetByDonorId(int id)
        {
            var appointments = await _context.Appointments.Include(x => x.CharityHome).Where(x => x.DonorId == id).ToListAsync();
            return appointments;
        }

        public async Task<Appointment> GetById(int id)
        {
            var appointment = await _context.Appointments.Include(x => x.Donor).Include(x => x.CharityHome).SingleOrDefaultAsync(x => x.Id == id);
            return appointment;
        }

        public async Task<IList<Appointment>> GetByCharityHomeId(int id)
        {
            return  await _context.Appointments.Include(x => x.Donor).Where(x => x.CharityHomeId == id).ToListAsync();
            
        }

        public async Task<IList<Appointment>> GetUnapproved()
        {
            var appointment = await _context.Appointments.Where(x => x.IsApproved == false).Include(x => x.Donor).Include(x => x.CharityHome).ToListAsync();
            return appointment;
        }
    }
}
