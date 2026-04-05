using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;


namespace EF_MSSQL.Repositories;

public class OrderRepository(StoreDbContext context) : IOrderRepository
{
    private readonly StoreDbContext _context = context;

    private IQueryable<Order> BaseQuery()
    {
        return _context.Orders
       .Include(o => o.ProductOrders)
           .ThenInclude(po => po.Product)
       .Include(o => o.Customer)
           .ThenInclude(c => c.ContactInfo)
       .Include(o => o.Shipping)
       .Include(o => o.PaymentMethod);

    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await GetByIdAsync(id);
        if (order == null)
        {
            return;
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await BaseQuery().ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await BaseQuery().
            FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId)
    {
        return await BaseQuery()
            .Where(o => o.CustomerId == customerId).ToListAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}