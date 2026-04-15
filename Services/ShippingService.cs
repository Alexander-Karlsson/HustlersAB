using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Services.Interfaces.Shipping;

namespace Services;

public class ShippingService(IShippingRepository repo) : IShippingService
{
    public async Task<IEnumerable<Entities.Shipping>> GetShippingAsync()
        => await repo.GetShippingAsync();
}
