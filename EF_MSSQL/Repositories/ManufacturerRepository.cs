using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Manufacturers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_MSSQL.Repositories;

public class ManufacturerRepository(StoreDbContext db) : IManufacturerRepository
{
    public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        => await db.Manufacturers
        .AsNoTracking()
        .ToListAsync();

    public async Task CreateAsync(Manufacturer manufacturer)
    {
        await db.Manufacturers.AddAsync(manufacturer);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Manufacturer manufacturer)
    {
        db.Manufacturers.Update(manufacturer);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var manufacturer = await db.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);

        if (manufacturer == null)
            return;

        db.Manufacturers.Remove(manufacturer);
        await db.SaveChangesAsync();
    }
}
