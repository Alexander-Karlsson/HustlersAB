using Entities;
using Services.Interfaces;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    public async Task AddCustomerAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException("Customer can not be null");
        await repo.AddAsync(customer);
    }

    public async Task<IEnumerable<Customer>> GetCustomersByMemberStatusAsync(bool isMember)
    {
        return await repo.GetByMemberStatusAsync(isMember);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email can not be empty");

        return await repo.GetByEmailAsync(email);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be Empty");
        return await repo.GetByIdAsync(id);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException("Customer can not be null");
        await repo.UpdateAsync(customer);
    }
}