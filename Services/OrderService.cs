using Services.Interfaces;

namespace Services;

public class OrderService(IOrderRepository repo) : IOrderService
{
    
}