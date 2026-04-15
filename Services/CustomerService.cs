using Entities;
using Services.Interfaces;
using Services.Interfaces.Customers;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
        => await repo.GetAllAsync();
    
    public async Task<Customer?> GetByIdAsync(Guid id)
     => await repo.GetByIdAsync(id);

    public async Task<IEnumerable<Customer>> GetBySearchAsync(string query)
        => await repo.GetBySearchAsync(query);

    public async Task<IEnumerable<Customer>> GetMembersAsync()
        => await repo.GetMembersAsync();

    public async Task<Customer> CreateAsync(Customer customer, CustomerContactInfo contactInfo)
        => await repo.CreateAsync(customer, contactInfo);
    
    public async Task UpdateAsync(Customer customer)
        => await repo.UpdateAsync(customer);

    public async Task DeleteAsync(Guid id)
        => await repo.DeleteAsync(id);
}