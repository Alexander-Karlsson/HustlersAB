using Entities;
using Services.Interfaces.Customers;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetBySearchAsync(string query)
    {
        return await repo.GetBySearchAsync(query);
    }

    public async Task<IEnumerable<Customer>> GetMembersAsync()
    {
        return await repo.GetMembersAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        return await repo.CreateAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        await repo.UpdateAsync(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repo.DeleteAsync(id);
    }
}