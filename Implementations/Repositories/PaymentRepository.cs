using CMSApp.Contexts;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }

    }
}
