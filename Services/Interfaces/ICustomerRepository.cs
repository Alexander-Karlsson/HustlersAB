using Entities;

namespace Services.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetBySearchAsync(string query);
    Task<IEnumerable<Customer>> GetMembersAsync();

    Task <Customer> CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
}