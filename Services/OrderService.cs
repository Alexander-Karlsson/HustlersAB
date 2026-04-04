using Entities;
using Services.Interfaces;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    public Task AddOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetOrderByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}