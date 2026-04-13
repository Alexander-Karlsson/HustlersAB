using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Orders;

namespace EF_MSSQL.Repositories;

public class OrderRepository(StoreDbContext db) : IOrderRepository
{
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await GetOrdersWithIncludes()
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await GetOrdersWithIncludes()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Order>> GetBySearchAsync(string query)
    {
        var dateQuery = DateTime.TryParse(query, out var date) ? date : (DateTime?)null;

        return await GetOrdersWithIncludes()
            .Where(o => o.Customer.Name.Contains(query) ||
                        o.Customer.CustomerContactInfo!.Email.Contains(query) ||
                        o.Customer.CustomerContactInfo!.Phone.Contains(query) ||
                        o.Shipping.TypeOfShipping.Contains(query) ||
                        o.PaymentMethod.PaymentName.Contains(query) ||
                        (dateQuery != null && o.OrderDate.Date == dateQuery.Value.Date) ||
                        o.Id.ToString().Contains(query))
            .ToListAsync();
    }

    public async Task<Order> CreateAsync(Order order)
    {
        await db.Orders.AddAsync(order);
        await db.SaveChangesAsync();

        return order;
    }

    public async Task UpdateAsync(Order order)
    {
        db.Orders.Update(order);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await db.Orders.FindAsync(id);
        if (order is null) return;

        db.Orders.Remove(order);
        await db.SaveChangesAsync();
    }

    private IQueryable<Order> GetOrdersWithIncludes()
    {
        return db.Orders
            .Include(o => o.ProductOrders)
            .Include(o => o.Shipping)
            .Include(o => o.PaymentMethod)
            .Include(o => o.Customer)
            .ThenInclude(c => c.CustomerContactInfo);
    }

    public async Task<IEnumerable<Order>> GetByPaymentMethodAsync(string query)
    {
        return await GetOrdersWithIncludes()
            .Where(o => o.PaymentMethod.PaymentName == query)
            .ToListAsync();
    }
}