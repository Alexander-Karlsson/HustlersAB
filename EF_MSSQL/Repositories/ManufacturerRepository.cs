using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Manufacturers;

namespace EF_MSSQL.Repositories;

public class ManufacturerRepository(StoreDbContext db) : IManufacturerRepository
{
    public async Task<IEnumerable<Manufacturer>> GetAllAsync()
    {
        return await db.Manufacturers
            .AsNoTracking()
            .ToListAsync();
    }
}