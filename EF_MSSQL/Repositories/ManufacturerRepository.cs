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
}
