using Entities;
using Services.Interfaces;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    private readonly ICustomerRepository _repo = repo;
    public async Task AddCustomerAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException("Customer can not be null");
        await _repo.AddAsync(customer);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await _repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email can not be empty");

        return await _repo.GetByEmailAsync(email);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be Empty");
        return await _repo.GetByIdAsync(id);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException("Customer can not be null");
        await _repo.UpdateAsync(customer);
    }
}