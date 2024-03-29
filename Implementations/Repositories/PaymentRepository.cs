﻿using CMSApplication.Contexts;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Repositories;

namespace CMSApplication.Implementations.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }

    }
}
