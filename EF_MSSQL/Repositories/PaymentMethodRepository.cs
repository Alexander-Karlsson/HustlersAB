using Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_MSSQL.Repositories
{
    public class PaymentMethodRepository(StoreDbContext db) : IPaymentMethodRepository
    {
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodAsync()
            => await db.PaymentMethods.AsNoTracking().ToListAsync();

        public async Task<PaymentMethod?> GetByIdAsync(Guid id)
            => await db.PaymentMethods.FindAsync(id);
    }
}
