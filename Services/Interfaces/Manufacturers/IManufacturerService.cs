using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Manufacturers;

public interface IManufacturerService
{
    Task<IEnumerable<Manufacturer>> GetAllAsync();
}
