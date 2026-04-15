using Entities;
using Services.Interfaces.Shipping;

namespace Services;

public class ShippingService(IShippingRepository repo) : IShippingService
{
    public async Task<IEnumerable<Shipping>> GetShippingAsync()
        => await repo.GetShippingAsync();
}
