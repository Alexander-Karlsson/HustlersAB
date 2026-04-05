using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EF_MSSQL.Repositories;

public class CustomerRepository(StoreDbContext db) : ICustomerRepository
{
    private IQueryable<Customer> GetCustomersWithIncludes()
        => db.Customers
            .Include(c => c.CustomerContactInfo);
    
    public async Task<IEnumerable<Customer>> GetAllAsync()
        => await GetCustomersWithIncludes()
            .ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
        => await GetCustomersWithIncludes()
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Customer>> GetBySearchAsync(string query)
        => await GetCustomersWithIncludes()
            .Where(c => c.Name.Contains(query) ||
                        c.CustomerContactInfo!.Phone.Contains(query) ||
                        c.CustomerContactInfo!.Email.Contains(query))
            .ToListAsync();

    public async Task<IEnumerable<Customer>> GetAllMembersAsync()
        => await GetCustomersWithIncludes()
            .Where(c => c.IsMember)
            .ToListAsync();
    
    public async Task CreateAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
        await db.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Customer customer)
    {
        db.Customers.Update(customer);
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var customer = await db.Customers.FindAsync(id);
        if (customer is null) return;
        
        db.Customers.Remove(customer);
        await db.SaveChangesAsync();
    }
}