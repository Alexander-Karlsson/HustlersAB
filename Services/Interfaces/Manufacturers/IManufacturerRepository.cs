using Entities;

namespace Services.Interfaces.Manufacturers;

public interface IManufacturerRepository
{
    Task<IEnumerable<Manufacturer>> GetAllAsync();
}