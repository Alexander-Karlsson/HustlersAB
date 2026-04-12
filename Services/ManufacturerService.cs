using Entities;
using Services.Interfaces.Manufacturers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class ManufacturerService(IManufacturerRepository repo) : IManufacturerService
{
    public async Task<IEnumerable<Manufacturer>> GetAllAsync() 
        => await repo.GetAllAsync();
}
