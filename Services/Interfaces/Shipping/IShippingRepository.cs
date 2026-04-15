using System;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Shipping;

public interface IShippingRepository
{
    Task<IEnumerable<Entities.Shipping>> GetShippingAsync();
}

