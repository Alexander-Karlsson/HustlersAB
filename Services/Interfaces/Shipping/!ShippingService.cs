using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Shipping;

public interface IShippingService
{
    Task<IEnumerable<Entities.Shipping>> GetShippingAsync();
}
