using Entities;

namespace Services.Interfaces.Customers;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetBySearchAsync(string query);
    Task<IEnumerable<Customer>> GetMembersAsync();
    Task<Customer> CreateAsync(Customer customer, CustomerContactInfo contactInfo);
    Task<Customer> CreateWithOutContactInfoAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
}