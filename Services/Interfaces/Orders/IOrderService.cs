using Entities;

namespace Services.Interfaces.Orders;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetBySearchAsync(string query);
    Task<Order> CreateAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Order>> GetAllWithDetailsAsync();
}