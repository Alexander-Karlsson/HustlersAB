using Entities;

namespace Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid id);
}
