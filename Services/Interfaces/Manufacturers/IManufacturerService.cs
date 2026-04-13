using Entities;

namespace Services.Interfaces.Manufacturers;

public interface IManufacturerService
{
    Task<IEnumerable<Manufacturer>> GetAllAsync();
}