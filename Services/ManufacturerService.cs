using Entities;
using Services.Interfaces.Manufacturers;

namespace Services;

public class ManufacturerService(IManufacturerRepository repo) : IManufacturerService
{
    public async Task<IEnumerable<Manufacturer>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }
}