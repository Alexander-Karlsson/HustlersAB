using Entities;

namespace Services.Interfaces.Manufacturers;

public interface IManufacturerService
{
    Task<IEnumerable<Manufacturer>> GetAllAsync();

    Task CreateAsync(Manufacturer manufacturer);

    Task UpdateAsync(Manufacturer manufacturer);
    Task DeleteAsync(Guid id);
}
