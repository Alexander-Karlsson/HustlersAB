using Entities;

namespace Services.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(Guid id);

    Task<Customer?> GetCustomerByEmailAsync(string email);

    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
    Task AddCustomerAsync(Customer customer);

}