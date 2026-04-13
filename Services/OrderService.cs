using Entities;
using Services.Interfaces.Orders;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetBySearchAsync(string query)
    {
        return await repo.GetBySearchAsync(query);
    }

    public async Task<Order> CreateAsync(Order order)
    {
        return await repo.CreateAsync(order);
    }

    public async Task UpdateAsync(Order order)
    {
        await repo.UpdateAsync(order);
    }

    public async Task DeleteAsync(Guid id)
    {
        await repo.DeleteAsync(id);
    }
}