using Entities;
using Services.Interfaces.Manufacturers;

namespace Services;

public class ManufacturerService(IManufacturerRepository repo) : IManufacturerService
{
    public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        => await repo.GetAllAsync();

    public async Task CreateAsync(Manufacturer manufacturer)
        => await repo.CreateAsync(manufacturer);

    public async Task UpdateAsync(Manufacturer manufacturer)
        => await repo.UpdateAsync(manufacturer);

    public async Task DeleteAsync(Guid id)
        => await repo.DeleteAsync(id);
}
