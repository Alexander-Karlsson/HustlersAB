using Entities;
using Services.Interfaces;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    public Task AddCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomerAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}