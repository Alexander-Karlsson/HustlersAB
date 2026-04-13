using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Customers;

namespace EF_MSSQL.Repositories;

public class CustomerRepository(StoreDbContext db) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await GetCustomersWithIncludes()
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await GetCustomersWithIncludes()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetBySearchAsync(string query)
    {
        return await GetCustomersWithIncludes()
            .Where(c => c.Name.Contains(query) ||
                        c.CustomerContactInfo!.Phone.Contains(query) ||
                        c.CustomerContactInfo!.Email.Contains(query))
            .ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetMembersAsync()
    {
        return await GetCustomersWithIncludes()
            .Where(c => c.IsMember)
            .ToListAsync();
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await db.Customers.AddAsync(customer);
        await db.SaveChangesAsync();

        return customer;
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

    private IQueryable<Customer> GetCustomersWithIncludes()
    {
        return db.Customers
            .Include(c => c.CustomerContactInfo);
    }
}