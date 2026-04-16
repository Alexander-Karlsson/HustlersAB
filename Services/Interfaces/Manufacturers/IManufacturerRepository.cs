using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Manufacturers;

public interface IManufacturerRepository
{
    Task<IEnumerable<Manufacturer>> GetAllAsync();
    Task CreateAsync(Manufacturer manufacturer);
    Task UpdateAsync(Manufacturer manufacturer);
    Task DeleteAsync(Guid id);
}
