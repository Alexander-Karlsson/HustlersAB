using Entities;
using Services.Interfaces;
using Services.Interfaces.Orders;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    public async Task<IEnumerable<Order>> GetAllAsync()
        => await repo.GetAllAsync();
    
    public async Task<Order?> GetByIdAsync(Guid id)
        => await repo.GetByIdAsync(id);

    public async Task<IEnumerable<Order>> GetBySearchAsync(string query)
        => await repo.GetBySearchAsync(query);
    
    public async Task<Order> CreateAsync(Order order)
        => await repo.CreateAsync(order);

    public async Task UpdateAsync(Order order)
        => await repo.UpdateAsync(order);

    public async Task DeleteAsync(Guid id)
        => await repo.DeleteAsync(id);

    public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
    => await repo.GetAllWithDetailsAsync();
}