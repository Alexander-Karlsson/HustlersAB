using Entities;
using Services.Interfaces;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    private readonly IOrderRepository _repo = repo;
    public async Task AddOrderAsync(Order order)
    {
        if (order == null) throw new ArgumentNullException("Order can not be null");
        await _repo.AddAsync(order);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be empty");
        await _repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id can not be Empty");
        return await _repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await _repo.GetByCustomerIdAsync(customerId);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        if (order == null) throw new ArgumentNullException("Order can not be null");
        await _repo.UpdateAsync(order);
    }
}
