using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Shipping;

namespace EF_MSSQL.Repositories
{
    public class ShippingRepository(StoreDbContext db) : IShippingRepository
    {
        public async Task<IEnumerable<Shipping>> GetShippingAsync()
            => await db.Shippings.AsNoTracking().ToListAsync();

        public async Task<Shipping?> GetByIdAsync(Guid id)
            => await db.Shippings.FindAsync(id);
    }
}
