using Entities;
using Services.Interfaces;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    public async Task AddOrderAsync(Order order)
    {
        if (order == null) throw new ArgumentNullException("Order can not be null");
        await repo.AddAsync(order);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await repo.GetAllAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be Empty");
        return await repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await repo.GetByCustomerIdAsync(customerId);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        if (order == null) throw new ArgumentNullException("Order can not be null");
        await repo.UpdateAsync(order);
    }
}
